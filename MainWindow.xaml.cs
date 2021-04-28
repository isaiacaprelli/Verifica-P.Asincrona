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
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Verifica_Asincrona
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Thread barra = new Thread(Movimento);
            barra.Start();
            
        }

        public async void Movimento()
        {
            await Task.Run(() =>
            {    
                    
                 for (int i = 0; i < 100; i++)
                 {
                    Thread.Sleep(200);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                       Progressbarx.Value = i;

                    }));

                 }
                 
            });
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblPercentuale.Content = Progressbarx.Value + "%";
        }

        private void btnRicomincia_Click(object sender, RoutedEventArgs e)
        {
            Progressbarx.Value = 0;
            Movimento();

        }
    }
}
