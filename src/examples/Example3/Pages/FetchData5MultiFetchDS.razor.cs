using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AgGrid.Blazor;
using Example3.Util;

namespace Example3.Pages
{
    public partial class FetchData5MultiFetchDS
    {
        private int renderCount = 0;

        private Grid albumGrid;
        private AlbumsDataSource albumDs;
        private GridOptions albumOp;
        private GridEvents albumEv;

        private Grid photoGrid;
        private PhotosDataSource photoDs;
        private GridOptions photoOp;
        private GridEvents photoEv;

        private IEnumerable<string> thumbnails;

        private int RenderCount()
        {
            return renderCount++;
        }

        protected override async Task OnInitializedAsync()
        {
            await InitAlbums();
            InitPhotos();
        }

        private async Task InitAlbums()
        {
            albumDs = new AlbumsDataSource { HttpFactory = HttpFactory };
            albumOp = new GridOptions
            {
                Datasource = albumDs,
                EnablePagination = true,
                SuppressRowDeselection = true,
                RowModelType = RowModelType.Infinite,
                RowSelection = RowSelection.Multiple,
                SuppressCellSelection = true,
                ColumnDefinitions = new[]
                {
                    new ColumnDefinition
                    {
                        HeaderName = "ID",
                        Field = "id",
                        IsResizable = true,
                        IsSortable = true,
                        CellRenderer = "funcColorCellRenderer",
                        CellRendererParams = new { color = "red" }
                    },
                    new ColumnDefinition
                    {
                        HeaderName = "User ID",
                        Field = "userId",
                        IsResizable = true,
                        IsSortable = true,
                        CellRenderer = "ClassColorCellRenderer",
                        CellRendererParams = new { color = "cyan" }
                    },
                    new ColumnDefinition
                    {
                        HeaderName = "Title",
                        Field = "title",
                        IsResizable = true,
                        IsSortable = true
                    },
                }
            };

            albumEv = new GridEvents
            {
                SelectionChanged = (Action<RowNode[]>)(nodes =>
                {
                    var sel = nodes?.Select(n => n.Id).ToArray();
                    Console.WriteLine("Album Selected: " + string.Join(",", sel));

                    var prevCount = photoDs.AlbumIds?.Length ?? 0;
                    photoDs.AlbumIds = sel;
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            // This seems to be necessary if the DS produced no
                            // rows previously, otherwise the grid doesn't update
                            if (prevCount == 0)
                                await photoGrid.Api.SetDatasource();
                            else
                                await photoGrid.Api.PurgeInfiniteCache();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to update DS: " + ex.ToString());
                        }
                    });
                })
            };

            //var module = await Module;
        }

        private void InitPhotos()
        {
            photoDs = new PhotosDataSource { HttpFactory = HttpFactory };
            photoOp = new GridOptions
            {
                Datasource = photoDs,
                EnablePagination = true,
                PaginationPageSize = 20,
                SuppressRowDeselection = true,
                RowModelType = RowModelType.Infinite,
                RowSelection = RowSelection.Multiple,
                SuppressCellSelection = true,
            };
            photoEv = new GridEvents
            {
                SelectionChanged = (Action<RowNode[]>)(nodes =>
                {
                    Console.WriteLine("Photo Selected: " + (nodes?.Length == 0
        ? "none" : string.Join(",", nodes.Select(n => n.Id))));

                    if ((nodes?.Length ?? 0) == 0)
                    {
                        thumbnails = null;
                    }
                    else
                    {
                        var opts = new System.Text.Json.JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        var photos = System.Text.Json.JsonSerializer.Deserialize<Photo[]>(
            System.Text.Json.JsonSerializer.Serialize(
                nodes.Select(n => n.Data), opts), opts);
                        thumbnails = photos.Select(p => p.ThumbnailUrl);
                    }
                    StateHasChanged();
                }),
            };
        }

        private async Task SizeToFitCols()
        {
            await photoGrid.Api.SizeColumnsToFit();
        }

        private async Task SizeToFitCols500()
        {
            await photoGrid.ColumnApi.SizeColumnsToFit(500);
        }

        private async Task AutosizeCols()
        {
            var colKeys = new[]
            {
            "id",
            "albumId",
            "title",
            "url",
            "thumbnailUrl",
        };
            await photoGrid.ColumnApi.AutoSizeColumns(colKeys);
        }

        private async Task RefreshRows()
        {
            await photoGrid.Api.RefreshInfiniteCache();
        }

        private async Task PurgeRows()
        {
            await photoGrid.Api.PurgeInfiniteCache();
        }
    }

    class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }

    class Photo
    {
        // Sample:
        //"albumId": 1,
        //"id": 1,
        //"title": "accusamus beatae ad facilis cum similique qui sunt",
        //"url": "https://via.placeholder.com/600/92c952",
        //"thumbnailUrl": "https://via.placeholder.com/150/92c952"

        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }

    class AlbumsDataSource : IGridDatasource
    {
        public IHttpClientFactory HttpFactory { get; set; }

        public async Task GetRows(IGetRowsParams getParams)
        {
            try
            {
                var url = "https://jsonplaceholder.typicode.com/albums";

                // https://github.com/typicode/json-server#slice
                url += $"?_start={getParams.StartRow}";
                url += $"&_end={getParams.EndRow}";

                if (getParams.SortModel?.Length > 0)
                {
                    // https://github.com/typicode/json-server#sort
                    url += $"&_sort={string.Join(",", getParams.SortModel.Select(sm => sm.ColumnId))}";
                    url += $"&_order={string.Join(",", getParams.SortModel.Select(sm => sm.Direction))}";
                }

                // TODO: FILTER

                using var http = HttpFactory.CreateClient();

                Console.WriteLine("Fetching from [{0}]", url);
                var resp = await http.GetAsync(url);
                resp.EnsureSuccessStatusCode();

                // https://github.com/typicode/json-server#slice
                resp.Headers.TryGetValues("X-Total-Count", out var totalCountHeader);
                var totalCount = int.TryParse(totalCountHeader?.FirstOrDefault(), out var totalCountInt)
                    ? (int?)totalCountInt
                    : null;

                var albums = await http.GetJsonAsync<Album[]>(url);
                //Console.WriteLine("From [{0}:{1}], got [{2}] row(s) out of [{3}]",
                //    getParams.StartRow, getParams.EndRow, photos.Length, totalCount);

                await getParams.SuccessCallback(albums, totalCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve!");
                Console.WriteLine(ex.ToString());
                await getParams.FailCallback();
            }
        }

        public Task Destroy()
        {
            // Nothing to do
            return Task.CompletedTask;
        }
    }

    class PhotosDataSource : IGridDatasource
    {
        public IHttpClientFactory HttpFactory { get; set; }

        public string[] AlbumIds { get; set; }

        public async Task GetRows(IGetRowsParams getParams)
        {
            try
            {
                var url = "https://jsonplaceholder.typicode.com/photos?";

                if (AlbumIds?.Length > 0)
                {
                    foreach (var aid in AlbumIds)
                        url += $"&albumId={aid}";
                }
                else
                {
                    url += "&albumId=-1";
                }

                // https://github.com/typicode/json-server#slice
                url += $"&_start={getParams.StartRow}";
                url += $"&_end={getParams.EndRow}";

                if (getParams.SortModel?.Length > 0)
                {
                    // https://github.com/typicode/json-server#sort
                    url += $"&_sort={string.Join(",", getParams.SortModel.Select(sm => sm.ColumnId))}";
                    url += $"&_order={string.Join(",", getParams.SortModel.Select(sm => sm.Direction))}";
                }

                // TODO: FILTER

                using var http = HttpFactory.CreateClient();

                Console.WriteLine("Fetching from [{0}]", url);
                var resp = await http.GetAsync(url);
                resp.EnsureSuccessStatusCode();

                // https://github.com/typicode/json-server#slice
                resp.Headers.TryGetValues("X-Total-Count", out var totalCountHeader);
                var totalCount = int.TryParse(totalCountHeader?.FirstOrDefault(), out var totalCountInt)
                    ? (int?)totalCountInt
                    : null;

                var photos = await http.GetJsonAsync<Photo[]>(url);
                //Console.WriteLine("From [{0}:{1}], got [{2}] row(s) out of [{3}]",
                //    getParams.StartRow, getParams.EndRow, photos.Length, totalCount);

                await getParams.SuccessCallback(photos, totalCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve!");
                Console.WriteLine(ex.ToString());
                await getParams.FailCallback();
            }
        }

        public Task Destroy()
        {
            // Nothing to do
            return Task.CompletedTask;
        }
    }
}
