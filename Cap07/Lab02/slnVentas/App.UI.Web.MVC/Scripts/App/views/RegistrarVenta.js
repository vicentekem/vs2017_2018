(function (app) {
    var me =
        {

            Init: function () {

                $("#registrarVenta .btn-buscar-producto").on("click", this.MostrarPopupProductos);

            },

            MostrarPopupProductos: function () {

                app.helpers.showModal(
                    'BusquedaDeProductosPopudID',
                    '/Producto/ConsultaProductosStock',
                    me.MostrarProducto
                );
            },
            MostrarProducto: function () {
                console.log("Producto Seleccionado");
            }

        }

    app.RegistrarVentaView = me;

})(window.app = window.app || {});

