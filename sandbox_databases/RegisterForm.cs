using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Введите имя";
            userSurnameField.Text = "Введите фамилию";
            textBox_login.Text = "Введите логин";
            textBox_pass.Text = "Введите пароль";
            textBox1_pas.Text = "Номер,серия паспорта";
            textBox1_tel.Text = "Номер телефона";
            textBox1_cat.Text = "Введите категорию";
            textBox1_otch.Text = "Введите отчество";
            textBox1_pol.Text = "Введите пол";

            userNameField.ForeColor = Color.Gray;
            textBox_login.ForeColor = Color.Gray;
            userSurnameField.ForeColor = Color.Gray;
            textBox_pass.ForeColor = Color.Gray;
            textBox1_pas.ForeColor = Color.Gray;
            textBox1_tel.ForeColor = Color.Gray;
            textBox1_cat.ForeColor = Color.Gray;
            textBox1_otch.ForeColor = Color.Gray;
            textBox1_pol.ForeColor = Color.Gray;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
                
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.Gray;
            }    
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if(userSurnameField.Text == "Введите фамилию")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if(userSurnameField.Text =="")
            {
                userSurnameField.Text = "Введите фамилию";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text.Contains(' ')|| userSurnameField.Text.Contains(' ') ||
                textBox_login.Text.Contains(' ') || textBox_pass.Text.Contains(' ')
                || textBox1_otch.Text.Contains(' ') || textBox1_pol.Text.Contains(' ')
                 || textBox1_pas.Text.Contains(' ') 
                  || textBox1_tel.Text.Contains(' ') || textBox1_cat.Text.Contains(' '))
            {
                MessageBox.Show("Введите корректные значения");
                return;
            }
            else
            if (userNameField.Text == "Введите имя" || userSurnameField.Text == "Введите фамилию" ||
                textBox_login.Text == "Введите логин" || textBox_pass.Text == "Введите пароль"
                 || textBox1_otch.Text == "Введите отчество" || textBox1_pol.Text == "Введите пол"
                  || textBox1_pas.Text == "Номер,серия паспорта" 
                   || textBox1_tel.Text == "Номер телефона" || textBox1_cat.Text == "Введите категорию")
            {
                MessageBox.Show("Введите данные");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `holding_2`.`users` (`Логин`, `Пароль`, `Имя`, `Фамилия`, `Отчество`," +
                " `Пол`, `Номер,серия паспорта`, `Дата рождения`, `Телефон`, `category`)" +
                " VALUES (@login, @pass, @name, @surname, @otch, @pol, @pas, @date, @tel, @cat)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox_login.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox_pass.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;
            command.Parameters.Add("@otch", MySqlDbType.VarChar).Value = textBox1_otch.Text;
            command.Parameters.Add("@pol", MySqlDbType.VarChar).Value = textBox1_pol.Text;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = textBox1_pas.Text;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = dateTimePicker1.Value;
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = textBox1_tel.Text;
            command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = textBox1_cat.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт создан");
            else
                MessageBox.Show("Аккаунт не создан");

            db.closeConnection();
        }



        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from `users` where `Логин` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox_login.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Логин занят");
                return true;
            }
            else
                return false;
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        Point lastPoint;
        private void RegisterForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void RegisterForm_MouseMove(object sender, MouseEventArgs e)
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

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
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

        private void textBox1_cat_Enter(object sender, EventArgs e)
        {
            if (textBox1_cat.Text == "Введите категорию")
            {
                textBox1_cat.Text = "";
                textBox1_cat.ForeColor = Color.Black;
            }
        }

        private void textBox1_cat_Leave(object sender, EventArgs e)
        {
            if (textBox1_cat.Text == "")
            {
                textBox1_cat.Text = "Введите категорию";
                textBox1_cat.ForeColor = Color.Gray;
            }
        }

        private void textBox1_otch_Enter(object sender, EventArgs e)
        {
            if (textBox1_otch.Text == "Введите отчество")
            {
                textBox1_otch.Text = "";
                textBox1_otch.ForeColor = Color.Black;
            }
        }

        private void textBox1_otch_Leave(object sender, EventArgs e)
        {
            if (textBox1_otch.Text == "")
            {
                textBox1_otch.Text = "Введите отчество";
                textBox1_otch.ForeColor = Color.Gray;
            }
        }

        private void textBox1_pol_Enter(object sender, EventArgs e)
        {
            if (textBox1_pol.Text == "Введите пол")
            {
                textBox1_pol.Text = "";
                textBox1_pol.ForeColor = Color.Black;
            }
        }

        private void textBox1_pol_Leave(object sender, EventArgs e)
        {
            if (textBox1_pol.Text == "")
            {
                textBox1_pol.Text = "Введите пол";
                textBox1_pol.ForeColor = Color.Gray;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (pere.Value == "1")
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            else
            {
                this.Hide();
                TableMain tablemainshow = new TableMain();
                tablemainshow.Show();
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.FromArgb(76, 75, 100);
        }
    }
}
