using System;
using System.Threading;

namespace ProKill_.Net
{
    // not in Use
    class TimerC
    {
        static int counterScans = 1;
        static string procName = "No";
        static int timeAllowed = 0;
        static int timeFreq = 0;



        public void TimerSet(string _procName, int _timeAllowed, int _timeFreq )
        {
          
            procName = _procName;
            timeAllowed = _timeAllowed;
            timeFreq = _timeFreq;
            // *1000(will be seconds) *60(will be minutes)
            int calcTime = timeFreq * 1000 * 60;

            object[] infoNeed = new object[]{ procName, timeAllowed, timeFreq };

            TimerCallback tm = new TimerCallback(TimeElapsed);
            System.Threading.Timer timer = new System.Threading.Timer(tm, infoNeed, 0, calcTime);

            

        }
        static void TimeElapsed(object sender)
        {
            counterScans++;
            Logger log = new Logger();
            Processes instProc = new Processes();
            int result = instProc.IfProcExist(procName, timeAllowed);

            switch (result)
            {
                case 0:
                    log.methodLoggerOfficial("Program Finished Successfully");
                    Environment.Exit(0);
                    break;

                case 1:
                    log.methodLoggerOfficial("result from scan #" + counterScans);
                    break;
                case 2:
                    log.methodLoggerOfficial("Program Finished Successfully");
                    Environment.Exit(0);
                    break;
                case 3:
                    log.methodLoggerOfficial("result from scan #" + counterScans);
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

        }
       

    }
}
