using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelo
{
    public class Resultados
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdCita { get; set; }

        public int IdPrueba { get; set; }

        public int IdDoctor { get; set; }

        public string Resultado { get; set; }

        public int IdEstado { get; set; }
    }
}
