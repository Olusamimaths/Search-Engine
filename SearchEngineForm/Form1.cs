using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchEngine;


namespace SearchEngineForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            List<String> results = SearchEngine.SearchNaive.Search(textBox1.Text);
            if (results.Count == 0) { richTextBox1.Text = "Your query does not match anything..."; }
            foreach (var docName in results)
            {
                richTextBox1.Text  += docName + "\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
       
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
   
}
