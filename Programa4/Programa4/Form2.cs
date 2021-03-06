﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Programa4
{
    public partial class Form2 : Form
    {
        public List<string> Files = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i<=100; i++)
            {
                if(backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    //simulateHeavyJob();
                    backgroundWorker1.ReportProgress(i);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                display("You Have Cancelled!");
                progressBar1.Value = 0;
                
            }
            else
            {
                display("Work Completed Successfully!");
            }
        }
        private void simulateHeavyJob()
        {

        }
        private void display(string Text)
        {
            MessageBox.Show(Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Files.Count();
            progressBar1.Step = 1;
            Master master = new Master();
            foreach (var item in Files)
            {
                master.Files.Add(item);
                this.Invoke(new MethodInvoker(() =>
                {
                    progressBar1.PerformStep();
                }));
            }
            master.run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
