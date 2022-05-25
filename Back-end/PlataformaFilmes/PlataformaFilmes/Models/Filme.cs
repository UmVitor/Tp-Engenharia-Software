using System.Collections.Generic;

namespace PlataformaFilmes.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Elenco { get; set; }
        public string Sinopse { get; set; }
        public string UrlImagem { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

    }
}
