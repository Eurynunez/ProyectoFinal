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
    public partial class FrmCitaPendienteDeConsulta : Form
    {
        public FrmCitaPendienteDeConsulta()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmCitaPendienteDeConsulta_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoCitas manttoCitas = new FrmManttoCitas();
            manttoCitas.Show();
            this.Close();
        }
        #endregion
    }
}
