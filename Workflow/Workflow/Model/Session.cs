using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow
{
    class Session
    {
        DateTime startTime;
        DateTime stopTime;

        public Session()
        {

        }
        public void start()
        {
            startTime = DateTime.Now;
        }
        public void stop()
        {
            stopTime = DateTime.Now;
        }
        public void calculateTime(out int hours, out int minutes)
        {
            TimeSpan span = stopTime.Subtract(startTime);
            hours = (int)span.TotalHours;
            minutes = span.Minutes;
        }
    }
}
