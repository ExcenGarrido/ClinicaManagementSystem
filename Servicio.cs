using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica
{
    internal class Servicio
    {
        public string Codigo { get; }
        public string NombreServicio { get; }
        public Medico JefeServicio { get; set; }

        public List <EmpleadoBase> EmpleadosAsignados { get; }

       public  Servicio( string codigo, string nombreservicio, Medico jefeservicio)
        {

            Codigo = codigo;
            NombreServicio = nombreservicio;
            JefeServicio = jefeservicio;
            EmpleadosAsignados = new List<EmpleadoBase>(); 

        }

        public void AsignarEmpleado(EmpleadoBase empleado)
        {
            if (EmpleadosAsignados.Contains(empleado))
            {
                throw new InvalidOperationException("Este médico o enfermero ya está asignado a un servicio.");
            }

            EmpleadosAsignados.Add(empleado);
        }

        

    }
}
