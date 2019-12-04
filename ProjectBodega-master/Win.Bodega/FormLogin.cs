using BL.Bodega;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Bodega
{
    public partial class FormLogin : Form
    {
        SeguridadBL _seguridad;

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario;
            string contraseña;

            usuario = textBox1.Text;
            contraseña = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando......";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contraseña);

            if (resultado == true)
            {
                this.Close();
            }

            else
            { 

                MessageBox.Show("El usuario o la contraseña son incorrectas");
                button1.Text = "Ingresar";
                button1.Enabled = true;
            }
        }
     
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if ((textBox1.Text == "Usuario"))
            {
                textBox1.Clear();
                pictureBox2.BackgroundImage = Properties.Resources.user___copia;
                panel1.BackColor = Color.FromArgb(77, 210, 255);
                textBox1.ForeColor = Color.FromArgb(77, 210, 255);

                pictureBox3.BackgroundImage = Properties.Resources.pass;
                panel2.BackColor = Color.WhiteSmoke;
                textBox2.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                pictureBox2.BackgroundImage = Properties.Resources.user___copia;
                panel1.BackColor = Color.FromArgb(77, 210, 255);
                textBox1.ForeColor = Color.FromArgb(77, 210, 255);

                pictureBox3.BackgroundImage = Properties.Resources.pass;
                panel2.BackColor = Color.WhiteSmoke;
                textBox2.ForeColor = Color.WhiteSmoke;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Contraseña")
            {
                textBox2.Clear();
                textBox2.PasswordChar = '•';
                pictureBox3.BackgroundImage = Properties.Resources.pass___copia;
                panel2.BackColor = Color.FromArgb(77, 210, 255);
                textBox2.ForeColor = Color.FromArgb(77, 210, 255);

                pictureBox2.BackgroundImage = Properties.Resources.user;
                panel1.BackColor = Color.WhiteSmoke;
                textBox1.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                textBox2.PasswordChar = '•';
                pictureBox3.BackgroundImage = Properties.Resources.pass___copia;
                panel2.BackColor = Color.FromArgb(77, 210, 255);
                textBox2.ForeColor = Color.FromArgb(77, 210, 255);

                pictureBox2.BackgroundImage = Properties.Resources.user;
                panel1.BackColor = Color.WhiteSmoke;
                textBox1.ForeColor = Color.WhiteSmoke;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Text = "Usuario";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Contraseña";
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.WhiteSmoke;

            pictureBox3.BackgroundImage = Properties.Resources.pass;
            panel2.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        private void button2_Enter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.user;
            panel1.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.WhiteSmoke;

            pictureBox3.BackgroundImage = Properties.Resources.pass;
            panel2.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.WhiteSmoke;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)
                && !string.IsNullOrEmpty(textBox2.Text))
            {
                button1.PerformClick();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            button1.Select();
            button1.Focus();
        }
    }
}
