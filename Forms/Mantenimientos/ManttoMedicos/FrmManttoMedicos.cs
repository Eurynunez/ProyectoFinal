using BussinesLayer.Servicios;
using DataBase.Modelo;
using ProyectoFinal.Forms.Mantenimientos.ManttoMedicos.SingletonMedicos;
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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoMedicos
{
    public partial class FrmManttoMedicos : Form
    {
        private ServicioMedicos servicioMedicos;
        int Id;
        string Nombre;
        string Apellido;
        string Correo;
        string Telefono;
        string Cedula;
        string Foto;
        public FrmManttoMedicos()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicioMedicos = new ServicioMedicos(connection);
            Id = 0;
            Nombre = "";
            Apellido = "";
            Correo = "";
            Telefono = "";
            Cedula = "";
            Foto = "";
            InitializeComponent();
        }

        #region Eventos
        private void FrmManttoMedicos_Load(object sender, EventArgs e)
        {
            ListarMedicos();
        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmHome home = new FrmHome();
            home.Show();
            this.Close();
        }

        private void PbNuevoMedico_Click(object sender, EventArgs e)
        {
            FrmNuevoMedico nuevoMedico = new FrmNuevoMedico();
            nuevoMedico.Show();
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            MedicoEditar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarMedico();
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        private void DgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnDeseleccionar.Visible = true;
                Id = Convert.ToInt32(DgvMedicos.Rows[e.RowIndex].Cells[0].Value.ToString());
                Nombre = DgvMedicos.Rows[e.RowIndex].Cells[1].Value.ToString();
                Apellido = DgvMedicos.Rows[e.RowIndex].Cells[2].Value.ToString();
                Correo = DgvMedicos.Rows[e.RowIndex].Cells[3].Value.ToString();
                Telefono = DgvMedicos.Rows[e.RowIndex].Cells[4].Value.ToString();
                Cedula = DgvMedicos.Rows[e.RowIndex].Cells[5].Value.ToString();
                Foto = servicioMedicos.ObtenerFoto(Id);
                CargarDatosMedico();
            }
        }

        #endregion

        #region Metodos

        private void ListarMedicos()
        {
            DgvMedicos.DataSource = servicioMedicos.Listar();
            DgvMedicos.ClearSelection();
        }

        private void CargarDatosMedico()
        {
            PbFotoDePerfil.ImageLocation = Foto;
            LblNombre.Text = Nombre;
            LblApellido.Text = Apellido;
            LblCedula.Text = Cedula;
            LblTelefono.Text = Telefono;
            LblCorreo.Text = Correo;
        }

        private void Deseleccionar()
        {
            DgvMedicos.ClearSelection();
            Id = 0;
            Foto = "";
            PbFotoDePerfil.ImageLocation = "";
            LblNombre.Text = "";
            LblApellido.Text = "";
            LblCedula.Text = "";
            LblTelefono.Text = "";
            LblCorreo.Text = "";
            BtnDeseleccionar.Visible = false;
        }

        private void MedicoEditar()
        {
            if (Id > 0)
            {
                Medicos medicos = new Medicos
                {
                    Id = Id,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Cedula = Cedula,
                    Telefono = Telefono,
                    Correo = Correo
                };

                RepositorioMedicosEditar.Instancia.medicoEditar.Add(medicos);
                FrmEditarMedico editarMedico = new FrmEditarMedico();
                editarMedico.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Medico", "Notificacion");
            }
        }

        private void EliminarMedico()
        {
            if (Id > 0)
            {
                DialogResult result = MessageBox.Show("¿Estas seguro que deseas eliminar este Medico?", "¡Advertencia!", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    bool respuesta = servicioMedicos.Eliminar(Id);

                    if (respuesta)
                    {
                        MessageBox.Show("El Medico ha sido eliminado correctamente", "Notificacion");
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos", "Error");
                    }
                }
                ListarMedicos();
                Deseleccionar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Medico", "Notificacion");
            }
        }
        #endregion
    }
}
