using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutoresRepository
    {
        List<AutoresDomain> Autores = new List<AutoresDomain>();

        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";

        public List<AutoresDomain> Listar()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select * from Autores";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutoresDomain autor = new AutoresDomain()
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            Data = Convert.ToDateTime(sdr["DataNascimento"])
                        };
                        Autores.Add(autor);

                    }
                }
                return Autores;
            }
        }

        public void Cadastrar(AutoresDomain Autores)
        {   
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "insert into Autores (Nome,Email,Ativo,DataNascimento) values (@Nome,@Email,@Ativo,@Data)";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", Autores.Nome);
                    cmd.Parameters.AddWithValue("@Email", Autores.Email);
                    cmd.Parameters.AddWithValue("@Ativo", Autores.Ativo);
                    cmd.Parameters.AddWithValue("@Data", Autores.Data);
                    cmd.ExecuteNonQuery();
                }


            }
        }
    }
}
