using System.Linq;
using API_Hospital_Boca.Models;

namespace API_Hospital_Boca.Services
{
    public interface IServicePacientes
    {
        IQueryable<object> getAll();
        Paciente getClassPaciente(string numExpediente);
        object getPaciente(string numExpediente);
        void savePaciente(Paciente pa);
        void updatePaciente(Paciente pa);
        void deletPaciente(string numExpediente);
    }
}
