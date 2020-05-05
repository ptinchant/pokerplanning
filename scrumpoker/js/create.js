const createClass = document.querySelector('.button');

function cadatrar() {
    const novasala = document.getElementById('novasala').value;
    const qtdsala = document.getElementById('qtdsala').value;

    if (novasala == "" || qtdsala == "") {
        alert("Preencha todos os campos");
    } else {
        const salas = JSON.parse(localStorage.getItem('Salas')) || [];

        const session = {
            novasala,
            qtdsala
        };

        salas.push(session);
        localStorage.setItem('Sala', JSON.stringify(salas));
        this.reset();

        window.location.href = "file:///C:/Users/g.pedro/Desktop/Gabriel/projects/scrumpoker/scrumpoker/create.html";

    }
}

createClass.addEventListener('submit', cadatrar);