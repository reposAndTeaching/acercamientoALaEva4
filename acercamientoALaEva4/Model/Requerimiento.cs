using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEva4.Model
{
    public class Requerimiento
    {
        private int id;
        private string descripcion;
        private int responable;
        private string tipo;
        private string prioridad;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Responable { get => responable; set => responable = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Prioridad { get => prioridad; set => prioridad = value; }

        public Requerimiento(int id, string descripcion, int responable, string tipo, string prioridad)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.responable = responable;
            this.tipo = tipo;
            this.prioridad = prioridad;
        }

        public Requerimiento(string descripcion, int responable, string tipo, string prioridad)
        {
            this.descripcion = descripcion;
            this.responable = responable;
            this.tipo = tipo;
            this.prioridad = prioridad;
        }
    }
}
