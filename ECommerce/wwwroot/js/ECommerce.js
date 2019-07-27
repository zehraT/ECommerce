
var ECommerce = {

    Page: {
        Home: {

        },
        Categor: {
            Save: function () {
                //stringify json obj stringe çeviriyor
                var categoryId = $("#CategoryId").val();
                var productName = $("#ProductName").val();
                var jsonObj = new Object();
                jsonObj.CategoryId = categoryId;
                jsonObj.ProductName = productName;
                var json = JSON.stringify(jsonObj);

                $.ajax({
                    method: "POST",
                    url: "/api",
                    data: "JSON=" + json
                })
                    .done(function (msg) {
                        alert("Data Saved: " + msg);
                    });

            }
        },
        Contact: {
           
        },
        Help: {

        }
    }
}