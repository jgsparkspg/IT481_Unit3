using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit9
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9_]*$");

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
            else if (!regex.IsMatch(textBox1.Text) || !regex.IsMatch(textBox2.Text))
            {
                MessageBox.Show("Please only utilize alphanumeric characters and underscores.");
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
