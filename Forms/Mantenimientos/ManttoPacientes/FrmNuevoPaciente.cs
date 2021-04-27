using BussinesLayer.Servicios;
using DataBase.Modelo;
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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoPacientes
{
    public partial class FrmNuevoPaciente : Form
    {
        ServicioPacientes servicio;
        int _Id;
        string _Filename;
        public FrmNuevoPaciente()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicio = new ServicioPacientes(connection);
            _Id = 0;
            _Filename = "";
            InitializeComponent();
        }

        #region Eventos
        private void FrmNuevoPaciente_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoPacientes manttoPacientes = new FrmManttoPacientes();
            manttoPacientes.Show();
            this.Close();
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            AgregarFoto();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPaciente();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion

        #region Eventos

        private void AgregarPaciente()
        {
            Paciente paciente = new Paciente
            {
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Telefono = TxtTelefono.Text,
                Direccion = TxtDireccion.Text,
                Cedula = TxtCedula.Text,
                FechaNacimiento = TxtFechaNacimiento.Text,
                Fumador = RbtnFumadorSi.Checked == true ? "SI" : "NO",
                Alergias = TxtAlergias.Text
            };

            if (TxtNombre.Text == null | TxtApellido.Text == null | TxtTelefono.Text == null | TxtDireccion.Text == null | TxtAlergias.Text == "")
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
            else if (TxtCedula.Text.Length < 13)
            {
                MessageBox.Show("Debe ingresar un numero de Cedula valido", "Notificacion");
            }
            else if (TxtTelefono.Text.Length < 13)
            {
                MessageBox.Show("Debe ingresar un numero de Telefono valido", "Notificacion");
            }
            else if (TxtFechaNacimiento.Text.Length < 10)
            {
                MessageBox.Show("Debe ingresar una fecha de nacimiento valida", "Notificacion");
            }
            else if (_Filename == "")
            {
                MessageBox.Show("Debe agregar una foto de perfil", "Notificacion");
            }
            else if (RbtnFumadorSi.Checked == false && RbtnFumadorNo.Checked == false)
            {
                MessageBox.Show("Debe seleccionar si el paciente fuma o no", "Notificacion");
            }
            else
            {
                bool respuesta = servicio.Agregar(paciente);

                GuardarFoto();

                if (respuesta)
                {
                    MessageBox.Show($"El paciente {paciente.Nombre} {paciente.Apellido} ha sido creado correctamente");
                    FrmManttoPacientes pacientes = new FrmManttoPacientes();
                    pacientes.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Lo sentimos, ha ocurrido un error en la base de datos");
                }
            }
        }

        private void AgregarFoto()
        {
            DialogResult result = FotoPacienteDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string File = FotoPacienteDialog.FileName;

                _Filename = File;

                PbFotoPerfil.ImageLocation = File;
            }
        }

        private void GuardarFoto()
        {
            int Id = servicio.UltimoId();

            string directory = @"Imagenes\Pacientes\" + Id + "\\";
            string[] FilenameSplit = _Filename.Split("\\");
            string filename = FilenameSplit[(FilenameSplit.Length - 1)];

            CreateDirectory(directory);

            string Destino = directory + filename;

            File.Copy(_Filename, Destino, true);

            servicio.GuardarFoto(Id, Destino);
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
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtTelefono.Clear();
            TxtDireccion.Clear();
            TxtCedula.Clear();
            TxtFechaNacimiento.Clear();
            RbtnFumadorSi.Checked = false;
            RbtnFumadorNo.Checked = false;
            TxtAlergias.Clear();
        }
        #endregion
    }   
}
