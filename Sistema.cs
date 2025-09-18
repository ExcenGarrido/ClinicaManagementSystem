using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestorClinica
{
    public static class Sistema
    {

        public static void MenuInteractivo()
        {

            while (true)
            {
                
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("1. Configurar Montos Sindicales");
                Console.WriteLine("2. Registrar Empleado");
                Console.WriteLine("3. Listar Empleados");
                Console.WriteLine("4. Registrar Servicio");
                Console.WriteLine("5. Asignar Empleado a Servicio");
                Console.WriteLine("6. Reemplazar Jefe de Servicio");
                Console.WriteLine("7. Listar Empleados por Servicio");
                Console.WriteLine("8. Consultar Datos de Empleado");
                Console.WriteLine("9. Eliminar Empleado");
                Console.WriteLine("10. Resumen de Servicios");
                Console.WriteLine("11. Salir");

                Console.WriteLine("Ingrese una opcion:");
                int opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {

                    case 1:
                        ConfigurarMontosSindicales();
                        break;

                    case 2:
                        RegistrarEmpleado();
                        break;

                    case 3:
                        ListarEmpleados();
                        break;

                    case 4:
                        RegistrarServicio();
                        break;

                    case 5:
                        AsignarEmpleadoAServicio();
                        break;

                    case 6:
                        ReemplazarJefeDeServicio();
                        break;

                    case 7:
                        ListarEmpleadosPorServicio();
                        break;

                    case 8:
                        ConsultarDatosDeEmpleado();
                        break;

                    case 9:
                        EliminarEmpleado();
                        break;

                    case 10:
                        ResumenDeServicio();
                        break;

                    case 11:
                        Console.WriteLine("¡Gracias, Hasta luego!");
                        return;

                    default:
                        Console.WriteLine("No se ingreso una opcion correcta, intenta de nuevo:");
                        break;
                }

            }
        }


        public static void ConfigurarMontosSindicales()
        {
            int opcion;
            Console.WriteLine("Ingrese 1 para establecer los montos sindicales " +
                "o bonos profesionales:");
            Console.WriteLine("Ingrese 2 para ver el monto de referencia y los bonos profesionales:");

            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                Console.WriteLine("Ingrese una de las opciones:");
                Console.WriteLine("1. Establecer monto de referencia");
                Console.WriteLine("2. Establecer el Bono profesional para Tecnico");
                Console.WriteLine("3. Establecer el Bono profesional para Enfermero");
                Console.WriteLine("4. Establecer el Bono profesional para Medico");
                int resultado;
                resultado = int.Parse(Console.ReadLine());

                switch (resultado)
                {

                    case 1:
                        Console.WriteLine("Ingres el nuevo monto de referencia:");
                        decimal nuevoMontoReferencia = decimal.Parse(Console.ReadLine());
                        Sindicato.MontoDeReferencia = nuevoMontoReferencia;
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el nuevo monto profesional para tecnico:");
                        decimal nuevoMontoBonoTecnico = decimal.Parse(Console.ReadLine());
                        Sindicato.BonoProfesionalTecnico = nuevoMontoBonoTecnico;
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el nuevo monto profesional para enfermero:");
                        decimal nuevoMontoBonoEnfermero = decimal.Parse(Console.ReadLine());
                        Sindicato.BonoProfesionalEnfermero = nuevoMontoBonoEnfermero;
                        break;

                    case 4:
                        Console.WriteLine("Ingrese el nuevo monto profesional para Medico:");
                        decimal nuevoMontoBonoMedico = decimal.Parse(Console.ReadLine());
                        Sindicato.BonoProfesionalMedico = nuevoMontoBonoMedico;
                        break;

                }


            }
            else if (opcion == 2)
            {

                Console.WriteLine("Informe monto referencia y bonos profesionales.");

                Console.WriteLine($"El monto de referencia dado por el sindicato es:{Sindicato.MontoDeReferencia}");
                Console.WriteLine($"El bono profesional que recibe un tecnico es:{Sindicato.BonoProfesionalTecnico}");
                Console.WriteLine($"El bono profesional que recibe un enfermero es:{Sindicato.BonoProfesionalEnfermero}");
                Console.WriteLine($"El bono profesional que recibe un medico es:{Sindicato.BonoProfesionalMedico}");


            }
            else
            {
                Console.WriteLine("No se ingreso una opcion correcta.");

            }


        }

        public static void RegistrarEmpleado()
        {

            Console.WriteLine("Bienvenido esta a punto de registrar un empleado");

            Console.WriteLine("Ingrese el legajo del empleado:");
            uint legajo = uint.Parse(Console.ReadLine());

            bool legajoExiste = false;

            foreach (var empleado in empleados)
            {
                if (empleado.Legajo == legajo)
                {
                    legajoExiste = true;
                    break;
                }
            }

            if (legajoExiste)
            {
                Console.WriteLine("Error: El legajo ingresado ya existe. Intente con un legajo diferente.");
                return;
            }


            Console.WriteLine("Ingrese el apellido del empleado:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el año de ingreso");
            int añodeingreso = int.Parse(Console.ReadLine());

            Console.WriteLine("Indique apoyo si es un empleado de apoyo o indique sanidad si es un empleado de sanidad:");
            string TipoEmpleado = Console.ReadLine().ToLower();

            if (TipoEmpleado == "apoyo")
            {

                EmpleadoAdministrativo empleadoAdministrativo = new EmpleadoAdministrativo(legajo, apellido, nombre, añodeingreso);
                empleados.Add(empleadoAdministrativo);
            }
            else if (TipoEmpleado == "sanidad")
            {

                Console.WriteLine("Ingrese la categoria profesional (medico, enfermero, tecnico):");
                string categoriaprofesional = Console.ReadLine().ToLower();
                Console.WriteLine("Ingrese la matricula:");
                uint matricula = uint.Parse(Console.ReadLine());

                if (categoriaprofesional == "enfermero" || categoriaprofesional == "tecnico")
                {

                    if (categoriaprofesional == "enfermero")
                    {

                        Console.WriteLine("Ingrese la especialidad del enfermero:");
                        Console.WriteLine("- ENFERMERIAGENERAL");
                        Console.WriteLine("- PEDIATRICA");
                        Console.WriteLine("- TERAPISTAINTENSICO");

                        string especialidadenfermero = Console.ReadLine().ToUpper();

                        Enfermero.Especialidad especialidadenum;

                        if (especialidadenfermero == "ENFERMERIAGENERAL")
                        {
                            especialidadenum = Enfermero.Especialidad.ENFERMERIAGENERAL;
                        }
                        else if (especialidadenfermero == "PEDIATRICA")
                        {
                            especialidadenum = Enfermero.Especialidad.PEDIATRICA;
                        }
                        else if (especialidadenfermero == "TERAPISTAINTENSICO")
                        {
                            especialidadenum = Enfermero.Especialidad.TERAPISTAINTENSICO;
                        }
                        else
                        {
                            Console.WriteLine("No se ingreso una especialidad valida");
                            return;
                        }

                        Enfermero enfermero = new Enfermero(legajo, apellido, nombre, añodeingreso, categoriaprofesional, matricula, especialidadenum);
                        empleados.Add(enfermero);
                        Console.WriteLine("Enfermero registrado exitosamente.");
                    }

                }
                else if (categoriaprofesional == "tecnico")
                {

                    Console.WriteLine("Ingrese la especialidad del tecnico:");
                    Console.WriteLine("- EXTRACCIONISTA");
                    Console.WriteLine("- RADIOLOGO");
                    Console.WriteLine("- KINESIOLOGO");

                    string especialidadtecnico = Console.ReadLine().ToUpper();
                    Tecnico.Especialidad especialidadenumtecnico;

                    if (especialidadtecnico == "EXTRACCIONISTA")
                    {
                        especialidadenumtecnico = Tecnico.Especialidad.EXTRACCIONISTA;

                    }

                    else if (especialidadtecnico == "RADIOLOGO")
                    {
                        especialidadenumtecnico = Tecnico.Especialidad.RADIOLOGO;

                    }
                    else if (especialidadtecnico == "KINESIOLOGO")
                    {
                        especialidadenumtecnico = Tecnico.Especialidad.KINESIOLOGO;
                    }
                    else
                    {
                        Console.WriteLine("No se ingreso una especialidad valida");
                        return;

                    }

                    Tecnico tecnico = new Tecnico(legajo, apellido, nombre, añodeingreso, categoriaprofesional, matricula, especialidadenumtecnico);
                    empleados.Add(tecnico);
                }

                if (categoriaprofesional == "medico")
                {
                    Console.WriteLine("Ingrese la especialidad del medico:");
                    Console.WriteLine("- GUARDIAMEDICA ");
                    Console.WriteLine("- TRAUMATOLOGIA");
                    Console.WriteLine("- CIRUGIA");
                    Console.WriteLine("- PEDIATRIA");

                    string especialidadmedico = Console.ReadLine().ToUpper();
                    Medico.Especialidad especialidadenummedico;

                    if (especialidadmedico == "GUARDIAMEDICA")
                    {
                        especialidadenummedico = Medico.Especialidad.GUARDIAMEDICA;
                    }
                    else if (especialidadmedico == "TRAUMATOLOGIA")
                    {
                        especialidadenummedico = Medico.Especialidad.TRAUMATOLOGIA;
                    }
                    else if (especialidadmedico == "CIRUGIA")
                    {
                        especialidadenummedico = Medico.Especialidad.CIRUGIA;
                    }
                    else if (especialidadmedico == "PEDIATRIA")
                    {
                        especialidadenummedico = Medico.Especialidad.PEDIATRIA;
                    }
                    else
                    {
                        Console.WriteLine("No se ingreso una especialidad valida");
                        return;
                    }

                    Console.WriteLine("Ingrese true si pertenece a un servicio o false en el caso que no:");
                    bool servicio = bool.Parse(Console.ReadLine());

                    if (servicio == true)
                    {

                        Console.WriteLine("Ingrese el servicio del medico:");
                        Console.WriteLine("- JEFEDESERVICIO ");
                        Console.WriteLine("- MEDICOTITULAR");
                        Console.WriteLine("- MEDICOASOCIADO");
                        Console.WriteLine("- RESIDENTE");

                        string serviciomedico = Console.ReadLine().ToUpper();
                        Medico.RolServicio rolServicioenum;

                        if (serviciomedico == "JEFEDESERVICIO")
                        {

                            rolServicioenum = Medico.RolServicio.JEFEDESERVICIO;

                        }
                        else if (serviciomedico == "MEDICOTITULAR")
                        {

                            rolServicioenum = Medico.RolServicio.MEDICOTITULAR;

                        }
                        else if (serviciomedico == "MEDICOASOCIADO")
                        {

                            rolServicioenum = Medico.RolServicio.RESIDENTE;
                        }
                        else if (serviciomedico == "RESIDENTE")
                        {

                            rolServicioenum = Medico.RolServicio.RESIDENTE;

                        }
                        else
                        {

                            Console.WriteLine("No se ingreso una especialidad valida");
                            return;

                        }
                        Medico mediconuevo = new Medico(legajo, apellido, nombre, añodeingreso, categoriaprofesional, matricula, especialidadenummedico, servicio, rolServicioenum);
                        empleados.Add(mediconuevo);
                    }

                    Medico medico = new Medico(legajo, apellido, nombre, añodeingreso, categoriaprofesional, matricula, especialidadenummedico, false, Medico.RolServicio.RESIDENTE);
                    empleados.Add(medico);
                }

            }
        }

        private static List<EmpleadoBase> empleados = new List<EmpleadoBase>();
        public static void ListarEmpleados()
        {
            Console.WriteLine("Lista de empleados:");
            foreach (var empleado in empleados)
            {

                Console.WriteLine(empleado);

            }

        }

        private static List<Servicio> servicios = new List<Servicio>();
        public static void RegistrarServicio()
        {

            Console.WriteLine("Ingrese el codigo del servicio:");
            string codigo = Console.ReadLine();

            bool codigoExiste = false;
            foreach (var servicio in servicios)
            {
                if (servicio.Codigo == codigo)
                {
                    codigoExiste = true;
                    break;  // Detenemos la búsqueda al encontrar una coincidencia
                }
            }

            if (codigoExiste)
            {
                Console.WriteLine("Error: El código del servicio ya existe.");
                return;
            }


            Console.WriteLine("Ingrese el nombre del servicio:");
            string nombreservicio = Console.ReadLine();

            Console.WriteLine("Ingrese el legajo del jefe de servicio:");
            uint legajo = uint.Parse(Console.ReadLine());

            bool medicoencontrado = false;
            Medico jefeMedico = null;
            foreach (var empleado in empleados)
            {

                if (empleado.Legajo == legajo && empleado is Medico)
                {
                    medicoencontrado = true;
                    jefeMedico = (Medico)empleado;
                }

            }
            if (!medicoencontrado)
            {

                Console.WriteLine("No se encontro un medico con ese legajo.");
                return;
            }

            bool yaEsJefe = false;

            foreach (Servicio servicio in servicios)
            {

                if (servicio.JefeServicio == jefeMedico)
                {
                    yaEsJefe = true;
                }

            }

            if (yaEsJefe)
            {

                Console.WriteLine("Error: Este médico ya es jefe de otro servicio.");
                return;
            }


            Servicio nuevoServicio = new Servicio(codigo, nombreservicio, jefeMedico);
            servicios.Add(nuevoServicio);
            Console.WriteLine("Servicio registrado exitosamente.");


        }


        public static void AsignarEmpleadoAServicio()
        {
            EmpleadoBase empleadoservicio = null;
            Console.WriteLine("Ingrese el legajo del empleado a asignar:");
            uint legajo = uint.Parse(Console.ReadLine());

            foreach (var empleado in empleados)
            {
                if (empleado.Legajo == legajo)
                {
                    empleadoservicio = empleado;
                    break;
                }

            }

            if (empleadoservicio == null)
            {
                Console.WriteLine("Error: No se encontró un empleado con ese legajo.");
                return;
            }

            Console.WriteLine("Ingrese el codigo de servicio:");
            string Codigoservicio = Console.ReadLine();
            Servicio servicioencontrado = null;

            foreach (var servicio in servicios)
            {
                if (servicio.Codigo == Codigoservicio)
                {
                    servicioencontrado = servicio;
                    break;
                }

            }

            if (servicioencontrado == null)
            {
                Console.WriteLine("No se encontro un servicio con dicho codigo.");
                return;
            }

            if (empleadoservicio is Medico || empleadoservicio is Enfermero)
            {
                foreach (var servicio in servicios)
                {
                    if (servicio.EmpleadosAsignados.Contains(empleadoservicio) || servicio.JefeServicio == empleadoservicio)
                    {
                        Console.WriteLine("Error: Un médico o enfermero no puede desempeñarse en más de un servicio.");
                        return;
                    }
                }
            }

            servicioencontrado.AsignarEmpleado(empleadoservicio);

        }

        public static void ReemplazarJefeDeServicio()
        {

            Console.WriteLine("Ingrese el legajo del nuevo jefe de servicio:");
            uint legajo = uint.Parse(Console.ReadLine());
            bool medicoregistrado = false;
            Medico NuevoJefeServicio = null;
            foreach (var empleado in empleados)
            {

                if (empleado.Legajo == legajo && empleado is Medico)
                {
                    medicoregistrado = true;
                    NuevoJefeServicio = (Medico)empleado;
                    break;
                }
            }
            if (!medicoregistrado)
            {
                Console.WriteLine("El legajo ingresado no corresponde a ningun medico registrado");
                return;
            }

            Console.WriteLine("Ingrese el codigo del servicio al que se le reemplazara el jefe de servicio:");
            string codigoservicio = Console.ReadLine();
            bool codigoservicioabuscar = false;

            foreach (var servicio in servicios)
            {

                if (servicio.Codigo == codigoservicio)
                {
                    codigoservicioabuscar = true;

                }
            }

            if (!codigoservicioabuscar)
            {
                Console.WriteLine("El codigo ingresado no pertenece a ningun servicio");
                return;
            }

            bool YaEsJefeDeServicio = false;
            foreach (var jefeservicio in servicios)
            {
                if (jefeservicio.JefeServicio == NuevoJefeServicio)
                {
                    YaEsJefeDeServicio = true;
                }
            }
            if (YaEsJefeDeServicio)
            {
                Console.WriteLine("El medico no se puede asignar a un nuevo servicio porque ya es jefe de otro servicio.");
                return;
            }
            else
            {
                foreach (var servicio in servicios)
                {
                    if (codigoservicio == servicio.Codigo)
                    {
                        servicio.JefeServicio = NuevoJefeServicio;
                    }
                }

            }


        }

        public static void ListarEmpleadosPorServicio()
        {

            Console.WriteLine("Ingrese el codigo de servicio:");
            string codigo = Console.ReadLine();
            Medico medicolistar = null;
            bool codigoingresado = false;
            foreach (var servicio in servicios)
            {

                if (servicio.Codigo == codigo)
                {
                    codigoingresado = true;
                    Console.WriteLine($"Nombre:{servicio.NombreServicio},Codigo:{servicio.Codigo}");

                    foreach (var empleado in servicio.EmpleadosAsignados)
                    {
                        Console.WriteLine($"Nombre Empleado:{empleado.Nombre}{empleado.Apellido}, Legajo:{empleado.Legajo}," +
                            $"Año de Servicio:{empleado.AñoDeIngreso},");
                        if (empleado is Medico)
                        {
                            medicolistar = (Medico)empleado;
                            Console.WriteLine($"Especialidad:{medicolistar.especialidad}, Rol de servicio:{medicolistar.rolservicio}");


                        }
                    }

                }

            }
            if (!codigoingresado)
            {
                Console.WriteLine("Error: No se ingreso un codigo de servicio valido");
                return;
            }

        }
        public static void ConsultarDatosDeEmpleado()
        {
            Console.WriteLine("Ingrese el legajo del empleado a consultar:");
            uint legajo = uint.Parse(Console.ReadLine());

            EmpleadoBase empleadoEncontrado = null;

            foreach (var empleado in empleados)
            {
                if (legajo == empleado.Legajo)
                {
                    empleadoEncontrado = empleado;
                    break; // No es necesario seguir buscando
                }
            }

            if (empleadoEncontrado == null)
            {
                Console.WriteLine("Error: No se ingresó un legajo que corresponda a un empleado");
                return;
            }

            // Mostrar datos generales
            Console.WriteLine($"Nombre: {empleadoEncontrado.Nombre} {empleadoEncontrado.Apellido}, Año de ingreso: {empleadoEncontrado.AñoDeIngreso}");

            // Verificar si es un médico o enfermero y mostrar datos específicos
            if (empleadoEncontrado is Medico medico)
            {
                Console.WriteLine($"Categoría Profesional: {medico.CategoriaProfesional}, Matrícula: {medico.Matricula}, Especialidad: {medico.especialidad}, Servicio: {medico.Servicio}, Rol del servicio: {medico.rolservicio}");
                Console.WriteLine($"Haber Mensual: {medico.CalcularHaberMensual()}");
            }
            else if (empleadoEncontrado is Enfermero enfermero)
            {
                Console.WriteLine($"Categoría Profesional: {enfermero.CategoriaProfesional}, Especialidad: {enfermero.especialidad}, Matrícula: {enfermero.Matricula}");
                Console.WriteLine($"Haber Mensual: {enfermero.CalcularHaberMensual()}");
            }
            else if (empleadoEncontrado is EmpleadoAdministrativo administrativo)
            {

                Console.WriteLine($"{administrativo.CalcularHaberMensual()}");
                
             
            }
            List<string> listaservicios = new List<string>();

            foreach (var servicio in servicios)
            {

                if (servicio.EmpleadosAsignados.Contains(empleadoEncontrado))
                {
                    listaservicios.Add(servicio.NombreServicio);
                }
                if (servicio.JefeServicio == empleadoEncontrado)
                {
                   listaservicios.Add($"{servicio.NombreServicio} (Jefe de Servicio)");
                }
            }

            // Mostrar servicios en los que se desempeña
            if (listaservicios.Count > 0)
            {
                Console.WriteLine("Servicios en los que se desempeña:");
                foreach (var servicio in listaservicios)
                {
                    Console.WriteLine($"- {servicio}");
                }
            }
            else
            {
                Console.WriteLine("El empleado no está asignado a ningún servicio.");
            }
           
        }

        public static void EliminarEmpleado()
        {

            Console.WriteLine("Ingrese el lagajo del empleado a eliminar:");
            uint legajo = uint.Parse(Console.ReadLine());
            bool legajoencontrado = false;
            EmpleadoBase empleadoAEliminar = null;

            foreach (var empleado in empleados)
            {
                if (empleado.Legajo == legajo)
                {
                    legajoencontrado = true;
                    empleadoAEliminar = empleado;
                }

            }
            if (!legajoencontrado)
            {
                Console.WriteLine("No se encontro un empleado con dicho legajo.");
                return;
            }
            bool empleadoEsJefeDeServicio = false;
            bool empleadoAsignadoAunServicio = false;
            foreach (var servicio in servicios)
            {
                if (empleadoAEliminar == servicio.JefeServicio)
                {
                    empleadoEsJefeDeServicio = true;

                }
                foreach (var empleadodelservicio in servicio.EmpleadosAsignados)
                {
                    if (empleadodelservicio == empleadoAEliminar  )
                    {
                        empleadoAsignadoAunServicio = true;
                        
                    }    
                }

            }
            if (empleadoAsignadoAunServicio == true || empleadoEsJefeDeServicio == true)
            {
                Console.WriteLine("No se puede eliminar al empleado ya que se encuentra en un servicio o es jefe del mismo.");
                return;
            } 
            else
            {
                empleados.Remove(empleadoAEliminar);
                
            }
        }

       public static void ResumenDeServicio()
        {

            foreach (var servicio in servicios)
            {
                decimal TotalHaberMensual = 0;
                int CantidadDeEmpleadosEnElServicio = 0;
                int CantidadDeEnfermerosEnElServicio = 0;
                int CantidadDeMedicosEnElServicio = 0;
                int CantidadDeAdministrativosEnElServicio = 0;
                
                CantidadDeEmpleadosEnElServicio = servicio.EmpleadosAsignados.Count;
                foreach (var empleadoasignadosalservicio in servicio.EmpleadosAsignados)
                {

                   if (empleadoasignadosalservicio is Enfermero)
                    {
                        CantidadDeEnfermerosEnElServicio++;
                        Enfermero empleado = (Enfermero)empleadoasignadosalservicio;
                        TotalHaberMensual += empleado.CalcularHaberMensual();
                    }
                   if  (empleadoasignadosalservicio is Medico)
                    {
                        CantidadDeMedicosEnElServicio++;
                        Medico empleado = (Medico)empleadoasignadosalservicio;
                        TotalHaberMensual += empleado.CalcularHaberMensual();
                    }
                    if (empleadoasignadosalservicio is EmpleadoAdministrativo)
                    {
                        CantidadDeAdministrativosEnElServicio++;
                        EmpleadoAdministrativo empleado = (EmpleadoAdministrativo)empleadoasignadosalservicio;
                        TotalHaberMensual += empleado.CalcularHaberMensual();
                    }
                }
                Console.WriteLine($"Servicio: {servicio.NombreServicio}");
                Console.WriteLine($"Cantidad total de Empleados:{CantidadDeEmpleadosEnElServicio}");
                Console.WriteLine($"Cantidad de medicos en el servicio:{CantidadDeMedicosEnElServicio}");
                Console.WriteLine($"Cantidad de enfermeros en el servicio:{CantidadDeEnfermerosEnElServicio}");
                Console.WriteLine($"Cantidad de Administraticos en el servicio:{CantidadDeAdministrativosEnElServicio}");
                Console.WriteLine($"Total Haber Mensual del servicio:{TotalHaberMensual}");
            }

        }

    }
}





