using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorClinica
{
    public abstract class EmpleadoSanidad : EmpleadoBase
    {
        public string CategoriaProfesional { get;}
        public ulong  Matricula            { get; }

        public EmpleadoSanidad (uint legajo, string apellido ,string nombre , int añodeingreso, string categoriaprofesional, ulong matricula)  :base  ( legajo, apellido, nombre, añodeingreso) 
        {
        
                CategoriaProfesional = categoriaprofesional;
                Matricula            = matricula;
        
        }

        public abstract decimal CalculoBonoProfesional();

        public override string ToString()
        {
            return base.ToString() + $"Categoria ProFesional:{CategoriaProfesional}, Matricula:{Matricula}";
        }

    }
}
