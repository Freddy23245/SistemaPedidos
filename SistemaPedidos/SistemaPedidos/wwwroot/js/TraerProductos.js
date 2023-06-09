$("#select-productos").change(function () {
    var idProducto = $(this).val();
    $.ajax({
        url: "/Ventas/TraerProducto/",
        type: "GET",
        data: { id: idProducto },
        success: function (data) {
            console.log(data);
            $("#StockProd").val(data.stock);
            $("#PrecioProd").val(data.precio);
        },
        error: function (error) {
            console.log(error);
        }
    });
});

