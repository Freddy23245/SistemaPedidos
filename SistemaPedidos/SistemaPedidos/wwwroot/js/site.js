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
                $('#SetVentas  #Item1_IdVenta').val(data.resultado);
                $('#SetPedidos  #Item2_IdVenta').val(data.resultado);

                $.ajax({
                    type: 'POST',
                    url: '/Ventas/SetPedidos/',
                    data: $('#SetPedidos').serialize(),
                    success: function (data) {
                        console.log(data);
                    }
                });
            }
        }
    });
});
