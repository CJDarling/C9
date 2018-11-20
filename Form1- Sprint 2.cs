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
            listView1.Items.Add(MovieTitle);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        

        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Checked)
                {
                    listView1.Items[i].Remove();
                }
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string MovieTitle = textBox1.Text;
            label3.Text = "";
            System.Net.WebClient webclient = new System.Net.WebClient();
            string webData = webclient.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=0853e59fd43ca7f94bd83ad97d04ebec&query=" + MovieTitle);
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
    }
}
