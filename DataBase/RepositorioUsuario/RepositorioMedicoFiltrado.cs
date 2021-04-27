using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.RepositorioUsuario
{
    public class RepositorioMedicoFiltrado
    {
        public static RepositorioMedicoFiltrado Instancia { get; } = new RepositorioMedicoFiltrado();

        public List<Medicos> MedicoFiltrado = new List<Medicos>();

        private RepositorioMedicoFiltrado()
        {

        }
    }
}
