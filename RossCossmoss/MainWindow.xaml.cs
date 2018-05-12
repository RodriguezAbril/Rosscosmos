using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace RossCossmoss
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OneTimePassword otp;
        private Codigo codigo;
        public MainWindow()
        {
            InitializeComponent();
            otp = new OneTimePassword("jbsw y3dp ehpk 3pxp");
            tmrUpdate(null, null);
        }

        private void tmrUpdate(object sender, System.EventArgs e)
        {
            if (otp != null)
            {
                CountDown();
            }
            else
            {
               
            }
        }

        private void CountDown() { System.Timers.Timer timer = new System.Timers.Timer(); timer.Interval = 1000; timer.Elapsed += OnTimedEvent; timer.Enabled = true; }
        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            //BeginInvokeOnMainThread(() =>
            // {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {

                codigo = new Codigo();
                codigo.Code = otp.GetCode().ToString("000000");

                this.DataContext = codigo;
            }
                ));



        }

    }
   
}
