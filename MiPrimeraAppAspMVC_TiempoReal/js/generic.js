function get(id) {
    //textbox (input type='text') combos(select)
    return document.getElementById(id).value;
}

//image (img)
function getS(id) {
    return document.getElementById(id).src;
}

function set(id, valor) {
    document.getElementById(id).value = valor;
}

function setS(id, valor) {
    document.getElementById(id).src = valor;
}

function pintar(url, id="divTabla", cabeceras, nombrePropiedades) {

    //Hacemos la llamada
    fetch(url).then(res => res.json())
        .then(res => {
            //Esto nos devolvera solo los object 
            //alert(res)
            //Mostrara la data obtenida en formato Json
           // alert(JSON.stringify(res))

            let contenido = "<table class='table'>";
            contenido += "<thead>";
            contenido += "<tr>";
            for (const element of cabeceras) {
                contenido += "<th>"
                contenido += element
                contenido += "</th>"
            }
            contenido += "</tr>";

            contenido += "</thead>";
            contenido += "<tbody>";
            let objetoActual;
            let nombrePropiedad;
            contenido += "</tbody>";
            for (var i = 0; i < res.length; i++) {
                objetoActual = res[i]
                contenido += "<tr>";
                for (var j = 0; j < nombrePropiedades.length; j++) {
                    nombrePropiedad = nombrePropiedades[j]
                    contenido += "<td>"
                    contenido += objetoActual[nombrePropiedad]
                    contenido += "</td>"
                }
                contenido+="</tr>"
            }
            contenido += "</table>";
            //Lo escribimos
            document.getElementById(id).innerHTML = contenido;
        });
}