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
    public partial class RukovosShow : Form
    {
        DataSet ds = new DataSet();
        internal string FlagTbl = "0";


        public RukovosShow()
        {
            InitializeComponent();
            label5.Text = logos.Value;
            button5.Visible = false;

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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_auth LoginForm = new Form_auth();
            LoginForm.Show();
        }


        public void offTime()
        {
            DateTime date1 = DateTime.Now;

            int useCat = int.Parse(intim.Value);


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE session " +
                "SET `Выход` = @vh," +
                " users_id = (SELECT id FROM users WHERE `Логин` = @uL), " +
                "WHERE id = @intim", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;
            command.Parameters.Add("@vh", MySqlDbType.DateTime).Value = date1;
            command.Parameters.Add("@intim", MySqlDbType.Int32).Value = useCat;


            db.openConnection();

            command.ExecuteReader();

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            FlagTbl = "1";
            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select `DOKUMENT`.`id`, `Дата`, `Содержание`, `Текущий_статус`, `Правки_и_изменения`, `Тип_Документа`" +
                " from DOKUMENT join `TIP_DOKUMENTA` on TIP_DOKUMENTA_id = TIP_DOKUMENTA.id" +
                " where DOKUMENT.id NOT IN (SELECT DOKUMENT_id FROM HISTORY)", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            FlagTbl = "2";
            ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from `HISTORY` where Дата_Отправки IS NULL", db.getConnection());


                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            FlagTbl = "3";
            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from `HISTORY` where Дата_Отправки > 0", db.getConnection());


            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();


        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_auth LoginForm = new Form_auth();
            LoginForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);


            DateTime date = DateTime.Now;

            DB db = new DB();

            MySqlDataReader reader;

            MySqlCommand slka = new MySqlCommand("select Ссылка from `doc` where id = @uL", db.getConnection());

            slka.Parameters.Add("@uL", MySqlDbType.Int32).Value = id;

            MySqlCommand command1 = new MySqlCommand("INSERT INTO work_user_doc " +
                "SET `Время` = @time," +
                " users_id = (SELECT id FROM users WHERE `Логин` = @idu)," +
                " doc_id = (SELECT id FROM doc WHERE `id` = @idd)", db.getConnection());

            command1.Parameters.Add("@time", MySqlDbType.DateTime).Value = date;
            command1.Parameters.Add("@idu", MySqlDbType.VarChar).Value = login.Value;
            command1.Parameters.Add("@idd", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Принят в работу");
            }
            else
                MessageBox.Show("Не принят в работу");

            reader = slka.ExecuteReader();
            while (reader.Read())
            {
                string slka1 = reader["Ссылка"].ToString();
            }

            db.closeConnection();

        }


        private void button5_Click(object sender, EventArgs e)
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            id_doc.Value = id;

            this.Hide();
            NewTable10_ NewTable10 = new NewTable10_();
            NewTable10.Show();


            //flagTbl = "0";
            //string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            //int id = int.Parse(ids);

            //DateTime date = DateTime.Now;

            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("DELETE FROM work_user_doc "  +
            //    " WHERE `doc_id` = @idx", db.getConnection());

            //MySqlCommand command1 = new MySqlCommand("INSERT INTO gotov_doc " +
            //    "SET `Время` = @time," +
            //    " users_id = (SELECT id FROM users WHERE `Логин` = @idu)," +
            //    " doc_id = (SELECT id FROM doc WHERE `id` = @idd)", db.getConnection());

            //command.Parameters.Add("@idx", MySqlDbType.Int32).Value = id;

            //command1.Parameters.Add("@time", MySqlDbType.DateTime).Value = date;
            //command1.Parameters.Add("@idu", MySqlDbType.VarChar).Value = login.Value;
            //command1.Parameters.Add("@idd", MySqlDbType.Int32).Value = id;

            //db.openConnection();

            //if (command.ExecuteNonQuery() == 1 && command1.ExecuteNonQuery() == 1)
            //    MessageBox.Show("Готово");
            //else
            //    MessageBox.Show("Не готово");

            //db.closeConnection();
        }


        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            //int id = int.Parse(ids);

            //Process.Start(@"C:\Users\danil\source\repos\sandbox_databases\sandbox_databases\bin\Debug\Testing\" + id + ".docx");


            //DB db = new DB();

            //MySqlDataReader reader;

            //MySqlCommand slka = new MySqlCommand("select Ссылка from `doc` where id = @uL", db.getConnection());

            //slka.Parameters.Add("@uL", MySqlDbType.Int32).Value = id;

            //db.openConnection();

            //reader = slka.ExecuteReader();
            //while (reader.Read())
            //{
            //    slka1 = reader["Ссылка"].ToString();
            //}

            //db.closeConnection();


            //string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            //int id = int.Parse(ids);

            //DB db = new DB();

            //MySqlDataReader reader;

            //MySqlCommand slka = new MySqlCommand("select Ссылка from `doc` where id = @uL", db.getConnection());

            //slka.Parameters.Add("@uL", MySqlDbType.Int32).Value = id;

            //db.openConnection();

            //reader = slka.ExecuteReader();
            //while (reader.Read())
            //{
            //    slka1 = reader["Ссылка"].ToString();
            //}

            //db.closeConnection();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewTable7 LoginForm = new NewTable7();
            LoginForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (FlagTbl == "1")
                button1_Click(login.Value, e);
            else if (FlagTbl == "2")
                button2_Click(login.Value, e);
            else if (FlagTbl == "3")
                button4_Click(login.Value, e);
            else if (FlagTbl == "0")
                MessageBox.Show("Готово");
            else MessageBox.Show("Ошибка");
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.BackColor = Color.Silver;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.Transparent;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            Process.Start(@"C:\Users\danil\source\repos\sandbox_databases\sandbox_databases\bin\Debug\Testing\" + id + ".docx");

        }


    }
}
