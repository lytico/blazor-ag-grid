function example4_fetchData5_albums_configure(gridOptions) {
    gridOptions.getRowNodeId = function (node) { return "" + node.id; };
    gridOptions.components = {
        ClassColorCellRenderer: ColorCellRenderer,
        funcColorCellRenderer: colorCellRenderer,
        tooltipComponent: TooltipComponent
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
var TooltipComponent = /** @class */ (function () {
    function TooltipComponent() {
        this.eGui = document.createElement('div');
    }
    TooltipComponent.prototype.init = function (params) {
        this.eGui.classList.add('custom-tooltip'); // ToDo: the correct class is required for the tooltip to be output in the correct place.
        var valueToDisplay = params.value.value ? params.value.value : '- Missing -';
        this.eGui.innerHTML =
            "<p>Athlete's name:</p>" +
                '<p><span class"name">' +
                valueToDisplay + '</span></p>';
    };
    TooltipComponent.prototype.getGui = function () { return this.eGui; };
    return TooltipComponent;
}());
//# sourceMappingURL=ag-grid-script-config.js.map