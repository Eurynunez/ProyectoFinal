using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoPacientes.SingletonPacientes
{
    public class RepositorioPacienteEditar
    {
        public static RepositorioPacienteEditar Instancia { get; } = new RepositorioPacienteEditar();

        public List<Paciente> pacientes = new List<Paciente>();
        private RepositorioPacienteEditar()
        {

        }
    }
}
