window.onload = function () {
    debugger;
    registroBM.inicializar();
}

var registroBM = {

    nombre: document.getElementById("nombre"),
    apellidoPaterno: document.getElementById("apellidoPaterno"),
    apellidoMaterno: document.getElementById("apellidoMaterno"),
    correoElectronico: document.getElementById("correoElectronico"),
    password: document.getElementById("password"),
    bttnRegistrar: document.getElementById("bttnRegistrar"),

    registrar: function () {

        debugger;

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
            .then(response => response.json())
            .then(function(result) {
                alert.mostrarResultado(result);
            })
            .catch(error => console.log('error', error))
    },

    inicializar: function () {
        registroBM.cargarEvantos();
    },

    cargarEvantos: function () {
        registroBM.bttnRegistrar.onclick = registroBM.registrar;
    }
   
}