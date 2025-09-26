function Empezar(palabra) {
  mostrada = []; 
    for (let i = 0; i < palabra.length; i++) {
        if (palabra[i] === " ") {
            mostrada.push(" ");
        } else {
            mostrada.push("_"); 
        }
    }
    mostrarPantalla(); 
}
    let intentos = 0;
    let letrasUsadas = [];

function mostrarPantalla() {
    let texto = "";
    let a = 0;
    while (a < mostrada.length) {
        texto = texto + mostrada[a] + " ";
        a = a + 1;
    }

    document.getElementById("palabraOculta").innerText = texto.trim();
    document.getElementById("intentosTexto").innerText = "" + intentos;
    document.getElementById("intentosHidden").value = "" + intentos;

    let usadas = "";
    let b = 0;
    while (b < letrasUsadas.length) {
        usadas = usadas + letrasUsadas[b] + " ";
        b = b + 1;
    }
    document.getElementById("letrasUsadas").innerText = usadas.trim();
}

function arriesgarLetra() {
    let caja = document.getElementById("entrada");
    let letra = (caja.value || "").toUpperCase();
    caja.value = "";

    if (letra.length !== 1) {
        alert("Ingresá UNA sola letra");
        return;
    }

    let repetida = false;
    let r = 0;
    while (r < letrasUsadas.length) {
        if (letrasUsadas[r] === letra) { repetida = true; }
        r = r + 1;
    }
    if (repetida) {
        alert("Ya usaste esa letra");
        return;
    }

    letrasUsadas.push(letra);

    let acierto = false;
    let j = 0;
    while (j < palabra.length) {
        if (palabra[j] === letra) 
        {
            mostrada[j] = letra;
            acierto = true;
        }
        j = j + 1;
    }

    if (acierto === false) {
        intentos = intentos + 1;
    }

    mostrarPantalla();

    let gano = true;
    let k = 0;
    while (k < mostrada.length) {
        if (mostrada[k] === "_") { gano = false; }
        k = k + 1;
    }

    if (gano) {
        alert("¡Felicitaciones!");
        
    }
}

function arriesgarPalabra() {
    let caja = document.getElementById("entrada");
    let intento = (caja.value || "").toUpperCase();
    caja.value = "";

    intentos = intentos + 1;

    if (intento === palabra) {
        let y = 0;
        while (y < palabra.length) {
            if (palabra[y] !== " ") { mostrada[y] = palabra[y]; }
            y = y + 1;
        }
        mostrarPantalla();
        alert("¡Felicitaciones!");
    } 
    else 
    {
        alert("Incorrecto");
    }
}

mostrarPantalla();