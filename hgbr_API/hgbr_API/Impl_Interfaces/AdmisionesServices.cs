using System.Linq;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace hgbr_API.ImplInterfaces
{
    public class AdmisionesServices : IAdmisionesServices
    {
        private readonly HospitalBocaContext context;
        public AdmisionesServices(HospitalBocaContext context)
        {
            this.context = context;
        }


        public IQueryable<object> getAll()
        {
            try
            {
                return context.Admisiones.Select(a => new {
                    folio = a.Folio,
                    nombre = a.Nombre,
                    primerApellido = a.PrimerApellido,
                    segundoApellido = a.SegundoApellido,
                    fechaNacimiento = a.FechaNacimiento,
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        
        public Admisione getClassAdmisiones(int folio)
        {
            try
            {
                Console.WriteLine("Attempting to fetch the admin");
                Admisione adm = context.Admisiones.Where(a => a.Folio.Equals(folio)).First();

                Sexo sexo = context.Sexos.Where(a => a.Id.Equals(adm.FkSexo)).First();
                adm.FkSexoNavigation = sexo;

                Tipoasentamiento asent = context.Tipoasentamientos.Where(a => a.Id.Equals(adm.FkTipoAsentamiento)).First();
                adm.FkTipoAsentamientoNavigation = asent;

                Tipovialidad vial = context.Tipovialidads.Where(a => a.Id.Equals(adm.FkTipoVialidad)).FirstOrDefault();
                adm.FkTipoVialidadNavigation = vial;

                return adm;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public object getAdmisiones(int folio)
        {
            try
            {
                return context.Admisiones.Where(a => a.Folio.Equals(folio)).Select(adm => new {
                    folio = adm.Folio,
                    nombre = adm.Nombre,
                    primerApellido = adm.PrimerApellido,
                    segundoApellido = adm.SegundoApellido,
                    curp = adm.Curp,
                    fechaNacimiento = adm.FechaNacimiento,
                    horaNacimiento = adm.HoraNacimiento,
                    entidadNacimiento = adm.EntidadNacimiento,
                    // Edad = adm.Edad,
                    edadYears = adm.EdadYears,
                    edadMonths = adm.EdadMonths,
                    edadDays = adm.EdadDays,
                    edadHours = adm.EdadHours,
                    //NacidoHospital = adm.NacidoHospital,
                    fkSexo = adm.FkSexo,
                    //Peso = adm.Peso,
                    //Talla = adm.Talla,
                    //FKEstadoCivil = adm.FkEstadoCivil,
                    insabi = adm.Insabi,
                    gratuitidad = adm.Gratuitidad,
                    //Indigena = adm.Indigena,
                    //LenguaIndigena = adm.LenguaIndigena,
                    //CualLengua = adm.CualLengua,
                    fkTipoVialidad = adm.FkTipoVialidad,
                    nombreVialidad = adm.NombreVialidad,
                    numExt = adm.NumExt,
                    numInt = adm.NumInt,
                    fkTipoAsentamiento = adm.FkTipoAsentamiento,
                    nombreAsentamiento = adm.NombreAsentamiento,
                    cp = adm.Cp,
                    localidad = adm.Localidad,
                    municipio = adm.Municipio,
                    entidadFederativa = adm.EntidadFederativa,
                    pais = adm.Pais,
                    telefono = adm.Telefono
                }).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        public void saveAdmisiones(Admisione admision)
        {
            try
            {
                context.Admisiones.Add(admision);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public void updateAdmisiones(Admisione admision)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalBocaContext>();
            optionsBuilder.EnableSensitiveDataLogging();

            using (var context = new HospitalBocaContext(optionsBuilder.Options))
            {
                try
                {
                    Admisione aux = context.Admisiones.FirstOrDefault(p => p.Folio.Equals(admision.Folio));
                    if (!aux.Nombre.Equals(admision.Nombre)) aux.Nombre = admision.Nombre;
                    if (!aux.PrimerApellido.Equals(admision.PrimerApellido)) aux.PrimerApellido = admision.PrimerApellido;
                    if (!aux.SegundoApellido.Equals(admision.SegundoApellido)) aux.SegundoApellido = admision.SegundoApellido;
                    if (!aux.Curp.Equals(admision.Curp)) aux.Curp = admision.Curp;
                    if (!aux.FechaNacimiento.Equals(admision.FechaNacimiento)) aux.FechaNacimiento = admision.FechaNacimiento;
                    if (!aux.HoraNacimiento.Equals(admision.HoraNacimiento)) aux.HoraNacimiento = admision.HoraNacimiento;
                    if (!aux.EntidadNacimiento.Equals(admision.EntidadNacimiento)) aux.EntidadNacimiento = admision.EntidadNacimiento;
                    // if (aux.Edad != admision.Edad) aux.Edad = admision.Edad;
                    if (aux.EdadYears != admision.EdadYears) aux.EdadYears = admision.EdadYears;
                    if (aux.EdadMonths != admision.EdadMonths) aux.EdadMonths = admision.EdadMonths;
                    if (aux.EdadDays != admision.EdadDays) aux.EdadDays = admision.EdadDays;
                    if (aux.EdadHours != admision.EdadHours) aux.EdadHours = admision.EdadHours;
                    // if (aux.NacidoHospital != admision.NacidoHospital) aux.NacidoHospital = admision.NacidoHospital;
                    if (aux.FkSexo != admision.FkSexo) aux.FkSexo = admision.FkSexo;
                    // if (aux.Peso != admision.Peso) aux.Peso = admision.Peso;
                    // if (aux.Talla != admision.Talla) aux.Talla = admision.Talla;
                    // if (aux.FkEstadoCivil != admision.FkEstadoCivil) aux.FkEstadoCivil = admision.FkEstadoCivil;
                    if (aux.Insabi != admision.Insabi) aux.Insabi = admision.Insabi;
                    if (aux.Gratuitidad != admision.Gratuitidad) aux.Gratuitidad = admision.Gratuitidad;
                    // if (aux.Indigena != admision.Indigena) aux.Indigena = admision.Indigena;
                    // if (aux.LenguaIndigena != admision.LenguaIndigena) aux.LenguaIndigena = admision.LenguaIndigena;
                    // if (!aux.CualLengua.Equals(admision.CualLengua)) aux.CualLengua = admision.CualLengua;
                    if (aux.FkTipoVialidad != admision.FkTipoVialidad) aux.FkTipoVialidad = admision.FkTipoVialidad;
                    if (!aux.NombreVialidad.Equals(admision.NombreVialidad)) aux.NombreVialidad = admision.NombreVialidad;
                    if (!aux.NumExt.Equals(admision.NumExt)) aux.NumExt = admision.NumExt;
                    if (!aux.NumInt.Equals(admision.NumInt)) aux.NumInt = admision.NumInt;
                    if (aux.FkTipoAsentamiento != admision.FkTipoAsentamiento) aux.FkTipoAsentamiento = admision.FkTipoAsentamiento;
                    if (!aux.NombreAsentamiento.Equals(admision.NombreAsentamiento)) aux.NombreAsentamiento = admision.NombreAsentamiento;
                    if (aux.Cp != admision.Cp) aux.Cp = admision.Cp;
                    if (!aux.Localidad.Equals(admision.Localidad)) aux.Localidad = admision.Localidad;
                    if (!aux.Municipio.Equals(admision.Municipio)) aux.Municipio = admision.Municipio;
                    if (!aux.EntidadFederativa.Equals(admision.EntidadFederativa)) aux.EntidadFederativa = admision.EntidadFederativa;
                    if (!aux.Pais.Equals(admision.Pais)) aux.Pais = admision.Pais;
                    if (!aux.Telefono.Equals(admision.Telefono)) aux.Telefono = admision.Telefono;

                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }


        public void deleteAdmisiones(int folio)
        {
            try
            {
                Admisione adm = context.Admisiones.Where(a => a.Folio.Equals(folio)).First();
                context.Admisiones.Remove(adm);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}