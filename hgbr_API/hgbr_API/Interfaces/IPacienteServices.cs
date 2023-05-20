using System;
using System.Linq;
using hgbr_API.Models;

namespace hgbr_API.Interfaces
{
    public interface IPacienteServices
    {
        IQueryable<object> getAll();
        Pacientesarch getClassPaciente(string numExpediente);
        object getPaciente(string numExpediente);
        void savePaciente(Pacientesarch paciente);
        void updatePaciente(Pacientesarch paciente);
        void deletePaciente(string numExpediente);
    }
}