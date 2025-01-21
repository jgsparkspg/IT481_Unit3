using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit3
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please enter a username and password.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a username.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a password.");
            }
            else try
                {
                    Business login = new Business(textBox1.Text, textBox2.Text);
                    this.Hide();
                    MainForm form = new MainForm(login);
                    form.ShowDialog();
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    this.Show();
                }

        }
    }
}
