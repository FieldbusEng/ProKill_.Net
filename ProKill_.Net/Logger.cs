using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKill_.Net
{
    class Logger
    {
        public Logger(string _message)
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string pathL = path + "LogFile.txt";
            if (!File.Exists(pathL))
            {
                DateTime timeNow = DateTime.Now;
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathL))
                {
                    sw.WriteLine(DateTime.Now.ToString()+_message);

                }
            }
            else
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(pathL))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        File.AppendAllText(pathL, DateTime.Now.ToString() + _message);
                    }
                }
            }

        }
       
       
    }
}
