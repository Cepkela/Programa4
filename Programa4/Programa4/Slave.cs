using System;
using System.Collections.Generic;
using System.Drawing;
//using tessnet2;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

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
            int i = 1;
            foreach (var item in Files)
            {
                var img = new Bitmap(item);
                var ocr = new TesseractEngine("tessdata", "eng", EngineMode.TesseractAndCube);// Sudmaliauja sita eilute paziurek kazka gal rasi nes man jau nervai neatlaike
                var page = ocr.Process(img);
                MessageBox.Show(page.GetText());
                break;
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
