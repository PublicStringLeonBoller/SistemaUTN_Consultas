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
    public partial class frmLista3 : Form
    {
        ConexionBD db = new ConexionBD();
        public string pMateria { set; get; } = string.Empty;
        public int pAño { set; get; } = 0;
        public int pPromedio { set; get; } = 0;

        Alumnos a = new Alumnos();
        public frmLista3()
        {
            InitializeComponent();
        }
        private void frmLista3_Load(object sender, EventArgs e)//Load de Form
        {
            txtAño.MaxLength = 4;
            CargarCombos(cboMateria, "materias");
            btnCons9.Enabled = false;
            btnCons9.IconColor = Color.Black;
        }
        
        public void CargarGrilla(int año, string materia, int promedio)//Cargar grilla
        {
            DataTable t = new DataTable();
            db.paSQL = $"pa_PromGral '{año}', '{materia}', {promedio}";            
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
        private void CargarCombos(ComboBox combo1, string nombreTabla)//Cargar Combos
        {
            DataTable tabla;
            tabla = db.recuperarTabla(nombreTabla);


            combo1.DataSource = tabla;
            combo1.ValueMember = tabla.Columns[0].ColumnName;
            combo1.DisplayMember = tabla.Columns[1].ColumnName;

            combo1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnCons9_Click(object sender, EventArgs e)//CLICK de botón
        {
            pAño = int.Parse(txtAño.Text);
            pMateria = cboMateria.Text;
            pPromedio = int.Parse(txtPromedio.Text);

            CargarGrilla(pAño, pMateria, pPromedio);

            var cadena = txtAño.Text;
            if(cadena.Length != 4)
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
            var vc = !string.IsNullOrEmpty(txtAño.Text) &&
                !string.IsNullOrEmpty(txtPromedio.Text);
            btnCons9.Enabled = vc;

            if(!string.IsNullOrEmpty(txtAño.Text) &&
                !string.IsNullOrEmpty(txtPromedio.Text))
            btnCons9.IconColor = Color.White;
            else
                btnCons9.IconColor = Color.Black;
        }

        private void txtPromedio_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }
        private void txtAño_TextChanged(object sender, EventArgs e)
        {
            validarDatos();
        }

        private void txtPromedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            if (e.KeyChar == 8)
            {
                e.Handled = true;
                txtPromedio.Clear();
            }

            if ((!char.IsDigit(e.KeyChar) ||
                Convert.ToInt32(txtPromedio.Text + e.KeyChar) >= 11 ||
                Convert.ToInt32(txtPromedio.Text + e.KeyChar) <= 0 ||
                txtPromedio.Text == "0"))
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
