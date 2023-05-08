using System;
using System.Linq;
using hgbr_API.Models;

namespace hgbr_API.Interfaces
{
    public interface IPacienteServices
    {
        IQueryable<object> getAll();
        Paciente getClassPaciente(string numExpediente);
        object getPaciente(string numExpediente);
        void savePaciente(Paciente paciente);
        void updatePaciente(Paciente paciente);
        void deletePaciente(string numExpediente);
    }
}