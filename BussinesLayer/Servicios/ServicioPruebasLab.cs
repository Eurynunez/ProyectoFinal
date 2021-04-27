using DataBase.Modelo;
using DataBase.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Servicios
{
    public class ServicioPruebasLab
    {
        private RepositorioPruebas repositorio;

        public ServicioPruebasLab(SqlConnection connection)
        {
            repositorio = new RepositorioPruebas(connection);
        }

        public bool AgregarPrueba(PruebasLab item)
        {
            return repositorio.AgregarPrueba(item);
        }

        public bool EditarPrueba(PruebasLab item)
        {
            return repositorio.EditarPrueba(item);
        }

        public bool EliminarPrueba(int Id)
        {
            return repositorio.Eliminar(Id); ;
        }

        public DataTable ListarPruebas()
        {
            return repositorio.Listar();
        }
    }
}
