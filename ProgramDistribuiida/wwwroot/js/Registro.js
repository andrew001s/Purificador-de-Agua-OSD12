
function alerta() {
    let timerInterval;
    Swal.fire({
        title: "Potabilizando",
        html: "Esto tomará unos segundos <b></b>.",
        timer: 3500,
        timerProgressBar: true,
        backdrop: false,
        didOpen: () => {
            Swal.showLoading();
            const timer = Swal.getPopup().querySelector("b");
            timerInterval = setInterval(() => {
                timer.textContent = `${Swal.getTimerLeft()}`;
            }, 100);
        },
        willClose: () => {
            clearInterval(timerInterval);
        }
    }).then((result) => {
        if (result.dismiss === Swal.DismissReason.timer) {
            console.log("I was closed by the timer");
        }
    });
}

function updateregistro(e) {
    e.preventDefault();
    Swal.fire({
        title: '¿Estás seguro?',
        icon: 'Question',
        showCancelButton: true,
        confirmButtonText: 'Si',
    }).then((result) => {
        if (result.isConfirmed) {
            const form = document.getElementById('form');
            const wave = document.querySelector('#wave1');
            const wave2 = document.querySelector('#wave2');
            const ocean = document.querySelector('#oceandirtid');
            const bubble = document.querySelector('#containerbuble');
            bubble.style.visibility= 'visible';
            wave.classList.add('waveclean');
            wave.classList.remove('wavedirt');
            wave2.classList.add('waveclean');
            wave2.classList.remove('wavedirt');
            ocean.classList.add('ocean');
            ocean.classList.remove('oceandirt');
            alerta();
            setTimeout(() => {

                form.submit();
               
            },3500);
            
        }
    })
}