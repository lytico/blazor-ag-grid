function example4_fetchData5_albums_configure(gridOptions) {
    gridOptions.getRowNodeId = node => "" + node.id;
    gridOptions.components = {
        ClassColorCellRenderer: ColorCellRenderer,
        funcColorCellRenderer: colorCellRenderer
    };
};

var colorCellRenderer: ICellRendererFunc = (parameters: ICellRendererParams | any): HTMLElement | string =>
    `<span style="color:${parameters.color};">${parameters.value}</span>`;

/** cell renderer class */
class ColorCellRenderer implements ICellRendererComp {
    public eGui;

    // init method gets the details of the cell to be renderer
    init(params: ICellRendererParams|any) {
        this.eGui = document.createElement('span');
        this.eGui.style = `color:${params.color};`;
        this.eGui.innerHTML = params.value;
    };

    getGui() {
        return this.eGui;
    }

    refresh(params: ICellRendererParams): boolean {
        return false;
    }

    destroy?(): void {
        
    }
}

interface ICellRendererParams {
    value: any, // value to be rendered
    valueFormatted: any, // value to be rendered formatted
    getValue: () => any, // convenience function to get most recent up to date value
    setValue: (value: any) => void, // convenience to set the value
    formatValue: (value: any) => any, // convenience to format a value using the column's formatter
    data: any, // the row's data
    node: any;//RowNode, // row node
    colDef: any;//ColDef, // the cell's column definition
    column: any;//Column, // the cell's column
    $scope: any;
    rowIndex: number, // the current index of the row (this changes after filter and sort)
    api: any;//GridApi, // the grid API
    eGridCell: HTMLElement, // the grid's cell, a DOM div element
    eParentOfValue: HTMLElement, // the parent DOM item for the cell renderer, same as eGridCell unless using checkbox selection
    columnApi: any;//ColumnApi, // grid column API
    context: any, // the grid's context
    refreshCell: () => void, // convenience function to refresh the cell
    addRenderedRowListener: (eventType: string, listener: Function) => void;
}

interface ICellRendererFunc {
    (params: ICellRendererParams|any): HTMLElement | string;
}

interface ICellRendererComp {
    // Optional - Params for rendering. The same params that are passed to the cellRenderer function.
    init?(params: ICellRendererParams): void;

    // Mandatory - Return the DOM element of the component, this is what the grid puts into the cell
    getGui(): HTMLElement;

    // Optional - Gets called once by grid after rendering is finished - if your renderer needs to do any cleanup,
    // do it here
    destroy?(): void;

    // Mandatory - Get the cell to refresh. Return true if the refresh succeeded, otherwise return false.
    // If you return false, the grid will remove the component from the DOM and create
    // a new component in its place with the new values.
    refresh(params: ICellRendererParams): boolean;
}
