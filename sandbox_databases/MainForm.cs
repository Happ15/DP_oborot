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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pere.Value = "0";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void registerLabel_Click(object sender, EventArgs e)
        {
            pere.Value = "1";
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_auth LoginForm = new Form_auth();
            LoginForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteUserForm DeleteForm = new DeleteUserForm();
            DeleteForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowUsers ShowUsersForm = new ShowUsers();
            ShowUsersForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TableMain tablemainshow = new TableMain();
            tablemainshow.Show();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM gotov_doc WHERE Время < DATE_SUB(NOW() , INTERVAL 1 MONTH)", db.getConnection());
            MySqlCommand command1 = new MySqlCommand("DELETE FROM work_user_doc WHERE Время < DATE_SUB(NOW() , INTERVAL 1 MONTH)", db.getConnection());

            command.Parameters.Add("@time", MySqlDbType.Date).Value = time.AddDays(-30);

            db.openConnection();

            if (command.ExecuteNonQuery() == 1 || command1.ExecuteNonQuery() == 1)
            {
                
                MessageBox.Show("Очищено");
            }
            else
                MessageBox.Show("Не очищено");

            db.closeConnection();
        }
    }
}
