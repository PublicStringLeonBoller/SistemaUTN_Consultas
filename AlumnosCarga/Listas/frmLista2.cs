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
    public partial class frmLista2 : Form
    {
        ConexionBD db = new ConexionBD();
        public int pPromedio { set; get; } = 0;
        public int pAño { set; get; } = 0;

        Alumnos a = new Alumnos();
        public frmLista2()
        {
            InitializeComponent();
        }
        private void frmLista2_Load(object sender, EventArgs e)
        {
            txtAñoProm.MaxLength =4;
            btnPromAño.Enabled = false;
            btnPromAño.IconColor = Color.Black;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void validarDatos()
        {
            var vc = !string.IsNullOrEmpty(txtNotaProm.Text) &&
                !string.IsNullOrEmpty(txtAñoProm.Text);
            btnPromAño.Enabled = vc;

            if (!string.IsNullOrEmpty(txtNotaProm.Text) &&
                !string.IsNullOrEmpty(txtAñoProm.Text))
                btnPromAño.IconColor = Color.White;
            else
                btnPromAño.IconColor = Color.Black;

            
        }

        public void CargarGrilla(int pPromedio, int pAño)
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_Mayor_Ocho '{pPromedio}', '{pAño}'";            
            t = db.leerPA(db.paSQL);

            grdLista.Rows.Clear();
            for (int i = 0; i < t.Rows.Count; i++)
            {
                grdLista.Rows.Add(
                    t.Rows[i][0],
                    t.Rows[i][1],
                    t.Rows[i][2]);
            }
        }
        private void iconButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPromAño_Click(object sender, EventArgs e)
        {
            pPromedio = int.Parse(txtNotaProm.Text);
            pAño = Convert.ToInt32(txtAñoProm.Text);

            CargarGrilla(pPromedio, pAño);

            var cadena = txtAñoProm.Text;
            if (cadena.Length != 4)
                MessageBox.Show("Ingrese un año valido");

        }

        private void txtNotaProm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtNotaProm.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtNotaProm.Text + e.KeyChar) >= 11 ||
                Convert.ToInt32(txtNotaProm.Text + e.KeyChar) <= 0 ||
                txtNotaProm.Text == "0"))
                e.Handled = true;
        }

        private void txtAñoProm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtAñoProm.Clear();
            }


        }

        private void txtNotaProm_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }

        private void txtAñoProm_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }


    }
}
