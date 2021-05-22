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

            textBox1_ind.Text = "Дата получения";
            textBox1_ind.ForeColor = Color.Gray;

            textBox1_obl.Text = "id сотрудника";
            textBox1_obl.ForeColor = Color.Gray;

            textBox1_gor.Text = "id документа";
            textBox1_gor.ForeColor = Color.Gray;

            textBox1_ul.Text = "Дата отправки";
            textBox1_ul.ForeColor = Color.Gray;

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
            if (textBox1_ind.Text == "Индекс компании")
            {
                textBox1_ind.Text = "";
                textBox1_ind.ForeColor = Color.Black;
            }
        }

        private void textBox1_ind_Leave(object sender, EventArgs e)
        {
            if (textBox1_ind.Text == "")
            {
                textBox1_ind.Text = "Индекс компании";
                textBox1_ind.ForeColor = Color.Gray;
            }
        }

        private void textBox1_obl_Enter(object sender, EventArgs e)
        {
            if (textBox1_obl.Text == "Область")
            {
                textBox1_obl.Text = "";
                textBox1_obl.ForeColor = Color.Black;
            }
        }

        private void textBox1_obl_Leave(object sender, EventArgs e)
        {
            if (textBox1_obl.Text == "")
            {
                textBox1_obl.Text = "Область";
                textBox1_obl.ForeColor = Color.Gray;
            }
        }

       

        private void textBox1_gor_Enter(object sender, EventArgs e)
        {
            if (textBox1_gor.Text == "Населенный пункт")
            {
                textBox1_gor.Text = "";
                textBox1_gor.ForeColor = Color.Black;
            }
        }

        private void textBox1_gor_Leave(object sender, EventArgs e)
        {
            if (textBox1_gor.Text == "")
            {
                textBox1_gor.Text = "Населенный пункт";
                textBox1_gor.ForeColor = Color.Gray;
            }
        }

        private void textBox1_ul_Enter(object sender, EventArgs e)
        {
            if (textBox1_ul.Text == "Улица")
            {
                textBox1_ul.Text = "";
                textBox1_ul.ForeColor = Color.Black;
            }
        }

        private void textBox1_ul_Leave(object sender, EventArgs e)
        {
            if (textBox1_ul.Text == "")
            {
                textBox1_ul.Text = "Улица";
                textBox1_ul.ForeColor = Color.Gray;
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
            if (textBox1_ind.Text.Contains(' ') || textBox1_obl.Text.Contains(' ')
                || textBox1_rai.Text.Contains(' ') || textBox1_gor.Text.Contains(' ')
                 || textBox1_ul.Text.Contains(' ') || textBox1_dom.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (textBox1_ind.Text == "Индекс компании" || textBox1_obl.Text == "Область"
                || textBox1_rai.Text == "Район" || textBox1_gor.Text == "Населенный пункт"
                || textBox1_ul.Text == "Улица" || textBox1_dom.Text == "Дом")
            {
                MessageBox.Show("Введите данные");
                return;
            }
            
            if (isUserExists())
                return;

            if (isExists())
                return;

            DB db = new DB();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO adres " +
                "SET `Индекс` = @ind, `Область` = @obl, `Район` = @rai, `Наименование места` = @mest, `Улица` = @ul, `Дом` = @dom," +
                " company_id = (SELECT id FROM company WHERE `id` = @id)", db.getConnection());

            command1.Parameters.Add("@ind", MySqlDbType.VarChar).Value = textBox1_ind.Text;
            command1.Parameters.Add("@obl", MySqlDbType.VarChar).Value = textBox1_obl.Text;
            command1.Parameters.Add("@rai", MySqlDbType.VarChar).Value = textBox1_rai.Text;
            command1.Parameters.Add("@mest", MySqlDbType.VarChar).Value = textBox1_gor.Text;
            command1.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1_ul.Text;
            command1.Parameters.Add("@dom", MySqlDbType.VarChar).Value = textBox1_dom.Text;
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox1.Text;

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

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox1.Text;

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

        
    }
}
