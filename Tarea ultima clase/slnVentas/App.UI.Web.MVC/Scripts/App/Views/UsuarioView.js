(function (app) {

    app.UsuarioView = {

        RefreshLista: function () {
            $("#filterByName").val("");
            $(".buscar").click();
            app.helpers.closeModal('UsuarioCreatePopup');            
        }
    }

})(window.app = window.app || {});