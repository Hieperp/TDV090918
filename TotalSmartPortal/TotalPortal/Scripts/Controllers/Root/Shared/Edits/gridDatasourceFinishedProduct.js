define(["superBase", "gridDatasourceQuantity"], (function (superBase, gridDatasourceQuantity) {

    var definedExemplar = function (kenGridName) {
        definedExemplar._super.constructor.call(this, kenGridName);
    }

    var superBaseHelper = new superBase();
    superBaseHelper.inherits(definedExemplar, gridDatasourceQuantity);






    definedExemplar.prototype._removeTotalToModelProperty = function (dataRow) {
        this._updateTotalToModelProperty("TotalQuantityFailure", "QuantityFailure", "sum", requireConfig.websiteOptions.rndQuantity, false);
        this._updateTotalToModelProperty("TotalQuantityExcess", "QuantityExcess", "sum", requireConfig.websiteOptions.rndQuantity, false);
        this._updateTotalToModelProperty("TotalQuantityShortage", "QuantityShortage", "sum", requireConfig.websiteOptions.rndQuantity, false);
        this._updateTotalToModelProperty("TotalSwarfs", "Swarfs", "sum", requireConfig.websiteOptions.rndQuantity, false);

        definedExemplar._super._removeTotalToModelProperty.call(this, dataRow);
    }


    definedExemplar.prototype._changeQuantityFailure = function (dataRow) {
        this._updateTotalToModelProperty("TotalQuantityFailure", "QuantityFailure", "sum", requireConfig.websiteOptions.rndQuantity);
    }

    definedExemplar.prototype._changeQuantityExcess = function (dataRow) {
        this._updateTotalToModelProperty("TotalQuantityExcess", "QuantityExcess", "sum", requireConfig.websiteOptions.rndQuantity);
    }

    definedExemplar.prototype._changeQuantityShortage = function (dataRow) {
        this._updateTotalToModelProperty("TotalQuantityShortage", "QuantityShortage", "sum", requireConfig.websiteOptions.rndQuantity);
    }

    definedExemplar.prototype._changeSwarfs = function (dataRow) {
        this._updateTotalToModelProperty("TotalSwarfs", "Swarfs", "sum", requireConfig.websiteOptions.rndQuantity);
    }
    

    return definedExemplar;
}));