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
    public partial class FrmManttoPruebas : Form
    {
        private ServicioPruebasLab servicio;
        int Id;
        string Nombre;
        public FrmManttoPruebas()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPruebasLab(connection);
            Id = 0;
            Nombre = "";
            InitializeComponent();
        }

        #region Eventos
        private void FrmManttoPruebas_Load(object sender, EventArgs e)
        {
            ListarPruebas();
        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmHome home = new FrmHome();
            home.Show();
            this.Close();
        }

        private void PbNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmNuevaPrueba nuevaPrueba = new FrmNuevaPrueba();
            nuevaPrueba.Show();
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                PruebaEditar();
                FrmEditarPrueba editarPrueba = new FrmEditarPrueba();
                editarPrueba.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una prueba", "Notificacion");
            }
        }

        private void DgvPruebas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Id = Convert.ToInt32(DgvPruebas.Rows[e.RowIndex].Cells[0].Value.ToString());
                Nombre = DgvPruebas.Rows[e.RowIndex].Cells[1].Value.ToString();
                BtnDeseleccionar.Visible = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPrueba();
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }
        #endregion

        #region Metodos

        private void ListarPruebas()
        {
            DgvPruebas.DataSource = servicio.ListarPruebas();
            DgvPruebas.ClearSelection();
        }

        private void EliminarPrueba()
        {
            if (Id > 0)
            {
                DialogResult result = MessageBox.Show("¿Estas seguro que deseas eliminar esta Prueba?", "Notificacion",MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    bool respuesta = servicio.EliminarPrueba(Id);

                    if (respuesta)
                    {
                        MessageBox.Show("Se ha eliminado la prueba correctamente", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una prueba", "Notificacion");
            }
            Deseleccionar();
            ListarPruebas();
        }

        private void Deseleccionar()
        {
            BtnDeseleccionar.Visible = false;
            DgvPruebas.ClearSelection();
            Id = 0;
            Nombre = "";
        }

        private void PruebaEditar()
        {
            PruebasLab pruebas = new PruebasLab
            {
                Id = Id,
                Nombre = Nombre
            };

            RepositorioPruebaEditar.Instancia.Pruebas.Add(pruebas);
        }
        #endregion
    }
}
