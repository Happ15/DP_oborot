using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace sandbox_databases
{
    public partial class NewTable10_ : Form
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        internal int id;
        public NewTable10_()
        {
            InitializeComponent();

            

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select `id`, `Фамилия`, `Имя`, `Отчество`, `Телефон`, `Электронная почта`  " +
                "from `SOTRUDNIK` where PODRAZDELENIE_id =" + podrazdelenie.Value
                + " AND `DOLZNOST_id` != '3'", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];

            db.closeConnection();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `oborot`.`history` (`Дата_Получения`, SOTRUDNIK_id, DOKUMENT_id)" +
               " VALUES (CURDATE(), @sotr_id, @doc_id)", db.getConnection());

            command.Parameters.Add("@sotr_id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@doc_id", MySqlDbType.Int32).Value = id_doc.Value;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Запись добавлена");
            }
            else
                MessageBox.Show("Запись не добавлена");

            db.closeConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RukovosShow RukovosShow = new RukovosShow();
            RukovosShow.Show();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RukovosShow RukovosShow = new RukovosShow();
            RukovosShow.Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ds.Reset();
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            id = int.Parse(ids);

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from `HISTORY` where SOTRUDNIK_id = " +
                id, db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            db.closeConnection();
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

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

    }
}
