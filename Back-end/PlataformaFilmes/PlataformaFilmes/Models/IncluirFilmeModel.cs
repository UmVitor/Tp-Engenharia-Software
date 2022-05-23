using System.Text.Json.Serialization;

namespace PlataformaFilmes.Models
{
    public class IncluirFilmeModel
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Elenco { get; set; }
        public string Sinopse { get; set; }
        public string UrlImagem { get; set; }
    }
}
