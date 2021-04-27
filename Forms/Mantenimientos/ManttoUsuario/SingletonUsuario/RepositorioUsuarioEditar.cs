using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoUsuario.SingletonUsuario
{
    public class RepositorioUsuarioEditar
    {
        public static RepositorioUsuarioEditar Instancia { get; } = new RepositorioUsuarioEditar();

        public List<Usuario> usuarios = new List<Usuario>();

        private RepositorioUsuarioEditar()
        {

        }
    }
}
