using BussinesLayer.Servicios;
using DataBase.Modelo;
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
    public partial class FrmNuevaPrueba : Form
    {
        private ServicioPruebasLab servicio;
        public FrmNuevaPrueba()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPruebasLab(connection);
            InitializeComponent();
        }

        #region Eventos
        private void FrmNuevaPrueba_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoPruebas manttoPruebas = new FrmManttoPruebas();
            manttoPruebas.Show();
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPrueba();
        }
        #endregion

        #region Metodos

        private void AgregarPrueba()
        {
            PruebasLab pruebasLab = new PruebasLab
            {
                Nombre = TxtNombre.Text
            };

            if (TxtNombre.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Notificacion");
            }
            else
            {
                bool respuesta = servicio.AgregarPrueba(pruebasLab);

                if (respuesta)
                {
                    MessageBox.Show($"La prueba {pruebasLab.Nombre} ha sido agregada correctamente", "Notificacion");
                    FrmManttoPruebas manttoPruebas = new FrmManttoPruebas();
                    manttoPruebas.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos");
                    LimpiarCampos();
                }
            }
        }

        private void LimpiarCampos()
        {
            TxtNombre.Clear();
        }

        #endregion
    }
}
