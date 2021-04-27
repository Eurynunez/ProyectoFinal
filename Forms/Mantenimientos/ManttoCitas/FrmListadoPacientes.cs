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
    public partial class FrmListadoPacientes : Form
    {
        ServicioPacientes servicio;
        int _Id;
        public FrmListadoPacientes()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPacientes(connection);
            _Id = 0;
            InitializeComponent();
        }

        #region Eventos
        private void FrmListadoPacientes_Load(object sender, EventArgs e)
        {
            ListarPacientes();
        }

        private void PbBuscar_Click(object sender, EventArgs e)
        {
            ListarPorCedula();
        }

        private void DgvListadoPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnQuitarSeleccion.Visible = true;
                BtnSiguiente.Visible = true;
                _Id = Convert.ToInt32(DgvListadoPacientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                TxtNombre.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                TxtApellido.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtCedula.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                TxtFechaNacimiento.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[6].Value.ToString();
                TxtFumador.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[7].Value.ToString();
                TxtAlergias.Text = DgvListadoPacientes.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private void BtnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {

             FrmListadoMedicos listadoMedicos = new FrmListadoMedicos();
             listadoMedicos.Show();
             this.Close();
         
        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmManttoCitas manttoCitas = new FrmManttoCitas();
            manttoCitas.Show();
            this.Close();
        }
        #endregion

        #region Metodos

        private void ListarPacientes()
        {
             DgvListadoPacientes.DataSource = servicio.Listar();
             DgvListadoPacientes.ClearSelection();
        }

        private void ListarPorCedula()
        {
            Paciente paciente = new Paciente
            {
                Cedula = TxtFiltrarCedula.Text
            };

            servicio.ListarPorCedula(paciente);

            _Id = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Id;
            TxtNombre.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Nombre;
            TxtApellido.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Apellido;
            TxtCedula.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Cedula;
            TxtFechaNacimiento.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].FechaNacimiento;
            TxtFumador.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Fumador;
            TxtAlergias.Text = RepositorioPacienteFiltrado.Instancia.PacienteFiltrado[0].Alergias;

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
            TxtFechaNacimiento.Clear();
            TxtFumador.Clear();
            TxtAlergias.Clear();
            _Id = 0;
            DgvListadoPacientes.ClearSelection();
            RepositorioPacienteFiltrado.Instancia.PacienteFiltrado.Clear();
        }

        private void Siguiente()
        {

        }

        
        #endregion
    }
}
