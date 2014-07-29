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

namespace XMLMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = true;
            dialog.Filter = "XML Files|*.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in dialog.FileNames)
                {
                    try
                    {
                        XDocument.Load(s);
                        FileList.Items.Add(s);
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("Couldn't load file " + s + " as an XML document.");
                    }
                }
            }
        }

        private void RemoveFileButton_Click(object sender, EventArgs e)
        {
            FileList.ClearSelected();
        }

        private void ClearFilesButton_Click(object sender, EventArgs e)
        {
            FileList.Items.Clear();
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            List<LoadedFile> Files = new List<LoadedFile>();

            foreach (string s in FileList.Items)
            {
                Files.Add(new LoadedFile(s));
            }

            DupeTester.FindDuplicates(ref Files);

            XDocument result = new XDocument(new XElement("StrSheet_Item"));

            List<XElement> allElements = new List<XElement>();

            

            foreach (LoadedFile f in Files)
            {
                allElements.AddRange(f.Elements);
            }

            allElements = allElements.OrderBy(x => int.Parse(x.Attribute("id").Value)).ToList();

            Console.WriteLine("Added " + allElements.Count + " elements.");

            result.Root.Add(allElements);

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "XML File|*.xml";
            save.Title = "Save Merged File";
            save.ShowDialog();

            if (save.FileName != "")
            {
                FileStream stream = (FileStream)save.OpenFile();
                result.Save(stream);
                stream.Close();
                string path = Path.GetDirectoryName(save.FileName);
                System.Diagnostics.Process.Start(path);
            }

            MessageBox.Show("Finished merging.");

        }
    }
}
