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
    public partial class frmLista9 : Form
    {
        ConexionBD db = new ConexionBD();
        public string pContenga { set; get; } = string.Empty;
        public string pComience { set; get; } = string.Empty;
        public frmLista9()
        {
            InitializeComponent();
        }
        private void frmLista9_Load(object sender, EventArgs e)
        {
            txtComiencee.MaxLength = 1;
            txtContenga.MaxLength = 1;
            btnCons9.Enabled = false;
            btnCons9.IconColor = Color.Black;
        }
        public void CargarGrilla(string contiene, string empieza)
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_Contiene_Empieza '{contiene}', '{empieza}'";            
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
            pContenga = txtContenga.Text;
            pComience = txtComiencee.Text;

            CargarGrilla(pContenga, pComience);
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
            var vc = !string.IsNullOrEmpty(txtComiencee.Text) &&
               !string.IsNullOrEmpty(txtContenga.Text);
            btnCons9.Enabled = vc;

            if (!string.IsNullOrEmpty(txtComiencee.Text) &&
                !string.IsNullOrEmpty(txtContenga.Text))
                btnCons9.IconColor = Color.White;
            else
                btnCons9.IconColor = Color.Black;
        }      
        private void txtContenga_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtComiencee_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtContenga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtComiencee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == 8 || char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
