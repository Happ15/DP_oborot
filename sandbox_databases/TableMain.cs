using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_databases
{
    public partial class TableMain : Form
    {
        DataSet ds = new DataSet();
        int flagTable = 0;
        string flagTbl = "";
        internal string vxod_id = "";
        public TableMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(flagTable == 1)
            {
                this.Hide();
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
            }
            else
            if(flagTable == 2)
            {
                this.Hide();
                NewTable2 newTable2 = new NewTable2();
                newTable2.Show();
            }
            else
            if (flagTable == 3)
            {
                this.Hide();
                NewTable3 newTable3 = new NewTable3();
                newTable3.Show();
            }
            else
            if (flagTable == 4)
            {
                this.Hide();
                NewTable4 newTable4 = new NewTable4();
                newTable4.Show();
            }
            else
            if (flagTable == 5)
            {
                this.Hide();
                NewTable5 newTable5 = new NewTable5();
                newTable5.Show();
            }
            else
            if (flagTable == 6)
            {
                this.Hide();
                NewTable6 newTable = new NewTable6();
                newTable.Show();
            }
            else
            if (flagTable == 7)
            {
                this.Hide();
                NewTable7 newTable = new NewTable7();
                newTable.Show();
            }
            else
            if (flagTable == 8)
            {
                this.Hide();
                NewTable8 newTable = new NewTable8();
                newTable.Show();
            }
            else
            if (flagTable == 9)
            {
                this.Hide();
                NewTable9 newTable = new NewTable9();
                newTable.Show();
            }
            else
            if (flagTable == 0)
            {
                MessageBox.Show("Выберите таблицу");
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            flagTable = 1;
            flagTbl = "SOTRUDNIK";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from sotrudnik", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            flagTable = 2;
            flagTbl = "VXOD";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from vxod", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            flagTable = 3;
            flagTbl = "PODRAZDELENIE";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from PODRAZDELENIE", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            flagTable = 4;
            flagTbl = "DOLZNOST";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from dolznost", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {

            flagTable = 5;
            flagTbl = "sessions";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from session", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

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

        Point lastPoint;
        private void TableMain_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void TableMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

            flagTable = 6;
            flagTbl = "HISTORY";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from HISTORY", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            flagTable = 7;
            flagTbl = "DOKUMENT";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select id, Дата, Текущий_статус, Правки_и_изменения, TIP_DOKUMENTA_id  from DOKUMENT", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(flagTable == 0)
            {
                MessageBox.Show("Выберите таблицу");
                return;
            }
            if (flagTable == 1)
            {
                noneid_SOTRUDNIK();
                return;
            }
            if (flagTable == 2)
            {
                noneidVXOD();
                return;
            }
            if (flagTable == 3)
            {
                noneid_PODRAZDELENIE();
                return;
            }
            if (flagTable == 4)
            {
                noneid_DOLZNOST();
                return;
            }
            if (flagTable == 6)
            {
                noneid_HISTORY();
                return;
            }
            if (flagTable == 7)
            {
                noneid_DOKUMENT();
                return;
            }

            if (flagTable == 8)
            {
                noneidWork();
                return;
            }
            if (flagTable == 9)
            {
                noneidWork();
                return;
            }

            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM " + flagTbl +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись удалена");
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }

        public void noneid_DOKUMENT()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM DOKUMENT " +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Запись удалена");
            }
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();


            //Это было до изменения программы
            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("DELETE FROM doc " +
            //    " WHERE `id` = @idx", db.getConnection());
            //MySqlCommand command3 = new MySqlCommand("DELETE FROM work_user_doc " +
            //    " WHERE `doc_id` IN (select id from doc where id = @idx)", db.getConnection());
            //MySqlCommand command4 = new MySqlCommand("DELETE FROM gotov_doc " +
            //    " WHERE `doc_id` IN (select id from doc where id = @idx)", db.getConnection());

            //command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command3.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command4.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;


            //db.openConnection();
            //command4.ExecuteNonQuery();
            //command3.ExecuteNonQuery();

            //if (command.ExecuteNonQuery() == 1)
            //{

            //    MessageBox.Show("Запись удалена");
            //}
            //else
            //    MessageBox.Show("Запись не удалена");

            //db.closeConnection();
        }

        public void noneid_SOTRUDNIK()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            

            DB db = new DB();

            MySqlDataReader reader;


            MySqlCommand command_vxod_id = new MySqlCommand("select vxod.id from `sotrudnik` join vxod on SOTRUDNIK.id = SOTRUDNIK_id WHERE SOTRUDNIK.id = @SOTR_ID", db.getConnection());

            command_vxod_id.Parameters.Add("@SOTR_ID", MySqlDbType.VarChar).Value = ids;


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

            command.Parameters.Add("@log_id", MySqlDbType.VarChar).Value = ids;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт удален");
            else
                MessageBox.Show("Аккаунт не удален");

            db.closeConnection();
        }

        public void noneid_HISTORY()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM HISTORY " +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Запись удалена");
            }
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }

        public void noneid_DOLZNOST()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM DOLZNOST " +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Запись удалена");
            }
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }

        public void noneid_PODRAZDELENIE()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM PODRAZDELENIE " +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {

                MessageBox.Show("Запись удалена");
            }
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();

            //Это было до изменения программы может пригодится
            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("DELETE FROM company " +
            //    " WHERE `id` = @idx", db.getConnection());
            //MySqlCommand command1 = new MySqlCommand("DELETE FROM adres " +
            //    " WHERE `company_id` = @idx", db.getConnection());
            //MySqlCommand command2 = new MySqlCommand("DELETE FROM doc " +
            //    " WHERE `company_id` = @idx", db.getConnection());
            //MySqlCommand command3 = new MySqlCommand("DELETE FROM work_user_doc " +
            //    " WHERE `doc_id` IN (select id from doc where company_id = @idx)", db.getConnection());
            //MySqlCommand command4 = new MySqlCommand("DELETE FROM gotov_doc " +
            //    " WHERE `doc_id` IN (select id from doc where company_id = @idx)", db.getConnection());

            //command.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command1.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command2.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command3.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //command4.Parameters.Add("@idx", MySqlDbType.Int32).Value = ids;

            //db.openConnection();
            //command4.ExecuteNonQuery();
            //command3.ExecuteNonQuery();
            //command1.ExecuteNonQuery();
            //command2.ExecuteNonQuery();

            //if (command.ExecuteNonQuery() == 1)
            //{

            //    MessageBox.Show("Запись удалена");
            //}
            //else
            //    MessageBox.Show("Запись не удалена");

            //db.closeConnection();
        }

        public void noneidVXOD()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM " + flagTbl +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.VarChar).Value = ids;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись удалена");
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }

        public void noneidWork()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM " + flagTbl +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись удалена");
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }

        public void noneid()
        {
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM " + flagTbl +
                " WHERE `id` = @idx", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Запись удалена");
            else
                MessageBox.Show("Запись не удалена");

            db.closeConnection();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (flagTbl == "SOTRUDNIK")
            {
                flagTable = 1;
                flagTbl = "SOTRUDNIK";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from SOTRUDNIK", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (flagTbl == "VXOD")
            {
                flagTable = 2;
                flagTbl = "VXOD";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from VXOD", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (flagTbl == "PODRAZDELENIE")
            {
                flagTable = 3;
                flagTbl = "PODRAZDELENIE";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from PODRAZDELENIE", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            //else
            //if (flagTbl == "sessions")
            //{
            //    flagTable = 5;
            //    flagTbl = "sessions";

            //    ds.Reset();
            //    MySqlDataAdapter adapter = new MySqlDataAdapter();

            //    DB db = new DB();

            //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    dataGridView1.AllowUserToAddRows = false;

            //    MySqlCommand command = new MySqlCommand("select * from session", db.getConnection());

            //    db.openConnection();

            //    adapter.SelectCommand = command;
            //    adapter.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];

            //    db.closeConnection();
                
            //}
            else
            if (flagTbl == "DOLZNOST")
            {
                flagTable = 4;
                flagTbl = "DOLZNOST";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from DOLZNOST", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (flagTbl == "HISTORY")
            {
                flagTable = 6;
                flagTbl = "HISTORY";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from HISTORY", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (flagTbl == "DOKUMENT")
            {
                flagTable = 7;
                flagTbl = "DOKUMENT";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from DOKUMENT", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (flagTbl == "work_TIP_DOKUMENTAuser_doc")
            {
                flagTable = 8;
                flagTbl = "TIP_DOKUMENTA";

                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from TIP_DOKUMENTA", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            //else
            //if (flagTbl == "gotov_doc")
            //{
            //    flagTable = 9;
            //    flagTbl = "gotov_doc";

            //    ds.Reset();
            //    MySqlDataAdapter adapter = new MySqlDataAdapter();

            //    DB db = new DB();

            //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    dataGridView1.AllowUserToAddRows = false;

            //    MySqlCommand command = new MySqlCommand("select * from gotov_doc", db.getConnection());

            //    db.openConnection();

            //    adapter.SelectCommand = command;
            //    adapter.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];

            //    db.closeConnection();
            //}
            else
            if (flagTbl == "")
            {
                MessageBox.Show("Выберите таблицу");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm1 = new MainForm();
            MainForm1.Show();
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.BackColor = Color.Red;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.BackColor = Color.FromArgb(76, 75, 100);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            flagTable = 8;
            flagTbl = "TIP_DOKUMENTA";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from TIP_DOKUMENTA", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            flagTable = 9;
            flagTbl = "gotov_doc";

            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from gotov_doc", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableMain_Load(object sender, EventArgs e)
        {

        }
    }
}
