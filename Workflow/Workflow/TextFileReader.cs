using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow
{
    class TextFileReader
    {
        private string filePath;
        public TextFileReader(string path)
        {
            filePath = path;
        }
        public string[] readLines()
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            return lines;
        }
    }
}
