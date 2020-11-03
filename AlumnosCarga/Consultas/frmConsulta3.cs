using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnosCarga.Consultas
{
    public partial class frmConsulta3 : Form
    {
        public frmConsulta3()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Listas.frmLista8 l8 = new Listas.frmLista8();
            l8.ShowDialog();
            l8.TopLevel = true;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Listas.frmLista9 l9 = new Listas.frmLista9();
            l9.ShowDialog();
            l9.TopLevel = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Listas.frmLista_10 l10 = new Listas.frmLista_10();
            l10.ShowDialog();
            l10.TopLevel = true;
        }
    }
}
