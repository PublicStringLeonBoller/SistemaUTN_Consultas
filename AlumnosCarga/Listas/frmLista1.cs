using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AlumnosCarga.Listas
{
    public partial class frmLista1 : Form
    {
        ConexionBD db = new ConexionBD();
        public string pSitLab1 { set; get; } = string.Empty;
        public string pSitLab2 { set; get; } = string.Empty;
        public int pNota { set; get; } = 0;
        

        Alumnos a = new Alumnos();
        public frmLista1()
        {
            InitializeComponent();
        }

        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmLista1_Load(object sender, EventArgs e)
        {
            cargarCombos(cbo1, "SIT_LABORALES");
            cargarCombos(cbo2, "SIT_LABORALES");
            iconButton1.Enabled = false;
            iconButton1.IconColor = Color.Black;
        }

        public void cargarGrilla(string pSitLab1, string pSitLab2, int pNota)
        {
            db.paSQL = $"pa_alumnos_prom_st '{pSitLab1}', '{pSitLab2}', {pNota}";
            DataTable dt = new DataTable();
            dt = db.leerPA(db.paSQL);

            grdLista.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)//Asignamos los campos a los Rows del DataGridView
            {
                grdLista.Rows.Add
                    (dt.Rows[i][0],
                    dt.Rows[i][1],
                    dt.Rows[i][2]);
            }
        }

        private void cargarCombos(ComboBox combo1, string nombreTabla)
        {
            DataTable tabla;
            tabla = db.recuperarTabla(nombreTabla);


            combo1.DataSource = tabla;
            combo1.ValueMember = tabla.Columns[0].ColumnName;
            combo1.DisplayMember = tabla.Columns[1].ColumnName;

            combo1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            pSitLab1 = cbo1.Text;
            pSitLab2 = cbo2.Text;
            pNota = Convert.ToInt32(txtNota.Text);

            cargarGrilla(pSitLab1, pSitLab2, pNota);
        }
        private void validarDatos()
        {
            var vc = !string.IsNullOrEmpty(txtNota.Text);
            iconButton1.Enabled = vc;

            if (!string.IsNullOrEmpty(txtNota.Text))
                iconButton1.IconColor = Color.White;
            else
                iconButton1.IconColor = Color.Black;
        }

        private void txtNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtNota.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtNota.Text + e.KeyChar) >= 11 ||
                Convert.ToInt32(txtNota.Text + e.KeyChar) <= 0 ||
                txtNota.Text == "0"))
                e.Handled = true;
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
    }
}
