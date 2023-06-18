using System.Linq;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace hgbr_API.ImplInterfaces
{
    public class PacientesArchServices : IPacientesArchServices
    {
        private readonly HospitalBocaContext context;
        public PacientesArchServices(HospitalBocaContext context)
        {
            this.context = context;
        }


        public IQueryable<object> getAll()
        {
            try
            {
                return context.Pacientesarches.Select(p => new {
                    folio = p.NoExpediente,
                    nombre = p.Nombre,
                    apPaterno = p.ApPaterno,
                    apMaterno = p.ApMaterno,
                    fechaNacimiento = p.FechaNac
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /* TODO: Esta acción resulta ser incompatible con Linq.dll,
         * Dado la dirección en donde está obteniendo la información por medio
         * del IQuerable<>. hay que verificar la acción si hay una opción donde
         * no es valido o nulo, aun que el valor de Paciente por alguna razón
         * no me deja colocarlo en nulo, aun que puede ocurrir casos donde
         * puede ser nulo, justo como este.
        */
        public Pacientesarch getClassPacientesArch(string numExpediente)
        {
            try
            {
                Console.WriteLine("Attempting to fetch the patient");
                Pacientesarch pa = context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).First();

                // Ok, con el paciente obtenido, llenemos la información extra.
                Estadocivil estado = context.Estadocivils.Where(p => p.IdEstadoCivil.Equals(pa.FkEstadoCivil)).First();
                pa.FkEstadoCivilNavigation = estado;

                Tipoasentamiento calle = context.Tipoasentamientos.Where(p => p.Id.Equals(pa.FkTipoCalleCasa)).First();
                pa.FkTipoColCasaNavigation = calle;

                Tipovialidad col = context.Tipovialidads.Where(p => p.Id.Equals(pa.FkTipoColCasa)).FirstOrDefault();
                pa.FkTipoCalleCasaNavigation = col;

                Sexo sexo = context.Sexos.Where(p => p.Id.Equals(pa.FkSexo)).First();
                pa.FkSexoNavigation = sexo;

                return pa;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public object getPacientesarch(string numExpediente)
        {
            try
            {
                return context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).Select(pa => new {
                    noExpediente = pa.NoExpediente,
                    nombre = pa.Nombre,
                    apPaterno = pa.ApPaterno,
                    apMaterno = pa.ApMaterno,
                    curp = pa.Curp,
                    fechaNac = pa.FechaNac,
                    horaNac = pa.HoraNac,
                    entidadNac = pa.EntidadNac,
                    // Edad = pa.Edad,
                    edadYears = pa.EdadYears,
                    edadMonths = pa.EdadMonths,
                    edadDays = pa.EdadDays,
                    edadHours = pa.EdadHours,
                    nacidoHospital = pa.NacidoHospital,
                    fkSexo = pa.FkSexo,
                    peso = pa.Peso,
                    talla = pa.Talla,
                    fkEstadoCivil = pa.FkEstadoCivil,
                    insabi = pa.Insabi,
                    gratuitidad = pa.Gratuitidad,
                    indigena = pa.Indigena,
                    lenguaIndigena = pa.LenguaIndigena,
                    cualLengua = pa.CualLengua,
                    fkTipoCalleCasa = pa.FkTipoCalleCasa,
                    nombreVialidad = pa.CalleCasa,
                    numCasa = pa.NumCasa,
                    numCasaInt = pa.NumCasaInt,
                    fkTipoColCasa = pa.FkTipoColCasa,
                    colCasa = pa.ColCasa,
                    cp = pa.Cp,
                    localidad = pa.Localidad,
                    municipio = pa.Municipio,
                    entidadFederativa = pa.EntidadFederativa,
                    pais = pa.Pais,
                    telCasa = pa.TelCasa
                }).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        public void savePacientesarch(Pacientesarch paciente)
        {
            try
            {
                Console.WriteLine(paciente.ToString());
                //En esta parte vamos a generar el folio del paciente con base a informacion de la BD y convertirlo en strings
                string currentYear = DateTime.Now.Year.ToString();
                string bornYear = Convert.ToDateTime(paciente.FechaNac).ToString("yy");
                string bornMonth = Convert.ToDateTime(paciente.FechaNac).ToString("MM");
                string bornDay = Convert.ToDateTime(paciente.FechaNac).ToString("dd");

                string gender = (paciente.FkSexo == 1) ? 'M'.ToString() : 'F'.ToString();

                string folio = "";
                string folioAux = currentYear + bornYear + bornMonth + bornDay;
                int count = 1;

                // Buscar el último paciente con los mismos primeros 10 caracteres en el folio.
                var ultimoPaciente = context.Pacientesarches
                    .OrderByDescending(p => p.NoExpediente)
                    .FirstOrDefault(p => p.NoExpediente.Substring(0, 10) == folioAux);

                if (ultimoPaciente != null)
                {
                    // Obtener el valor del contador del folio del último paciente.
                    string ultimoContadorStr = ultimoPaciente.NoExpediente.Substring(10, 2);
                    int ultimoContador = int.Parse(ultimoContadorStr);

                    // Incrementamos al contador en 1.
                    count = ultimoContador + 1;
                }

                // Pasamos al contador en formato de dos numeros (01, 02, 03, etc.).
                string countStr = count.ToString("D2");

                // Aqui se construye el folio con el formato que se solicito.
                folio = currentYear + bornYear + bornMonth + bornDay + countStr + gender;

                paciente.NoExpediente = folio;  //  El folio se alojaria a la BD.

                context.Pacientesarches.Add(paciente);
                context.SaveChanges();


                // Crear un objeto de la clase Pacientes utilizando los datos que coincidadan con pacientesArch
                Paciente pacientePacientes = new Paciente
                {
                    NoExpediente = folio,
                    Nombre = paciente.Nombre,
                    ApPaterno = paciente.ApPaterno,
                    ApMaterno = paciente.ApMaterno,
                    FechaNac = paciente.FechaNac,
                    FkEstadoCivil = paciente.FkEstadoCivil,
                    CalleCasa = paciente.CalleCasa,
                    NumCasa = Convert.ToInt32(paciente.NumCasa),
                    ColCasa = paciente.ColCasa,
                    TelCasa = Convert.ToString(paciente.TelCasa)
                };

                // Insertar el objeto en la tabla paciente
                context.Pacientes.Add(pacientePacientes);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    
        public void updatePacientesarch(Pacientesarch paciente)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalBocaContext>();
            optionsBuilder.EnableSensitiveDataLogging(); // Habilitar el registro de datos sensibles

            // Resto de la configuración del DbContext

            using (var context = new HospitalBocaContext(optionsBuilder.Options))
            {
                // Realizar la consulta LINQ
                try
                {
                    Pacientesarch aux = context.Pacientesarches.FirstOrDefault(p => p.NoExpediente.Equals(paciente.NoExpediente));
                //Pacientesarch aux = context.Pacientesarches.Where(p => p.NoExpediente.Equals(paciente.NoExpediente)).First();
                    if (aux.Nombre == null) aux.Nombre = paciente.Nombre;
                    else    if (!aux.Nombre.Equals(paciente.Nombre)) aux.Nombre = paciente.Nombre;
                    if (aux.ApPaterno == null)  aux.ApPaterno = paciente.ApPaterno;
                    else    if (!aux.ApPaterno.Equals(paciente.ApPaterno)) aux.ApPaterno = paciente.ApPaterno;
                    if (aux.ApMaterno == null)  aux.ApMaterno = paciente.ApMaterno;
                    else    if (!aux.ApMaterno.Equals(paciente.ApMaterno)) aux.ApMaterno = paciente.ApMaterno;
                    if (aux.Curp == null)  aux.Curp = paciente.Curp;
                    else    if (!aux.Curp.Equals(paciente.Curp)) aux.Curp = paciente.Curp;
                    if (aux.FechaNac == null)  aux.FechaNac = paciente.FechaNac;
                    else    if (!aux.FechaNac.Equals(paciente.FechaNac)) aux.FechaNac = paciente.FechaNac;
                    if (aux.HoraNac == null)  aux.HoraNac = paciente.HoraNac;
                    else    if (!aux.HoraNac.Equals(paciente.HoraNac)) aux.HoraNac = paciente.HoraNac;
                    if (aux.EntidadNac == null)  aux.EntidadNac = paciente.EntidadNac;
                    else    if (!aux.EntidadNac.Equals(paciente.EntidadNac)) aux.EntidadNac = paciente.EntidadNac;
                    // if (aux.Edad != paciente.Edad) aux.Edad = paciente.Edad;
                    if (aux.EdadYears == null)  aux.EdadYears = paciente.EdadYears;
                    else    if (aux.EdadYears != paciente.EdadYears) aux.EdadYears = paciente.EdadYears;
                    if (aux.EdadMonths == null)  aux.EdadMonths = paciente.EdadMonths;
                    else    if (aux.EdadMonths != paciente.EdadMonths) aux.EdadMonths = paciente.EdadMonths;
                    if (aux.EdadDays == null)  aux.EdadDays = paciente.EdadDays;
                    else    if (aux.EdadDays != paciente.EdadDays) aux.EdadDays = paciente.EdadDays;
                    if (aux.EdadHours == null)  aux.EdadHours = paciente.EdadHours;
                    else    if (aux.EdadHours != paciente.EdadHours) aux.EdadHours = paciente.EdadHours;
                    if (aux.NacidoHospital == null)  aux.NacidoHospital = paciente.NacidoHospital;
                    else    if (aux.NacidoHospital != paciente.NacidoHospital) aux.NacidoHospital = paciente.NacidoHospital;
                    if (aux.FkSexo == null)  aux.FkSexo = paciente.FkSexo;
                    else    if (aux.FkSexo != paciente.FkSexo) aux.FkSexo = paciente.FkSexo;
                    if (aux.Peso == null)  aux.Peso = paciente.Peso;
                    else    if (aux.Peso != paciente.Peso) aux.Peso = paciente.Peso;
                    if (aux.Talla == null)  aux.Talla = paciente.Talla;
                    else    if (aux.Talla != paciente.Talla) aux.Talla = paciente.Talla;
                    if (aux.FkEstadoCivil == null)  aux.FkEstadoCivil = paciente.FkEstadoCivil;
                    else    if (aux.FkEstadoCivil != paciente.FkEstadoCivil) aux.FkEstadoCivil = paciente.FkEstadoCivil;
                    if (aux.Insabi == null)  aux.Insabi = paciente.Insabi;
                    else    if (aux.Insabi != paciente.Insabi) aux.Insabi = paciente.Insabi;
                    if (aux.Gratuitidad == null)  aux.Gratuitidad = paciente.Gratuitidad;
                    else    if (aux.Gratuitidad != paciente.Gratuitidad) aux.Gratuitidad = paciente.Gratuitidad;
                    if (aux.Indigena == null)  aux.Indigena = paciente.Indigena;
                    else    if (aux.Indigena != paciente.Indigena) aux.Indigena = paciente.Indigena;
                    if (aux.LenguaIndigena == null)  aux.LenguaIndigena = paciente.LenguaIndigena;
                    else    if (aux.LenguaIndigena != paciente.LenguaIndigena) aux.LenguaIndigena = paciente.LenguaIndigena;
                    if (aux.CualLengua == null)  aux.CualLengua = paciente.CualLengua;
                    else    if (!aux.CualLengua.Equals(paciente.CualLengua)) aux.CualLengua = paciente.CualLengua;
                    if (aux.FkTipoCalleCasa == null)  aux.FkTipoCalleCasa = paciente.FkTipoCalleCasa;
                    else    if (aux.FkTipoCalleCasa != paciente.FkTipoCalleCasa) aux.FkTipoCalleCasa = paciente.FkTipoCalleCasa;
                    if (aux.CalleCasa == null)  aux.CalleCasa = paciente.CalleCasa;
                    else    if (!aux.CalleCasa.Equals(paciente.CalleCasa)) aux.CalleCasa = paciente.CalleCasa;
                    if (aux.NumCasa == null)  aux.NumCasa = paciente.NumCasa;
                    else    if (!aux.NumCasa.Equals(paciente.NumCasa)) aux.NumCasa = paciente.NumCasa;
                    if (aux.NumCasaInt == null)  aux.NumCasaInt = paciente.NumCasaInt;
                    else    if (!aux.NumCasaInt.Equals(paciente.NumCasaInt)) aux.NumCasaInt = paciente.NumCasaInt;
                    if (aux.FkTipoColCasa == null)  aux.FkTipoColCasa = paciente.FkTipoColCasa;
                    else    if (aux.FkTipoColCasa != paciente.FkTipoColCasa) aux.FkTipoColCasa = paciente.FkTipoColCasa;
                    if (aux.ColCasa == null)  aux.ColCasa = paciente.ColCasa;
                    else    if (!aux.ColCasa.Equals(paciente.ColCasa)) aux.ColCasa = paciente.ColCasa;
                    if (aux.Cp == null)  aux.Cp = paciente.Cp;
                    else    if (aux.Cp != paciente.Cp) aux.Cp = paciente.Cp;
                    if (aux.Localidad == null)  aux.Localidad = paciente.Localidad;
                    else    if (!aux.Localidad.Equals(paciente.Localidad)) aux.Localidad = paciente.Localidad;
                    if (aux.Municipio == null)  aux.Municipio = paciente.Municipio;
                    else    if (!aux.Municipio.Equals(paciente.Municipio)) aux.Municipio = paciente.Municipio;
                    if (aux.EntidadFederativa == null)  aux.EntidadFederativa = paciente.EntidadFederativa;
                    else    if (!aux.EntidadFederativa.Equals(paciente.EntidadFederativa)) aux.EntidadFederativa = paciente.EntidadFederativa;
                    if (aux.Pais == null)  aux.Pais = paciente.Pais;
                    else    if (!aux.Pais.Equals(paciente.Pais)) aux.Pais = paciente.Pais;
                    if (aux.TelCasa == null)  aux.TelCasa = paciente.TelCasa;
                    else    if (!aux.TelCasa.Equals(paciente.TelCasa)) aux.TelCasa = paciente.TelCasa;

                    context.SaveChanges();



                    // Realizar la actualización en la tabla pacientes
                    var pacientePacientes = context.Pacientes.FirstOrDefault(p => p.NoExpediente.Equals(paciente.NoExpediente));

                    if (pacientePacientes != null)
                    {
                        pacientePacientes.Nombre = paciente.Nombre;
                        pacientePacientes.ApPaterno = paciente.ApPaterno;
                        pacientePacientes.ApMaterno = paciente.ApMaterno;
                        pacientePacientes.FechaNac = paciente.FechaNac;
                        pacientePacientes.FkEstadoCivil = paciente.FkEstadoCivil;
                        pacientePacientes.CalleCasa = paciente.CalleCasa;
                        pacientePacientes.NumCasa = Convert.ToInt32(paciente.NumCasa);
                        pacientePacientes.ColCasa = paciente.ColCasa;
                        pacientePacientes.TelCasa = Convert.ToString(paciente.TelCasa);

                        context.SaveChanges();
                    }

                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }


        public void deletePacientesarch(string numExpediente)
        {
            try
            {
                Pacientesarch pa = context.Pacientesarches.Where(p => p.NoExpediente.Equals(numExpediente)).First();
                context.Pacientesarches.Remove(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}