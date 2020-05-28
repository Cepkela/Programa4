using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa4
{
    public class Slave
    {
        public List<string> Files = new List<string>();
        private bool done = false;
        public void halt()
        {
            done = true;
        }
        protected bool task()
        {
            foreach (var item in Files)
            {
                MessageBox.Show(item);
            }
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
