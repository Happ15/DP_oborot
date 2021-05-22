using MySql.Data.MySqlClient;
using System;
using System.IO;
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
    public partial class NewTable7 : Form
    {
        public NewTable7()
        {
            InitializeComponent();

            textBox1.Text = "Имя документа";
            textBox1.ForeColor = Color.Gray;

            textBox2.Text = "Пояснение";
            textBox2.ForeColor = Color.Gray;

            textBox3.Text = "Задача";
            textBox3.ForeColor = Color.Gray;

            textBox4.Text = "id компании";
            textBox4.ForeColor = Color.Gray;

            textBox5.Text = "Ссылка";
            textBox5.ForeColor = Color.Gray;

            if(logos.Value == "office")
            {
                registerLabel.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (logos.Value == "office")
            {
                this.Hide();
                UserMain tablemainshow = new UserMain();
                tablemainshow.Show();
            }
            else
            {
                this.Hide();
                TableMain tablemainshow = new TableMain();
                tablemainshow.Show();
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Имя документа")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Имя документа";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пояснение")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пояснение";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Задача")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Задача";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "id компании")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "id компании";
                textBox4.ForeColor = Color.Gray;
            }
        }

        Point lastPoint;
        private void NewTable7_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void NewTable7_MouseMove(object sender, MouseEventArgs e)
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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(' ') || textBox2.Text.Contains(' ') || textBox3.Text.Contains(' ') || textBox4.Text.Contains(' ') || textBox5.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1.Text == "Имя документв" || textBox2.Text == "Пояснение" || textBox3.Text == "Задача" || textBox4.Text == "id компании" || textBox4.Text == "Ссылка")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            if (isExists())
                return;

            DB db = new DB();
            MySqlCommand command1 = new MySqlCommand("INSERT INTO doc " +
                "SET `Наименование` = @name, `Задача` = @zd, `Пояснение` = @po, `Ссылка` = @ss," +
                " company_id = (SELECT id FROM company WHERE `id` = @id)", db.getConnection());

            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command1.Parameters.Add("@zd", MySqlDbType.VarChar).Value = textBox3.Text;
            command1.Parameters.Add("@po", MySqlDbType.VarChar).Value = textBox2.Text;
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox4.Text;
            command1.Parameters.Add("@ss", MySqlDbType.VarChar).Value = textBox5.Text;

            db.openConnection();

            if (command1.ExecuteNonQuery() == 1)
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

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox4.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Компания не существует");
                return true;
            }

        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from doc where `Наименование` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Ссылка")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Ссылка";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] result = null;
            FileStream fileStream = File.OpenRead(Directory.GetCurrentDirectory() + @"\Testing\Test.docx");
            BinaryReader binaryReader = new BinaryReader(fileStream);
            int count = (int)fileStream.Length;
            result = binaryReader.ReadBytes(count);

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO DOKUMENT (`Дата`, `Содержание`, `Текущий_статус`, `TIP_DOKUMENTA_id`) VALUES ('2021-05-20', @Content, 'TEST.docx', '1')", db.getConnection());
            command.Parameters.AddWithValue("@Content", result);

            db.openConnection();

            int numberOfUpdatedItems = command.ExecuteNonQuery();

            db.closeConnection();
        }
    }
}
