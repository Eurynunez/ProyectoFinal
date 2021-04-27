using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelo
{
    public class Citas
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdMedico { get; set; }

        public string Fecha { get; set; }

        public string Hora { get; set; }

        public string Causa { get; set; }

        public int IdEstado { get; set; }

    }
}
