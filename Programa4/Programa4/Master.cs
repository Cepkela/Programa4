using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa4
{
    public class Master
    {
        static private int slaveCount = 10;
        private Slave[] slaves = new Slave[slaveCount];
        List<Thread> threads = new List<Thread>();
        public void run()
        {
            // create slaves:
            for (int i = 0; i < slaveCount; i++)
            {
                slaves[i] = new Slave();
            }
            // start slaves:
            for (int i = 0; i < slaveCount; i++)
            {
                Thread t = new Thread(new ThreadStart(slaves[i].run));
                threads.Add(t);
                t.Start();
            }
            // wait for slaves to die:
            for (int i = 0; i < slaveCount; i++)
            {
                try
                {
                    threads[i].Join();
                }
                catch (ThreadInterruptedException ie)
                {
                    MessageBox.Show(ie.Message);
                }
                finally
                {
                    MessageBox.Show(threads[i].ManagedThreadId + " has died");
                }
            }
            MessageBox.Show("The master will now die ... ");
        }
    }
}
