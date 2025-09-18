using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorClinica
{
    public class Tecnico : EmpleadoSanidad
    {

       public enum Especialidad { EXTRACCIONISTA,RADIOLOGO,KINESIOLOGO};
        public Especialidad especialidad { get; }

        public Tecnico(uint legajo,string apellido,string nombre, int añodeingreso,string categoriaprofesional,ulong matricula, Especialidad especialidad) : base (legajo,apellido,nombre,añodeingreso,categoriaprofesional,matricula)
        {

            this.especialidad = especialidad;
        
        
        }


        public decimal CalcularHaberMensual()
        {
            decimal montoreferencia = Sindicato.MontoDeReferencia;
            int antiguedad = CalcularAntiguedad();
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

        public override decimal CalculoBonoProfesional()
        {
            
            return Sindicato.BonoProfesionalTecnico;

        }

        public override string ToString()
        {
            return base.ToString() + $"Especialidad : {especialidad}";
        }

    }
}
