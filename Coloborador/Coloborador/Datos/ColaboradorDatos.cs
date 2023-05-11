using Coloborador.Models;
using System.Data.SqlClient;
using System.Data;


namespace Coloborador.Datos
{
    public class ColaboradorDatos
    {
        public List<ColaboradorModel> Listar()
        {

            var oLista = new List<ColaboradorModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ColaboradorModel
                        {
                            id= Convert.ToInt32(dr["id"]),
                            nombres = dr["nombres"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            fecha_nacimiento = dr["fecha_nacimiento"].ToString(),
                            estado_civil = dr["estado_civil"].ToString(),
                            grado_academico = dr["grado_academico"].ToString(),
                            direccion = dr["direccion"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }


        public ColaboradorModel Obtener(int id)
        {

            var oColaborador = new ColaboradorModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oColaborador.id = Convert.ToInt32(dr["id"]);
                        oColaborador.nombres = dr["nombres"].ToString();
                        oColaborador.apellidos = dr["apellidos"].ToString();
                        oColaborador.fecha_nacimiento = dr["fecha_nacimiento"].ToString();
                        oColaborador.estado_civil = dr["estado_civil"].ToString();
                        oColaborador.grado_academico = dr["grado_academico"].ToString();
                        oColaborador.direccion = dr["direccion"].ToString();


                    }
                }


            }
            return oColaborador;
        }

        public bool Guardar(ColaboradorModel oColaborador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar", conexion);
                    cmd.Parameters.AddWithValue("nombres", oColaborador.nombres);
                    cmd.Parameters.AddWithValue("apellidos", oColaborador.apellidos);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", oColaborador.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("estado_civil", oColaborador.estado_civil);
                    cmd.Parameters.AddWithValue("grado_academico", oColaborador.grado_academico);
                    cmd.Parameters.AddWithValue("direccion", oColaborador.direccion);                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rpta = false;

            }

            return rpta;
        }


        public bool Editar(ColaboradorModel oColaborador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", conexion);
                    cmd.Parameters.AddWithValue("id", oColaborador.id);
                    cmd.Parameters.AddWithValue("nombres", oColaborador.nombres);
                    cmd.Parameters.AddWithValue("apellidos", oColaborador.apellidos);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", oColaborador.fecha_nacimiento);
                    cmd.Parameters.AddWithValue("estado_civil", oColaborador.estado_civil);
                    cmd.Parameters.AddWithValue("grado_academico", oColaborador.grado_academico);
                    cmd.Parameters.AddWithValue("direccion", oColaborador.direccion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rpta = false;

            }

            return rpta;
        }

        public bool Eliminar(int idcolaborador)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", idcolaborador);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                rpta = true;


            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rpta = false;

            }

            return rpta;
        }








    }
}
