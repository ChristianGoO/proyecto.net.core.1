window.onload = function () {
    activarRegistroBM.inicializar();
}

var activarRegistroBM = {

    activarUsuario: function () {
        //Aqui va el codigo para activar el usuario

       

    },

    obtenerUsuario: function () {
        //Aqui va el codigo para obtener la informacion del usuario
    },

    inicializar : function () {
        const urlParams = new URLSearchParams(window.location.search);
        const uid = urlParams.get('uid');

        alert(uid);
    }

}