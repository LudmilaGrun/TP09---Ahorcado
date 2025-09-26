using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Juego
{
    [JsonProperty]
    private List<Palabra> ListaPalabras { get; set; } = new List<Palabra>();

    [JsonProperty]
    private List<Usuario> Jugadores { get; set; } = new List<Usuario>();

    [JsonProperty]
    private Usuario JugadorActual { get; set; }

    [JsonProperty]
    public string PalabraActual { get; private set; } = "";

    public void LlenarListaPalabras()
    {
        ListaPalabras = new List<Palabra> {
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

    public void InicializarJuego(string nombreUsuario, int dificultad)
    {
        Usuario nuevoUsuario = new Usuario(nombreUsuario, 0);
        JugadorActual = nuevoUsuario;
    }

    public string CargarPalabra(int dificultad)
    {
        List<Palabra> palabrasFiltradas = new List<Palabra>();

        foreach (Palabra palabra in ListaPalabras)
        {
            if (palabra.Dificultad == dificultad)
            {
                palabrasFiltradas.Add(palabra);
            }
        }

        if (palabrasFiltradas.Count == 0)
        {
            return "No hay palabras disponibles para esta dificultad.";
        }

        Random rnd = new Random();
        int indice = rnd.Next(0, palabrasFiltradas.Count);
        return palabrasFiltradas[indice].Texto;
    }
    public void FinJuego(int intentos, string nombre)
    {
        Usuario jugador = new Usuario(nombre, intentos);
        Jugadores.Add(jugador);
    }

    public List<Usuario> DevolverListaUsuarios()
    {
        if (Jugadores == null)
        {
            Jugadores = new List<Usuario>();
            return new List<Usuario>();
        }
        else
        {
            if (Jugadores.Count == 0)
            {
                return new List<Usuario>();
            }
            else
            {
                int CantJugador = Jugadores.Count;
                for (int i = 0; i < CantJugador - 1; i++)
                {
                    for (int j = 0; j < CantJugador - i - 1; j++)
                    {
                        if (Jugadores[j].CantidadIntentos > Jugadores[j + 1].CantidadIntentos)
                        {
                            Usuario AuxJug = Jugadores[j];
                            Jugadores[j] = Jugadores[j + 1];
                            Jugadores[j + 1] = AuxJug;
                        }
                    }
                }
                return Jugadores;
            }
        }
    }
}
