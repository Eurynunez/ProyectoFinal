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
    public class ServicioMedicos
    {
        private RepositorioMedicos repositorio;

        public ServicioMedicos(SqlConnection connection)
        {
            repositorio = new RepositorioMedicos(connection);
        }

        public bool Agregar(Medicos item)
        {
            return repositorio.Agregar(item);
        }

        public bool Editar(Medicos item)
        {
            return repositorio.Editar(item);
        }

        public bool Eliminar(int Id)
        {
            return repositorio.Eliminar(Id);
        }

        public bool GuardarFoto(int Id, string Destino)
        {
            return repositorio.GuardarFoto(Id, Destino);
        }

        public DataTable Listar()
        {
            return repositorio.Listar();
        }

        public int UltimoId()
        {
            return repositorio.UltimoId();
        }

        public string ObtenerFoto(int Id)
        {
            return repositorio.ObtenerFoto(Id);
        }

        public Medicos ListarPorCedula(Medicos item)
        {
            return repositorio.ListarPorCedula(item);
        }
    }
}
