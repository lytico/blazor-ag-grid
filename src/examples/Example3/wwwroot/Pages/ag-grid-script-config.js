function example4_fetchData5_albums_configure(gridOptions) {
    gridOptions.getRowNodeId = function (node) { return "" + node.id; };
    gridOptions.components = {
        ClassColorCellRenderer: ColorCellRenderer,
        funcColorCellRenderer: colorCellRenderer
    };
}
;
var colorCellRenderer = function (parameters) {
    return "<span style=\"color:" + parameters.color + ";\">" + parameters.value + "</span>";
};
/** cell renderer class */
var ColorCellRenderer = /** @class */ (function () {
    function ColorCellRenderer() {
    }
    // init method gets the details of the cell to be renderer
    ColorCellRenderer.prototype.init = function (params) {
        this.eGui = document.createElement('span');
        this.eGui.style = "color:" + params.color + ";";
        this.eGui.innerHTML = params.value;
    };
    ;
    ColorCellRenderer.prototype.getGui = function () {
        return this.eGui;
    };
    ColorCellRenderer.prototype.refresh = function (params) {
        return false;
    };
    ColorCellRenderer.prototype.destroy = function () {
    };
    return ColorCellRenderer;
}());
//# sourceMappingURL=ag-grid-script-config.js.map