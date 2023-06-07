$(document).on('#EliminarPedido1', '#BodyPedido', function (e) {
    $.ajax({
        type: 'POST',
        url: '/Ventas/EliminarPedido/',
        data: $('#BodyPedido').serialize(),
        success: function (data) {
            console.log(data);

        }
    });
});