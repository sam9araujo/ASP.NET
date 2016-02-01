using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Hours
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string pathSRC = @"C:\02-2016.csv";

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDatehorarioAtual.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

            StreamReader read = new StreamReader(pathSRC);

            foreach (var item in read.ReadToEnd())
            {
                txtReadTXT.Text += item.ToString();
            }

            read.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sWriter = new StreamWriter(pathSRC);
            Decimal total = Convert.ToDecimal(txtStart.Text.Replace(':',' ')) + Convert.ToDecimal(txtEnd.Text.Replace(':',' '));
            sWriter.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + ";" + txtStart.Text + ";" + txtEnd.Text + ";" + total.ToString("00:00"));

            sWriter.Close();

            StreamReader read = new StreamReader(pathSRC);

            foreach (var item in read.ReadToEnd())
            {
                txtReadTXT.Text += item.ToString();
            }

            read.Close();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
