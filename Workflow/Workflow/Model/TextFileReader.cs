using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Model
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
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);
                return lines;
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
            return null;
        }
    }
}
