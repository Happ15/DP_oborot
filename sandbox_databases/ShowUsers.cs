using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    public partial class ShowUsers : Form
    {
        public ShowUsers()
        {
            InitializeComponent();

            DataSet ds = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from users", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from users", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void ShowUsers_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.holdingDataSet.users);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(76, 75, 100);
        }
    }
}
