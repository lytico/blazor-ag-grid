// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.example4_fetchData4_configure = function (gridOptions) {
    gridOptions.getRowNodeId = function (node) {
        var id = node.id;

        return "ID#" + id;
    }
};

function example4_fetchData5_albums_configure(gridOptions) {
    gridOptions.getRowNodeId = function(node) {
        return "" + node.id;
    };
    gridOptions.components = {
        redColorCellRenderer: RedColorCellRenderer
    };
};

// cell renderer class
function RedColorCellRenderer() {
}

// init method gets the details of the cell to be renderer
RedColorCellRenderer.prototype.init = function (params) {
    this.eGui = document.createElement('span');
    this.eGui.style = "color:red;";
    this.eGui.innerHTML = params.value;
};

RedColorCellRenderer.prototype.getGui = function () {
    return this.eGui;
};

window.example4_fetchData5_photos_configure = function (gridOptions) {
    gridOptions.getRowNodeId = function (node) {
        return "ID#" + node.id;
    }
};
