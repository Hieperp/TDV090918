function cancelButton_Click() {
    window.parent.$("#myWindow").data("kendoWindow").close();
}

function handleOKEvent(finishedHandoverGridDataSource, pendingDetailGridDataSource) {
    if (finishedHandoverGridDataSource != undefined && pendingDetailGridDataSource != undefined) {
        var pendingDetailGridDataItems = pendingDetailGridDataSource.view();        
        
        var finishedHandoverJSON = finishedHandoverGridDataSource.data().toJSON();
        for (var i = 0; i < pendingDetailGridDataItems.length; i++) {
            if (pendingDetailGridDataItems[i].IsSelected === true)
                _setParentInput(finishedHandoverJSON, pendingDetailGridDataItems[i]);
        }
        
        finishedHandoverJSON.push(new Object()); //Add a temporary empty row

        finishedHandoverGridDataSource.data(finishedHandoverJSON);

        var rawData = finishedHandoverGridDataSource.data()
        finishedHandoverGridDataSource.remove(rawData[rawData.length - 1]); //Remove the last row: this is the temporary empty row

        cancelButton_Click();
    }


    //http://www.telerik.com/forums/adding-multiple-rows-performance
    //By design the dataSource does not provide an opportunity for inserting multiple records via one operation. The performance is low, because each time when you add row through the addRow method, the DataSource throws its change event which forces the Grid to refresh and re-paint the content.
    //To avoid the problem you may try to modify the data of the DataSource manually.
    //var grid = $("#grid").data("kendoGrid");
    //var data = gr.dataSource.data().toJSON(); //the data of the DataSource

    ////change the data array
    ////any changes in the data array will not automatically reflect in the Grid

    //grid.dataSource.data(data); //set changed data as data of the Grid


    function _setParentInput(finishedHandoverJSON, finishedHandoverGridDataItem) {

        //var dataRow = finishedHandoverJSON.add({});        
        var dataRow = new Object();
        

        dataRow.LocationID = null;
        dataRow.EntryDate = null;

        dataRow.FinishedHandoverDetailID = 0;
        dataRow.FinishedHandoverID = window.parent.$("#FinishedHandoverID").val();

        dataRow.FinishedProductID = finishedHandoverGridDataItem.FinishedProductID;
        dataRow.FinishedProductDetailID = finishedHandoverGridDataItem.FinishedProductDetailID;

        dataRow.FinishedProductCode = finishedHandoverGridDataItem.FinishedProductCode;
        dataRow.FinishedProductReference = finishedHandoverGridDataItem.FinishedProductReference;
        dataRow.FinishedProductEntryDate = finishedHandoverGridDataItem.EntryDate;

        dataRow.CustomerID = finishedHandoverGridDataItem.CustomerID;
        dataRow.CustomerName = finishedHandoverGridDataItem.CustomerName;
        dataRow.CustomerCode = finishedHandoverGridDataItem.CustomerCode;

        dataRow.CommodityID = finishedHandoverGridDataItem.CommodityID;
        dataRow.CommodityCode = finishedHandoverGridDataItem.CommodityCode;
        
        dataRow.Quantity = finishedHandoverGridDataItem.Quantity;                        

        dataRow.CrucialWorkerID = finishedHandoverGridDataItem.CrucialWorkerID;
        dataRow.CrucialWorkerName = finishedHandoverGridDataItem.CrucialWorkerName;

        dataRow.CommodityTypeID = finishedHandoverGridDataItem.CommodityTypeID;

        dataRow.Remarks = null;        
        dataRow.InActive = false;
        dataRow.InActivePartial = false;
        dataRow.InActiveIssue = false;

        finishedHandoverJSON.push(dataRow);
    }
}

