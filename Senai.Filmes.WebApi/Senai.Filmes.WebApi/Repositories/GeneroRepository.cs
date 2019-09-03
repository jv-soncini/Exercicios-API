using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_RoteiroFilmes;User Id=sa;Pwd=132;";

        List<GeneroDomain> Generos = new List<GeneroDomain>();

        public List<GeneroDomain> Listar()
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
            string Query = "Select * from Generos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        Generos.Add(genero);


                    }
                }
                return Generos;

            }
            
        }

        public void Cadastrar(GeneroDomain generos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "insert into Generos(Nome) values (@Nome)";
                

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generos.Nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId (int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "select * from Generos where IdGenero = @Id";
                SqlDataReader sdr;


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();

                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            GeneroDomain generos = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"])
                                ,
                                Nome = sdr["Nome"].ToString()
                            };
                            return generos;
                        }
                    }
                    return null;
                }
            }
        }

        public void Atualizar(GeneroDomain generoDomain)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "update Generos set Nome = @Nome where IdGenero = @Id";


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                    cmd.Parameters.AddWithValue("@Nome", generoDomain.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar (int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "delete Generos where IdGenero = @Id";
                


                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
