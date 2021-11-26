using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEva4.Model
{
    class Rol
    {
        private int id;
        private string nombre;
        private bool tienePermisosAdmin;

        public Rol(string nombre, bool tienePermisosAdmin)
        {
            this.nombre = nombre;
            this.tienePermisosAdmin = tienePermisosAdmin;
        }

        public Rol(int id, string nombre, bool tienePermisosAdmin)
        {
            this.id = id;
            this.nombre = nombre;
            this.tienePermisosAdmin = tienePermisosAdmin;
        }

        public bool TienePermisosAdmin { get => tienePermisosAdmin; set => tienePermisosAdmin = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
    }
}
