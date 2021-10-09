using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wheather
{
    class File
    {
        string FileName;
       public string[] lines;

        public File(string FileName)
        {
            this.FileName = FileName;
        }
        public void ReadFromFile()
        {
            lines = System.IO.File.ReadAllLines(FileName);
        }
        public void RemoveUnwantedCharacter(char ch)
        {
            string[] newLines = new string[lines.Length];

            for(int i = 0; i<lines.Length;i++)
            {
                newLines[i]=lines[i].Replace(ch,' ');
            }
            lines = newLines;
        }
    }
}
