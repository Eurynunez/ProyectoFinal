using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Modelo;
using DataBase.RepositorioUsuario;


namespace DataBase.Repositorios
{
    public class RepositorioUsuario
    {
        private SqlConnection _connection;

        public RepositorioUsuario (SqlConnection connection)
        {
            _connection = connection;
        }

        #region Metodos para Agregar, Editar y Eliminar Usuario

        public bool Agregar(Usuario item)
        {
            SqlCommand command = new SqlCommand("Insert into USUARIO (NOMBRE, APELLIDO, CORREO, NOMBRE_USUARIO, CONTRASENA, ID_TIPO_USUARIO) VALUES (@Nombre, @Apellido, @Correo, @NombreUsuario, @Contrasena, @IdTipoUsuario)",_connection);

            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Correo", item.Correo);
            command.Parameters.AddWithValue("@NombreUsuario", item.NombreUsuario);
            command.Parameters.AddWithValue("@Contrasena", item.Contrasena);
            command.Parameters.AddWithValue("@IdTipoUsuario", item.IdTipoUsuario);

            return ExecuteDML(command);
        }

        public bool Editar(Usuario item)
        {
            SqlCommand command = new SqlCommand("Update USUARIO set NOMBRE = @Nombre, APELLIDO = @Apellido, CORREO = @Correo, NOMBRE_USUARIO = @NombreUsuario, CONTRASENA = @Contrasena, ID_TIPO_USUARIO = @IdTipoUsuario WHERE ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Nombre", item.Nombre);
            command.Parameters.AddWithValue("@Apellido", item.Apellido);
            command.Parameters.AddWithValue("@Correo", item.Correo);
            command.Parameters.AddWithValue("@NombreUsuario", item.NombreUsuario);
            command.Parameters.AddWithValue("@Contrasena", item.Contrasena);
            command.Parameters.AddWithValue("@IdTipoUsuario", item.IdTipoUsuario);

            return ExecuteDML(command);
        }
        
        public bool Eliminar(int Id)
        {
            SqlCommand command = new SqlCommand("Delete USUARIO Where ID = @Id",_connection);

            command.Parameters.AddWithValue("@Id",Id);

            return ExecuteDML(command);
        }

        public DataTable Listar()
        {
            SqlDataAdapter ListUsuarios = new SqlDataAdapter("Select U.ID, U.NOMBRE, U.APELLIDO, U.CORREO, U.NOMBRE_USUARIO AS 'NOMBRE DE USUARIO', U.CONTRASENA AS 'CONTRASEÑA', TU.NOMBRE AS 'TIPO DE USUARIO' From USUARIO U INNER JOIN TIPO_USUARIO TU ON U.ID_TIPO_USUARIO = TU.ID", _connection);

            return CargarData(ListUsuarios);
        }
        #endregion
        
        public Usuario ValidacionDeUsuario(Usuario item)
        {
            _connection.Open();

            SqlCommand command = new SqlCommand("Select ID, NOMBRE, APELLIDO, NOMBRE_USUARIO, CONTRASENA, ID_TIPO_USUARIO From USUARIO Where NOMBRE_USUARIO = @NombreUsuario AND CONTRASENA = @Contrasena", _connection);

            command.Parameters.AddWithValue("@NombreUsuario", item.NombreUsuario);
            command.Parameters.AddWithValue("@Contrasena", item.Contrasena);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.IsDBNull(0) == false)
                {
                    if (item.NombreUsuario == reader.GetString(3) && item.Contrasena == reader.GetString(4))
                    {
                        item.Id = reader.GetInt32(0);
                        item.Nombre = reader.GetString(1);
                        item.Apellido = reader.GetString(2);
                        item.NombreUsuario = reader.GetString(3);
                        item.Contrasena = reader.GetString(4);
                        item.IdTipoUsuario = reader.GetInt32(5);

                        RepositorioUsuarioLogin.Instancia.UsuarioLogin.Add(item);
                    }
                }
                else
                {
                    item.NombreUsuario = null;
                    item.Contrasena = null;

                    RepositorioUsuarioLogin.Instancia.UsuarioLogin.Add(item);
                }
            }

            reader.Close();
            reader.Dispose();

            _connection.Close();

            return item;
        }
        #region Metodos para ejecutar Query
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
        #endregion
    }
}
