using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivrosRepository
    {

        List<LivrosDomain> Livros = new List<LivrosDomain>();

        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<LivrosDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select * from Livros";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        LivrosDomain livros = new LivrosDomain()
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Titulo = sdr["Nome"].ToString(),


                            Genero = new GenerosDomain()
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Descricao = sdr["Descricao"].ToString()
                            },

                            Autor = new AutoresDomain()
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = sdr["Nome"].ToString(),
                                Email = sdr["Email"].ToString(),
                                Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                Data = Convert.ToDateTime(sdr["DataNascimento"])
                            }
                        };
                        Livros.Add(livros);
                    }
                }
                return Livros;
            }
        }

        public void Cadastrar(LivrosDomain Livros)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Insert into Livros (@Titulo,@IdAutor,@IdGenero)";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", Livros.Titulo);
                    cmd.Parameters.AddWithValue("@IdAutor", Livros.AutoresId);
                    cmd.Parameters.AddWithValue("@IdAutor", Livros.GeneroId);
                    cmd.ExecuteNonQuery();
                }


            }
        }

        public LivrosDomain BuscarPorId(int id)
        {
            string Query = "SELECT * FROM Livros WHERE IdLivros = @Id";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        while (sdr.Read())
                        {
                            LivrosDomain livros = new LivrosDomain()
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Titulo = sdr["Nome"].ToString(),


                                Genero = new GenerosDomain()
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Descricao = sdr["Descricao"].ToString()
                                },

                                Autor = new AutoresDomain()
                                {
                                    IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                    Nome = sdr["Nome"].ToString(),
                                    Email = sdr["Email"].ToString(),
                                    Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                    Data = Convert.ToDateTime(sdr["DataNascimento"])
                                }
                            };
                            return livros;
                        }
                    }
                    return null;

                    // retornar
                }
            }
        }

        public void Atualizar(LivrosDomain livrosDomain)
        {

            string Query = "Update Livros set Titulo = @Titulo, IdGenero = @IdGenero, IdAutor = @IdAutor where idTitulo = @id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", livrosDomain.Titulo);
                cmd.Parameters.AddWithValue("@id", livrosDomain.IdLivro);
                cmd.Parameters.AddWithValue("@idAutor", livrosDomain.GeneroId);
                cmd.Parameters.AddWithValue("@idGenero", livrosDomain.AutoresId);


                con.Open();
                cmd.ExecuteNonQuery();


            }


        }

    }
}
