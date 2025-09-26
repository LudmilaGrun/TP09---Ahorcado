using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;

public class Palabra {
    [JsonProperty]
    public string Texto { get; set; }

    [JsonProperty]
    public int Dificultad { get; set; }

    public Palabra() { 

    }

    public Palabra(string texto, int dificultad)
    {
        Texto = texto;
        Dificultad = dificultad;
    }
}