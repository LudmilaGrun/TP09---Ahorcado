using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Palabra {
    [JsonProperty]
    public string texto { get; set; }

    [JsonProperty]
    public int dificultad { get; set; }

     public Palabra(string texto, int dificultad)
        {
            this.texto = texto;
            this.dificultad = dificultad;
        }
}