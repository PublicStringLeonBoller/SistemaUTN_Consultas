using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace AlumnosCarga
{
    public partial class frmConsulta1 : Form
    {
        ConexionBD db = new ConexionBD();
        public string pSitLab1 { set; get; } = string.Empty;
        public string pSitLab2 { set; get; } = string.Empty;
        public int pNota { set; get; } = 0;

        public frmConsulta1()
        {
            InitializeComponent();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Listas.frmLista3 l3 = new Listas.frmLista3();
            l3.ShowDialog();
            l3.TopLevel = true;           
        }       
        private void cargarCombos(ComboBox combo, string nombreTabla)
        {
            DataTable tabla;
            tabla = db.recuperarTabla(nombreTabla);

            combo.DataSource = tabla;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Listas.frmLista1 l1 = new Listas.frmLista1();
            l1.ShowDialog();
            l1.TopLevel = true;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            Listas.frmLista2 l2 = new Listas.frmLista2();
            l2.ShowDialog();
            l2.TopLevel = true;
        }
    }
}
