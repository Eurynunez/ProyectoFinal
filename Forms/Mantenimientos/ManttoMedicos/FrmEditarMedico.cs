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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoMedicos
{
    public partial class FrmEditarMedico : Form
    {
        private ServicioMedicos servicioMedicos;
        string _Filename;
        public FrmEditarMedico()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicioMedicos = new ServicioMedicos(connection);
            _Filename = "";
            InitializeComponent();
        }

        #region Eventos
        private void FrmEditarMedico_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            RepositorioMedicosEditar.Instancia.medicoEditar.Clear();
            FrmManttoMedicos manttoMedicos = new FrmManttoMedicos();
            manttoMedicos.Show();
            this.Close();
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            AgregarFoto();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            EditarMedico();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion

        #region Metodos

        private void CargarDatos()
        {
            TxtNombre.Text = RepositorioMedicosEditar.Instancia.medicoEditar[0].Nombre;
            TxtApellido.Text = RepositorioMedicosEditar.Instancia.medicoEditar[0].Apellido;
            TxtCorreo.Text = RepositorioMedicosEditar.Instancia.medicoEditar[0].Correo;
            TxtTelefono.Text = RepositorioMedicosEditar.Instancia.medicoEditar[0].Telefono;
            TxtCedula.Text = RepositorioMedicosEditar.Instancia.medicoEditar[0].Cedula;
        }

        private void EditarMedico()
        {
            Medicos medicos = new Medicos
            {
                Id = RepositorioMedicosEditar.Instancia.medicoEditar[0].Id,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Correo = TxtCorreo.Text,
                Telefono = TxtTelefono.Text,
                Cedula = TxtCedula.Text,
            };

            if (TxtNombre.Text == "" | TxtApellido.Text == "" | TxtCorreo.Text == "")
            {
                MessageBox.Show("Todos los campos deben ser llenados","Notificacion");
            }
            else if (TxtCedula.Text.Length < 13)
            {
                MessageBox.Show("Debe ingresar un numero de Cedula valido","Notificacion");
            }
            else if (TxtTelefono.Text.Length < 13)
            {
                MessageBox.Show("Debe ingresar un numero de Telefono valido", "Notificacion");
            }
            else if (_Filename == "")
            {
                MessageBox.Show("Debe agregar una foto de perfil", "Notificacion");
            }
            else
            {
                bool respuesta = servicioMedicos.Editar(medicos);

                GuardarFoto();

                if (respuesta)
                {
                    MessageBox.Show($"El medico ha sido modificado correctamente", "Notificacion");
                    RepositorioMedicosEditar.Instancia.medicoEditar.Clear();
                    FrmManttoMedicos manttoMedicos = new FrmManttoMedicos();
                    manttoMedicos.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lo sentimos, ha ocurrido un error en la Base de Datos", "Error");
                }
            }
        }

        private void AgregarFoto()
        {
            DialogResult result = FotoMedicoEditarDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string File = FotoMedicoEditarDialog.FileName;

                _Filename = File;

                PbFotoPerfil.ImageLocation = File;
            }
        }

        private void GuardarFoto()
        {
            int Id = RepositorioMedicosEditar.Instancia.medicoEditar[0].Id;

            string directory = @"Imagenes\Medicos\" + Id + "\\";
            string[] FilenameSplit = _Filename.Split("\\");
            string filename = FilenameSplit[(FilenameSplit.Length - 1)];

            CreateDirectory(directory);

            string Destino = directory + filename;

            File.Copy(_Filename, Destino, true);

            servicioMedicos.GuardarFoto(Id, Destino);
        }

        private void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void LimpiarCampos()
        {
            PbFotoPerfil.ImageLocation = null;
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
            TxtCedula.Clear();
        }
        #endregion
    }
}
