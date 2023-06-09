// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('submit', '#SetPedidos', function (e) {
    e.preventDefault();
    if (!$('#SetVentas').valid()) {
        return false;
    }
    var IdVenta = 0;
    $.ajax({
        type: 'POST',
        url: '/Ventas/SetVentas/',
        data: $('#SetVentas').serialize(),
        success: function (data) {
            if (data.estado) {
                $('#SetVentas  #Item1_IdVenta').val(data.resultado);//Se establece la variable resultado que devuelve el id de la venta
                $('#SetPedidos  #Item2_IdVenta').val(data.resultado);

                $.ajax({
                    type: 'POST',
                    url: '/Ventas/SetPedidos/',
                    data: $('#SetPedidos').serialize(),
                    success: function (data) {
                        console.log(data); //el valor de data ya no traeria todos los datos si no el id de la venta que retornaria la funcion SetPedidos asi me llevaria al otro formulario
                       window.location.href = "/Ventas/Modificar/" + data;
           
                    }
                });
            }
        }
    });
});
