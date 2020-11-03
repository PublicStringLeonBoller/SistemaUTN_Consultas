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
    public partial class frmLista8 : Form
    {
        ConexionBD db = new ConexionBD();
        public int pEdad { set; get; } = 0;
        public int pAño { set; get; } = 0;

        public frmLista8()
        {
            InitializeComponent();
        }
        private void frmLista8_Load(object sender, EventArgs e)
        {
            txtAño.MaxLength = 4;
            btnCons9.Enabled = false;
            btnCons9.IconColor = Color.Black;

        }
        public void CargarGrilla(int edad, int año)
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_23años_2000 {edad}, {año}";            
            t = db.leerPA(db.paSQL);

            grdLista.Rows.Clear();
            for (int i = 0; i < t.Rows.Count; i++)
            {
                grdLista.Rows.Add(
                    t.Rows[i][0],
                    t.Rows[i][1],
                    t.Rows[i][2],
                    t.Rows[i][3]);
            }
        }
        private void btnCons9_Click(object sender, EventArgs e)
        {
            pEdad = Convert.ToInt32(txtEdad.Text);
            pAño = int.Parse(txtAño.Text);

            CargarGrilla(pEdad, pAño);

            var cadena = txtAño.Text;
            if (cadena.Length != 4)
            {
                MessageBox.Show("Ingrese un año entre 1900 y 2020");
            }
        }
        /// 
        ///
        ///  //////////////////////Empieza la función de minimizar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        ///  /////////////////////Termina la función de minimizar
        ///  
        ///
        /// 
        /// 
        /// 
        /// 
        ///////////////////////////Validaciones de datos
        private void validarDatos()
        {
            var vc = !string.IsNullOrEmpty(txtAño.Text) &&
               !string.IsNullOrEmpty(txtEdad.Text);
            btnCons9.Enabled = vc;

            if (!string.IsNullOrEmpty(txtAño.Text) &&
                !string.IsNullOrEmpty(txtEdad.Text))
                btnCons9.IconColor = Color.White;
            else
                btnCons9.IconColor = Color.Black;
        }
        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtAño_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtEdad.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtEdad.Text + e.KeyChar) >= 101 ||
                Convert.ToInt32(txtEdad.Text + e.KeyChar) <= 0 ||
                txtEdad.Text == "0"))
                e.Handled = true;
        }
        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtAño.Clear();
            }
        }
        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
