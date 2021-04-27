using BussinesLayer.Servicios;
using DataBase.Modelo;
using DataBase.RepositorioUsuario;
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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoCitas
{
    public partial class FrmListadoMedicos : Form
    {
        ServicioMedicos servicio;
        int _Id;
        public FrmListadoMedicos()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioMedicos(connection);
            _Id = 0;
            InitializeComponent();
        }

        #region Eventos
        private void FrmListadoMedicos_Load(object sender, EventArgs e)
        {
            ListarPacientes();
        }

        private void PbBuscar_Click(object sender, EventArgs e)
        {
            ListarPorCedula();
        }

        private void BtnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            FrmNuevaCita nuevaCita = new FrmNuevaCita();
            nuevaCita.Show();
            this.Close();
        }
        private void DgvListadoMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnQuitarSeleccion.Visible = true;
                BtnSiguiente.Visible = true;
                _Id = Convert.ToInt32(DgvListadoMedicos.Rows[e.RowIndex].Cells[0].Value.ToString());
                TxtNombre.Text = DgvListadoMedicos.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtApellido.Text = DgvListadoMedicos.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtCorreo.Text = DgvListadoMedicos.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtTelefono.Text = DgvListadoMedicos.Rows[e.RowIndex].Cells[4].Value.ToString();
                TxtCedula.Text = DgvListadoMedicos.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
        #endregion

        #region Metodos

        private void ListarPacientes()
        {
            DgvListadoMedicos.DataSource = servicio.Listar();
            DgvListadoMedicos.ClearSelection();
        }

        private void ListarPorCedula()
        {
            Medicos medicos = new Medicos
            {
                Cedula = TxtFiltrarCedula.Text
            };

            servicio.ListarPorCedula(medicos);

            _Id = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Id;
            TxtNombre.Text = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Nombre;
            TxtApellido.Text = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Apellido;
            TxtCedula.Text = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Cedula;
            TxtTelefono.Text = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Telefono;
            TxtCorreo.Text = RepositorioMedicoFiltrado.Instancia.MedicoFiltrado[0].Correo;

            if (_Id > 0)
            {
                BtnQuitarSeleccion.Visible = true;
                BtnSiguiente.Visible = true;
            }

            TxtFiltrarCedula.ReadOnly = true;
        }

        private void Deseleccionar()
        {
            BtnQuitarSeleccion.Visible = false;
            BtnSiguiente.Visible = false;
            TxtFiltrarCedula.Clear();
            TxtFiltrarCedula.ReadOnly = false;
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCedula.Clear();
            TxtTelefono.Clear();
            TxtCorreo.Clear();
            _Id = 0;
            DgvListadoMedicos.ClearSelection();
            RepositorioMedicoFiltrado.Instancia.MedicoFiltrado.Clear();
        }

        #endregion
    }
}
