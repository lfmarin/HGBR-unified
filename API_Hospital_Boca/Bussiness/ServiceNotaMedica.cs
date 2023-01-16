using API_Hospital_Boca.Models;
using API_Hospital_Boca.Services;
using API_Hospital_Boca.Utilities;
using System.Linq;

namespace API_Hospital_Boca.Bussiness
{
    public class ServiceNotaMedica : IServiceNotaMedica
    {
        private readonly hospital_bocaContext context;

        public ServiceNotaMedica(hospital_bocaContext context)
        {
            this.context = context;
        }

        public object getNotaMedicaByNumExp(string numExp)
        {
            var ficha = context.Fichaidentificacions.Where(f => f.FkPaciente.Equals(numExp)).First();
            return context.Notamedicas.Where(n => n.FkFicha == ficha.IdFicha).Select(nm => new {
                FkFicha = nm.FkFicha,
                FechaHora = nm.FechaHora,
                SignosVitales = nm.SignosVitales,
                DiagnosticoPre = nm.DiagnosticoPre,
                CirugiaProgramada = nm.CirugiaProgramada,
                FechaCirugia  = nm.FechaCirugia,
                TipoAnestesia = nm.TipoAnestesia,
                Preparacion = nm.Preparacion,
                FkDoctor = nm.FkDoctor,
                DiagnosticoPost = nm.DiagnosticoPost,
                Complicaciones = nm.Complicaciones,
                Descripcion = nm.Descripcion
            }).First();
        }

        public void saveNotaMedica(Notamedica nota)
        {
            try
            {
                context.Notamedicas.Add(nota);
                context.SaveChanges();   
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void updateNotaMedica(Notamedica nota)
        {
            var notaVieja = context.Notamedicas.Where(n => n.FkFicha == nota.FkFicha).First();
            
            if (!Utils.isTheSame(notaVieja.FechaHora, nota.FechaHora)) notaVieja.FechaHora = nota.FechaHora;
            if (!Utils.isTheSame(notaVieja.SignosVitales, nota.SignosVitales)) notaVieja.SignosVitales = nota.SignosVitales;
            if (!Utils.isTheSame(notaVieja.DiagnosticoPre, nota.DiagnosticoPre)) notaVieja.DiagnosticoPre = nota.DiagnosticoPre;
            if (!Utils.isTheSame(notaVieja.CirugiaProgramada, nota.CirugiaProgramada)) notaVieja.CirugiaProgramada = nota.CirugiaProgramada;
            if (!Utils.isTheSame(notaVieja.FechaCirugia, nota.FechaCirugia)) notaVieja.FechaCirugia = nota.FechaCirugia;
            if (!Utils.isTheSame(notaVieja.TipoAnestesia, nota.TipoAnestesia)) notaVieja.TipoAnestesia = nota.TipoAnestesia;
            if (!Utils.isTheSame(notaVieja.Preparacion, nota.Preparacion)) notaVieja.Preparacion = nota.Preparacion;
            if (!Utils.isTheSame(notaVieja.FkDoctor, nota.FkDoctor)) notaVieja.FkDoctor = nota.FkDoctor;
            if (!Utils.isTheSame(notaVieja.DiagnosticoPost, nota.DiagnosticoPost)) notaVieja.DiagnosticoPost = nota.DiagnosticoPost;
            if (!Utils.isTheSame(notaVieja.Complicaciones, nota.Complicaciones)) notaVieja.Complicaciones = nota.Complicaciones;
            if (!Utils.isTheSame(notaVieja.Descripcion, nota.Descripcion)) notaVieja.Descripcion = nota.Descripcion;

            context.SaveChanges();

        }
    }
}