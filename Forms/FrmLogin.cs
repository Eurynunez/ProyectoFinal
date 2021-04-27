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
using BussinesLayer.Servicios;
using DataBase.RepositorioUsuario;
using DataBase.Modelo;

namespace ProyectoFinal.Forms
{
    public partial class FrmLogin : Form
    {
        public static FrmLogin Instancia = new FrmLogin();

        ServicioUsuario servicio;
        private FrmLogin()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioUsuario(connection);
            InitializeComponent();
        }

        #region Eventos
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        #endregion

        #region Metodos

        private void IniciarSesion()
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = TxtUsuario.Text,
                Contrasena = TxtContrasena.Text
            };

            servicio.ValidacionDeUsuario(usuario);

            if (RepositorioUsuarioLogin.Instancia.UsuarioLogin.Count > 0)
            {
                if (usuario.NombreUsuario == RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].NombreUsuario && usuario.Contrasena == RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].Contrasena)
                {
                    FrmHome home = new FrmHome();
                    home.Show();
                    FrmLogin.Instancia.Hide();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("El Usuario o la Contraseña son incorrectos, porfavor intente ingresar nuevamente");
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            TxtUsuario.Clear();
            TxtContrasena.Clear();
        }
        #endregion

    }
}
