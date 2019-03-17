(function (app) {
    var me =
        {
            DetalleVenta:[],
            productoSeleccionado: {},
            Init: function () {

                $("#registrarVenta .btn-buscar-producto").on("click", me.MostrarPopupProductos);
                $("#registrarVenta .agregar").on("click", me.AgregarLista);
                $("#registrarVenta .guardar").on("click", me.Guardar);

                $("#BusquedaDeProductosPopudID").on('hidden.bs.modal', me.MostrarProducto);                

            },

            MostrarPopupProductos: function () {

                app.helpers.showModal(
                    'BusquedaDeProductosPopudID',
                    '/Producto/ConsultaProductosStock',
                    me.MostrarProducto
                );
            },
            MostrarProducto: function () {
                 
                me.productoSeleccionado = app.helpers.stateModal;
                
                $('#registrarVenta .nombre-producto').val(me.productoSeleccionado.Nombre);
                $('#registrarVenta .precio-producto').val(me.productoSeleccionado.PrecioMenor);

            },
            AgregarLista: function () {

                //setear datos del producto seleccionado
                me.productoSeleccionado.Cantidad = $("#registrarVenta .cantidad-producto").val();
                me.productoSeleccionado.SubTotal = me.productoSeleccionado.Cantidad * me.productoSeleccionado.PrecioMenor;
                me.productoSeleccionado.Precio = me.productoSeleccionado.PrecioMenor;
                me.DetalleVenta.push(me.productoSeleccionado);

                //uso de la libreria mustache
                var templateTable = $('#RegistrarVentaDetalle').html();
                Mustache.parse(templateTable);
                var htmlDetalle = Mustache.render(templateTable, {detalle: me.DetalleVenta} );
                $("#contenidoDetalle").html(htmlDetalle); 

            },
            Guardar: function () {
                //Haciendo un llamada ajax para registrar la venta

                var venta = {
                    ClienteID: 1,
                    VentaDetalle:me.DetalleVenta
                }

                $.post("/Venta/Guardar", { model: venta }, function (response) {
                    app.helpers.ShowMessageSuccess("Se registro la venta correctamente");
                });
            }

        }

    app.RegistrarVentaView = me;

})(window.app = window.app || {});

