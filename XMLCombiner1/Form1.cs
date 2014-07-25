using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace XMLCombiner
{
    public partial class Form1 : Form
    {
        Dictionary<string, XDocument> Documents;

        public Form1()
        {
            InitializeComponent();
         
            this.openFileDialog1.Filter =
                "XML Files | *.XML | All Files | *.*";

            // Allow the user to select multiple images. 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Add Files";

            Documents = new Dictionary<string, XDocument>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openFileDialog1.FileNames)
                {
                    System.IO.StreamReader sr = new
                        System.IO.StreamReader(openFileDialog1.FileName);

                    if (Documents.ContainsKey(s))
                        Documents[s] = XDocument.Load(sr);
                    else
                        Documents.Add(s, XDocument.Load(sr));
                    sr.Close();
                }
            }

            RefreshListBoxContents();
        }

        private void RefreshListBoxContents()
        {
            listBox1.ClearSelected();
            foreach (string s in Documents.Keys)
            {
                listBox1.Items.Add(s);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
