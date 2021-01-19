function example4_fetchData5_albums_configure(gridOptions) {
    gridOptions.getRowNodeId = function (node) { return "" + node.id; };
    gridOptions.components = {
        redColorCellRenderer: RedColorCellRenderer
    };
}
;
/** cell renderer class */
var RedColorCellRenderer = /** @class */ (function () {
    function RedColorCellRenderer() {
    }
    // init method gets the details of the cell to be renderer
    RedColorCellRenderer.prototype.init = function (params) {
        this.eGui = document.createElement('span');
        this.eGui.style = "color:red;";
        this.eGui.innerHTML = params.value;
    };
    ;
    RedColorCellRenderer.prototype.getGui = function () {
        return this.eGui;
    };
    RedColorCellRenderer.prototype.refresh = function (params) {
        return false;
    };
    RedColorCellRenderer.prototype.destroy = function () {
    };
    return RedColorCellRenderer;
}());
//# sourceMappingURL=ag-grid-script-config.js.map