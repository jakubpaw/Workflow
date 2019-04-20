using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
{
    class TextFileWriter
    {
        private string filePath;

        public TextFileWriter(string path)
        {
            filePath = path;
        }

        public void Write(List<string> newText)
        {
            System.IO.File.WriteAllLines(filePath, newText);
        }

        public void AddOneLine(string newLine)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true)) ;
        }
    }
}
