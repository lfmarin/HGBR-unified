using API_Hospital_Boca.Models;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Utilities;
using System.Linq;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceEncuestaSeguimeinto : IServiceEncuestaSeguimeinto
    {
        private readonly hospital_bocaContext context;

        public ServiceEncuestaSeguimeinto(hospital_bocaContext context)
        {
            this.context = context;
        }
        public void saveEncuestaSeguimeinto(Encuestaseguimiento es)
        {
            try
            {
                context.Encuestaseguimientos.Add(es);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateEncuestaSeguimiento(Encuestaseguimiento es)
        {
            try
            {
                var oldData = context.Encuestaseguimientos.Where(e => e.FkPaciente == es.FkPaciente).First();

                if (!Utils.isTheSame(oldData.FkHospital, es.FkHospital)) oldData.FkHospital = es.FkHospital;
                if (!Utils.isTheSame(oldData.FechaEncuesta, es.FechaEncuesta)) oldData.FechaEncuesta = es.FechaEncuesta;
                if (!Utils.isTheSame(oldData.FechaVasectomia, es.FechaVasectomia)) oldData.FechaVasectomia = es.FechaVasectomia;
                if (!Utils.isTheSame(oldData.OrigenInfo, es.OrigenInfo)) oldData.OrigenInfo = es.OrigenInfo;
                if (!Utils.isTheSame(oldData.FkConsejeria, es.FkConsejeria)) oldData.FkConsejeria = es.FkConsejeria;
                if (!Utils.isTheSame(oldData.Referido, es.Referido)) oldData.Referido = es.Referido;
                if (!Utils.isTheSame(oldData.FkHospitalReferencia, es.FkHospitalReferencia)) oldData.FkHospitalReferencia = es.FkHospitalReferencia;
                if (!Utils.isTheSame(oldData.FkCalidad, es.FkCalidad)) oldData.FkCalidad = es.FkCalidad;
                if (!Utils.isTheSame(oldData.Satisfaccion, es.Satisfaccion)) oldData.Satisfaccion = es.Satisfaccion;
                if (!Utils.isTheSame(oldData.MotivoSatisfaccion, es.MotivoSatisfaccion)) oldData.MotivoSatisfaccion = es.MotivoSatisfaccion;
                if (!Utils.isTheSame(oldData.Complicacion, es.Complicacion)) oldData.Complicacion = es.Complicacion;
                if (!Utils.isTheSame(oldData.MotivoComplicacion, es.MotivoComplicacion)) oldData.MotivoComplicacion = es.MotivoComplicacion;
                if (!Utils.isTheSame(oldData.FkCalidadRelacion, es.FkCalidadRelacion)) oldData.FkCalidadRelacion = es.FkCalidadRelacion;
                if (!Utils.isTheSame(oldData.MotivoCalidad, es.MotivoCalidad)) oldData.MotivoCalidad = es.MotivoCalidad;
                if (!Utils.isTheSame(oldData.FechaNegativo, es.FechaNegativo)) oldData.FechaNegativo = es.FechaNegativo;
                if (!Utils.isTheSame(oldData.LugarEspermaconteo, es.LugarEspermaconteo)) oldData.LugarEspermaconteo = es.LugarEspermaconteo;
                if (!Utils.isTheSame(oldData.Recomendacion, es.Recomendacion)) oldData.Recomendacion = es.Recomendacion;
                if (!Utils.isTheSame(oldData.MotivoRecomendacion, es.MotivoRecomendacion)) oldData.MotivoRecomendacion = es.MotivoRecomendacion;
                if (!Utils.isTheSame(oldData.LugarVasectomia, es.LugarVasectomia)) oldData.LugarVasectomia = es.LugarVasectomia;
                if (!Utils.isTheSame(oldData.MotivoLugar, es.MotivoLugar)) oldData.MotivoLugar = es.MotivoLugar;
                if (!Utils.isTheSame(oldData.RecomendacionHospital, es.RecomendacionHospital)) oldData.RecomendacionHospital = es.RecomendacionHospital;
                if (!Utils.isTheSame(oldData.CualRecomendacion, es.CualRecomendacion)) oldData.CualRecomendacion = es.CualRecomendacion;

                context.SaveChanges(); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getEncuestaSeguimientoByNumExp(string numExp)
        {
            try
            {
                return context.Encuestaseguimientos.Where(e => e.FkPaciente == numExp).Select(es => new {
                    FkPaciente = es.FkPaciente,
                    FkHospital = es.FkHospital,
                    FechaEncuesta = es.FechaEncuesta,
                    FechaVasectomia = es.FechaVasectomia,
                    OrigenInfo = es.OrigenInfo,
                    FkConsejeria = es.FkConsejeria,
                    Referido = es.Referido,
                    FkHospitalReferencia = es.FkHospitalReferencia,
                    FkCalidad = es.FkCalidad,
                    Satisfaccion = es.Satisfaccion,
                    MotivoSatisfaccion = es.MotivoSatisfaccion,
                    Complicacion = es.Complicacion,
                    MotivoComplicacion = es.MotivoComplicacion,
                    FkCalidadRelacion = es.FkCalidadRelacion,
                    MotivoCalidad = es.MotivoCalidad,
                    FechaNegativo = es.FechaNegativo,
                    LugarEspermaconteo = es.LugarEspermaconteo,
                    Recomendacion = es.Recomendacion,
                    MotivoRecomendacion = es.MotivoRecomendacion,
                    LugarVasectomia = es.LugarVasectomia,
                    MotivoLugar = es.MotivoLugar,
                    RecomendacionHospital = es.RecomendacionHospital,
                    CualRecomendacion = es.CualRecomendacion
                }).First();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Encuestaseguimiento getEncuestaClassSeguimientoByNumExp(string numExp)
        {
            try
            {
                Encuestaseguimiento ec = context.Encuestaseguimientos.Where(e => e.FkPaciente == numExp).First();

                // Ok, con el elemento encontrado, llegna la información.
                Paciente pc = context.Pacientes.Where(e => e.NoExpediente == numExp).First();

                Escolaridad sco = context.Escolaridads.Where(p => p.IdEscolaridad.Equals(pc.FkEscolaridad)).First();
                pc.FkEscolaridadNavigation = sco;

                Estadocivil EC = context.Estadocivils.Where(p => p.IdEstadoCivil.Equals(pc.FkEstadoCivil)).First();
                pc.FkEstadoCivilNavigation = EC;

                Ocupacion Opc = context.Ocupacions.Where(p => p.IdOcupacion.Equals(pc.FkOcupacion)).First();
                pc.FkOcupacionNavigation = Opc;

                Lugarreferencium Ref = context.Lugarreferencia.Where(p => p.IdLugar.Equals(pc.FkLugarReferencia)).FirstOrDefault();
                pc.FkLugarReferenciaNavigation = Ref;

                Religion Reg = context.Religions.Where(p => p.IdReligion.Equals(pc.FkReligion)).First();
                pc.FkReligionNavigation = Reg;

                ec.FkPacienteNavigation = pc;

                Hospitale hosp = context.Hospitales.Where(p => p.IdHospital.Equals(ec.FkHospital)).First();
                ec.FkHospitalNavigation = hosp;

                Hospitale h_ref = context.Hospitales.Where(p => p.IdHospital.Equals(ec.FkHospitalReferencia)).First();
                ec.FkHospitalReferenciaNavigation = h_ref;
                /*
                return context.Encuestaseguimientos.Where(e => e.FkPaciente == numExp).Select(es => new {
                    FkPaciente = es.FkPaciente,
                    FkHospital = es.FkHospital,
                    FechaEncuesta = es.FechaEncuesta,
                    FechaVasectomia = es.FechaVasectomia,
                    OrigenInfo = es.OrigenInfo,
                    FkConsejeria = es.FkConsejeria,
                    Referido = es.Referido,
                    FkHospitalReferencia = es.FkHospitalReferencia,
                    FkCalidad = es.FkCalidad,
                    Satisfaccion = es.Satisfaccion,
                    MotivoSatisfaccion = es.MotivoSatisfaccion,
                    Complicacion = es.Complicacion,
                    MotivoComplicacion = es.MotivoComplicacion,
                    FkCalidadRelacion = es.FkCalidadRelacion,
                    MotivoCalidad = es.MotivoCalidad,
                    FechaNegativo = es.FechaNegativo,
                    LugarEspermaconteo = es.LugarEspermaconteo,
                    Recomendacion = es.Recomendacion,
                    MotivoRecomendacion = es.MotivoRecomendacion,
                    LugarVasectomia = es.LugarVasectomia,
                    MotivoLugar = es.MotivoLugar,
                    RecomendacionHospital = es.RecomendacionHospital,
                    CualRecomendacion = es.CualRecomendacion
                }).First();
                */
                return ec;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }
}