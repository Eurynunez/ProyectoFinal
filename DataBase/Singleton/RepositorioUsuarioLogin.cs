using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Modelo;

namespace DataBase.RepositorioUsuario
{
    public class RepositorioUsuarioLogin
    {
        public static RepositorioUsuarioLogin Instancia { get; } = new RepositorioUsuarioLogin();

        public List<Usuario> UsuarioLogin = new List<Usuario>();

        private RepositorioUsuarioLogin()
        {

        }
    }
}
