using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica
{
    internal class EmpleadoAdministrativo : EmpleadoBase, IHaberMensual
    {

        public EmpleadoAdministrativo ( uint legajo, string apellido,string nombre,int añodeingreso) : base (legajo,apellido,nombre,añodeingreso)
        {
        
        
        }

        public decimal CalcularHaberMensual()
        {
            decimal montoreferencia = Sindicato.MontoDeReferencia;
            int     antiguedad      = CalcularAntiguedad();
            decimal HaberMensual, porcentaje;


            if (antiguedad < 2)
            {

                porcentaje = 0.5m;

            }
            else
            {
                porcentaje = 1 + (antiguedad / 2) * 0.2m;
                if (porcentaje > 2.5m)
                {
                    porcentaje = 2.5m;
                }
            }
            HaberMensual = montoreferencia * porcentaje;
            return HaberMensual;
        }


    }
}
