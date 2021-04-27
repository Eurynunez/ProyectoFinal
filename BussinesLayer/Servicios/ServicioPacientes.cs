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
    public class ServicioPacientes
    {
        private RepositorioPacientes repositorio;

        public ServicioPacientes(SqlConnection connection)
        {
            repositorio = new RepositorioPacientes(connection);
        }

        public bool Agregar(Paciente item)
        {
            return repositorio.Agregar(item);
        }

        public bool Editar(Paciente item)
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

        public string ObtenerFoto(int Id)
        {
            return repositorio.ObtenerFoto(Id);
        }

        public int UltimoId()
        {
            return repositorio.UltimoId();
        }

        public bool GuardarFoto(int Id, string Destino)
        {
            return repositorio.GuardarFoto(Id, Destino);
        }

        public Paciente ListarPorCedula(Paciente item)
        {
            return repositorio.ListarPorCedula(item);
        }
    }

}
