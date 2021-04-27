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
    public partial class FrmReportarResultado : Form
    {
        public FrmReportarResultado()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmReportarResultado_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmManttoResultados manttoResultados = new FrmManttoResultados();
            manttoResultados.Show();
            this.Close();
        }
        #endregion
    }
}
