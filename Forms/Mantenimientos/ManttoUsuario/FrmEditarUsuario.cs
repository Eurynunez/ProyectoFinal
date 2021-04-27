using BussinesLayer.Servicios;
using DataBase.Modelo;
using DataBase.RepositorioUsuario;
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
    public partial class FrmEditarUsuario : Form
    {
        ServicioUsuario servicio;

        public FrmEditarUsuario()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioUsuario(connection);

            InitializeComponent();
        }

        #region Eventos
        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {
            CargarDatosEditar();
        }

        private void FrmEditarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            CargarDatosEditar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoUsuarios manttoUsuarios = new FrmManttoUsuarios();
            manttoUsuarios.Show();
            this.Close();
            RepositorioUsuarioEditar.Instancia.usuarios.Clear();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            EditarUsuario();
        }
        #endregion

        #region Metodos

        private void EditarUsuario()
        {
            Usuario usuario = new Usuario
            {
                Id = RepositorioUsuarioEditar.Instancia.usuarios[0].Id,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Correo = TxtCorreo.Text,
                NombreUsuario = TxtNombreUsuario.Text,
                Contrasena = TxtContrasena.Text,
                IdTipoUsuario = RbtnAdministrador.Checked == true ? 1 : 2
            };
            if (TxtNombre.Text == null | TxtApellido.Text == null | TxtCorreo.Text == null | TxtNombreUsuario.Text == null | TxtContrasena.Text == "" | TxtConfirmarContrasena.Text == "")
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (RbtnAdministrador.Checked == false && RbtnMedico.Checked == false)
            {
                MessageBox.Show("Debe seleccionar el tipo de usuario", "Notificacion");
            }
            else if (TxtConfirmarContrasena.Text != TxtContrasena.Text)
            {
                MessageBox.Show("La contraseña debe ser igual en ambos campos");
                TxtContrasena.Clear();
                TxtConfirmarContrasena.Clear();
            }
            else
            {
                bool respuesta = servicio.Editar(usuario);

                if (respuesta)
                {
                    MessageBox.Show($"El usuario ha sido modificado correctamente");
                    RepositorioUsuarioEditar.Instancia.usuarios.Clear();
                    FrmManttoUsuarios usuarios = new FrmManttoUsuarios();
                    usuarios.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Lo sentimos, ha ocurrido un error en la base de datos");
                }
            }
        }

        private void CargarDatosEditar()
        {
            TxtNombre.Text = RepositorioUsuarioEditar.Instancia.usuarios[0].Nombre;
            TxtApellido.Text = RepositorioUsuarioEditar.Instancia.usuarios[0].Apellido;
            TxtCorreo.Text = RepositorioUsuarioEditar.Instancia.usuarios[0].Correo;
            TxtNombreUsuario.Text = RepositorioUsuarioEditar.Instancia.usuarios[0].NombreUsuario;
        }

        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCorreo.Clear();
            TxtNombreUsuario.Clear();
            TxtContrasena.Clear();
            TxtConfirmarContrasena.Clear();
            RbtnAdministrador.Checked = false;
            RbtnMedico.Checked = false;
        }
        #endregion
    }
}
