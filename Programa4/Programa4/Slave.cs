using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Programa4
{
    public class Slave
    {
        private bool done = false;
        public void halt()
        {
            done = true;
        }
        protected bool task()
        {
            /*
            if (state == goal) return true;
            improve state;
            return false;
            */
            return true; // for now
        }
        public void run()
        {
            while (!done)
            {
                done = task();
                // be cooperative:
                try
                {
                    Thread.Sleep(1000);
                } // sleep for 1 sec.
                catch (Exception e) { }
            }
        }
    }
}
