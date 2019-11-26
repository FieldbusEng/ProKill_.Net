using System;
using System.IO;


namespace ProKill_.Net
{
    class Logger
    {
        public Logger()
        { }
        public void methodLogger(string _message)
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string pathL = path + "\\LogFile.txt";
            if (!File.Exists(pathL))
            {
                DateTime timeNow = DateTime.Now;
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathL))
                {
                    sw.WriteLine(DateTime.Now.ToString()+"  "+ _message);

                }
            }
            else
            {

                using (StreamWriter sr = File.AppendText(pathL))
                {
                    sr.WriteLine(DateTime.Now.ToString() + "  " + _message);
                }
            }

        }

        public void methodDelete()
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string pathL = path + "\\LogFile.txt";
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(pathL))
                {
                    // If file found, delete it    
                    File.Delete(pathL);

                }

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

        }

        public void methodLoggerOfficial(string _message)
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string pathL = path + "\\LogFileOfficial.txt";
            if (!File.Exists(pathL))
            {
                DateTime timeNow = DateTime.Now;
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(pathL))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "  " + _message);

                }
            }
            else
            {

                using (StreamWriter sr = File.AppendText(pathL))
                {
                    sr.WriteLine(DateTime.Now.ToString() + "  " + _message);
                }
            }

        }

        public void methodDeleteOfficial()
        {
            // Get the current directory.
            string path = Directory.GetCurrentDirectory();
            string pathL = path + "\\LogFileOfficial.txt";
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(pathL))
                {
                    // If file found, delete it    
                    File.Delete(pathL);

                }

            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

        }

    }
}
