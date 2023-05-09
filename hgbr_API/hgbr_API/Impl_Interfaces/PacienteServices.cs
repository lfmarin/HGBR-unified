using System.Linq;
using hgbr_API.Models;
using hgbr_API.Interfaces;
using System;

namespace API_Hospital_Boca.Bussiness
{
    public class PacienteServices : IPacienteServices
    {
        private readonly HgbrContext context;
        public PacienteServices(HgbrContext context)
        {
            this.context = context;
        }


        public IQueryable<object> getAll()
        {
            try
            {
                return context.Pacientes.Select(p => new {
                    Folio = p.Folio,
                    Nombre = p.Nombre,
                    ApPaterno = p.PrimerApellido,
                    ApMaerno = p.SegundoApellido,
                    FechaNacimiento = p.FechaNacimiento
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
        public Paciente getClassPaciente(string numExpediente)
        {
            try
            {
                Console.WriteLine("Attempting to fetch the patient");
                Paciente pa = context.Pacientes.Where(p => p.Folio.Equals(numExpediente)).First();

                // Ok, con el paciente obtenido, llenemos la información extra.
                EstadoConyugal estado = context.EstadoConyugals.Where(p => p.Id.Equals(pa.FkEstadoConyugal)).First();
                pa.FkEstadoConyugalNavigation = estado;

                TipoAsentamiento asent = context.TipoAsentamientos.Where(p => p.Id.Equals(pa.FkTipoAsentamiento)).First();
                pa.FkTipoAsentamientoNavigation = asent;

                TipoVialidad vial = context.TipoVialidads.Where(p => p.Id.Equals(pa.FkTipoVialidad)).FirstOrDefault();
                pa.FkTipoVialidadNavigation = vial;

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

        public object getPaciente(string numExpediente)
        {
            try
            {
                return context.Pacientes.Where(p => p.Folio.Equals(numExpediente)).Select(pa => new {
                    Folio = pa.Folio,
                    Nombre = pa.Nombre,
                    ApPaterno = pa.PrimerApellido,
                    ApMaterno = pa.SegundoApellido,
                    Curp = pa.Curp,
                    FechaNac = pa.FechaNacimiento,
                    EntidadNac = pa.EntidadNacimiento,
                    Edad = pa.Edad,
                    NacidoHosp = pa.NacidoHospital,
                    FKSexo = pa.FkSexo,
                    Peso = pa.Peso,
                    Talla = pa.Talla,
                    FKEstadoConyugal = pa.FkEstadoConyugal,
                    Insabi = pa.Insabi,
                    Gratuitidad = pa.Gratuitidad,
                    Indigena = pa.Indigena,
                    LenguaIndigena = pa.LenguaIndigena,
                    CualLengua = pa.CualLengua,
                    FKTipoVialidad = pa.FkTipoVialidad,
                    NombreVialidad = pa.NombreVialidad,
                    NumExt = pa.NumExt,
                    NumInt = pa.NumInt,
                    FKTipoAsentamiento = pa.FkTipoAsentamientoNavigation,
                    NombreAsentamiento = pa.NombreAsentamiento,
                    Cp = pa.Cp,
                    Localidad = pa.Localidad,
                    MunicipioDeleg = pa.MunicipioDeleg,
                    Entidad = pa.EntidadFederativa,
                    Pais = pa.Pais,
                    Telefono = pa.Telefono
                }).First();
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public void savePaciente(Paciente paciente)
        {
            try
            {
                context.Pacientes.Add(paciente);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updatePaciente(Paciente paciente)
        {
            try
            {
                Paciente aux = context.Pacientes.Where(p => p.Folio == paciente.Folio).First();

                if (!aux.Nombre.Equals(paciente.Nombre)) aux.Nombre = paciente.Nombre;
                if (!aux.PrimerApellido.Equals(paciente.PrimerApellido)) aux.PrimerApellido = paciente.PrimerApellido;
                if (!aux.SegundoApellido.Equals(paciente.SegundoApellido)) aux.SegundoApellido = paciente.SegundoApellido;
                if (!aux.Curp.Equals(paciente.Curp)) aux.Curp = paciente.Curp;
                if (!aux.FechaNacimiento.Equals(paciente.FechaNacimiento)) aux.FechaNacimiento = paciente.FechaNacimiento;
                if (!aux.EntidadNacimiento.Equals(paciente.EntidadNacimiento)) aux.EntidadNacimiento = paciente.EntidadNacimiento;
                if (aux.Edad != paciente.Edad) aux.Edad = paciente.Edad;
                if (aux.NacidoHospital != paciente.NacidoHospital) aux.NacidoHospital = paciente.NacidoHospital;
                if (aux.FkSexo != paciente.FkSexo) aux.FkSexo = paciente.FkSexo;
                if (aux.Peso != paciente.Peso) aux.Peso = paciente.Peso;
                if (aux.Talla != paciente.Talla) aux.Talla = paciente.Talla;
                if (aux.FkEstadoConyugal != paciente.FkEstadoConyugal) aux.FkEstadoConyugal = paciente.FkEstadoConyugal;
                if (aux.Insabi != paciente.Insabi) aux.Insabi = paciente.Insabi;
                if (aux.Gratuitidad != paciente.Gratuitidad) aux.Gratuitidad = paciente.Gratuitidad;
                if (aux.Indigena != paciente.Indigena) aux.Indigena = paciente.Indigena;
                if (aux.LenguaIndigena != paciente.LenguaIndigena) aux.LenguaIndigena = paciente.LenguaIndigena;
                if (!aux.CualLengua.Equals(paciente.CualLengua)) aux.CualLengua = paciente.CualLengua;
                if (aux.FkTipoVialidad != paciente.FkTipoVialidad) aux.FkTipoVialidad = paciente.FkTipoVialidad;
                if (!aux.NombreVialidad.Equals(paciente.NombreVialidad)) aux.NombreVialidad = paciente.NombreVialidad;
                if (!aux.NumExt.Equals(paciente.NumExt)) aux.NumExt = paciente.NumExt;
                if (!aux.NumInt.Equals(paciente.NumInt)) aux.NumInt = paciente.NumInt;
                if (aux.FkTipoAsentamiento != paciente.FkTipoAsentamiento) aux.FkTipoAsentamiento = paciente.FkTipoAsentamiento;
                if (!aux.NombreAsentamiento.Equals(paciente.NombreAsentamiento)) aux.NombreAsentamiento = paciente.NombreAsentamiento;
                if (aux.Cp != paciente.Cp) aux.Cp = paciente.Cp;
                if (!aux.Localidad.Equals(paciente.Localidad)) aux.Localidad = paciente.Localidad;
                if (!aux.MunicipioDeleg.Equals(paciente.MunicipioDeleg)) aux.MunicipioDeleg = paciente.MunicipioDeleg;
                if (!aux.EntidadFederativa.Equals(paciente.EntidadFederativa)) aux.EntidadFederativa = paciente.EntidadFederativa;
                if (!aux.Pais.Equals(paciente.Pais)) aux.Pais = paciente.Pais;
                if (!aux.Telefono.Equals(paciente.Telefono)) aux.Telefono = paciente.Telefono;

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public void deletePaciente(string numExpediente)
        {
            try
            {
                Paciente pa = context.Pacientes.Where(p => p.Folio.Equals(numExpediente)).First();
                context.Pacientes.Remove(pa);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}


