function ontestt(e) {
    var kendoGrid = $("#kendoGridDetails").data("kendoGrid");

    return {
        searchText: e.filter.filters[0].value,
        commodityID: window.bomCommodityID != undefined ? window.bomCommodityID : 0,
        commodityCategoryID: $("#CommodityCategoryID").val() != undefined ? $("#CommodityCategoryID").val() : 0,
        commodityClassID: $("#CommodityClassID").val() != undefined ? $("#CommodityClassID").val() : 0,
        commodityLineID: $("#CommodityLineID").val() != undefined ? $("#CommodityLineID").val() : 0
    };
}