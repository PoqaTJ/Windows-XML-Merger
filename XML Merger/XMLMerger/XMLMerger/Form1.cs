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
        public List<LoadedFile> Files;

        public Form1()
        {
            InitializeComponent();
            Files = new List<LoadedFile>();
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
                    Files.Add(new LoadedFile(s));
                }
            }

            RefreshUI();
        }

        public void RefreshUI()
        {
            if (Files != null)
            {
                List<string> names = Files.Select(f => f.FileName).ToList();

                FileList.Items.Clear();
                FileList.Items.AddRange(names.ToArray());
            }
            else
                FileList.Items.Clear();
        }

        private void RemoveFileButton_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();

            foreach (Object o in FileList.SelectedItems)
                names.Add(o.ToString());

            ClearFiles(names);
            RefreshUI();
        }

        private void ClearFilesButton_Click(object sender, EventArgs e)
        {
            ClearFiles();
            RefreshUI();
        }

        private void ClearFiles()
        {
            Files = new List<LoadedFile>();
        }

        private void ClearFiles(List<string> names)
        {
            foreach (string s in names)
            {
                for (int i = 0; i <= Files.Count - 1; i++)
                    if (Files[i].FileName == s)
                        Files.RemoveAt(i);
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
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
