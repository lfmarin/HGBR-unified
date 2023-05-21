using System;
using System.Linq;
using hgbr_API.Models;

namespace hgbr_API.Interfaces
{
    public interface IPacientesArchServices
    {
        IQueryable<object> getAll();
        Pacientesarch getClassPacientesArch(string numExpediente);
        object getPacientesarch(string numExpediente);
        void savePacientesarch(Pacientesarch paciente);
        void updatePacientesarch(Pacientesarch paciente);
        void deletePacientesarch(string numExpediente);
    }
}