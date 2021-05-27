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
    public partial class FolderTable : Form
    {
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
        public FolderTable()
        {
            InitializeComponent();
            label5.Text = FileEnd.Value;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm1 = new MainForm();
            MainForm1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm1 = new MainForm();
            MainForm1.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label5.Text = folderBrowserDialog1.SelectedPath;
                FileEnd.Value = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
