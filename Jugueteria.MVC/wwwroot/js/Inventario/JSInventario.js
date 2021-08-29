function borrarArticulo(id) {
    if (!confirm("Desea eliminar el articulo: " + id)) {
        return
    }
    $.ajax({
        url: "Inventario/borrarArticulo?id=" + id,
        type: 'POST',
        statusCode: {
            200: function (data) {
                window.location.href = "";
            }
        },
        400: function () {
            //  ClearForm();
            alert('Error');
        },
        500: function () {
            alert('Internal server error');
        }
    });
}
function editarArticulo(id) {

    
    $.ajax({
        url: "Inventario/editarArticulo?id=" + id,
        type: 'POST',
        statusCode: {
            200: function (data) {
                document.getElementById("id-Articulo").value = data.id;
                document.getElementById("nombreArticulo").value = data.nombre;
                document.getElementById("precioArticulo").value = "$ " + new Intl.NumberFormat().format(data.precio);
                document.getElementById("companiaArticulo").value = data.compania;
                document.getElementById("maxEdadArticulo").value = data.restriccionEdad;
                document.getElementById("descripcionArticulo").value = data.descripcion;
            }
        },
        400: function () {
            //  ClearForm();
            alert('Error');
        },
        500: function () {
            alert('Internal server error');
        }
    });
}

function guardarArticuloEditado() {
    const nombreinpObj = document.getElementById("nombreArticulo");
    if (!nombreinpObj.checkValidity()) {
        document.getElementById("nombreArticuloMsn").innerHTML = nombreinpObj.validationMessage;
        return
    } else {
        document.getElementById("nombreArticuloMsn").innerHTML = "";
    }
    const descripcioninpObj = document.getElementById("descripcionArticulo");
    if (!descripcioninpObj.checkValidity()) {
        document.getElementById("descripcionArticuloMsn").innerHTML = descripcioninpObj.validationMessage;
        return
    } else {
        document.getElementById("descripcionArticuloMsn").innerHTML = "";
    }
    const maxEdadinpObj = document.getElementById("maxEdadArticulo");
    if (!maxEdadinpObj.checkValidity()) {
        document.getElementById("maxEdadArticuloMsn").innerHTML = maxEdadinpObj.validationMessage;
        return
    } else {
        document.getElementById("maxEdadArticuloMsn").innerHTML = "";
    }
    const companiainpObj = document.getElementById("companiaArticulo");
    if (!companiainpObj.checkValidity()) {
        document.getElementById("companiaArticuloMsn").innerHTML = companiainpObj.validationMessage;
        return
    } else {
        document.getElementById("companiaArticuloMsn").innerHTML = "";
    }
    const precioinpObj = document.getElementById("precioArticulo");
    if (!precioinpObj.checkValidity()) {
        document.getElementById("precioArticuloMsn").innerHTML = precioinpObj.validationMessage;
        return
    } else {
        document.getElementById("precioArticuloMsn").innerHTML = "";
    }


    var parametros = {
        "Id": document.getElementById("id-Articulo").value,
        "Nombre": document.getElementById("nombreArticulo").value,
        "Descripcion": document.getElementById("descripcionArticulo").value,
        "RestriccionEdad": document.getElementById("maxEdadArticulo").value,
        "Compania": document.getElementById("companiaArticulo").value,
        "Precio": document.getElementById("precioArticulo").value.replace(/[$]/g, '')
    };

    $.ajax({
        url: "Inventario/guardarArticuloEditado/",
        type: 'POST',
        data: parametros,
        statusCode: {
            200: function (data) {
                window.location.href = "";
            }
        },
        400: function () {
            //  ClearForm();
            alert('Error');
        },
        500: function () {
            alert('Internal server error');
        }
    });
}

function guardarArticulo() {

    const nombreinpObj = document.getElementById("nombreArticuloNuevo");
    if (!nombreinpObj.checkValidity()) {
        document.getElementById("nombreArticuloNuevoMsn").innerHTML = nombreinpObj.validationMessage;
    } else {
        document.getElementById("nombreArticuloNuevoMsn").innerHTML = "";
    }
    const descripcioninpObj = document.getElementById("descripcionArticuloNuevo");
    if (!descripcioninpObj.checkValidity()) {
        document.getElementById("descripcionArticuloNuevoMsn").innerHTML = descripcioninpObj.validationMessage;
    } else {
        document.getElementById("descripcionArticuloNuevoMsn").innerHTML = "";
    }
    const maxEdadinpObj = document.getElementById("maxEdadArticuloNuevo");
    if (!maxEdadinpObj.checkValidity()) {
        document.getElementById("maxEdadArticuloNuevoMsn").innerHTML = maxEdadinpObj.validationMessage;
    } else {
        document.getElementById("maxEdadArticuloNuevoMsn").innerHTML = "";
    }
    const companiainpObj = document.getElementById("companiaArticuloNuevo");
    if (!companiainpObj.checkValidity()) {
        document.getElementById("companiaArticuloNuevoMsn").innerHTML = companiainpObj.validationMessage;
    } else {
        document.getElementById("companiaArticuloNuevoMsn").innerHTML = "";
    }
    const precioinpObj = document.getElementById("precioArticuloNuevo");
    if (!precioinpObj.checkValidity()) {
        document.getElementById("precioArticuloNuevoMsn").innerHTML = precioinpObj.validationMessage;
    } else {
        document.getElementById("precioArticuloNuevoMsn").innerHTML = "";
    }
    

    var parametros = {
        "Nombre": document.getElementById("nombreArticuloNuevo").value,
        "Descripcion": document.getElementById("descripcionArticuloNuevo").value,
        "RestriccionEdad": document.getElementById("maxEdadArticuloNuevo").value,
        "Compania": document.getElementById("companiaArticuloNuevo").value,
        "Precio": document.getElementById("precioArticuloNuevo").value.replace(/[$]/g, '')
    };

    $.ajax({
        url: "Inventario/guardarArticulo/",
        type: 'POST',
        data: parametros,
        statusCode: {
            200: function (data) {
                window.location.href = "";
            }
        },
        400: function () {
            //  ClearForm();
            alert('Error');
        },
        500: function () {
            alert('Internal server error');
        }
    });
}