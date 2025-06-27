using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryGinoPistoliaLABORATORIOIEFI.Clases
{
    public class Usuarios
    {
        public string usuarios { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Tarea { get; set; }
        
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        public Usuarios(string usurios, string Id, string Nombre, string Puesto, string Tarea, DateTime FechaVencimiento)
        {
            this.usuarios = usuarios;
            this.Id = Id;
            this.Nombre = Nombre;
            this.Puesto = Puesto;
            this.Tarea = Tarea;
            this.FechaVencimiento = FechaVencimiento;
            this.Completada = false;

        }
    }
}
