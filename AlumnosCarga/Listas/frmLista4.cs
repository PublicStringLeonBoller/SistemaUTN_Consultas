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
    public partial class frmLista4 : Form
    {
        ConexionBD db = new ConexionBD();
        public int pPromedio { set; get; } = 0;

        Alumnos a = new Alumnos();
        public frmLista4()
        {
            InitializeComponent();
        }
        private void frmLista4_Load(object sender, EventArgs e)
        {
            btnCons9.IconColor = Color.Black;
            btnCons9.Enabled = false;

        }
        private void btnCons9_Click(object sender, EventArgs e)
        {
            pPromedio = Convert.ToInt32(txtNota.Text);

            CargarGrilla(pPromedio);
        }

        public void CargarGrilla(int promedio)
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_Becados '{promedio}'";           
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
        }///  /////////////////////Termina la función de minimizar
         ///  
         ///
         /// 
         /// 
         /// 
         /// 
        ///////////////////////////Validaciones de datos
        private void validarDatos()
        {
            var vc = !string.IsNullOrEmpty(txtNota.Text);
            btnCons9.Enabled = vc;

            if (!string.IsNullOrEmpty(txtNota.Text))
                btnCons9.IconColor = Color.White;
            else
                btnCons9.IconColor = Color.Black;
        }
        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
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
    }
    
}
