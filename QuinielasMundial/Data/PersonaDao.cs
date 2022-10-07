using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuinielasMundial.Data
{
    public class PersonaDao
    {

        public static bool Registrar(Persona persona)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarPersona",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre1", persona.nombre1);
                cmd.Parameters.AddWithValue("@nombre2", persona.nombre2);
                cmd.Parameters.AddWithValue("@apellido1", persona.apellido1);
                cmd.Parameters.AddWithValue("@apellido2", persona.apellido2);
                cmd.Parameters.AddWithValue("@correo", persona.correo);


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

        public static bool Registrar(Persona persona)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);
                cmd.Parameters.AddWithValue("@nombre1", persona.nombre1);
                cmd.Parameters.AddWithValue("@nombre2", persona.nombre2);
                cmd.Parameters.AddWithValue("@apellido1", persona.apellido1);
                cmd.Parameters.AddWithValue("@apellido2", persona.apellido2);
                cmd.Parameters.AddWithValue("@correo", persona.correo);

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


        public static List<Persona> Listar()
        {
            List<Persona> oListaPersona = new List<Persona>();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaPersona.Add(new Persona()
                            {
                                idPersona = Convert.ToInt32(dr["idPersona"]),
                                nombre1 = dr["nombre1"].ToString(),
                                nombre2 = dr["nombre2"].ToString(),
                                apellido1 = dr["apellido1"].ToString(),
                                apellido2 = dr["apellido2"].ToString(),
                                correo = dr["correo"].ToString()

                            });
                        }

                    }



                    return oListaPersona;
                }
                catch (Exception ex)
                {
                    return oListaPersona;
                }
            }
        }





        public static Persona Obtener(int idPper)
        {
            Persona Ppersona = new Persona();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPper", idPper);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            Ppersona = new Persona()
                            {
                                idPersona = Convert.ToInt32(dr["idPersona"]),
                                nombre1 = dr["nombre1"].ToString(),
                                nombre2 = dr["nombre2"].ToString(),
                                apellido1 = dr["apellido1"].ToString(),
                                apellido2 = dr["apellido2"].ToString(),
                                correo = dr["correo"].ToString()
                            };
                        }

                    }



                    return Ppersona;
                }
                catch (Exception ex)
                {
                    return Ppersona;
                }
            }
        }


        public static bool Eliminar(int idP)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarPersona", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", idP);

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