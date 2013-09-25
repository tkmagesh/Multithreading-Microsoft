using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultithreadingDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(Form1.DoWork);
            thread.Start();
        }

        public static void DoWork()
        {
            Debug.WriteLine("Work Started");
            Thread.Sleep(10000);
            Debug.WriteLine("Work Completed");
        }
    }
}
