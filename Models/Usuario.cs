using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Usuario {
    [JsonProperty]
    public string Nombre { get; set; }

    [JsonProperty]
    public int CantidadIntentos { get; set; }
    public Usuario(){


    }   
     public Usuario(string nombre, int cantidadIntentos = 0)
        {
            Nombre = nombre;
            CantidadIntentos = cantidadIntentos;
        }
}