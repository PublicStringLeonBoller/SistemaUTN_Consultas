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
    public partial class frmConsulta2 : Form
    {
        public frmConsulta2()
        {
            InitializeComponent();
        }

        private void frmConsulta2_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Listas.frmLista4 l4 = new Listas.frmLista4();
            l4.ShowDialog();
            l4.TopLevel = true;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Listas.frmLista5 l5 = new Listas.frmLista5();
            l5.ShowDialog();
            l5.TopLevel = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Listas.frmLista6 l6 = new Listas.frmLista6();
            l6.ShowDialog();
            l6.TopLevel = true;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Listas.frmLista7 l7 = new Listas.frmLista7();
            l7.ShowDialog();
            l7.TopLevel = true;
        }
    }
}
