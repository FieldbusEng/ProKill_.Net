using System;


namespace ProKill_.Net
{
    class Processes
    {
        public int IfProcExist(string processName)
        {
            try
            {

                System.Diagnostics.Process[] p1 = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process pro in p1)
                {
                    if (pro.ProcessName.Contains(processName))
                    {
                        Console.WriteLine("The process {0} is: Running", processName);
                        return 1;
                    }

                }
                Console.WriteLine("The process {0} : not found", processName);
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.Source);
                return -1;
            }
        }


    }
}
