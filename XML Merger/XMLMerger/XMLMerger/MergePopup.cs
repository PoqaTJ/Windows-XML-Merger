using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLMerger
{
    public partial class MergePopup : Form
    {
        public string Choice = null;

        List<string> Choices;

        public MergePopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Choice = Choices[listBox1.SelectedIndex];
                this.Close();
            }
            else
                MessageBox.Show("Please select which file to keep.");
        }

        public void CreateList(List<LoadedFile> Files, string ElementID)
        {
            
        }

        internal void SetItems(string ID, List<LoadedFile> Files)
        {
            Choices = new List<string>();

            foreach (LoadedFile f in Files)
            {
                if (f.HasElementWithID(ID))
                {
                    listBox1.Items.Add(f.FileName + " string: " + f.GetStringForID(ID) + " toolTip: " + f.GetTooltipForID(ID));
                    Choices.Add(f.FileName);
                }
            }
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width). 
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Width, control.Size.Width);
            }
        }
    }
}
