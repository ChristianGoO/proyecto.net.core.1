window.onload = function () {
    registroBM.inicializar();
}

var registroBM = {

    nombre: document.getElementById("nombre"),
    apellidoPaterno: document.getElementById("apellidoPaterno"),
    apellidoMaterno: document.getElementById("apellidoMaterno"),
    correoElectronico: document.getElementById("correoElectronico"),
    password: document.getElementById("password"),
    bttnRegistrar: document.getElementById("bttnRegistrar"),
    myAlertInfo: document.getElementById("myAlertInfo"),

    registrar: function () {

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
            "id": 0,
            "nombre": registroBM.nombre.value,
            "apellidoPaterno": registroBM.apellidoPaterno.value,
            "apellidoMaterno": registroBM.apellidoMaterno.value,
            "correoElectronico": registroBM.correoElectronico.value,
            "contraseña": registroBM.password.value
        });

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
        };


        fetch("https://localhost:7092/api/Usuario", requestOptions)
            .then(response => response.text())
            .then(result => function () {
                if (result.codigo == 201) {
                    registroBM.mostrarInformacion(result.mensaje);
                }
                else if (result.codigo == 400) {
                    registroBM.mostrarAlerta(result.mensaje, result.detalles);
                }
                else {
                    registroBM.mostrarError(result.mensaje, result.detalles);
                }
            })
            .catch(error => console.log('error', error))
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

    inicializar: function () {
        registroBM.cargarEvantos();
    },

    cargarEvantos: function () {

        console.log("text in console")
        console.log(registroBM.bttnRegistrar);

        registroBM.bttnRegistrar.onclick = registroBM.registrar;
    }
   
}