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
    public partial class DeleteUserForm : Form
    {
        internal string log_id = "";
        internal string vxod_id = "";
        public DeleteUserForm()
        {
            InitializeComponent();
            userNameField.Text = "Логин пользователя";
            userNameField.ForeColor = Color.Gray;
        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Логин пользователя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Логин пользователя";
                userNameField.ForeColor = Color.Gray;
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlDataReader reader;

            MySqlCommand command_log = new MySqlCommand("select sotrudnik.id from `sotrudnik` join vxod on SOTRUDNIK.id = SOTRUDNIK_id WHERE login = @login", db.getConnection());

            command_log.Parameters.Add("@login", MySqlDbType.VarChar).Value = userNameField.Text;
            

            db.openConnection();

            reader = command_log.ExecuteReader();
            while (reader.Read())
            {
                log_id = reader["id"].ToString();
            }

            db.closeConnection();

            MySqlCommand command_vxod_id = new MySqlCommand("select vxod.id from `sotrudnik` join vxod on SOTRUDNIK.id = SOTRUDNIK_id WHERE login = @login", db.getConnection());

            command_vxod_id.Parameters.Add("@login", MySqlDbType.VarChar).Value = userNameField.Text;


            db.openConnection();

            reader = command_vxod_id.ExecuteReader();
            while (reader.Read())
            {
                vxod_id = reader["id"].ToString();
            }

            db.closeConnection();

            MySqlCommand command_del_vxod = new MySqlCommand("DELETE FROM `oborot`.`vxod` WHERE (`id` = @vxod_id);", db.getConnection());

            command_del_vxod.Parameters.Add("@vxod_id", MySqlDbType.VarChar).Value = vxod_id;

            db.openConnection();

            command_del_vxod.ExecuteNonQuery();

            db.closeConnection();

            MySqlCommand command = new MySqlCommand("DELETE FROM `oborot`.`sotrudnik` WHERE (`id` = @log_id);", db.getConnection());

            command.Parameters.Add("@log_id", MySqlDbType.VarChar).Value = log_id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт удален");
            else
                MessageBox.Show("Аккаунт не удален");

            db.closeConnection();
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.BackColor = Color.Red;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }
    }
}
