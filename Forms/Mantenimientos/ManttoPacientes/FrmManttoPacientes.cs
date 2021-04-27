using BussinesLayer.Servicios;
using DataBase.Modelo;
using ProyectoFinal.Forms.Mantenimientos.ManttoPacientes.SingletonPacientes;
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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoPacientes
{
    public partial class FrmManttoPacientes : Form
    {
        private ServicioPacientes servicio;
        int _Id;
        string Nombre;
        string Apellido;
        string Telefono;
        string Direccion;
        string Cedula;
        string FechaNacimiento;
        string Fumador;
        string Alergias;
        string Foto;

        public FrmManttoPacientes()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPacientes(connection);
            int _Id = 0;
            string Nombre = "";
            string Apellido = "";
            string Telefono = "";
            string Direccion = "";
            string Cedula = "";
            string FechaNacimiento = "";
            string Fumador = "";
            string Alergias = "";
            string Foto = "";
            InitializeComponent();
        }

        #region Eventos
        private void FrmManttoPacientes_Load(object sender, EventArgs e)
        {
            ListarPacientes();
        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmHome home = new FrmHome();
            home.Show();
            this.Close();
        }

        private void PbNuevoMedico_Click(object sender, EventArgs e)
        {
            FrmNuevoPaciente nuevoPaciente = new FrmNuevoPaciente();
            nuevoPaciente.Show();
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            PacienteEditar();
        }

        private void DgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDeseleccionar.Visible = true;
                _Id = Convert.ToInt32(DgvPacientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                Nombre = (DgvPacientes.Rows[e.RowIndex].Cells[1].Value.ToString());
                Apellido = (DgvPacientes.Rows[e.RowIndex].Cells[2].Value.ToString());
                Telefono = (DgvPacientes.Rows[e.RowIndex].Cells[3].Value.ToString());
                Direccion = (DgvPacientes.Rows[e.RowIndex].Cells[4].Value.ToString());
                Cedula = (DgvPacientes.Rows[e.RowIndex].Cells[5].Value.ToString());
                FechaNacimiento = (DgvPacientes.Rows[e.RowIndex].Cells[6].Value.ToString());
                Fumador = (DgvPacientes.Rows[e.RowIndex].Cells[7].Value.ToString());
                Alergias = (DgvPacientes.Rows[e.RowIndex].Cells[8].Value.ToString());
                Foto = servicio.ObtenerFoto(_Id);
                CargarDatos();
            }
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPaciente();
        }
        #endregion


        #region Metodos

        private void ListarPacientes()
        {
            DgvPacientes.DataSource = servicio.Listar();
            DgvPacientes.ClearSelection();
        }

        private void CargarDatos()
        {
            LblNombre.Text = Nombre;
            LblApellido.Text = Apellido;
            LblTelefono.Text = Telefono;
            LblCedula.Text = Cedula;
            LblFechaNacimiento.Text = FechaNacimiento;
            LblFumador.Text = "Fumador: " + Fumador;
            LblAlergias.Text = "Alergias: " + Alergias;
            PbFotoDePerfil.ImageLocation = Foto;

        }

        private void Deseleccionar()
        {
            BtnDeseleccionar.Visible = false;

            //Variables
            _Id = 0;
            Nombre = "";
            Apellido = "";
            Telefono = "";
            Direccion = "";
            Cedula = "";
            FechaNacimiento = "";
            Fumador = "";
            Alergias = "";
            Foto = "";

            //Labels

            LblNombre.Text = "";
            LblApellido.Text = "";
            LblTelefono.Text = "";
            LblFechaNacimiento.Text = "";
            LblCedula.Text = "";
            LblFumador.Text = "";
            LblAlergias.Text = "";
            PbFotoDePerfil.ImageLocation = "";

            DgvPacientes.ClearSelection();
        }

        private void PacienteEditar()
        {
            if (_Id > 0)
            {
                Paciente paciente = new Paciente
                {
                    Id = _Id,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Telefono = Telefono,
                    Direccion = Direccion,
                    Cedula = Cedula,
                    FechaNacimiento = FechaNacimiento,
                };
                RepositorioPacienteEditar.Instancia.pacientes.Add(paciente);
                FrmEditarPaciente editarPaciente = new FrmEditarPaciente();
                editarPaciente.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un paciente", "Notificacion");
            }
        }

        private void EliminarPaciente()
        {
            if (_Id > 0)
            {
                DialogResult result = MessageBox.Show("¿Estas seguro que deseas eliminar este Paciente?", "¡Advertencia!", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    bool respuesta = servicio.Eliminar(_Id);

                    if (respuesta)
                    {
                        MessageBox.Show("El Paciente ha sido eliminado correctamente", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos", "Error");
                    }
                }
                ListarPacientes();
                Deseleccionar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Paciente", "Notificacion");
            }
        }
        #endregion
    }
}
