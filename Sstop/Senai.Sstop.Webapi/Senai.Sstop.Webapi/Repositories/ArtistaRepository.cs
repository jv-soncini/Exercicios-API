using Senai.Sstop.Webapi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.Webapi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Sstop;User Id=sa;Pwd=132;";

        public List<ArtistaDomain> Listar()
        {

            List<ArtistaDomain> Artistas = new List<ArtistaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "SELECT A.IdArtista, A.Nome, E.IdEstilo, E.Nome AS NomeEstilo FROM Artistas AS A INNER JOIN Estilos AS E ON A.IdEstilo = E.IdEstilo;";
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain()
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtista"])
                            , Nome = sdr["Nome"].ToString()
                            , Estilo = new EstiloDomain()
                             {
                                 IdEstilo = Convert.ToInt32(sdr["IdEstilo"])
                                , Nome = sdr["NomeEstilo"].ToString()
                             }
                        };
                        Artistas.Add(artista);

                    };
                }
            return Artistas;
            }


        }
            public void Cadastrar(ArtistaDomain artistaDomain)
            {
                using (SqlConnection con = new SqlConnection(StringConexao))
                {
                    con.Open();
                    string Query = "INSERT INTO Artistas (Nome, IdArtista) VALUES (@Nome, @IdEstilo);";

                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        SqlDataReader sdr;
                        cmd.Parameters.AddWithValue("@Nome", artistaDomain.Nome);
                        cmd.Parameters.AddWithValue("@IdEstilo", artistaDomain.EstiloId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
    }
}
