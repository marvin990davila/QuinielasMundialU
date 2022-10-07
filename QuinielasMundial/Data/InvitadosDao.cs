using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class InvitadosDao
    {

        public static bool Registrar(Invitados invitados)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarInvitados", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAdministrador", invitados.idAdministrador);
                cmd.Parameters.AddWithValue("@idPersona", invitados.idPersona);



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

        public static bool Registrar(Invitados invitados)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarInvitados", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idInvitados", invitados.idInvitados);
                cmd.Parameters.AddWithValue("@idAdministrador", invitados.idAdministrador);
                cmd.Parameters.AddWithValue("@idPersona", invitados.idPersona);


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


        public static List<Invitados> Listar()
        {
            List<Invitados> oListaInvitados = new List<Invitados>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarInvitados", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaInvitados.Add(new Invitados()
                            {
                                idInvitados = Convert.ToInt32(dr["idInvitados"]),
                                idAdministrador = Convert.ToInt32(dr["idAdministrador"]),
                                idPersona = Convert.ToInt32(dr["idPersona"])

                            });
                        }

                    }



                    return oListaInvitados;
                }
                catch (Exception ex)
                {
                    return oListaInvitados;
                }
            }
        }





        public static Invitados Obtener(int idIinv)
        {
            Invitados Iinvitados = new Invitados();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerInvitados", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idIinv", idIinv);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Iinvitados = new Invitados()
                            {
                                idInvitados = Convert.ToInt32(dr["idInvitados"]),
                                idAdministrador = Convert.ToInt32(dr["idAdministrador"]),
                                idPersona = Convert.ToInt32(dr["idPersona"])
                            };
                        }

                    }



                    return Iinvitados;
                }
                catch (Exception ex)
                {
                    return Iinvitados;
                }
            }
        }


        public static bool Eliminar(int idI)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarInvitados", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idInvitados", idI);

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