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
    public partial class NewTable3 : Form
    {
        public NewTable3()
        {
            InitializeComponent();

            textBox1_name.Text = "Наименование компании";
            textBox1_name.ForeColor = Color.Gray;

            textBox1_mail.Text = "Почта";
            textBox1_mail.ForeColor = Color.Gray;

            textBox1_OGRN.Text = "ОГРН";
            textBox1_OGRN.ForeColor = Color.Gray;

            textBox1_INN.Text = "ИНН";
            textBox1_INN.ForeColor = Color.Gray;

            textBox1_KPP.Text = "КПП";
            textBox1_KPP.ForeColor = Color.Gray;

            textBox1_direct.Text = "id директора";
            textBox1_direct.ForeColor = Color.Gray;
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
        private void NewTable3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable3_MouseMove(object sender, MouseEventArgs e)
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
            if (textBox1_name.Text.Contains(' ') || textBox1_mail.Text.Contains(' ')
                || textBox1_OGRN.Text.Contains(' ') || textBox1_INN.Text.Contains(' ')
                 || textBox1_KPP.Text.Contains(' ') || textBox1_direct.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1_name.Text == "Наименование компании" || textBox1_mail.Text == "Почта"
                || textBox1_OGRN.Text == "ОГРН" || textBox1_INN.Text == "ИНН"
                || textBox1_KPP.Text == "КПП" || textBox1_direct.Text == "id директора")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `holding_2`.`company` (`Наименование`, `E-mail`, `ОГРН`, `ИНН`" +
                ", `КПП`, `gen_direct_id`) VALUES (@name, @mail, @ogrn, @inn, @kpp, @direct)", db.getConnection());

            MySqlCommand command1 = new MySqlCommand("INSERT INTO company " +
                "SET `Наименование` = @name, `E-mail` = @mail, `ОГРН` = @ogrn, `ИНН` = @inn, `КПП` = @kpp," +
                " gen_direct_id = (SELECT id FROM gen_direct WHERE `id` = @direct)", db.getConnection());

            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1_name.Text;
            command1.Parameters.Add("@mail", MySqlDbType.VarChar).Value = textBox1_mail.Text;
            command1.Parameters.Add("@ogrn", MySqlDbType.VarChar).Value = textBox1_OGRN.Text;
            command1.Parameters.Add("@inn", MySqlDbType.VarChar).Value = textBox1_INN.Text;
            command1.Parameters.Add("@kpp", MySqlDbType.VarChar).Value = textBox1_KPP.Text;
            command1.Parameters.Add("@direct", MySqlDbType.VarChar).Value = textBox1_direct.Text;

            db.openConnection();

            if (command1.ExecuteNonQuery() == 1)
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

            MySqlCommand command = new MySqlCommand("select * from company where `Наименование` = @uL AND `ОГРН` = @ogrn AND" +
                " `ИНН` = @inn AND `КПП` = @kpp", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1_name.Text;
            command.Parameters.Add("@ogrn", MySqlDbType.VarChar).Value = textBox1_OGRN.Text;
            command.Parameters.Add("@inn", MySqlDbType.VarChar).Value = textBox1_INN.Text;
            command.Parameters.Add("@kpp", MySqlDbType.VarChar).Value = textBox1_KPP.Text;

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

        private void textBox1_name_Enter(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "Наименование компании")
            {
                textBox1_name.Text = "";
                textBox1_name.ForeColor = Color.Black;
            }
        }

        private void textBox1_name_Leave(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "")
            {
                textBox1_name.Text = "Наименование компании";
                textBox1_name.ForeColor = Color.Gray;
            }
        }

        private void textBox1_mail_Enter(object sender, EventArgs e)
        {
            if (textBox1_mail.Text == "Почта")
            {
                textBox1_mail.Text = "";
                textBox1_mail.ForeColor = Color.Black;
            }
        }

        private void textBox1_mail_Leave(object sender, EventArgs e)
        {
            if (textBox1_mail.Text == "")
            {
                textBox1_mail.Text = "Почта";
                textBox1_mail.ForeColor = Color.Gray;
            }
        }

        private void textBox1_OGRN_Enter(object sender, EventArgs e)
        {
            if (textBox1_OGRN.Text == "ОГРН")
            {
                textBox1_OGRN.Text = "";
                textBox1_OGRN.ForeColor = Color.Black;
            }
        }

        private void textBox1_OGRN_Leave(object sender, EventArgs e)
        {
            if (textBox1_OGRN.Text == "")
            {
                textBox1_OGRN.Text = "ОГРН";
                textBox1_OGRN.ForeColor = Color.Gray;
            }
        }

        private void textBox1_INN_Enter(object sender, EventArgs e)
        {
            if (textBox1_INN.Text == "ИНН")
            {
                textBox1_INN.Text = "";
                textBox1_INN.ForeColor = Color.Black;
            }
        }

        private void textBox1_INN_Leave(object sender, EventArgs e)
        {
            if (textBox1_INN.Text == "")
            {
                textBox1_INN.Text = "ИНН";
                textBox1_INN.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KPP_Enter(object sender, EventArgs e)
        {
            if (textBox1_KPP.Text == "КПП")
            {
                textBox1_KPP.Text = "";
                textBox1_KPP.ForeColor = Color.Black;
            }
        }

        private void textBox1_KPP_Leave(object sender, EventArgs e)
        {
            if (textBox1_KPP.Text == "")
            {
                textBox1_KPP.Text = "КПП";
                textBox1_KPP.ForeColor = Color.Gray;
            }
        }

        private void textBox1_direct_Enter(object sender, EventArgs e)
        {
            if (textBox1_direct.Text == "id директора")
            {
                textBox1_direct.Text = "";
                textBox1_direct.ForeColor = Color.Black;
            }
        }

        private void textBox1_direct_Leave(object sender, EventArgs e)
        {
            if (textBox1_direct.Text == "")
            {
                textBox1_direct.Text = "id директора";
                textBox1_direct.ForeColor = Color.Gray;
            }
        }
    }
}
