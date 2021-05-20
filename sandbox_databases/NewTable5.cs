using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    public partial class NewTable5 : Form
    {
        public NewTable5()
        {
            InitializeComponent();

            textBox1.Text = "Время входа";
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "Время выхода";
            textBox2.ForeColor = Color.Gray;

            textBox3.Text = "Логин пользователя";
            textBox3.ForeColor = Color.Gray;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            TableMain tablemainshow = new TableMain();
            tablemainshow.Show();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(76, 75, 100);
        }

        Point lastPoint;
        private void NewTable5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(' ') || textBox2.Text.Contains(' ') || textBox3.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1.Text == "Время входа" || textBox2.Text == "Время выхода" || textBox2.Text == "Логин пользователя")
            {
                MessageBox.Show("Введите данные");
                return;
            }


            DB db = new DB();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO session " +
                "SET `Вход` = @vh, `Выход` = @vhd," +
                " users_id = (SELECT id FROM users WHERE `Логин` = @log)", db.getConnection());

            command1.Parameters.Add("@vh", MySqlDbType.VarChar).Value = textBox1.Text;
            command1.Parameters.Add("@vhd", MySqlDbType.VarChar).Value = textBox2.Text;
            command1.Parameters.Add("@log", MySqlDbType.VarChar).Value = textBox3.Text;

            db.openConnection();

            if (command1.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись добавлена");
            else
                MessageBox.Show("Запись не добавлена");

            db.closeConnection();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Время входа")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Время входа";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Время выхода")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Время выхода";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Логин пользователя")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Логин пользователя";
                textBox3.ForeColor = Color.Gray;
            }
        }
    }
}
