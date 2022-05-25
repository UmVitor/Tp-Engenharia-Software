using PlataformaFilmes.Models;
using System.Collections.Generic;

namespace PlataformaFilmes.Repositories
{
    public interface IFilmeRepository
    {
        List<Filme> ObterTodosFilmes();
        Filme ObtemFilmeId(int id);
        void IncluiFilme(IncluirFilmeModel filme);
        void IncluirAvaliacao(IncluirAvaliacaoModel avaliacao);
        List<Filme> ObtemPeloNome(string nome);
    }
}
