const uri = 'http://127.0.0.1:8000/api';
const xhr = new XMLHttpRequest();
function onRequestHandler() {
    if (this.status == 200 && this.readyState == 4) {
        console.log(this.response); 
        Swal.fire({
            position: "top-end",
            icon: "success",
            backdrop: false,
            title: "Nuevos Registros",
            showConfirmButton: false,
            timer: 1500
        });
    }
}


function calldata() {
    xhr.addEventListener('load', onRequestHandler);
    xhr.open('GET', uri);
    xhr.send();
}

setInterval(calldata, 30000);
