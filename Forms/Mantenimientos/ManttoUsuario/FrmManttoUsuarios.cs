using BussinesLayer.Servicios;
using DataBase.Modelo;
using ProyectoFinal.Forms.Mantenimientos.ManttoUsuario.SingletonUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoUsuario
{
    public partial class FrmManttoUsuarios : Form
    {
        ServicioUsuario servicioUsuario;
        public int Id;
        public string Nombre;
        public string Apellido;
        public string Correo;
        public string NombreUsuario;

        public FrmManttoUsuarios()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicioUsuario = new ServicioUsuario(connection);
            Id = 0;
            Nombre = "";
            Apellido = "";
            Correo = "";
            NombreUsuario = "";
            InitializeComponent();
        }

        #region Eventos

        private void FrmManttoUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void FrmManttoUsuarios_VisibleChanged(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmHome home = new FrmHome();
            home.Show();
            this.Close();
        }

        private void PbNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmNuevoUsuario nuevoUsuario = new FrmNuevoUsuario();
            nuevoUsuario.Show();
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                CargarDatos();
                FrmEditarUsuario editarUsuario = new FrmEditarUsuario();
                editarUsuario.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario", "Notificacion");
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Id = Convert.ToInt32(DgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                Nombre = DgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                Apellido = DgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                Correo = DgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                NombreUsuario = DgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
                BtnDeseleccionar.Visible = true;
            }
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }
        #endregion

        #region Metodos

        private void ListarUsuarios()
        {
            DgvUsuarios.DataSource = servicioUsuario.Listar();
            DgvUsuarios.ClearSelection();
        }

        private void EliminarUsuario()
        {

            if (Id > 0)
            {

                DialogResult result = MessageBox.Show("¿Estas seguro que deseas eliminar este usuario?", "¡Advertencia!", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    bool respuesta = servicioUsuario.Eliminar(Id);

                    if (respuesta)
                    {
                        MessageBox.Show("Usuario eliminado correctamente", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un usuario", "Notificacion");
            }
            Deseleccionar();
            ListarUsuarios();
        }

        private void Deseleccionar()
        {
            DgvUsuarios.ClearSelection();
            BtnDeseleccionar.Visible = false;
            Id = 0;
            Nombre = "";
            Apellido = "";
            Correo = "";
            NombreUsuario = "";
        }

        private void CargarDatos()
        {
            Usuario usuario = new Usuario
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Correo = Correo,
                NombreUsuario = NombreUsuario
            };

            RepositorioUsuarioEditar.Instancia.usuarios.Add(usuario);
        }

        #endregion
    }
}
