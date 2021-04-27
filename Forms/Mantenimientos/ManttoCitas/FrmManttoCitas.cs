using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoCitas
{
    public partial class FrmManttoCitas : Form
    {
        public FrmManttoCitas()
        {
            InitializeComponent();
        }

        #region
        private void FrmManttoCitas_Load(object sender, EventArgs e)
        {

        }

        private void PbVolverAtras_Click(object sender, EventArgs e)
        {
            FrmHome home = new FrmHome();
            home.Show();
            this.Close();
        }

        private void PbNuevaCita_Click(object sender, EventArgs e)
        {
            FrmListadoPacientes listadoPacientes = new FrmListadoPacientes();
            listadoPacientes.Show();
            this.Close();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            FrmCitaPendienteDeConsulta citaPendienteDeConsulta = new FrmCitaPendienteDeConsulta();
            citaPendienteDeConsulta.Show();
            this.Close();
        }

        private void BtnConsultarResultados_Click(object sender, EventArgs e)
        {
            FrmCitaPendienteDeResultado citaPendienteDeResultado = new FrmCitaPendienteDeResultado();
            citaPendienteDeResultado.Show();
            this.Close();
        }

        private void BtnVerResultados_Click(object sender, EventArgs e)
        {
            FrmCitaCompletada citaCompletada = new FrmCitaCompletada();
            citaCompletada.Show();
            this.Close();
        }
        #endregion

    }
}
