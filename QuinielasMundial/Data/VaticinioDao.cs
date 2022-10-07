using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class VaticinioDao
    {

        public static bool Registrar(Vaticinio vaticinio)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarVaticinio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", vaticinio.idPersona);
                cmd.Parameters.AddWithValue("@idQui", vaticinio.idQui);
                cmd.Parameters.AddWithValue("@idEquipo1", vaticinio.idEquipo1);
                cmd.Parameters.AddWithValue("@idEquipo2", vaticinio.idEquipo2);
                cmd.Parameters.AddWithValue("@resultado1", vaticinio.resultado1);
                cmd.Parameters.AddWithValue("@resultado2", vaticinio.resultado2);

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

        public static bool Registrar(Vaticinio vaticinio)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarVaticinio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVaticinio", vaticinio.idVaticinio);
                cmd.Parameters.AddWithValue("@idPersona", vaticinio.idPersona);
                cmd.Parameters.AddWithValue("@idQui", vaticinio.idQui);
                cmd.Parameters.AddWithValue("@idEquipo1", vaticinio.idEquipo1);
                cmd.Parameters.AddWithValue("@idEquipo2", vaticinio.idEquipo2);
                cmd.Parameters.AddWithValue("@resultado1", vaticinio.resultado1);
                cmd.Parameters.AddWithValue("@resultado2", vaticinio.resultado2);

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


        public static List<Vaticinio> Listar()
        {
            List<Vaticinio> oListaVaticinio = new List<Vaticinio>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarVaticinio", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaVaticinio.Add(new Vaticinio()
                            {
                                idVaticinio = Convert.ToInt32(dr["idVaticinio"]),
                                idPersona = Convert.ToInt32(dr["idPersona"]),
                                idQui = Convert.ToInt32(dr["idQui"]),
                                idEquipo1 = Convert.ToInt32(dr["idEquipo1"]),
                                idEquipo2 = Convert.ToInt32(dr["idEquipo2"]),
                                resultado1 = Convert.ToInt32(dr["resultado1"]),
                                resultado2 = Convert.ToInt32(dr["resultado2"]),
                                fechaVaticinio = Convert.ToDateTime(dr["fechaVaticinio"].ToString())
                            });
                        }

                    }



                    return oListaVaticinio;
                }
                catch (Exception ex)
                {
                    return oListaVaticinio;
                }
            }
        }





        public static Vaticinio Obtener(int idvati)
        {
            Vaticinio Vvaticinio = new Vaticinio();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerVaticinio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idvati", idvati);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Vvaticinio = new Vaticinio()
                            {
                                idVaticinio = Convert.ToInt32(dr["idVaticinio"]),
                                idPersona = Convert.ToInt32(dr["idPersona"]),
                                idQui = Convert.ToInt32(dr["idQui"]),
                                idEquipo1 = Convert.ToInt32(dr["idEquipo1"]),
                                idEquipo2 = Convert.ToInt32(dr["idEquipo2"]),
                                resultado1 = Convert.ToInt32(dr["resultado1"]),
                                resultado2 = Convert.ToInt32(dr["resultado2"]),
                                fechaVaticinio = Convert.ToDateTime(dr["fechaVaticinio"].ToString())
                            };
                        }

                    }



                    return Vvaticinio;
                }
                catch (Exception ex)
                {
                    return Vvaticinio;
                }
            }
        }


        public static bool Eliminar(int idV)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarVaticinio", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVaticinio", idV);

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