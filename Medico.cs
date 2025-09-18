using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica
{
    public class Medico : EmpleadoSanidad
    {

        public enum Especialidad { GUARDIAMEDICA,TRAUMATOLOGIA, CIRUGIA,PEDIATRIA}
        public Especialidad especialidad { get;}
        public enum RolServicio { JEFEDESERVICIO,MEDICOTITULAR, MEDICOASOCIADO,RESIDENTE}
        
        public bool Servicio { get; }
        public RolServicio rolservicio { get; }

        public Medico (uint legajo,string apellido,string nombre,int añodeingreso,string categoriaprofesional, ulong matricula,Especialidad especialidad,bool servicio,RolServicio rolservicio) : base(legajo, apellido, nombre, añodeingreso, categoriaprofesional, matricula)
        {
            this.especialidad = especialidad;
            Servicio = servicio;
            this.rolservicio = rolservicio;
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

            if (Servicio)
            {

                switch (rolservicio)
                {

                    case RolServicio.JEFEDESERVICIO:
                        return Sindicato.BonoProfesionalMedico * 1.50m;

                    case RolServicio.MEDICOTITULAR:
                        return Sindicato.BonoProfesionalMedico * 1.00m;

                    case RolServicio.MEDICOASOCIADO:
                        return Sindicato.BonoProfesionalMedico * 0.80m;

                    case RolServicio.RESIDENTE:
                        return Sindicato.BonoProfesionalMedico * 0.50m;


                    default:
                        return 0;
                    
                }

            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Especialidad : {especialidad} , Rol:{rolservicio}";
        }


    }
}
