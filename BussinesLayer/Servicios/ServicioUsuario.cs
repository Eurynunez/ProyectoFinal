using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Modelo;
using DataBase.Repositorios;

namespace BussinesLayer.Servicios
{
    public class ServicioUsuario
    {
        private RepositorioUsuario repositorio;

        public ServicioUsuario(SqlConnection connection)
        {
            repositorio = new RepositorioUsuario(connection);
        }

        public bool Agregar(Usuario item)
        {
            return repositorio.Agregar(item);
        }

        public bool Editar(Usuario item)
        {
            return repositorio.Editar(item);
        }

        public bool Eliminar(int Id)
        {
            return repositorio.Eliminar(Id);
        }

        public DataTable Listar()
        {
            return repositorio.Listar();
        }

        public Usuario ValidacionDeUsuario(Usuario item)
        {
            return repositorio.ValidacionDeUsuario(item);
        }
    }
}
