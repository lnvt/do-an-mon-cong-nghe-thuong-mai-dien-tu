var cart =
{
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/"; //đưa về trang chủ
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan"; //đưa về trang chủ
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listproduct = $('.txtQuantity');
            var cartlist = [];
            $.each(listproduct, function (i, item) {
                cartlist.push({
                    Quantity: $(item).val(), //thuoc tinh trong Models
                    Product:
                    {
                        ID: $(item).data('id')

                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartlist) }, //parse carlist sang string
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
cart.init();