using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLMerger
{
    class DupeTester
    {
        public static void FindDuplicates(ref List<LoadedFile> Files)
        {
            bool DuplicateFound = true;

            while (DuplicateFound == true)
            {
                string duplicateID = FindFirstDuplicate(Files);

                if (duplicateID != null)
                {
                    // choose which file to keep
                    var Popup = new MergePopup();
                    Popup.SetItems(duplicateID, Files);
                    Popup.ShowDialog();
                    string exception = Popup.Choice;
                    RemoveElementWithID(ref Files, exception, duplicateID);
                }
                else
                    DuplicateFound = false;
            }
        }

        private static string FindFirstDuplicate(List<LoadedFile> Files)
        {
            Dictionary<int, XElement> Elements = new Dictionary<int, XElement>();

            foreach (LoadedFile file in Files)
            {
                foreach (XElement element in file.Elements)
                {
                    try
                    {
                        Elements.Add(int.Parse(element.Attribute("id").Value), element);
                    }
                    catch (ArgumentException e)
                    {
                        return element.Attribute("id").Value;
                    }
                }
            }

            return null;
        }

        private static void RemoveElementWithID(ref List<LoadedFile> Files, string exception, string p)
        {
            //MessageBox.Show("Duplicate detected! Removing all items with id " + p);

            List<LoadedFile> filesWithDuplicates = new List<LoadedFile>();

            foreach (LoadedFile f in Files)
            {
                if (f.FileName != exception)
                {

                    foreach (XElement e in f.Elements)
                    {
                        if (e.Attribute("id").Value == p)
                        {
                            filesWithDuplicates.Add(f);
                        }
                    }
                }
            }

            for (int i = filesWithDuplicates.Count - 1; i >= 0; i--)
            {
                RemoveElement(filesWithDuplicates[i], p);
            }
        }

        private static void RemoveElement(LoadedFile f, string p)
        {
            for (int i = f.Elements.Count - 1; i >= 0; i--)
            {
                if (f.Elements[i].Attribute("id").Value == p)
                    f.Elements.RemoveAt(i);
            }
        }
    }
}