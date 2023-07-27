window.onload = function () {
    activarRegistroBM.inicializar();
}

var activarRegistroBM = {

    nombre: document.getElementById("nombre"),
    activacionExitosa: document.getElementById("activacionExitosa"),
    activacionExpirada: document.getElementById("activacionExpirada"),

    consultaUsuario: function () {

        const urlParams = new URLSearchParams(window.location.search);
        const uid = urlParams.get('uid');

        var url = "https://localhost:7092/api/Usuario?uid=" + uid;

        var requestOptions = {
            method: 'GET',
            redirect: 'follow'
        };

        fetch(url, requestOptions)
            .then(response => response.json())
            .then(function (result) {
                if (result.codigo == 200) {
                    activarRegistroBM.nombre.innerText = result.resultado.nombre + " " + result.resultado.apellidoPaterno;
                }
            })
            .catch(error => console.log('error', error));
    },

    activarUsuario: function () {


        const urlParams = new URLSearchParams(window.location.search);
        const uid = urlParams.get('uid');

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
            "uid": uid,
        });

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
        };


        fetch("https://localhost:7092/api/Usuario/ActivarUsuario", requestOptions)
            .then(response => response.json())
            .then(function (result) {
                if (result.codigo == 200) {
                    activarRegistroBM.consultaUsuario();
                    activarRegistroBM.mostrarActivacionExitosa(result.mensaje);
                }
                else if (result.codigo == 404) {
                    activarRegistroBM.mostrarAlerta(result.mensaje, result.detalles);
                }
                else if (result.codigo == 409) {
                    activarRegistroBM.mostrarActivacionExpirada();
                }
                else {
                    activarRegistroBM.mostrarError(result.mensaje, result.detalles);
                }
            })
            .catch(error => console.log('error', error))
    },

    mostrarActivacionExitosa: function () {
        activarRegistroBM.activacionExitosa.classList.remove("hidden-div");
        activarRegistroBM.activacionExpirada.classList.add("hidden-div");

    },

    mostrarActivacionExpirada: function () {
        activarRegistroBM.activacionExitosa.classList.add("hidden-div");
        activarRegistroBM.activacionExpirada.classList.remove("hidden-div");

    },

    mostrarInformacion: function (mensaje) {
        console.info(mensaje)
    },

    mostrarAlerta: function (mensaje, detalle) {
        console.warn("Mensaje: " + mensaje);
        console.warn("Detalle: " + detalle);
    },

    mostrarError: function (mensaje, detalle) {
        console.error("Mensaje: " + mensaje);
        console.error("Detalle: " + detalle);
    },

    obtenerUsuario: function () {
        //Aqui va el codigo para obtener la informacion del usuario
    },

    inicializar: function () {
        activarRegistroBM.activarUsuario();
    }

}