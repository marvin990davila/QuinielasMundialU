using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class EquipoDao
    {

        public static bool Registrar(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreEquipo", equipo.nombreEquipo);



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

        public static bool Registrar(Equipo equipo)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEquipo", equipo.idEquipo);
                cmd.Parameters.AddWithValue("@nombreEquipo", equipo.nombreEquipo);



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


        public static List<Equipo> Listar()
        {
            List<Equipo> oListaEquipo = new List<Equipo>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaEquipo.Add(new Equipo()
                            {
                                idEquipo = Convert.ToInt32(dr["idEquipo"]),
                                nombreEquipo = dr["nombreEquipo"].ToString()

                            });
                        }

                    }



                    return oListaEquipo;
                }
                catch (Exception ex)
                {
                    return oListaEquipo;
                }
            }
        }





        public static Equipo Obtener(int idEequipo)
        {
            Equipo Eequipo = new Equipo();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEequipo", idEequipo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Eequipo = new Equipo()
                            {
                                idEquipo = Convert.ToInt32(dr["idEquipo"]),
                                nombreEquipo = dr["nombreEquipo"].ToString()
                            };
                        }

                    }



                    return Eequipo;
                }
                catch (Exception ex)
                {
                    return Eequipo;
                }
            }
        }


        public static bool Eliminar(int idE)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarEquipo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEquipo", idE);

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