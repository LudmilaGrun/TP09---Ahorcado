using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Juego {
    [JsonProperty]
    private List<Palabra> listaPalabras { get; set; }

    [JsonProperty]
    private List<Usuario> jugadores { get; set; }

    [JsonProperty]
    private Usuario jugadorActual { get; set; }
        
    private void LlenarListaPalabras() {
        listaPalabras = new List<Palabra> {
        new Palabra("Sol", 1),
        new Palabra("Mar", 1),
        new Palabra("Pan", 1),
        new Palabra("Flor", 1),
        new Palabra("Casa", 1),
        new Palabra("Perro", 1),
        new Palabra("Gato", 1),
        new Palabra("Agua", 1),
        new Palabra("Luz", 1),
        new Palabra("Cielo", 1),

        new Palabra("Camino", 2),
        new Palabra("Libro", 2),
        new Palabra("Escuela", 2),
        new Palabra("Amigo", 2),
        new Palabra("Zapato", 2),
        new Palabra("Mañana", 2),
        new Palabra("Ventana", 2),
        new Palabra("Reloj", 2),
        new Palabra("Barco", 2),
        new Palabra("Río", 2),

        new Palabra("Montaña", 3),
        new Palabra("Historia", 3),
        new Palabra("Jardín", 3),
        new Palabra("Palabra", 3),
        new Palabra("Teatro", 3),
        new Palabra("Pintura", 3),
        new Palabra("Ciudad", 3),
        new Palabra("Música", 3),
        new Palabra("Castillo", 3),
        new Palabra("Ciencia", 3),

        new Palabra("Filosofía", 4),
        new Palabra("Astronomía", 4),
        new Palabra("Arquitectura", 4),
        new Palabra("Democracia", 4),
        new Palabra("Evolución", 4),
        new Palabra("Tecnología", 4),
        new Palabra("Literatura", 4),
        new Palabra("Matemáticas", 4),
        new Palabra("Biología", 4),
        new Palabra("Geografía", 4)
        };
    }

    public void InicializarJuego(string nombreUsuario, int dificultad) {
        jugadorActual = new Usuario ()
        {
            nombre = nombreUsuario,
            cantidadIntentos = 0
        };
         
    }

    private string CargarPalabra (int dificultad) {
    List<Palabra> palabrasDificultad = new List<Palabra>();

      foreach (Palabra palabra in listaPalabras)
    {
        if (palabra.dificultad == dificultad)
        {
            palabrasDificultad.Add(palabra);
        }
    }

     Random rnd = new Random();
     int aleatorio = rnd.Next(0, palabrasDificultad.Count);
     return palabrasDificultad[aleatorio].ToString();

    }
}