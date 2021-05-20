using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    public partial class Form_auth : Form
    {
        DateTime date1 = DateTime.Now;
        string date = "";
        internal string categoryUser = "";
        public Form_auth()
        {
            InitializeComponent();
            textBox_login.Text = "Введите логин";
            textBox_pass.Text = "Введите пароль";
            textBox_login.ForeColor = Color.Gray;
            textBox_pass.ForeColor = Color.Gray;
            buttonLogin.BackColor = Color.White;

            this.textBox_pass.AutoSize = false;
            this.textBox_pass.Size = new Size(this.textBox_pass.Size.Width, 37);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_login_Enter(object sender, EventArgs e)
        {
            if (textBox_login.Text == "Введите логин")
            {
                textBox_login.Text = "";
                textBox_login.ForeColor = Color.Black;
            }
        }

        private void textBox_login_Leave(object sender, EventArgs e)
        {
            if (textBox_login.Text == "")
            {
                textBox_login.Text = "Введите логин";
                textBox_login.ForeColor = Color.Gray;
            }
        }

        private void textBox_pass_Enter(object sender, EventArgs e)
        {
            if (textBox_pass.Text == "Введите пароль")
            {
                textBox_pass.Text = "";
                textBox_pass.ForeColor = Color.Black;
            }
        }

        private void textBox_pass_Leave(object sender, EventArgs e)
        {
            if (textBox_pass.Text == "")
            {
                textBox_pass.Text = "Введите пароль";
                textBox_pass.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox_login.Text;
            string passUser = textBox_pass.Text;
            login.Value = textBox_login.Text;

            

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlDataReader reader;

            MySqlCommand command = new MySqlCommand("select * from `users` where Логин = @uL AND Пароль = @uP", db.getConnection());
            MySqlCommand command_category = new MySqlCommand("select category from `users` where Логин = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            command_category.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command_category.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            reader = command_category.ExecuteReader();
            while (reader.Read())
            {
                categoryUser = reader["category"].ToString();
            }

            
            
            if (table.Rows.Count > 0 && categoryUser == "admin")
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            if (table.Rows.Count > 0 && categoryUser == "office")
            {
                logos.Value = categoryUser;
                this.Hide();
                UserMain UserMain = new UserMain();
                
                UserMain.Show();
                
            }
            else
            if (table.Rows.Count > 0 && categoryUser == "company")
            {
                logos.Value = categoryUser;
                this.Hide();
                UserMain UserMain = new UserMain();
                
                UserMain.Show();
                
            }
            else
                MessageBox.Show("Неверный логин или пароль");

            db.closeConnection();
        }

        private void Form_auth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) {
                button1_Click(buttonLogin, null);
            }
        }

        Point lastPoint;
        private void Form_auth_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }    
        }

        private void Form_auth_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(76, 75, 100);
        }


        public void time()
        {
            string loginUser = textBox_login.Text;
            
            DateTime date1 = DateTime.Now;
            
            
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO session " +
                "SET `Вход` = @vh," +
                " users_id = (SELECT id FROM users WHERE `Логин` = @uL), " +
                " Логин = (SELECT Логин FROM users WHERE `Логин` = @uL)", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@vh", MySqlDbType.DateTime).Value = date1;
            date = date1.ToString();

            date1.ToString(date);

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

        }

        public void oftime()
        {
            string loginUser = "";

            DateTime date2;
            date2 = DateTime.Parse(date);
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlDataReader reader;

            MySqlCommand command_category = new MySqlCommand("select `id` from `session` where `Вход` = @uP", db.getConnection());

            command_category.Parameters.Add("@uP", MySqlDbType.DateTime).Value = date2;

            db.openConnection();

            reader = command_category.ExecuteReader();

            while (reader.Read())
            {
                loginUser = reader["id"].ToString();
            }
            intim.Value = loginUser;
            db.closeConnection();
        }

    }
}
