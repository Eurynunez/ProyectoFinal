using DataBase.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositorios
{
    public class RepositorioPruebas
    {
        private SqlConnection _connection;

        public RepositorioPruebas(SqlConnection connection)
        {
            _connection = connection;
        }

        #region Metodos para Agregar, Editar y Eliminar Pruebas

        public bool AgregarPrueba(PruebasLab item)
        {
            SqlCommand command = new SqlCommand("Insert into PRUEBAS_LABORATORIO (NOMBRE) Values (@Nombre)",_connection);

            command.Parameters.AddWithValue("@Nombre", item.Nombre);

            return ExecuteDML(command);
        }

        public bool EditarPrueba(PruebasLab item)
        {
            SqlCommand command = new SqlCommand("Update PRUEBAS_LABORATORIO set NOMBRE = @Nombre Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Nombre", item.Nombre);

            return ExecuteDML(command);
        }

        public bool Eliminar(int Id)
        {
            SqlCommand command = new SqlCommand("Delete PRUEBAS_LABORATORIO Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", Id);

            return ExecuteDML(command);
        }

        public DataTable Listar()
        {
            SqlDataAdapter ListPruebas = new SqlDataAdapter("Select ID, NOMBRE from PRUEBAS_LABORATORIO", _connection);

            return CargarData(ListPruebas);
        }
        #endregion

        private bool ExecuteDML(SqlCommand query)
        {
            try
            {
                _connection.Open();

                query.ExecuteNonQuery();

                _connection.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private DataTable CargarData(SqlDataAdapter query)
        {
            try
            {
                _connection.Open();

                DataTable data = new DataTable();

                query.Fill(data);

                _connection.Close();

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
