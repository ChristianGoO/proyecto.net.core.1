
var alert = {

    alertPlaceholder: document.getElementById("alertPlaceholder"),

    agregarAlerta: function (message, detalle, type) {

        detalle = detalle != undefined && detalle != null ? detalle.join('<br />') : '';
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `   <div><b>${message}</b></div>`,
            `   <div>${detalle}</div>`,
            '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('');

        alert.alertPlaceholder.append(wrapper)
    },

    mostrarInformacion: function (mensaje) {
        alert.agregarAlerta(mensaje, [], 'success')
    },

    mostrarAdvertencia: function (mensaje, detalle) {
        alert.agregarAlerta(mensaje, detalle, 'warning')
    },

    mostrarError: function (mensaje, detalle) {
        alert.agregarAlerta(mensaje, detalle, 'danger')
 
    },

    mostrarResultaro: function (result) {
        if (result.codigo == 201) {
            alert.mostrarInformacion(result.mensaje);
        }
        else if (result.codigo == 400) {
            alert.mostrarAdvertencia(result.mensaje, result.detalles);
        }
        else {
            alert.mostrarError(result.mensaje, result.detalles);
        }
    }

}