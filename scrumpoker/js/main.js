const createSession = document.querySelector('.button');

function entrar() {
    var usuario = document.getElementById('usuario').value;
    var sala = document.getElementById('sala').value;

    if (usuario == "" || sala == "") {
        alert("Preencha todos os campos");
    } else {
        const items = JSON.parse(localStorage.getItem('items')) || [];

        const item = {
            usuario,
            sala
        };

        items.push(item);
        localStorage.setItem('User', JSON.stringify(items));
        this.reset();

        window.location.href = "file:///C:/Users/g.pedro/Desktop/Gabriel/projects/scrumpoker/scrumpoker/create.html";

    }

}

createSession.addEventListener('submit', entrar);