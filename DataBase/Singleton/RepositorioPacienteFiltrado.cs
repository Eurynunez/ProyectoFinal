using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.RepositorioUsuario
{
    public class RepositorioPacienteFiltrado
    {
        public static RepositorioPacienteFiltrado Instancia { get; } = new RepositorioPacienteFiltrado();

        public List<Paciente> PacienteFiltrado = new List<Paciente>();

        private RepositorioPacienteFiltrado()
        {

        }
    }
}
