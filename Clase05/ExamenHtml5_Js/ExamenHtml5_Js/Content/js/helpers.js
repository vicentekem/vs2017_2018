
(function (cibertec) {

    cibertec.helpers = {

        replaceAll: function (string, find, replace) {

            var resultado = string.replace(
                new RegExp(find, 'g'), replace
            );

            return resultado;
           
        },
        getAniosArray: function (anioInicio) {

            var hoy = new Date();
            var anios = [];

            for (i = anioInicio; i <= hoy.getFullYear(); i++) {

                anios.push(i);

            }

            return anios;

        },
        BloquearControles: function () {

            $('input, select, button, textarea').attr('disabled', 'disabled');

        },
        DesbloquearControles: function () {

            $('input, select, button, textarea').removeAttr('disabled', 'disabled');

        },
        SetObjetctLocalStorage: function (jsObject, keyStorage) {
            //stringify: SERIALIZA
            var objectString = JSON.stringify(jsObject);
            //ALMACENAR
            localStorage.setItem(keyStorage, objectString);

        },
        GetObjetctLocalStorage: function (keyStorage) {
            //parse: DESERIALIZA
            var objectString = localStorage.getItem(keyStorage);
            var objectJS = JSON.parse(objectString);
            
            return objectJS;
        },
        ValidarRequerido: function (elementID, message = "Este campo es requerido") {

            var element = $("#" + elementID);
            var value = element.val();            

            if ( value.trim().length === 0 ) {
                element[0].setCustomValidity(message);
            }

        },
        ValidarNumero: function (elementID, message = "Debe ingresar un número") {

            var element = $("#" + elementID);
            var value = element.val();
            var isNum = (!isNaN(value) && value.trim().length > 0);

            if (!isNum) {
                element[0].setCustomValidity(message);
            }
            
        }
               
    }
})(window.cibertec = window.cibertec || {});