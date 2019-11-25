using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProKill_.Net
{
    // not in Use
    class TimerC
    {
        private static Timer timer;
        string procName = "No";
        int timeOut = 0;

        public void TimerSet(int _timeOut, string _procName)
        {
          
            procName = _procName;
            timeOut = _timeOut;
            // *1000(will be seconds) *60(will be minutes)
            int calcTime = _timeOut * 1000 * 60;
            timer = new Timer(calcTime);
            timer.Elapsed += TimeElapsed;
        }
        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            methodFromElapsed();
        }
        void methodFromElapsed()
        {
            Console.WriteLine("The App {0} is running {1} min - will be Closed", procName, timeOut);

        }

    }
}
