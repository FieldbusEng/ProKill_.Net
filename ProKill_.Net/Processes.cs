using System;


namespace ProKill_.Net
{
    class Processes
    {
        public int IfProcExist(string processName, int timeAllowed)
        {
            try
            {
                int countKilled = 0;
                int countNotKilled = 0;
                System.Diagnostics.Process[] p1 = System.Diagnostics.Process.GetProcesses();
                Logger llogg = new Logger();
                foreach (System.Diagnostics.Process pro in p1)
                {
                    if (pro.ProcessName.Contains(processName))
                    {
                        
                        TimeSpan runtime = new TimeSpan();
                        try
                        {
                            runtime = DateTime.Now - pro.StartTime;

                            if (runtime.Minutes >= timeAllowed)
                            {
                                pro.Kill();
                                countKilled++;
                                string message = "process " + pro.ProcessName + " just found and killed ";
                                llogg.methodLoggerOfficial(message);
                                Console.WriteLine(message);
                            }
                            else
                            {
                                // process exist but time not elapsed
                                countNotKilled++;
                                
                            }


                        }
                        catch (System.ComponentModel.Win32Exception ex)
                        {
                            // Ignore processes that give "access denied" error.
                            if (ex.NativeErrorCode == 5)
                                continue;
                            throw;
                        }

                                           
                    }

                }

                if (countKilled > 0 && countNotKilled == 0)
                {
                    string message = "process " + processName + " - was found and killed Totally: " + countKilled.ToString() + " times";
                    llogg.methodLoggerOfficial(message);
                    Console.WriteLine(message);
                    return 0;
                }
                else if (countKilled > 0 && countNotKilled > 0)
                {
                    string message = "process " + processName + " was found and killed " + countKilled.ToString() + " times, But some processs not killed because time not elapsed";
                    llogg.methodLoggerOfficial(message);
                    Console.WriteLine(message);
                    return 1;
                }
                else if (countKilled == 0 && countNotKilled == 0)
                {
                    string message = processName + " - not found";
                    llogg.methodLoggerOfficial(message);
                    Console.WriteLine(message);
                    return 2;
                }
                else if (countKilled == 0 && countNotKilled > 0)
                {
                    string message = processName + " - found - Time not elapsed";
                    llogg.methodLoggerOfficial(message);
                    Console.WriteLine(message);
                    return 3;
                }
                else
                {
                    return 4;
                }


            }
            catch (Exception ex)
            {
                Logger llog = new Logger();
                string message = ex.Message + "\r\n" + ex.StackTrace + "\r\n" + ex.Source;
                llog.methodLogger(message);
                Console.WriteLine(message);
                return 5;
            }
        }


    }
}
