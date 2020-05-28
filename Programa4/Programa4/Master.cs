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
        public List<string> Files = new List<string>();
        private Slave[] slaves = new Slave[slaveCount];
        List<Thread> threads = new List<Thread>();
        Form2 fr2;
        public void run()
        {
            // create slaves:
            for (int i = 0; i < slaveCount; i++)
            {
                slaves[i] = new Slave();
            }
            int c = 0;
            int j = 0;
            int a = 0;
            int b = 1;
            // start slaves:
            for (int i = 0; i < slaveCount; i++)
            {
                Thread t = new Thread(new ThreadStart(slaves[i].run));
                threads.Add(t);
               // MessageBox.Show(Files.Count.ToString());
                for (j = a; j < 10*b; j++)
                {
                    slaves[i].Files.Add(Files[j]);
                    a++;
                    for (int c = 0; c < 50000000; c++)
                    {
                        //MessageBox.Show(c.ToString());
                    }
                }
                b++;
                t.Start();
                c++;
                fr2.setProgress(c);
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
