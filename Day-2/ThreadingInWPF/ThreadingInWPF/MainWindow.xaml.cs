using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadingInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("T id @ Button Click = {0}", Thread.CurrentThread.ManagedThreadId);
            DoWork();
        }

        public void DoWork() {
            var t = new Task<DateTime>(() =>
            {
                Debug.WriteLine("T id @ Task - 1 = {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                return DateTime.Now;
            });
            t.ContinueWith((pt) => {
                Debug.WriteLine("T id @ Task - 2 = {0}", Thread.CurrentThread.ManagedThreadId);
                //this.tbStatus.Text = pt.Result.ToLongTimeString();
            });
            t.Start();
        }
    }
}
