using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Usuario {
    [JsonProperty]
    public string nombre { get; set; }

    [JsonProperty]
    public int cantidadIntentos { get; set; }

     public Usuario(){


    }   
     public Usuario(string nombre, int cantidadIntentos)
        {
            this.nombre = nombre;
            this.cantidadIntentos = cantidadIntentos;
        }
}