using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        List<GenerosDomain> Generos = new List<GenerosDomain>();

        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<GenerosDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select * from Generos";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain()
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = sdr["Descricao"].ToString()
                        };
                        Generos.Add(genero);

                    }
                }
                return Generos;
            }
        }

        public void Cadastrar(GenerosDomain Generos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Insert into Generos (Descricao) values (@Descricao)";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", Generos.Descricao);
                    cmd.ExecuteNonQuery();
                }


            }
        }
    }
}
