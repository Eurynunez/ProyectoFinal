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
    public partial class FrmCitaPendienteDeResultado : Form
    {
        public FrmCitaPendienteDeResultado()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmCitaPendienteDeResultado_Load(object sender, EventArgs e)
        {

        }

        private void BtnCerrarResultados_Click(object sender, EventArgs e)
        {
            FrmManttoCitas manttoCitas = new FrmManttoCitas();
            manttoCitas.Show();
            this.Close();
        }
        #endregion

    }
}
