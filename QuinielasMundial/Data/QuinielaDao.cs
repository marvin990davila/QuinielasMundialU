using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class QuinielaDao
    {

        public static bool Registrar(Quiniela quiniela)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarQuiniela", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@quiniela", quiniela.quiniela);
                cmd.Parameters.AddWithValue("@idLiga", quiniela.idLiga);
                cmd.Parameters.AddWithValue("@idUsuario", quiniela.idUsuario);
                

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }

        public static bool Registrar(Quiniela quiniela)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarQuiniela", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idQui", quiniela.idQui);
                cmd.Parameters.AddWithValue("@quiniela", quiniela.quiniela);
                cmd.Parameters.AddWithValue("@idLiga", quiniela.idLiga);
                cmd.Parameters.AddWithValue("@idUsuario", quiniela.idUsuario);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        public static List<Quiniela> Listar()
        {
            List<Quiniela> oListaQuiniela = new List<Quiniela>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarQuiniela", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaQuiniela.Add(new Quiniela()
                            {
                                idQui = Convert.ToInt32(dr["idQui"]),
                                quiniela = dr["quiniela"].ToString(),
                                idLiga = Convert.ToInt32(dr["idLiga"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                                
                            });
                        }

                    }



                    return oListaQuiniela;
                }
                catch (Exception ex)
                {
                    return oListaQuiniela;
                }
            }
        }





        public static Quiniela Obtener(int idQqui)
        {
            Quiniela Qquiniela = new Quiniela();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerQuiniela", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idQqui", idQqui);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Qquiniela = new Quiniela()
                            {
                                idQui = Convert.ToInt32(dr["idQui"]),
                                quiniela = dr["quiniela"].ToString(),
                                idLiga = Convert.ToInt32(dr["idLiga"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"])
                            };
                        }

                    }



                    return Qquiniela;
                }
                catch (Exception ex)
                {
                    return Qquiniela;
                }
            }
        }


        public static bool Eliminar(int idQ)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarQuiniela", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idQui", idQ);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}