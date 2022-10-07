using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class LigaDao
    {

        public static bool Registrar(Liga liga)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarLiga", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreLiga", liga.nombreLiga);
                cmd.Parameters.AddWithValue("@idEquipo", liga.idEquipo);
                
                

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

        public static bool Registrar(Liga liga)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarLiga", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLiga", liga.idLiga);
                cmd.Parameters.AddWithValue("@nombreLiga", liga.nombreLiga);
                cmd.Parameters.AddWithValue("@idEquipo", liga.idEquipo);


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


        public static List<Liga> Listar()
        {
            List<Liga> oListaLiga = new List<Liga>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarLiga", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaLiga.Add(new Liga()
                            {
                                idLiga = Convert.ToInt32(dr["idLiga"]),
                                nombreLiga = dr["nombreLiga"].ToString(),
                                idEquipo = Convert.ToInt32(dr["idEquipo"])

                            });
                        }

                    }



                    return oListaLiga;
                }
                catch (Exception ex)
                {
                    return oListaLiga;
                }
            }
        }





        public static Liga Obtener(int idLliga)
        {
            Liga Lliga = new Liga();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerLiga", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLliga", idLliga);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Lliga = new Liga()
                            {
                                idLiga = Convert.ToInt32(dr["idLiga"]),
                                nombreLiga = dr["nombreLiga"].ToString(),
                                idEquipo = Convert.ToInt32(dr["idEquipo"])
                            };
                        }

                    }



                    return Lliga;
                }
                catch (Exception ex)
                {
                    return Lliga;
                }
            }
        }


        public static bool Eliminar(int idL)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarLiga", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLiga", idL);

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