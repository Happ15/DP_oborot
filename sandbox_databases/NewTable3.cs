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

            textBox1_name.Text = "Наименование подразделения";
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
            if (textBox1_name.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1_name.Text == "Наименование подразделения")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `oborot`.`PODRAZDELENIE` (`Наименование_подразделения`) VALUES (@name)", db.getConnection());

            MySqlCommand command1 = new MySqlCommand("INSERT INTO PODRAZDELENIE " +
                "SET `Наименование_подразделения` = @name)", db.getConnection());


            //Может пригодится
            //MySqlCommand command1 = new MySqlCommand("INSERT INTO company " +
            //    "SET `Наименование` = @name, `E-mail` = @mail, `ОГРН` = @ogrn, `ИНН` = @inn, `КПП` = @kpp," +
            //    " gen_direct_id = (SELECT id FROM gen_direct WHERE `id` = @direct)", db.getConnection());


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

            MySqlCommand command = new MySqlCommand("select * from PODRAZDELENIE where `Наименование_подразделения` = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1_name.Text;
           
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Подразделение с таким наименованием уже существует");
                return true;
            }
            else
                return false;
        }

        private void textBox1_name_Enter(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "Наименование подразделения")
            {
                textBox1_name.Text = "";
                textBox1_name.ForeColor = Color.Black;
            }
        }

        private void textBox1_name_Leave(object sender, EventArgs e)
        {
            if (textBox1_name.Text == "")
            {
                textBox1_name.Text = "Наименование подразделения";
                textBox1_name.ForeColor = Color.Gray;
            }
        }

    }
}
