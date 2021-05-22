﻿using MySql.Data.MySqlClient;
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

namespace sandbox_databases
{
    
    public partial class UserMain : Form
    {
        string obnovTbl = "0";
        string flagTbl = "0";
        string flagTblcomp = "0";
        DataSet ds = new DataSet();
        string slka1 = "";
        public UserMain()
        {
            InitializeComponent();

            button3.Visible = false;
            button5.Visible = false;

            if (logos.Value == "office")
            {
                button6.Visible = true;
                label5.Text = login.Value;
            }
            else
            if (logos.Value == "company")
            {
                button6.Visible = false;
                label5.Text = login.Value;
            }
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
            obnovTbl = "1";
            linkLabel1.Text = "";
            if (logos.Value == "office")
            {
                button5.Visible = false;
                button3.Visible = false;
                flagTblcomp = "0";
            }
            else
            if (logos.Value == "company")
            {
                button5.Visible = false;
                button3.Visible = true;
            }
            

            flagTbl = "0";
            ds.Reset();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DB db = new DB();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand command = new MySqlCommand("select * from doc where not EXISTS(select * from work_user_doc where doc_id = id) and not EXISTS(select * from gotov_doc where doc_id = id)", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obnovTbl = "2";
            if (logos.Value == "office")
            {
                button5.Visible = false;
                button3.Visible = false;
                flagTblcomp = "1";
                linkLabel1.Text = "";
            }
            else
           if (logos.Value == "company")
            {
                button5.Visible = true;
                button3.Visible = false;
            }

            if (logos.Value == "company")
            {
                flagTbl = "1";
                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from work_user_doc where users_id = (select id from users where логин = @uL)", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
           if (logos.Value == "office")
            {
                flagTbl = "2";
                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from work_user_doc", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obnovTbl = "3";
            button5.Visible = false;
            button3.Visible = false;
            flagTbl = "0";
            linkLabel1.Text = "";
            if (logos.Value == "company")
            {
                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from gotov_doc where users_id = (select id from users where логин = @uL)", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if(logos.Value == "office")
            {
                flagTblcomp = "2";
                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from gotov_doc", db.getConnection());

                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
                
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_auth LoginForm = new Form_auth();
            LoginForm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            flagTbl = "0";
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
                slka1 = reader["Ссылка"].ToString();
            }

            db.closeConnection();

            linkLabel1.Text = slka1;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flagTbl = "0";
            string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            int id = int.Parse(ids);

            DateTime date = DateTime.Now;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM work_user_doc "  +
                " WHERE `doc_id` = @idx", db.getConnection());

            MySqlCommand command1 = new MySqlCommand("INSERT INTO gotov_doc " +
                "SET `Время` = @time," +
                " users_id = (SELECT id FROM users WHERE `Логин` = @idu)," +
                " doc_id = (SELECT id FROM doc WHERE `id` = @idd)", db.getConnection());

            command.Parameters.Add("@idx", MySqlDbType.Int32).Value = id;

            command1.Parameters.Add("@time", MySqlDbType.DateTime).Value = date;
            command1.Parameters.Add("@idu", MySqlDbType.VarChar).Value = login.Value;
            command1.Parameters.Add("@idd", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1 && command1.ExecuteNonQuery() == 1)
                MessageBox.Show("Готово");
            else
                MessageBox.Show("Не готово");

            db.closeConnection();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(flagTbl == "1")
            {
                string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int id = int.Parse(ids);

                DB db = new DB();

                MySqlDataReader reader;

                MySqlCommand slka = new MySqlCommand("select Ссылка from `doc` where id = @uL", db.getConnection());

                slka.Parameters.Add("@uL", MySqlDbType.Int32).Value = id;

                db.openConnection();

                reader = slka.ExecuteReader();
                while (reader.Read())
                {
                    slka1 = reader["Ссылка"].ToString();
                }

                db.closeConnection();

                linkLabel1.Text = slka1;
            }

            if (flagTblcomp == "2")
            {
                string ids = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                int id = int.Parse(ids);

                DB db = new DB();

                MySqlDataReader reader;

                MySqlCommand slka = new MySqlCommand("select Ссылка from `doc` where id = @uL", db.getConnection());

                slka.Parameters.Add("@uL", MySqlDbType.Int32).Value = id;

                db.openConnection();

                reader = slka.ExecuteReader();
                while (reader.Read())
                {
                    slka1 = reader["Ссылка"].ToString();
                }

                db.closeConnection();

                linkLabel1.Text = slka1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            flagTblcomp = "0";
            this.Hide();
            NewTable7 LoginForm = new NewTable7();
            LoginForm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (obnovTbl == "1")
            {
                linkLabel1.Text = "";
                if (logos.Value == "office")
                {
                    button5.Visible = false;
                    button3.Visible = false;
                    flagTblcomp = "0";
                }
                else
                if (logos.Value == "company")
                {
                    button5.Visible = false;
                    button3.Visible = true;
                }


                flagTbl = "0";
                ds.Reset();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                DB db = new DB();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;

                MySqlCommand command = new MySqlCommand("select * from doc where not EXISTS(select * from work_user_doc where doc_id = id) and not EXISTS(select * from gotov_doc where doc_id = id)", db.getConnection());

                db.openConnection();

                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                db.closeConnection();
            }
            else
            if (obnovTbl == "2")
            {
                if (logos.Value == "office")
                {
                    button5.Visible = false;
                    button3.Visible = false;
                    flagTblcomp = "0";
                    linkLabel1.Text = "";
                }
                else
           if (logos.Value == "company")
                {
                    button5.Visible = true;
                    button3.Visible = false;
                }

                if (logos.Value == "company")
                {
                    flagTbl = "1";
                    ds.Reset();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DB db = new DB();

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;

                    MySqlCommand command = new MySqlCommand("select * from work_user_doc where users_id = (select id from users where логин = @uL)", db.getConnection());

                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    db.closeConnection();
                }
                else
               if (logos.Value == "office")
                {
                    ds.Reset();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DB db = new DB();

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;

                    MySqlCommand command = new MySqlCommand("select * from work_user_doc", db.getConnection());

                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    db.closeConnection();
                }
            }
            else
            if (obnovTbl == "3")
            {
                button5.Visible = false;
                button3.Visible = false;
                flagTbl = "0";
                linkLabel1.Text = "";
                if (logos.Value == "company")
                {
                    ds.Reset();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DB db = new DB();

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;

                    MySqlCommand command = new MySqlCommand("select * from gotov_doc where users_id = (select id from users where логин = @uL)", db.getConnection());

                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    db.closeConnection();
                }
                else
                if (logos.Value == "office")
                {
                    flagTblcomp = "1";
                    ds.Reset();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DB db = new DB();

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AllowUserToAddRows = false;

                    MySqlCommand command = new MySqlCommand("select * from gotov_doc", db.getConnection());

                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Value;

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    db.closeConnection();
                }
            }
            else
            if (obnovTbl == "0")
            {
                MessageBox.Show("Выберите таблицу!");
            }
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.BackColor = Color.Silver;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.Transparent;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}