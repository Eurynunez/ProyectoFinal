using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoMedicos.SingletonMedicos
{
    public class RepositorioMedicosEditar
    {
        public static RepositorioMedicosEditar Instancia { get; } = new RepositorioMedicosEditar();

        public List<Medicos> medicoEditar = new List<Medicos>();
        private RepositorioMedicosEditar()
        {

        }
    }
}
