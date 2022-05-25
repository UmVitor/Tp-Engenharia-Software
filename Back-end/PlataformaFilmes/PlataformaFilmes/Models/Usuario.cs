using System.Text.Json.Serialization;

namespace PlataformaFilmes.Models
{
    public class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int avaliacao { get; set; }
        public string nickname { get; set; }
        public string comentario { get; set; }
    }
}
