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

namespace ProyectoFinal.Forms.Mantenimientos.ManttoMedicos
{
    public partial class FrmNuevoMedico : Form
    {
        ServicioMedicos servicioMedicos;
        string _Filename;
        int _Id;
        public FrmNuevoMedico()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);
            servicioMedicos = new ServicioMedicos(connection);
            _Filename = "";
            _Id = 0;
            InitializeComponent();
        }

        #region Eventos
        private void FrmNuevoMedico_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoMedicos manttoMedicos = new FrmManttoMedicos();
            manttoMedicos.Show();
            this.Close();
        }

        private void BtnAgregarFoto_Click(object sender, EventArgs e)
        {
            AgregarFoto();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMedico();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion

        #region Metodos

        private void AgregarFoto()
        {
            DialogResult result = FotoMedicoDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string File = FotoMedicoDialog.FileName;

                _Filename = File;

                PbFotoPerfil.ImageLocation = File;
            }
        }

        private void GuardarFoto()
        {
            int Id = servicioMedicos.UltimoId();

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

        private void AgregarMedico()
        {
            Medicos medicos = new Medicos
            {
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                Correo = TxtCorreo.Text,
                Telefono = TxtTelefono.Text,
                Cedula = TxtCedula.Text
            };

            if (TxtNombre.Text == "" | TxtApellido.Text == "" | TxtCorreo.Text == "")
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
            else if (_Filename == "")
            {
                MessageBox.Show("Debe agregar una foto de perfil", "Notificacion");
            }
            else
            {
                bool respuesta = servicioMedicos.Agregar(medicos);

                GuardarFoto();

                if (respuesta)
                {
                    MessageBox.Show($"El medico {medicos.Nombre} {medicos.Apellido} ha sido agregado correctamente", "Notificacion");
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

        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtCorreo.Clear();
            TxtTelefono.Clear();
            TxtCedula.Clear();
            PbFotoPerfil.ImageLocation = "";
        }
        #endregion
    }
}
