using DataBase.Modelo;
using DataBase.RepositorioUsuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositorios
{
    public class RepositorioMedicos
    {
        private SqlConnection _connection;

        public RepositorioMedicos(SqlConnection connection)
        {
            _connection = connection;
        }

        #region Metodos para Agregar, Editar y Eliminar Medicos
        public bool Agregar(Medicos item)
        {
            SqlCommand command = new SqlCommand("Insert into MEDICOS (NOMBRE, APELLIDO, CORREO, TELEFONO, CEDULA) VALUES (@Nombre, @Apellido, @Correo, @Telefono, @Cedula)", _connection);

            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Correo", item.Correo);
            command.Parameters.AddWithValue("@Telefono", item.Telefono);
            command.Parameters.AddWithValue("@Cedula", item.Cedula);

            return ExecuteDML(command);
        }

        public bool Editar(Medicos item)
        {
            SqlCommand command = new SqlCommand("Update MEDICOS set NOMBRE = @Nombre, APELLIDO = @Apellido, CORREO = @Correo, TELEFONO = @Telefono, CEDULA = @Cedula WHERE ID = @Id", _connection);

            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Correo", item.Correo);
            command.Parameters.AddWithValue("@Telefono", item.Telefono);
            command.Parameters.AddWithValue("@Cedula", item.Cedula);

            return ExecuteDML(command);
        }

        public bool Eliminar(int Id)
        {
            SqlCommand command = new SqlCommand("Delete MEDICOS Where ID = @Id", _connection);

            command.Parameters.AddWithValue("@Id", Id);

            return ExecuteDML(command);
        }

        public bool GuardarFoto(int Id, string Destino)
        {
            SqlCommand command = new SqlCommand("Update MEDICOS set FOTO = @Foto Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Foto", Destino);
            command.Parameters.AddWithValue("@Id", Id);

            return ExecuteDML(command);
        }
        public DataTable Listar()
        {
            SqlDataAdapter ListUsuarios = new SqlDataAdapter("Select ID, NOMBRE, APELLIDO, CORREO, TELEFONO, CEDULA from MEDICOS",_connection);

            return CargarData(ListUsuarios);
        }

        public Medicos ListarPorCedula(Medicos item)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select ID, NOMBRE, APELLIDO, CEDULA, TELEFONO, CORREO From MEDICOS Where CEDULA = @Cedula", _connection);

            command.Parameters.AddWithValue("@Cedula", item.Cedula);

            SqlDataReader reader = command.ExecuteReader();

            Medicos medicos = new Medicos();

            while (reader.Read())
            {
                medicos.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                medicos.Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                medicos.Apellido = reader.IsDBNull(2) ? "" : reader.GetString(2);
                medicos.Correo = reader.IsDBNull(3) ? "" : reader.GetString(3);
                medicos.Telefono = reader.IsDBNull(4) ? "" : reader.GetString(4);
                medicos.Cedula = reader.IsDBNull(5) ? "" : reader.GetString(5);

                RepositorioMedicoFiltrado.Instancia.MedicoFiltrado.Add(medicos);
            }

            reader.Close();
            reader.Dispose();

            _connection.Close();

            return medicos;
        }

        public string ObtenerFoto(int Id)
        {
            string Foto = "";

            _connection.Open();

            SqlCommand command = new SqlCommand("Select FOTO from MEDICOS where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Foto = reader.IsDBNull(0) ? "" : reader.GetString(0);
            }

            reader.Close();
            reader.Dispose();

            _connection.Close();

            return Foto;
        }

        public int UltimoId()
        {
            int UltimoId = 0;

            _connection.Open();

            SqlCommand command = new SqlCommand("Select MAX(ID) as ID from MEDICOS",_connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UltimoId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            }

            reader.Close();
            reader.Dispose();

            _connection.Close();

            return UltimoId;
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
