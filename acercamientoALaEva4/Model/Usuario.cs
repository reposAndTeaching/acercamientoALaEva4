using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEva4.Model
{
    public class Usuario
    {
        private int id;
        private string rut;
        private string password;
        private string nombre;
        private string apellido;
        private int rol;

        public Usuario(string rut, string password, string nombre, string apellido, int rol)
        {
            this.rut = rut;
            this.password = password;
            this.rol = rol;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Usuario(int id, string rut, string password, string nombre, string apellido, int rol)
        {
            this.id = id;
            this.rut = rut;
            this.password = password;
            this.rol = rol;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Rut { get => rut; set => rut = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }
        public int Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public override string ToString()
        {
            return nombre + " " + apellido;
        }
    }
}
