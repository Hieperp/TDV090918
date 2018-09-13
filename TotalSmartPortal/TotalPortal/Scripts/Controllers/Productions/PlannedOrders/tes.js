function ontestt(e) {
    var kendoGrid = $("#kendoGridDetails").data("kendoGrid");

    //var a = kendoGrid.current();
    //alert($(e.container));
    //var selectedItem = kendoGrid != undefined ? kendoGrid.dataItem($(this).closest("tr")) : undefined;   
    
    var selectedItem = kendoGrid != undefined ? kendoGrid.dataItem(kendoGrid.select()) : undefined;    

    return {        
        searchText: $("#BomCode").data("kendoAutoComplete").value(),
        commodityID: selectedItem != undefined ? selectedItem.CommodityID : 0,
        //commodityID: $("#CommodityID").val() != undefined ? $("#CommodityID").val() : 0,
        commodityCategoryID: $("#CommodityCategoryID").val() != undefined ? $("#CommodityCategoryID").val() : 0,
        commodityClassID: $("#CommodityClassID").val() != undefined ? $("#CommodityClassID").val() : 0,
        commodityLineID: $("#CommodityLineID").val() != undefined ? $("#CommodityLineID").val() : 0
    };
}