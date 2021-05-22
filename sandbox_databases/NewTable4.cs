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
    public partial class NewTable4 : Form
    {
        public NewTable4()
        {
            InitializeComponent();

            textBox1_name.Text = "Наименование должности";
            textBox1_name.ForeColor = Color.Gray;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void textBox1_name_Enter(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "Наименование должности")
            {
                textBox1_name.Text = "";
                textBox1_name.ForeColor = Color.Black;
            }
        }

        private void textBox1_name_Leave(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "")
            {
                textBox1_name.Text = "Наименование должности";
                textBox1_name.ForeColor = Color.Gray;
            }
        }

        Point lastPoint;
        private void NewTable4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBox1_name.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректное значение");
                return;
            }
            else
            if (textBox1_name.Text == "Наименование_должности")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `oborot`.`DOLZNOST` (`Наименование_должности`)" +
                " VALUES (@name)", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1_name.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись добавлена");
            else
                MessageBox.Show("Запись не добавлена");

            db.closeConnection();
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from `DOLZNOST` where `Наименование_должности` = @pas", db.getConnection());
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = textBox1_name.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Должность с таким наименованием уже существует");
                return true;
            }
            else
                return false;
        }
    }
}
