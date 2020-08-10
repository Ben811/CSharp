using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compliator_semest
{
    public class FileTxtReader
    {

        public static string ReadFile(string filename)
        {
            string code = "";
            var lines = File.ReadLines(filename);

            foreach (var line in lines)
            {
                code += line + "\n";
            }            
            return code;
        }
    }
}
