using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Forms.Mantenimientos.ManttoResultados
{
    public partial class FrmManttoResultados : Form
    {
        public FrmManttoResultados()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmManttoResultados_Load(object sender, EventArgs e)
        {

        }

        private void BtnReportarResultado_Click(object sender, EventArgs e)
        {
            FrmReportarResultado reportarResultado = new FrmReportarResultado();
            reportarResultado.Show();
            this.Close();
        }
        #endregion
    }
}
