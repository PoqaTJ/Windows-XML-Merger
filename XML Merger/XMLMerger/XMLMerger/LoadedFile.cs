using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.IO;


namespace XMLMerger
{
    public class LoadedFile
    {
        private List<XElement> elements;
        private string fileName;
        private string filePath;

        public String FileName
        {
            get { return fileName; }
        }
        public String FilePath
        {
            get { return filePath; }
        }
        public List<XElement> Elements
        {
            get { return elements; }
        }

        public int Count
        {
            get { return Elements.Count; }
        }

        public LoadedFile(string path)
        {
            this.filePath = path;
            this.fileName = Path.GetFileName(path);

            StreamReader stream = new StreamReader(path);
            XDocument document = XDocument.Load(stream);
            stream.Close();

            PopulateElements(document);

            Console.WriteLine("Loaded XML file with path: " + path);
            Console.WriteLine("Loaded XML file with file name: " + fileName);
        }

        private void LoadXML()
        {

        }

        private void PopulateElements(XDocument document)
        {
            elements = new List<XElement>();

            foreach (XElement e in document.Root.Elements())
            {
                elements.Add(e);
            }

            Console.WriteLine("Added " + Count + " elements.");
        }

        internal bool HasElementWithID(string ID)
        {
            foreach (XElement e in Elements)
            {
                if (e.Attribute("id").Value == ID)
                    return true;
            }

            return false;
        }

        internal string GetValueForID(string attribute, string ID)
        {
            foreach (XElement e in Elements)
            {
                if (e.Attribute("id").Value == ID)
                    return e.Attribute(attribute).Value;
            }

            return null;
        }

        internal string GetStringForID(string ID)
        {
            return GetValueForID("string", ID);
        }

        internal string GetTooltipForID(string ID)
        {
            return GetValueForID("toolTip", ID);
        }
    }
}
