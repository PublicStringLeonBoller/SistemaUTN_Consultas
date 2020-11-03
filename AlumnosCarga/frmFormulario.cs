using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Data.OleDb;


namespace AlumnosCarga
{
    public partial class frmFormulario : Form
    {
        //Campos
        private IconButton btnActual;
        private Panel leftBorderBtn;
        private Form formActual;


        //Constructor

        public frmFormulario()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,53);
            panelBotones.Controls.Add(leftBorderBtn);
            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Estructuras
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 113, 206);
        }

        //Metodos
        private void ActivateButton(object senderBtn,Color color)
        {
            if(senderBtn != null)
            {
                DeshabilitarBoton();
                btnActual = (IconButton)senderBtn;
                btnActual.BackColor = Color.FromArgb(245, 245, 245);
                btnActual.ForeColor = color;
                btnActual.TextAlign = ContentAlignment.MiddleCenter;
                btnActual.IconColor = color;
                btnActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                btnActual.ImageAlign = ContentAlignment.MiddleRight;
                //Boton izquierdo
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, btnActual.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icono Inicio
                iconoInicio.IconChar = btnActual.IconChar;
                iconoInicio.IconColor = Color.White;
            }
        }

        private void DeshabilitarBoton()
        {
            if (btnActual != null)
            {
                btnActual.BackColor = Color.FromArgb(0, 113, 206);
                btnActual.ForeColor = Color.White;
                btnActual.TextAlign = ContentAlignment.MiddleLeft;
                btnActual.IconColor = Color.White;
                btnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnActual.ImageAlign = ContentAlignment.MiddleLeft;              
            }
        }

 
        private void abrirFormHijo(Form formHijo)
        {
            if (formActual != null)
            {
                formActual.Close();
            }
            formActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelInicio.Controls.Add(formHijo);
            panelInicio.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
            lblInicio.Text = formHijo.Text;
        }
        private void panelIzquierdo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmFormulario_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void custimizarDiseño()
        {
            panelAlumno.Visible = false;
            panelIzquierdo.Visible = false;
        }

        private void esconterSubMenu()
        {
            if (panelAlumno.Visible == true)
                panelAlumno.Visible = false;
            
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new frmConsulta1());
            ActivateButton(sender, RGBColors.color1);
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Consultas.frmConsulta2());
            ActivateButton(sender, RGBColors.color1); 
            
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Consultas.frmConsulta3());
            ActivateButton(sender, RGBColors.color1);
            
        }

        private void btnUtn_Click(object sender, EventArgs e)
        {
            if (formActual != null)
                formActual.Close();
            Reset();
        }

        private void Reset()
        {
            DeshabilitarBoton();
            leftBorderBtn.Visible = false;
            //Cambiar Icono
            iconoInicio.IconChar = IconChar.Home;
            iconoInicio.IconColor = Color.White;
            lblInicio.Text = "Inicio";

        }
        //Arrastrar el form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Saliendo...",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            Info i = new Info();
            i.ShowDialog();
            i.TopLevel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHoraHome.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
