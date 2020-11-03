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
    public partial class frmLista_10 : Form
    {
        ConexionBD db = new ConexionBD();
        public int pId1 { set; get; } = 0;
        public int pId2 { set; get; } = 0;
        public frmLista_10()
        {
            InitializeComponent();
        }
        private void frmLista_10_Load(object sender, EventArgs e)
        {
            btnCons9.Enabled = false;
            btnCons9.IconColor = Color.Black;
        }
        public void CargarGrilla(int id1, int id2)
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_Direc_Ba {id1}, {id2}";
            t = db.leerPA(db.paSQL);

            grdLista.Rows.Clear();
            for (int i = 0; i < t.Rows.Count; i++)
            {
                grdLista.Rows.Add(
                    t.Rows[i][0],
                    t.Rows[i][1],
                    t.Rows[i][2],
                    t.Rows[i][3],
                    t.Rows[i][4]);
            }
        }      
        private void btnCons9_Click(object sender, EventArgs e)
        {
            pId1 = Convert.ToInt32(txtid1.Text);
            pId2 = int.Parse(txtid2.Text);

            CargarGrilla(pId1, pId2);
        }
        /// 
        ///
        ///  //////////////////////Empieza la función de minimizar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
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
            var vc = !string.IsNullOrEmpty(txtid1.Text) &&
               !string.IsNullOrEmpty(txtid2.Text);
            btnCons9.Enabled = vc;

            if (!string.IsNullOrEmpty(txtid1.Text) &&
                !string.IsNullOrEmpty(txtid2.Text))
                btnCons9.IconColor = Color.White;
            else
                btnCons9.IconColor = Color.Black;
        }
        private void txtid1_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtid2_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtid1.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtid1.Text + e.KeyChar) >= 1001 ||
                Convert.ToInt32(txtid1.Text + e.KeyChar) <= 0 ||
                txtid1.Text == "0"))
                e.Handled = true;
        }

        private void txtid2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtid2.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtid2.Text + e.KeyChar) >= 1001 ||
                Convert.ToInt32(txtid2.Text + e.KeyChar) <= 0 ||
                txtid2.Text == "0"))
                e.Handled = true;

        }
        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
