using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa4
{
    public partial class Form1 : Form
    {
        string[] files;
        public Form1()
        {
            InitializeComponent();
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folder.SelectedPath;
                Environment.SpecialFolder root = folder.RootFolder;
                string filename = Directory.GetFiles(textBox1.Text).First();
                files = Directory.GetFiles(textBox1.Text);
                MessageBox.Show(Convert.ToString(files.Length));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Master master = new Master();
            foreach (var item in files)
            {
                master.Files.Add(item);
            }
            master.run();
        }
    }
}
