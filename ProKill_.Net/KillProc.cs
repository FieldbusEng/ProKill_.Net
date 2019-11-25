using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKill_.Net
{
    class KillProc
    {
        public bool ProcEnd(string processName)
        {
            try
            {
                int counter = 0;
                System.Diagnostics.Process[] p1 = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process pro in p1)
                {
                    if (pro.ProcessName.Contains(processName))
                    {
                        pro.Kill();
                        counter++;
                    }

                }
                if (counter > 0)
                {
                    Console.WriteLine("Quntity of {0} Killed : {1}", processName, counter);
                    return true;
                }

                Console.WriteLine("The process {0} : not found", processName);
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.Source);
                return false;
            }
        }
    }
}
