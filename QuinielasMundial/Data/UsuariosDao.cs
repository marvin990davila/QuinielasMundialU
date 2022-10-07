using QuinielasMundial.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace QuinielasMundial.Data
{
    public class UsuariosDao
    {

        public static bool Registrar(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_registrarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", usuario.contrasena);
                cmd.Parameters.AddWithValue("@idPersona", usuario.idPersona);

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

        public static bool Registrar(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlConnection cmd = new SqlConnection("usp_modificarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
                cmd.Parameters.AddWithValue("@contrasena", usuario.contrasena);
                cmd.Parameters.AddWithValue("@idPersona", usuario.idPersona);

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


                public static List<Usuario> Listar()
                {
                    List<Usuario> oListaUsuario = new List<Usuario>();
                    using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
                    {
                        SqlCommand cmd = new SqlCommand("usp_listarUsuario", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {

                                while (dr.Read())
                                {
                                    oListaUsuario.Add(new Usuario()
                                    {
                                        idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                        nombreUsuario = dr["nombreUsuario"].ToString(),
                                        contrasena = dr["contrasena"].ToString(),
                                        idPersona = Convert.ToInt32(dr["idPersona"])
                                    });
                                }

                            }



                            return oListaUsuario;
                        }
                        catch (Exception ex)
                        {
                            return oListaUsuario;
                        }
                    }
                }




        public static Usuario Obtener(int idusuario)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idusuario);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            usuario = new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                nombreUsuario = dr["nombreUsuario"].ToString(),
                                contrasena = dr["contrasena"].ToString(),
                                idPersona = Convert.ToInt32(dr["idPersona"])
                            };
                        }

                    }



                    return usuario;
                }
                catch (Exception ex)
                {
                    return usuario;
                }
            }
        }


        public static bool Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Coneccion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);

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