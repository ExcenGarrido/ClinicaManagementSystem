using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica
{
    public abstract class EmpleadoBase
    {

       public uint   Legajo       { get; } 
       public string Apellido     { get; }        
       public string Nombre       { get; } 
       public int    AñoDeIngreso { get; }

       public EmpleadoBase(uint legajo, string apellido, string nombre, int añodeingreso) 
        {

            if (string.IsNullOrWhiteSpace(apellido))
            {

                throw new ArgumentException("El apellido no puede estar vacio");

            }

            if (string.IsNullOrWhiteSpace(nombre))
            {

                throw new ArgumentException("El nombre no puede estar vacio");

            }

            if (añodeingreso < 1900 || añodeingreso > DateTime.Now.Year)
            {
                throw new ArgumentException("El año de ingreso es inválido.");
            }
               

            Legajo       = legajo;
            Apellido     = apellido;
            Nombre       = nombre;
            AñoDeIngreso = añodeingreso;
  
        
        }

       public int CalcularAntiguedad()
        {

            int añoactual = 0;
            añoactual = DateTime.Now.Year;
            return añoactual - AñoDeIngreso;


        }

        public override string ToString()
        {
            return $"Legajo: {Legajo} , Nombre: {Nombre} {Apellido} ,  AñoDeIngreso:{AñoDeIngreso}";
        }

    }
}
