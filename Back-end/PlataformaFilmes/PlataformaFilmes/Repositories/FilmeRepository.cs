using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PlataformaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PlataformaFilmes.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private IDbConnection _connection;

        public FilmeRepository()
        {
            _connection = new MySqlConnection("Server=localhost;Database=tp-engSoftware-database;Uid=root;Pwd=limao;");
        }
        public List<Filme> ObterTodosFilmes()
        {
            string query = "SELECT id_filme as Id, Nome, Genero, Elenco, Sinopse, url_imagem as UrlImagem FROM filme";

            return _connection.Query<Filme>(query).ToList();
        }

        public List<Filme> ObtemPeloNome(string nome)
        {
            string query = "SELECT * FROM filme where nome LIKE '%" + nome + "%';";

            return _connection.Query<Filme>(query).ToList();
        }

        public Filme ObtemFilmeId(int id)
        {
            List<Filme> filmes = new List<Filme>();
            string query = @"SELECT F.id_filme AS Id, Nome, Genero, Elenco, Sinopse, url_imagem as UrlImagem, U.id_usuario AS Id,avaliacao, nickname, comentario 
                            FROM filme F
                            INNER JOIN avaliacao A ON F.id_filme = A.id_filme
                            INNER JOIN usuario U ON U.id_usuario = A.id_usuario
                            WHERE F.id_filme = @id;";

            _connection.Query<Filme, Usuario, Filme>(query,
                (filme, usuario) =>
                {
                    if(filmes.SingleOrDefault(a=> a.Id == filme.Id) == null)
                    {
                        filme.Usuarios = new List<Usuario>();
                        filmes.Add(filme);
                    }
                    else
                    {
                        filme = filmes.SingleOrDefault(a => a.Id == filme.Id);
                    }
                    filme.Usuarios.Add(usuario);
                    return filme;
                }, new { Id = id});
            return filmes.SingleOrDefault();
        }

        public void IncluiFilme(IncluirFilmeModel filme)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                string sql = "INSERT INTO filme (Nome, Genero, Elenco, Sinopse, url_imagem) VALUES (@Nome, @Genero, @Elenco, @Sinopse, @UrlImagem); SELECT LAST_INSERT_ID();";
                filme.Id = _connection.Query<int>(sql, filme, transaction).Single();
                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            finally
            {
                _connection.Close();    
            }
        }

        public void IncluirAvaliacao(IncluirAvaliacaoModel avaliacao)
        {
            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                string sql = "INSERT INTO usuario (avaliacao, nickname, comentario) VALUES (@Avaliacao, @Nickname, @Comentario); SELECT LAST_INSERT_ID();";
                avaliacao.Id = _connection.Query<int>(sql, avaliacao, transaction).Single();
                

                string sqlAvaliacao = "INSERT INTO avaliacao (id_filme, id_usuario) VALUES (@IdFilme, @Id); SELECT LAST_INSERT_ID();";
                var idAvaliacao = _connection.Query<int>(sqlAvaliacao, avaliacao, transaction).Single();

                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
