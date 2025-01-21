using System.Data;

namespace Unit3
{
    public partial class MainForm : Form
    {
        Business biz;
        public MainForm(Business login)
        {
            InitializeComponent();
            biz = login;
        }

        private void PopulateTable(DataTable table)
        {
            dataGridView1.DataSource = table;
            SetTotal((dataGridView1.RowCount - 1).ToString());
        }

        private void SetTotal(String labelstring)
        {
            label1.Text = labelstring;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (listBox1.GetItemText(listBox1.SelectedItem))
                {
                    case "Customers":
                        PopulateTable(biz.GetTable("GetCustomerNames"));
                        break;
                    case "Orders":
                        PopulateTable(biz.GetTable("GetOrderDetails"));
                        break;
                    case "Employees":
                        PopulateTable(biz.GetTable("GetEmployeeNames"));
                        break;
                    default:
                        MessageBox.Show("Select a table");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
