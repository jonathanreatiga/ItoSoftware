using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Entitles.Models
{
    public class Dependencia
    {
        public int IdDependencia { get; set; }

        public string Nombre { get; set; }

        public string Departamento { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}