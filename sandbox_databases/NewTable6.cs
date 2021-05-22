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
    public partial class NewTable6 : Form
    {
        public NewTable6()
        {
            InitializeComponent();

            textBox1_ind.Text = "id сотрудника";
            textBox1_ind.ForeColor = Color.Gray;

            textBox1_obl.Text = "id документа";
            textBox1_obl.ForeColor = Color.Gray;


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

        Point lastPoint;
        private void NewTable6_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void textBox1_ind_Enter(object sender, EventArgs e)
        {
            if (textBox1_ind.Text == "id сотрудника")
            {
                textBox1_ind.Text = "";
                textBox1_ind.ForeColor = Color.Black;
            }
        }

        private void textBox1_ind_Leave(object sender, EventArgs e)
        {
            if (textBox1_ind.Text == "")
            {
                textBox1_ind.Text = "id сотрудника";
                textBox1_ind.ForeColor = Color.Gray;
            }
        }

        private void textBox1_obl_Enter(object sender, EventArgs e)
        {
            if (textBox1_obl.Text == "id документа")
            {
                textBox1_obl.Text = "";
                textBox1_obl.ForeColor = Color.Black;
            }
        }

        private void textBox1_obl_Leave(object sender, EventArgs e)
        {
            if (textBox1_obl.Text == "")
            {
                textBox1_obl.Text = "id документа";
                textBox1_obl.ForeColor = Color.Gray;
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
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;

            if (textBox1_ind.Text.Contains(' ') || textBox1_obl.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1_ind.Text == "id сотрудника" || textBox1_obl.Text == "id документа")
            {
                MessageBox.Show("Введите данные");
                return;
            }


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `oborot`.`HISTORY` (`Дата_Получения`, `SOTRUDNIK_id`, `DOKUMENT_id`," +
                " `Дата_Отправки`)" +
                " VALUES (@otch, @name, @surname, @pol)", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1_ind.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox1_obl.Text;
            command.Parameters.Add("@otch", MySqlDbType.Date).Value = dt1;
            command.Parameters.Add("@pol", MySqlDbType.Date).Value = dt2;
           
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись добавлена");
            else
                MessageBox.Show("Запись не добавлена");

            db.closeConnection();
        }

        public Boolean isExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from company where id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1_ind.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Компании не существует");
                return true;
            }
                
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from adres where company_id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1_ind.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Имя занято");
                return true;
            }
            else
                return false;
        }

        
    }
}
