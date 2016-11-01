function StoreInfoViewModel() {
    var self = this;
    //详情
    self.StoreID = ko.observable("");
    self.Name = ko.observable("");
    self.ImgLongitude = ko.observable("");
    self.ImgLatitude = ko.observable("");
    self.Address = ko.observable("");
    self.Telephone = ko.observable("");
    self.OpeningTime = ko.observable("");

    self.Store_List = ko.observableArray();
    //页面初始化
    self.Init = function () {
 
    };

    //初始化DataTable
    self.Init_DataTable = function () {

    };
    
    self.del = function (data, event) {
        $.ajax({
            type: "post",
            url: "http://" + window.location.host  + "/api/Display/StoreApi/DelStore",
            contentType: "application/json; charset=utf-8",
            data: "{\"StoreID\":\"" + data.StoreID + "\"}",
            success: function (shop) {
                self.Store_List.removeAll();
                $("#storeDetailModal").modal('hide');
                self.Refresh();
            },
            dataType: "json"
        });
       
    };

    self.save = function () {
        $.ajax({
            type: "post",
            url: "http://" + window.location.host + "/api/Display/StoreApi/SaveStore",
            contentType: "application/json; charset=utf-8",
            data: "{\"StoreID\":\"" + $('#inputStoreID').val() + "\",\"Name\":\"" + $('#inputName').val() + "\",\"ImgLongitude\":\"" + $('#inputImgLongitude').val() + "\",\"ImgLatitude\":\"" + $('#inputImgLatitude').val() + "\",\"Address\":\"" + $('#inputAddress').val() + "\",\"Telephone\":\"" + $('#inputTelephone').val() + "\",\"OpeningTime\":\"" + $('#inputOpeningTime').val() + "\"}",
            success: function (shop) {
                self.Store_List.removeAll();
                $("#storeDetailModal").modal('hide');
                self.Refresh();
            },
            dataType: "json"
        });
        
    };

    self.Refresh = function () {
     
        $.ajax({
            type: "post",
            url: "http://"+window.location.host +  "/api/Display/StoreApi/GetStore",
            contentType: "application/json; charset=utf-8",
            data: "{\"where\":\"1=1\",\"go2page\":\"0\"}",
            success: function (shop) {
                var data = JSON.parse(shop.data);
                var datashow = JSON.parse(data.data);
                ko.utils.arrayForEach(datashow, function (item) {
                    self.Store_List.push({ StoreID: item.StoreID, Name: item.Name, ImgLongitude: item.ImgLongitude, ImgLatitude: item.ImgLatitude, Address: item.Address, Telephone: item.Telephone, OpeningTime: item.OpeningTime });
                });
            },
            dataType: "json"
        });
    }
}


