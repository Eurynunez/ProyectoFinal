using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.Forms.Mantenimientos.ManttoUsuario;
using ProyectoFinal.Forms.Mantenimientos.ManttoMedicos;
using ProyectoFinal.Forms.Mantenimientos.ManttoPruebas;
using ProyectoFinal.Forms.Mantenimientos.ManttoPacientes;
using ProyectoFinal.Forms.Mantenimientos.ManttoCitas;
using ProyectoFinal.Forms.Mantenimientos.ManttoResultados;
using DataBase.RepositorioUsuario;

namespace ProyectoFinal.Forms
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmHome_Load(object sender, EventArgs e)
        {
            InformacionUsuario();
        }

        private void FrmHome_VisibleChanged(object sender, EventArgs e)
        {
            InformacionUsuario();
        }

        private void BtnManttoUsuario_Click(object sender, EventArgs e)
        {
            FrmManttoUsuarios manttoUsuarios = new FrmManttoUsuarios();
            manttoUsuarios.Show();
            this.Close();
        }

        private void BtnManttoMedicos_Click(object sender, EventArgs e)
        {
            FrmManttoMedicos manttoMedicos = new FrmManttoMedicos();
            manttoMedicos.Show();
            this.Close();
        }

        private void BtnManttoPruebas_Click(object sender, EventArgs e)
        {
            FrmManttoPruebas manttoPruebas = new FrmManttoPruebas();
            manttoPruebas.Show();
            this.Close();
        }

        private void BtnManttoPacientes_Click(object sender, EventArgs e)
        {
            FrmManttoPacientes manttoPacientes = new FrmManttoPacientes();
            manttoPacientes.Show();
            this.Close();
        }

        private void BtnManttoCitas_Click(object sender, EventArgs e)
        {
            FrmManttoCitas manttoCitas = new FrmManttoCitas();
            manttoCitas.Show();
            this.Close();
        }

        private void BtnManttoResultados_Click(object sender, EventArgs e)
        {
            FrmManttoResultados manttoResultados = new FrmManttoResultados();
            manttoResultados.Show();
            this.Close();
        }

        private void PbCerrarSesion_Click_1(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        #endregion


        #region Metodos

        private void InformacionUsuario()
        {
            if (RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].IdTipoUsuario == 1)
            {
                //Nombre y tipo de usuario
                LblNombre.Text = RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].Nombre + " " + RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].Apellido;
                LblTipoUsuario.Text = "Administrativo";

                //Accesibilidad a las funcionalidades
                PbManttoPacientes.Visible = false;
                BtnManttoPacientes.Visible = false;

                PbManttoCitas.Visible = false;
                BtnManttoCitas.Visible = false;

                PbManttoResultados.Visible = false;
                BtnManttoResultados.Visible = false;
            }
            else
            {
                //Nombre y tipo de usuario
                LblNombre.Text = RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].Nombre + " " + RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].Apellido;
                LblTipoUsuario.Text = "Doctor";

                //Accesibilidad a las funcionalidades
                PbManttoUsuario.Visible = false;
                BtnManttoUsuario.Visible = false;

                PbManttoMedicos.Visible = false;
                BtnManttoMedicos.Visible = false;

                PbManttoPruebas.Visible = false;
                BtnManttoPruebas.Visible = false;
            }
        }

        private void CerrarSesion()
        {
            DialogResult result = MessageBox.Show($"¿Desea salir de la cuenta de {RepositorioUsuarioLogin.Instancia.UsuarioLogin[0].NombreUsuario}?","Notificacion",MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                RepositorioUsuarioLogin.Instancia.UsuarioLogin.Clear();
                FrmLogin.Instancia.Show();
                this.Close();
            }
        }

        #endregion
    }
}
