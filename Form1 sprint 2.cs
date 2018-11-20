using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> wishlist = new List<string>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MovieTitle = textBox1.Text;
            string MovieYear = textBox2.Text;
            label3.Text = "";
            System.Net.WebClient webclient = new System.Net.WebClient();
            string webData = webclient.DownloadString("http://www.omdbapi.com/?apikey=29739845&s=" + MovieTitle + "&y=" + MovieYear);
            List<string> matches = new List<string>(webData.Split('{'));
            for (int i = 2; i < matches.Count; i++)
            {
                string newword = matches[i].Replace('"', ' ');
                matches[i] = newword;
                newword = matches[i].Replace('}', '\n');
                matches[i] = newword;
                newword = matches[i].Replace(']', ' ');
                matches[i] = newword;
                newword = matches[i].Replace(',', '\n');
                matches[i] = newword;
                label3.Text += matches[i] + '\n';
            } 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string MovieTitle = textBox1.Text;
            wishlist.Add(MovieTitle);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var message = string.Join(Environment.NewLine, wishlist);
            MessageBox.Show(message);
        }
    }

}
