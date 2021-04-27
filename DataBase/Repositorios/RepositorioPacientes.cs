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
    public class RepositorioPacientes
    {
        private SqlConnection _connection;

        public RepositorioPacientes(SqlConnection connection)
        {
            _connection = connection;
        }

        #region Metodos para Agregar, Editar y Eliminar Pacientes
        public bool Agregar(Paciente item)
        {
            SqlCommand command = new SqlCommand("Insert into PACIENTE (NOMBRE, APELLIDO, TELEFONO, DIRECCION, CEDULA, FECHA_NACIMIENTO, FUMADOR, ALERGIAS) Values (@Nombre, @Apellido, @Telefono, @Direccion, @Cedula, @FechaNacimiento, @Fumador, @Alergias)",_connection);

            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Telefono", item.Telefono); 
            command.Parameters.AddWithValue("@Direccion", item.Direccion);
            command.Parameters.AddWithValue("@Cedula", item.Cedula);
            command.Parameters.AddWithValue("@FechaNacimiento", item.FechaNacimiento);
            command.Parameters.AddWithValue("@Fumador", item.Fumador);
            command.Parameters.AddWithValue("@Alergias", item.Alergias);

            return ExecuteDML(command);
        }

        public bool Editar(Paciente item)
        {
            SqlCommand command = new SqlCommand("Update PACIENTE set NOMBRE = @Nombre, APELLIDO = @Apellido, TELEFONO = @Telefono, DIRECCION = @Direccion, CEDULA = @Cedula, FECHA_NACIMIENTO = @FechaNacimiento, FUMADOR = @Fumador, ALERGIAS = @Alergias Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Telefono", item.Telefono); ;
            command.Parameters.AddWithValue("@Direccion", item.Direccion);
            command.Parameters.AddWithValue("@Cedula", item.Cedula);
            command.Parameters.AddWithValue("@FechaNacimiento", item.FechaNacimiento);
            command.Parameters.AddWithValue("@Fumador", item.Fumador);
            command.Parameters.AddWithValue("@Alergias", item.Alergias);

            return ExecuteDML(command);
        }

        public bool Eliminar(int Id)
        {
            SqlCommand command = new SqlCommand("Delete PACIENTE Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", Id);

            return ExecuteDML(command);
        }

        public DataTable Listar()
        {
            SqlDataAdapter ListPacientes = new SqlDataAdapter("Select ID, NOMBRE, APELLIDO, TELEFONO, DIRECCION, CEDULA, FECHA_NACIMIENTO, FUMADOR, ALERGIAS from PACIENTE",_connection);

            return CargarData(ListPacientes);
        }

        public string ObtenerFoto(int Id)
        {
            string Foto = "";

            _connection.Open();

            SqlCommand command = new SqlCommand("Select FOTO from PACIENTE where ID = @Id",_connection);

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

            SqlCommand command = new SqlCommand("Select MAX(ID) as ID from PACIENTE",_connection);

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

        public bool GuardarFoto(int Id, string Destino)
        {
            SqlCommand command = new SqlCommand("Update PACIENTE set FOTO = @Foto Where ID = @Id", _connection);

            command.Parameters.AddWithValue("@Foto", Destino);
            command.Parameters.AddWithValue("@Id", Id);

            return ExecuteDML(command);
        }

        public Paciente ListarPorCedula(Paciente item)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select ID, NOMBRE, APELLIDO, CEDULA, FECHA_NACIMIENTO, FUMADOR, ALERGIAS From PACIENTE Where CEDULA = @Cedula", _connection);

            command.Parameters.AddWithValue("@Cedula", item.Cedula);

            SqlDataReader reader = command.ExecuteReader();

            Paciente paciente = new Paciente();

            while (reader.Read())
            {
                paciente.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                paciente.Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1);
                paciente.Apellido = reader.IsDBNull(2) ? "" : reader.GetString(2);
                paciente.Cedula = reader.IsDBNull(3) ? "" : reader.GetString(3);
                paciente.FechaNacimiento = reader.IsDBNull(4) ? "" : reader.GetString(4);
                paciente.Fumador = reader.IsDBNull(5) ? "" : reader.GetString(5);
                paciente.Alergias = reader.IsDBNull(6) ? "" : reader.GetString(6);

                RepositorioPacienteFiltrado.Instancia.PacienteFiltrado.Add(paciente);
            }

            reader.Close();
            reader.Dispose();

            _connection.Close();

            return paciente;
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
