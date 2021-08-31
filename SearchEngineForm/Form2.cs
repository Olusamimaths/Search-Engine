using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchEngine.src.Uploader;

namespace SearchEngineForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.Filter = "Document types (*.txt;*.html;*.xlsx;*.xls;*.ppts;*.ppt;*.docx;*.doc;*.pdf;*.xml)|*.txt;*.html;*.xlsx;*.xls;*.ppts;*.ppt;*.docx;*.doc;*.pdf;*.xml|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string labelmessage = UploadType.Upload(textBox1.Text);
            label1.Text = labelmessage;
        }
    }
}

