using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public int IdTipoUsuario { get; set; }
    }
}
