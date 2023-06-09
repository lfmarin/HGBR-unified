using System.Linq;
using API_Hospital_Boca.Models;
using API_Hospital_Boca.Utilities;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceHistoriaClinica : API_Hospital_Boca.Services.IServiceHistoriaClinica
    {
        private readonly hospital_bocaContext context;
        public ServiceHistoriaClinica(hospital_bocaContext context)
        {
            this.context = context;
        }
        public void saveEstudioAnatomo(Estudioanatomo ea)
        {
            try
            {
                context.Estudioanatomos.Add(ea);
                context.SaveChanges();

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveEvolucion(Evolucion ev)
        {
            try
            {
                context.Evolucions.Add(ev);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveHistoriaClinica(Historiaclinica hc)
        {
            try
            {
                context.Historiaclinicas.Add(hc);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveHistoriaExploracion(Historiaexploracion he)
        {
            try
            {
                context.Historiaexploracions.Add(he);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveMotivoSolicitud(Motivosolicitud ms)
        {
            try
            {
                context.Motivosolicituds.Add(ms);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void saveProcedimientoQuirurgico(Procquirurgico pq)
        {
            try
            {
                context.Procquirurgicos.Add(pq);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateEstudioAnatomo(Estudioanatomo ea)
        {
            try
            {
                var res = context.Estudioanatomos.Where(est => est.FkHistoria == ea.FkHistoria).First();

                if (!Utils.isTheSame(res.FechaEnvio, ea.FechaEnvio)) res.FechaEnvio = ea.FechaEnvio;
                if (!Utils.isTheSame(res.Clave, ea.Clave)) res.Clave = ea.Clave;
                if (!Utils.isTheSame(res.Resultado, ea.Resultado)) res.Resultado = ea.Resultado;

                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateEvolucion(Evolucion ev)
        {
            try
            {
                var res = context.Evolucions.Where(e => e.FkHistoria == ev.FkHistoria).First();

                if (!Utils.isTheSame(res.Complicaciones, ev.Complicaciones)) res.Complicaciones = ev.Complicaciones;
                if (!Utils.isTheSame(res.Espermaconteo, ev.Espermaconteo)) res.Espermaconteo = ev.Espermaconteo;
                if (!Utils.isTheSame(res.Fecha1, ev.Fecha1)) res.Fecha1 = ev.Fecha1;
                if (!Utils.isTheSame(res.Resultado1, ev.Resultado1)) res.Resultado1 = ev.Resultado1;
                if (!Utils.isTheSame(res.Fecha2, ev.Fecha2)) res.Fecha2 = ev.Fecha2;
                if (!Utils.isTheSame(res.Resultado2, ev.Resultado2)) res.Resultado2 = ev.Resultado2;

                context.SaveChanges(); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateHistoriaExploracion(Historiaexploracion he)
        {
            try
            {
                var res = context.Historiaexploracions.Where(his => his.FkHistoria == he.FkHistoria).First();   

                if (!Utils.isTheSame(res.AntFamiliares, he.AntFamiliares)) res.AntFamiliares = he.AntFamiliares;
                if (!Utils.isTheSame(res.AntPersonalesNoPat, he.AntPersonalesNoPat)) res.AntPersonalesNoPat = he.AntPersonalesNoPat;
                if (!Utils.isTheSame(res.AntPersonalesPat, he.AntPersonalesPat)) res.AntPersonalesPat = he.AntPersonalesPat;
                if (!Utils.isTheSame(res.Ta, he.Ta)) res.Ta = he.Ta;
                if (!Utils.isTheSame(res.Peso, he.Peso)) res.Peso = he.Peso;
                if (!Utils.isTheSame(res.Talla, he.Talla)) res.Talla = he.Talla;
                if (!Utils.isTheSame(res.Fc, he.Fc)) res.Fc = he.Fc;
                if (!Utils.isTheSame(res.Fr, he.Fr)) res.Fr = he.Fr;
                if (!Utils.isTheSame(res.Tem, he.Tem)) res.Tem = he.Tem;
                if (!Utils.isTheSame(res.ExpOrganos, he.ExpOrganos)) res.ExpOrganos = he.ExpOrganos;
                if (!Utils.isTheSame(res.TipoPaciente, he.TipoPaciente)) res.TipoPaciente = he.TipoPaciente;

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateMotivoSolicitud(Motivosolicitud ms)
        {
            try
            {
                var res = context.Motivosolicituds.Where(msol => msol.FkHistoria == ms.FkHistoria).First();
                
                if (!Utils.isTheSame(ms.CausaNoHijos, res.CausaNoHijos)) res.CausaNoHijos = ms.CausaNoHijos;
                if (!Utils.isTheSame(ms.FkOpinion, res.FkOpinion)) res.FkOpinion = ms.FkOpinion;
                if (!Utils.isTheSame(ms.FkMetodoPlanificacion, res.FkMetodoPlanificacion)) res.FkMetodoPlanificacion = ms.FkMetodoPlanificacion;
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateProcedimeintoQuirurgico(Procquirurgico pq)
        {
            try
            {
                try
                {
                    var res = context.Procquirurgicos.Where(porc => porc.FkHistoria == pq.FkHistoria).First();
                    
                    if (!Utils.isTheSame(res.FechaCirugia, pq.FechaCirugia)) res.FechaCirugia = pq.FechaCirugia;
                    if (!Utils.isTheSame(res.FkDoctor, pq.FkDoctor)) res.FkDoctor = pq.FkDoctor;
                    if (!Utils.isTheSame(res.NotaQuirurgica, pq.NotaQuirurgica)) res.NotaQuirurgica = pq.NotaQuirurgica;
                    if (!Utils.isTheSame(res.Patologia, pq.Patologia)) res.Patologia = pq.Patologia;

                    context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }   
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public int getLastId()
        {
            var lastHist = context.Historiaclinicas.OrderBy(hi => hi.IdHistoriaClinica).Last();
            return lastHist.IdHistoriaClinica;
        }

        public Historiaclinica getHistoriaClassByNumExp(string numExpe)
        {
            try
            {
                Historiaclinica hs = context.Historiaclinicas.Where(h => h.FkPaciente == numExpe).FirstOrDefault();
                
                Hospitale hos = context.Hospitales.Where(p => p.IdHospital.Equals(hs.FkHospital)).First();
                hs.FkHospitalNavigation = hos;

                Paciente pc = context.Pacientes.Where(p => p.NoExpediente.Equals(hs.FkPaciente)).First();
                hs.FkPacienteNavigation = pc;

                Historiaexploracion hex = context.Historiaexploracions.Where(p => p.FkHistoria == hs.IdHistoriaClinica).First();
                hs.Historiaexploracion = hex;

                Procquirurgico proc = context.Procquirurgicos.Where(p => p.FkHistoria == hs.IdHistoriaClinica).First();

                Doctore doc = context.Doctores.Where(p => p.IdDoctor == proc.FkDoctor).First();
                proc.FkDoctorNavigation = doc;

		        Evolucion evo = context.Evolucions.Where(p => p.FkHistoria == hs.IdHistoriaClinica).First();
		        hs.Evolucion = evo;

		        Estudioanatomo estudio = context.Estudioanatomos.Where(p => p.FkHistoria == hs.IdHistoriaClinica).First();
		        hs.Estudioanatomo = estudio;

                hs.Procquirurgico = proc;

                return hs;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getHistoriaByNumExp(string numExpe)
        {
            try
            {
                IQueryable<Historiaclinica> historias = context.Historiaclinicas.Where(h => h.FkPaciente == numExpe);

                if (historias.Count() == 0)
                    return new
                    {
                        status = "vacio"
                    };

				return historias.Select(hi => new {
                    IdHistoriaClinica = hi.IdHistoriaClinica,
                    FkHospital = hi.FkHospital,
                    FkPaciente = hi.FkPaciente,
                    FechaElab = hi.FechaElab
                }).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Motivosolicitud getClassMotivo(int idHistoria)
        {
            try
            {
                return context.Motivosolicituds.Where(m => m.FkHistoria == idHistoria).FirstOrDefault();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public object getMotivoSolicitudByIdHist(int idHistoria)
        {
            try
            {
                return context.Motivosolicituds.Where(m => m.FkHistoria == idHistoria).Select(mo => new {
                    FkHistoria = mo.FkHistoria,
                    CaudaNoHijos = mo.CausaNoHijos,
                    FkOpinion = mo.FkOpinion,
                    FkMetodoPlanificacion = mo.FkMetodoPlanificacion
                }).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getHistoriaexploracionByIdHist(int idHistoria)
        {
            try
            {
                return context.Historiaexploracions.Where(h => h.FkHistoria == idHistoria).Select(he => new {
                    FkHistoria = he.FkHistoria,
                    AntFamiliares = he.AntFamiliares,
                    AntPersonalesNoPat = he.AntPersonalesNoPat,
                    AntPersonalesPat = he.AntPersonalesPat,
                    Ta = he.Ta,
                    Peso = he.Peso,
                    Talla = he.Talla,
                    Fc = he.Fc,
                    Fr = he.Fr,
                    Tem = he.Tem,
                    ExpOrganos = he.ExpOrganos,
                    TipoPaciente = he.TipoPaciente
                }).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getProcedimientoQuirurgicoByIdHist(int idHistoria)
        {
            try
            {
                return context.Procquirurgicos.Where(p => p.FkHistoria == idHistoria).Select(pq => new {
                    FkHistoria = pq.FkHistoria,
                    FechaCirugia = pq.FechaCirugia,
                    FkDoctor = pq.FkDoctor,
                    NotaQuirurgica = pq.NotaQuirurgica,
                    Patologia = pq.Patologia
                }).First();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public object getEstudioAnatomo(int idHistoria)
        {
            try
            {
                return context.Estudioanatomos.Where(e => e.FkHistoria == idHistoria).Select(ea => new {
                    FkHistoria = ea.FkHistoria,
                    FechaEnvio = ea.FechaEnvio,
                    Clave = ea.Clave,
                    Resultado = ea.Resultado
                }).First();
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        public object getEvolucionByIdHist(int idHistoria)
        {
            try
            {
                return context.Evolucions.Where(e => e.FkHistoria == idHistoria).Select(ev => new {
                    FkHistoria = ev.FkHistoria,
                    Complicaciones = ev.Complicaciones,
                    Espermaconteo = ev.Espermaconteo,
                    Fecha1 = ev.Fecha1,
                    Resultado1 = ev.Resultado1,
                    Fecha2 = ev.Fecha2,
                    Resultado2 = ev.Resultado2
                }).First();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
