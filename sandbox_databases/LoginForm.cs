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
            login.Value = textBox_login.Text;
            

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlDataReader reader;
            MySqlDataReader reader1;
            MySqlDataReader reader2;

            MySqlCommand command = new MySqlCommand("select * from `vxod` where login = @uL AND password = @uP", db.getConnection());
            MySqlCommand command_category = new MySqlCommand("select наименование_должности from sotrudnik join dolznost on DOLZNOST_id = dolznost.id join VXOD on SOTRUDNIK_id = SOTRUDNIK.id where login = @uL", db.getConnection());
            MySqlCommand command_name = new MySqlCommand("select имя from `SOTRUDNIK` join VXOD on SOTRUDNIK_id = SOTRUDNIK.id where login = @uL", db.getConnection());
            MySqlCommand command_podrazdelenie = new MySqlCommand("select PODRAZDELENIE.id from `PODRAZDELENIE` " +
                "join SOTRUDNIK on PODRAZDELENIE_id = PODRAZDELENIE.id join VXOD on SOTRUDNIK_id = SOTRUDNIK.id " +
                "where login = @uL;", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox_login.Text;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = textBox_pass.Text;

            command_category.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox_login.Text;

            command_name.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox_login.Text;

            command_podrazdelenie.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox_login.Text;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            reader = command_category.ExecuteReader();
            while (reader.Read())
            {
                categoryUser.Value = reader["наименование_должности"].ToString();
            }

            db.closeConnection();

            db.openConnection();

            reader2 = command_podrazdelenie.ExecuteReader();
            while (reader2.Read())
            {
                podrazdelenie.Value = reader2["id"].ToString();
            }

            db.closeConnection();

            db.openConnection();

            reader1 = command_name.ExecuteReader();
            while (reader1.Read())
            {
                logos.Value = reader1["имя"].ToString();
            }


            if (table.Rows.Count > 0 && categoryUser.Value == "admin")
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            if (table.Rows.Count > 0 && categoryUser.Value == "rukovoditel")
            {
                this.Hide();
                RukovosShow RukovosShow = new RukovosShow();

                RukovosShow.Show();
                
            }
            else
            if (table.Rows.Count > 0 && categoryUser.Value == "sotrudnik")
            {
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


       
    }
}
