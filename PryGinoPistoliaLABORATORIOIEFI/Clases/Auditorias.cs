using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryGinoPistoliaLABORATORIOIEFI.Clases
{
    public class Auditorias
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Tarea { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Completada { get; set; }

        public Auditorias(string Id, string Nombre, string Puesto, string Tarea, string Estado, DateTime FechaVencimiento)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Puesto = Puesto;
            this.Tarea = Tarea;
            this.Estado = Estado;
            this.FechaVencimiento = FechaVencimiento;
            this.Completada = false;

        }
    }
}
