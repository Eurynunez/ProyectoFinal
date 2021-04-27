using BussinesLayer.Servicios;
using DataBase.Modelo;
using ProyectoFinal.Forms.Mantenimientos.ManttoPruebas.SingletonPruebas;
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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoPruebas
{
    public partial class FrmEditarPrueba : Form
    {
        private ServicioPruebasLab servicio;
        public FrmEditarPrueba()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPruebasLab(connection);
            InitializeComponent();
        }

        #region Eventos
        private void FrmEditarPrueba_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            RepositorioPruebaEditar.Instancia.Pruebas.Clear();
            FrmManttoPruebas manttoPruebas = new FrmManttoPruebas();
            manttoPruebas.Show();
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            EditarPrueba();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion

        #region Metodos

        private void CargarDatos()
        {
            TxtNombre.Text = RepositorioPruebaEditar.Instancia.Pruebas[0].Nombre;
        }

        private void LimpiarCampos()
        {
            TxtNombre.Clear();
        }

        private void EditarPrueba()
        {
            PruebasLab pruebas = new PruebasLab
            {
                Id = RepositorioPruebaEditar.Instancia.Pruebas[0].Id,
                Nombre = TxtNombre.Text
            };

            if (TxtNombre.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Notificacion");
            }
            else
            {
                bool respuesta = servicio.EditarPrueba(pruebas);

                if (respuesta)
                {
                    MessageBox.Show("La prueba ha sido modificada correctamente", "Notificacion");
                    FrmManttoPruebas manttoPruebas = new FrmManttoPruebas();
                    manttoPruebas.Show();
                    this.Close();
                    RepositorioPruebaEditar.Instancia.Pruebas.Clear();
                }
                else
                {
                    MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos", "Error");
                    LimpiarCampos();
                }
            }

        }

        #endregion
    }
}
