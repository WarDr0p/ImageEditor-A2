using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == BtnGénérer)
            {
                Fractale frctl = new Fractale();
                frctl.Show();
            }else if(sender == BtnTraiter){
                // Configure open file dialog box

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                string path = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Projet_S4_FORESTIER_A\bin\debug");
                dlg.InitialDirectory = path;
                dlg.DefaultExt = ".bmp"; // Default file extension
                dlg.Filter = "Images (.bmp)|*.bmp"; // Filter files by extension
                

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    Traitement trt = new Traitement(dlg.FileName);
                    trt.Show();

                }
                

            }else if (sender == BtnQuit)
            {
                this.Close();
            }
        }
    }
}
