const dropArea = document.querySelector('.drop-section');
const listSection = document.querySelector('.list-section');
const listContainer = document.querySelector('.list');
const fileSelector = document.querySelector('.file-selector');
const fileSelectorInput = document.getElementById("fileup");
const btnUpload = document.getElementById('btnUpload');
const preview = document.getElementById('ifile');
const barrita = document.getElementById('barrita');
//upload files with browse button
fileSelector.onclick = () => fileSelectorInput.click();

fileSelectorInput.onchange = function () {
    var file = fileSelectorInput.files[0];

    filePreview(file);

}

dropArea.ondragover = (e) => {
    e.preventDefault();
    [...e.dataTransfer.items].forEach((item) => {
        if (typeValidation(item.type)) {
            dropArea.classList.add('drag-over-effect');
        }
    })
}
dropArea.ondragleave = () => {
    dropArea.classList.remove('drag-over-effect');

}

dropArea.ondrop = (e) => {
    e.preventDefault();
    dropArea.classList.remove('drag-over-effect');
    if (e.dataTransfer.items) {
        [...e.dataTransfer.items].forEach((item) => {
            if (item.kind === 'file') {
                const file = item.getAsFile();
                if (typeValidation(file.type)) {

                    const dataTransfer = new DataTransfer();
                    dataTransfer.items.add(file);
                    fileSelectorInput.files = dataTransfer.files;


                    dropArea.classList.add('file-preview');
                    //Lectura del documento
                    filePreview(file);
                } else {
                    alert('solo pdf');
                }
            }
        })
    }
}

function typeValidation(type) {
    var splitType = type.split('/')[0];
    if (type == 'application/pdf') {
        return true;
    }
}
btnCancelar.onclick = () => {
    Limpiar();
}

const myModalEl = document.getElementById('exampleModal');
myModalEl.addEventListener('hidden.bs.modal', event => {
    Limpiar();
})

btnUpload.onclick = () => {

    $('#btnCancelar').hide();
    $('#btnUpload').hide();
    subirArchivoXML();
    
    //subirArchivoAjax();
}

$('document').ready(function () {
    console.log('cargada:3');
});

function filePreview(file) {
    if (typeValidation(file.type)) {
        console.log(file);

        const reader = new FileReader();
        var filename = file.name;
        $('#btnCancelar').show();
        $('#btnUpload').show();
        $('#lblNombre').html(filename);
        reader.readAsArrayBuffer(file);
        reader.addEventListener("load", function () {
            const buffer = reader.result;
            const fileblob = new Blob([new Uint8Array(buffer)], { type: "application/pdf" });
            preview.src = window.URL.createObjectURL(fileblob);
            preview.classList.remove('holds-the-iframe');
            /*console.log(preview.scr);*/
            dropArea.classList.add('file-preview');

        }, false)
    }
}

function subirArchivoXML() {
    barrita.innerHTML = '0';
    barrita.style.width = '0';
    document.getElementById('pgrs').style.display = 'block';
    let selector2 = document.getElementById("fileup");
    //listSection.style.display = 'block';
    var li = document.createElement('li');
    li.classList.add('in-prog');
    li.innerHTML = `
        <div class="col">
            <img src="assets/Pdf-2127829.png" width="100%" />
            </div>
            <div class="col">
                <div class="file-name">
                    <div class="name">${selector2.files[0].name}</div>
                    <span>0%</span>
                </div>
                <div class="file-progress">
                    <span></span>
                </div>
                <div class="file-size">${(selector2.files[0].size / (1024 * 1024)).toFixed(2)} MB</div>
            </div>
            <div class="col">
                <svg xmlns="http://www.w3.org/2000/svg" class="cross" height="20" width="20">
                    <path d="m5.979 14.917-.854-.896 4-4.021-4-4.062.854-.896 4.042 4.062 4-4.062.854.896-4 4.062 4 4.021-.854.896-4-4.063Z" />
                </svg>
                <svg xmlns="http://www.w3.org/2000/svg" class="tick" height="20" width="20">
                    <path d="m8.229 14.438-3.896-3.917 1.438-1.438 2.458 2.459 6-6L15.667 7Z"></path>
                </svg>
            </div>
    `;
    //listContainer.prepend(li);

    var http = new XMLHttpRequest();
    var data = new FormData();

    var empleado =  $('#lblNombres').text() + ' ' + $('#lblApellido').text();
    data.append(selector2.files[0].name, selector2.files[0]);
    data.append("expiracion", $('#hfExpiracion').val());
    data.append("documento", $('#hfDocumento').val());
    data.append("empresa", $('#imgEmpresa').attr('alt'));
    data.append("nombre", empleado);
    data.append("noempleado", $('#txtNoEmpleado').val());
    data.append("DocumentacionID", $('#hfDocumentacionID').val());
    data.append("accion", $('#hfAccion').val());
    data.append("fecha", $('#dateFecha').val());


    http.onload = function () {
        li.classList.add('complete');
        li.classList.remove('in-prog');
        barrita.innerHTML = 'Archivo subido';

        /*alert(':D');*/
        if (barrita.innerHTML == 'Archivo subido') {
            setTimeout(hideModal, 5000);
        //Limpiar();
        setTimeout(() => { document.location.reload(); }, 3000);
        console.log(http.responseText);
        }
       

    }
    http.upload.onprogress = (e) => {
        var porcentaje = (e.loaded / e.total) * 100;
        li.querySelectorAll('span')[0].innerHTML = Math.round(porcentaje) + '%';
        li.querySelectorAll('span')[1].style.width = porcentaje + '%';

        barrita.innerHTML = Math.round(porcentaje) + '%';
        barrita.style.width = porcentaje + '%';

        console.log(porcentaje);

    }
    http.open('POST', 'hFIleUpload.ashx');
    http.send(data);

}

function subirArchivoAjax() {
    //Boton subir archivo
    var data = new FormData();

    let selector = document.getElementById("fileup");
    /*var fileSel = fileSelectorInput.files[0];*/
    data.append("nombre", "juan");
    data.append("id", "12");
    data.append(selector.files[0].name, selector.files[0]);
    $.ajax({
        url: "hFIleUpload.ashx",
        type: "POST",
        data: data,
        contentType: false,
        processData: false,
        success: function (result) {
            alert(result);
            //window.location.reload();
            Limpiar();
        },
        error: function (err) {
            alert(err.statusText);
        }
    });
}

function Limpiar() {
    fileSelectorInput.value = "";
    preview.src = "";
    dropArea.classList.remove('file-preview');
    preview.classList.add('holds-the-iframe');
    $('#lblNombre').html('Sin archivo seleccionado');
    document.getElementById('pgrs').style.display = 'none';

    $('#btnCancelar').hide();
    $('#btnUpload').hide();
}

function cerrarModal() {
    $('#exampleModal').modal('hide');

}

function hideModal() {
    $find('ModalPopupExtender1').hide();
    Limpiar();
    return false;
}

function OcultarModal() {
    $find('ModalHistorial').hide();   
    return false;
}

window.addEventListener(
    "keydown",
    (event) => {
        if (event.code == 'Escape') {
            hideModal();
        }
    },
    true,
);
