using System;

namespace ProKill_.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new Logger();
            // clear logs
            log.methodDelete();
            log.methodDeleteOfficial();

            CheckClass inputC = new CheckClass();
            var input = inputC.methodCheck(args);
            string inputName = input.Item1;
            int timeAllowed = Convert.ToInt32(input.Item2);
            int timeFreq = Convert.ToInt32(input.Item3);


            Processes instProc = new Processes();
            int result = instProc.IfProcExist(inputName, timeAllowed);

            switch (result)
            {
                case 0:
                    log.methodLoggerOfficial("Program Finished Successfully");
                    Environment.Exit(0);
                    break;
                
                case 1:
                    TimerC timerClass = new TimerC();
                    timerClass.TimerSet(inputName, timeAllowed, timeFreq);
                    break;
                case 2:
                    log.methodLoggerOfficial("Program Finished Successfully");
                    Environment.Exit(0);
                    break;
                case 3:
                    TimerC timerClass1 = new TimerC();
                    timerClass1.TimerSet(inputName, timeAllowed, timeFreq);
                    break;
                case 4:
                    log.methodLoggerOfficial("Program Finished with Error");
                    Environment.Exit(0);
                    break;
                case 5:
                default:
                    log.methodLoggerOfficial("Program Finished with Exception");
                    Environment.Exit(0);
                    break;
                    

            }
            while (true)
            {
                string stop = Console.ReadLine();
                if (stop == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Waiting for next scan");
                }
            }
            

        }
        
    }
   

    
}
