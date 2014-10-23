using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lab2
{
    public partial class Form1 : Form
    {
        FileStream fs;
        byte[] fileContends;
        
        public Form1()
        {

            InitializeComponent();
        }


        public void doRead(object sender, EventArgs e)
        { 

            int count = 1;
            while (count == 1)
            {
                openFileDialog1.ShowDialog();
                try
                {

                   using (fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, false))
                    {
                        count = 0;
                        // Read the source file into a byte array. 
                        fileContends = new byte[fs.Length];
                        int numBytesToRead = (int)fs.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            // Read may return anything from 0 to numBytesToRead. 
                            int n = fs.Read(fileContends, numBytesRead, numBytesToRead);

                            // Break when the end of the file is reached. 
                            if (n == 0)
                                break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }
                        numBytesToRead = fileContends.Length; 
                        string text = Encoding.UTF8.GetString(fileContends);
                        textBox1.AppendText(text);
                        
                    }
                }
                catch (FileNotFoundException ioEx)
                {

                    textBox1.AppendText(ioEx.Message);
                    count = 0;
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              

        }
        private void btnAsync_clic() {

            doRead();
        }

        private void doRead()
        {
        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
}
}
