using acercamientoALaEva4.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;//<-- SQL
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codigoBD.modelBD
{
    public class Data
    {
        private Conexion con;
        private SqlConnection sqlcon;
        private SqlCommand sqlcmd;
        private SqlDataReader response;

        private string consulta;

        public Data(string servidor, string bd, string user, string pass)
        {
            con = new Conexion(servidor, bd, user, pass);
        }

        //Traerá todos los usuarios de la tabla "usuario"
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            Usuario u = null;
            consulta = "select * from usuarios;";

            using(sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                //Toda la lógica de la consulta
                using(sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    while (response.Read())
                    {
                        int id = response.GetInt32(0);
                        string usuario = response.GetString(1);
                        string passs = response.GetString(2);
                        string nombre = response.GetString(3);
                        string apellido = response.GetString(4);
                        int rol = response.GetInt32(5);

                        u = new Usuario(id, usuario, passs, nombre, apellido, rol);
                        listaUsuario.Add(u);
                    }

                }
            }//Cerrará la conexión automáticamente // implícitamente hay un sqlcon.Close();
            return listaUsuario;
        }

        public Usuario GetUsuario(int id)
        {
            Usuario u = null;
            consulta = $"select * from usuario where id = {id};";
            using(sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    if (response.Read()) //pero el while va a funcionar igual
                    {
                        int _id = response.GetInt32(0);
                        string usuario = response.GetString(1);
                        string passs = response.GetString(2);
                        string nombre = response.GetString(3);
                        string apellido = response.GetString(4);
                        int rol = response.GetInt32(5);

                        u = new Usuario(_id, usuario, passs, nombre, apellido, rol);
                    }
                }
            }

            return u;
        }

        public Usuario Autentificacion(string rut, string pass)
        {
            Usuario u = null;
            consulta = "select * from usuarios where rut = '"+rut+"' and pass = '"+pass+"';";

            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    if (response.Read())
                    {
                        int id = response.GetInt32(0);
                        string usuario = response.GetString(1);
                        string passs = response.GetString(2);
                        string nombre = response.GetString(3);
                        string apellido = response.GetString(4);
                        int rol = response.GetInt32(5);

                        u = new Usuario(id, usuario, passs, nombre, apellido, rol);
                    }
                }
            }//sqlcon.Close();

            return u;
        }


        public List<Requerimiento> GetRequerimientos()
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();
            Requerimiento r = null;
            consulta = "select * from requerimientos;";

            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                //Toda la lógica de la consulta
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    while (response.Read())
                    {
                        int id = response.GetInt32(0);
                        string descripcion = response.GetString(1);
                        int responsable = response.GetInt32(2);
                        string tipo = response.GetString(3);
                        string prioridad = response.GetString(4);
                       

                        r = new Requerimiento(id, descripcion, responsable, tipo, prioridad);
                        listaRequerimientos.Add(r);
                    }

                }
            }//Cerrará la conexión automáticamente // implícitamente hay un sqlcon.Close();
            return listaRequerimientos;
        }

        public List<Requerimiento> GetRequerimientosByResponsable(int idResponsable)
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();
            Requerimiento r = null;
            consulta = "select * from requerimientos where responsable = "+idResponsable+";";

            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                //Toda la lógica de la consulta
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    while (response.Read())
                    {
                        int id = response.GetInt32(0);
                        string descripcion = response.GetString(1);
                        int responsable = response.GetInt32(2);
                        string tipo = response.GetString(3);
                        string prioridad = response.GetString(4);


                        r = new Requerimiento(id, descripcion, responsable, tipo, prioridad);
                        listaRequerimientos.Add(r);
                    }

                }
            }//Cerrará la conexión automáticamente // implícitamente hay un sqlcon.Close();
            return listaRequerimientos;
        }

        public Requerimiento GetRequerimiento(int id)
        {
            Requerimiento r = null;
            consulta = "select * from requerimientos where id = " + id + ";";

            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                //Toda la lógica de la consulta
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    response = sqlcmd.ExecuteReader();

                    if (response.Read())
                    {
                        int _id = response.GetInt32(0);
                        string descripcion = response.GetString(1);
                        int responsable = response.GetInt32(2);
                        string tipo = response.GetString(3);
                        string prioridad = response.GetString(4);


                        r = new Requerimiento(_id, descripcion, responsable, tipo, prioridad);
                    }

                }
            }//Cerrará la conexión automáticamente // implícitamente hay un sqlcon.Close();
            return r;
        }

        public int RegistrarRequerimiento(Requerimiento r)
        {
            int filasAfectadas;
            consulta = $"insert into requerimientos values('{r.Descripcion}', {r.Responable}, '{r.Tipo}', '{r.Prioridad}');";
            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    filasAfectadas = sqlcmd.ExecuteNonQuery();
                }
            }
            return filasAfectadas;
        }


        /*
        public int AddUsuario(Usuario u)
        {
            int filasAfectadas;
            consulta = $"insert into usuario values('{u.Nombre}', '{u.Contrasenia}', {u.EsMayorDeEdad});";
            using (sqlcon = new SqlConnection(con.Csb.ConnectionString))
            {
                sqlcon.Open();
                using (sqlcmd = new SqlCommand(consulta, sqlcon))
                {
                    filasAfectadas = sqlcmd.ExecuteNonQuery();
                }
            }
            return filasAfectadas;
        }
        */
    }
}
