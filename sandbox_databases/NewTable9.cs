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
    public partial class NewTable9 : Form
    {
        string flagTbl = "";
        public NewTable9()
        {
            InitializeComponent();

            textBox3.Text = "Время";
            textBox3.ForeColor = Color.Gray;

            textBox1.Text = "id пользователя";
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "id документа";
            textBox2.ForeColor = Color.Gray;
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

        Point lastPoint;
        private void NewTable9_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable9_MouseMove(object sender, MouseEventArgs e)
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "id документа")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "id документа";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "id пользователя")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "id пользователя";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Время")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Время";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            flagTbl = "work_user_doc";
            if (textBox1.Text.Contains(' ') || textBox2.Text.Contains(' ') || textBox3.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1.Text == "id пользователя" || textBox2.Text == "id документа" || textBox3.Text == "Время")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isDocExists())
                return;

            if (isExists())
                return;

            if (isUserExists())
                return;

            if (isExistsDoc())
                return;

            if (isExistsUser())
                return;

            DB db = new DB();
            MySqlCommand command1 = new MySqlCommand("INSERT INTO gotov_doc " +
                "SET `Время` = @time," +
                " users_id = (SELECT users_id FROM work_user_doc WHERE `users_id` = @idu)," +
                " doc_id = (SELECT doc_id FROM work_user_doc WHERE `doc_id` = @idd)", db.getConnection());

            MySqlCommand command2 = new MySqlCommand("DELETE FROM " + flagTbl +
                " WHERE doc_id = (SELECT id FROM doc WHERE `id` = @idv)", db.getConnection());

            command1.Parameters.Add("@time", MySqlDbType.VarChar).Value = textBox3.Text;
            command1.Parameters.Add("@idu", MySqlDbType.VarChar).Value = textBox1.Text;
            command1.Parameters.Add("@idd", MySqlDbType.VarChar).Value = textBox2.Text;

            command2.Parameters.Add("@idv", MySqlDbType.VarChar).Value = textBox2.Text;

            db.openConnection();

            if(command1.ExecuteNonQuery() == 1)
            {
                command2.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена");
            }
            else
                MessageBox.Show("Запись не добавлена");

            db.closeConnection();
        }


        public Boolean isExistsUser()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from work_user_doc where users_id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Пользователь не брал в работу");
                return true;
            }
        }

        public Boolean isDocExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from doc where id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Документ не существует");
                return true;
            }
        }

        public Boolean isExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from users where id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Пользователь не существует");
                return true;
            }
        }


        public Boolean isExistsDoc()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * " +
                "from work_user_doc where doc_id = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Документ не принят в работу");
                return true;
            }
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from gotov_doc where `doc_id` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox2.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Документ занят");
                return true;
            }
            else
                return false;
        }
    }
}
