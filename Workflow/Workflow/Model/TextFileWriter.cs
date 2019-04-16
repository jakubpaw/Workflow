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

        public void Write(string[] newText)
        {
            throw new NotImplementedException();
        }

        public void AddOneLine(string newLine)
        {
            throw new NotImplementedException();
        }
    }
}
