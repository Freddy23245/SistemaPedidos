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
            $('#TalleProd').val(data.talle);
            $('#CantProd').val(1);
            var prec = document.querySelector("#PrecioProd");
            prec.focus();
        },
        error: function (error) {
            console.log(error);
        }
    });

});

