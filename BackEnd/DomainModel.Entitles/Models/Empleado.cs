using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel.Entitles.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string NumeroDocumento { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int IdDependencia { get; set; }
        public Dependencia Dependencia { get; set; }
    }
}