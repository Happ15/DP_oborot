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

            textBox1_name.Text = "Имя";
            textBox1_name.ForeColor = Color.Gray;

            textBox1_surname.Text = "Фамилия";
            textBox1_surname.ForeColor = Color.Gray;

            textBox1_otch.Text = "Отчество";
            textBox1_otch.ForeColor = Color.Gray;

            textBox1_pol.Text = "Пол";
            textBox1_pol.ForeColor = Color.Gray;

            textBox1_pas.Text = "Номер,серия паспорта";
            textBox1_pas.ForeColor = Color.Gray;

            textBox1_mail.Text = "e-mail";
            textBox1_mail.ForeColor = Color.Gray;

            textBox1_tel.Text = "Номер телефона";
            textBox1_tel.ForeColor = Color.Gray;
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
            if (textBox1_name.Text == "Имя")
            {
                textBox1_name.Text = "";
                textBox1_name.ForeColor = Color.Black;
            }
        }

        private void textBox1_name_Leave(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "")
            {
                textBox1_name.Text = "Имя";
                textBox1_name.ForeColor = Color.Gray;
            }
        }

        private void textBox1_surname_Enter(object sender, EventArgs e)
        {
            if (textBox1_surname.Text == "Фамилия")
            {
                textBox1_surname.Text = "";
                textBox1_surname.ForeColor = Color.Black;
            }
        }

        private void textBox1_surname_Leave(object sender, EventArgs e)
        {
            if (textBox1_surname.Text == "")
            {
                textBox1_surname.Text = "Фамилия";
                textBox1_surname.ForeColor = Color.Gray;
            }
        }

        private void textBox1_otch_Enter(object sender, EventArgs e)
        {
            if (textBox1_otch.Text == "Отчество")
            {
                textBox1_otch.Text = "";
                textBox1_otch.ForeColor = Color.Black;
            }
        }

        private void textBox1_otch_Leave(object sender, EventArgs e)
        {
            if (textBox1_otch.Text == "")
            {
                textBox1_otch.Text = "Отчество";
                textBox1_otch.ForeColor = Color.Gray;
            }
        }

        private void textBox1_pol_Enter(object sender, EventArgs e)
        {
            if (textBox1_pol.Text == "Пол")
            {
                textBox1_pol.Text = "";
                textBox1_pol.ForeColor = Color.Black;
            }
        }

        private void textBox1_pol_Leave(object sender, EventArgs e)
        {
            if (textBox1_pol.Text == "")
            {
                textBox1_pol.Text = "Пол";
                textBox1_pol.ForeColor = Color.Gray;
            }
        }
        private void textBox1_pas_Enter(object sender, EventArgs e)
        {
            if (textBox1_pas.Text == "Номер,серия паспорта")
            {
                textBox1_pas.Text = "";
                textBox1_pas.ForeColor = Color.Black;
            }
        }

        private void textBox1_pas_Leave(object sender, EventArgs e)
        {
            if (textBox1_pas.Text == "")
            {
                textBox1_pas.Text = "Номер,серия паспорта";
                textBox1_pas.ForeColor = Color.Gray;
            }
        }

        private void textBox1_mail_Enter(object sender, EventArgs e)
        {
            if (textBox1_mail.Text == "e-mail")
            {
                textBox1_mail.Text = "";
                textBox1_mail.ForeColor = Color.Black;
            }
        }

        private void textBox1_mail_Leave(object sender, EventArgs e)
        {
            if (textBox1_mail.Text == "")
            {
                textBox1_mail.Text = "e-mail";
                textBox1_mail.ForeColor = Color.Gray;
            }
        }

        private void textBox1_tel_Enter(object sender, EventArgs e)
        {
            if (textBox1_tel.Text == "Номер телефона")
            {
                textBox1_tel.Text = "";
                textBox1_tel.ForeColor = Color.Black;
            }
        }

        private void textBox1_tel_Leave(object sender, EventArgs e)
        {
            if (textBox1_tel.Text == "")
            {
                textBox1_tel.Text = "Номер телефона";
                textBox1_tel.ForeColor = Color.Gray;
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
            if (textBox1_name.Text.Contains(' ') || textBox1_surname.Text.Contains(' ') ||
                textBox1_otch.Text.Contains(' ') || textBox1_pol.Text.Contains(' ')
                || textBox1_pas.Text.Contains(' ')
                 || textBox1_mail.Text.Contains(' ') || textBox1_tel.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1_name.Text == "Имя" || textBox1_surname.Text == "Фамилия"
                 || textBox1_otch.Text == "Отчество" || textBox1_pol.Text == "Пол"
                  || textBox1_pas.Text == "Номер,серия паспорта" 
                   || textBox1_tel.Text == "Номер телефона" || textBox1_mail.Text == "e-mail")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `holding_2`.`gen_direct` (`Имя`, `Фамилия`, `Отчество`," +
                " `Пол`, `Дата рождения`, `Номер,серия паспорта`, `E-mail`, `Телефон`)" +
                " VALUES (@name, @surname, @otch, @pol, @date, @pas, @mail, @tel)", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1_name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox1_surname.Text;
            command.Parameters.Add("@otch", MySqlDbType.VarChar).Value = textBox1_otch.Text;
            command.Parameters.Add("@pol", MySqlDbType.VarChar).Value = textBox1_pol.Text;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = textBox1_pas.Text;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = dateTimePicker1.Value;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = textBox1_tel.Text;
            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = textBox1_mail.Text;

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

            MySqlCommand command = new MySqlCommand("select * from `gen_direct` where `Номер,серия паспорта` = @pas", db.getConnection());
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = textBox1_pas.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Введите корректные данные паспорта");
                return true;
            }
            else
                return false;
        }
    }
}
