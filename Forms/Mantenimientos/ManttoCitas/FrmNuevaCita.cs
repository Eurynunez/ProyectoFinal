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
    public partial class FrmNuevaCita : Form
    {
        public FrmNuevaCita()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FrmNuevaCita_Load(object sender, EventArgs e)
        {

        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            FrmListadoPacientes listadoPacientes = new FrmListadoPacientes();
            listadoPacientes.Show();
            this.Close();
        }
        #endregion
    }
}
