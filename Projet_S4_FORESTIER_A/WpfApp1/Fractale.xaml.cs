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
using System.Windows.Shapes;
using Projet_S4_FORESTIER_A;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Fractale.xaml
    /// </summary>
    public partial class Fractale : Window
    {
        string path;
        public Fractale()
        {
            this.path = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Projet_S4_FORESTIER_A\bin\debug\Fractale");
            InitializeComponent();
        }

        private void GenTer_Click(object sender, RoutedEventArgs e)
        {
            bool genApp = (bool) AperTer.IsChecked;
            int taille = 50;

            int.TryParse(HTer.Text, out taille);

            if(taille > 200||taille < 0)
            {
                taille = 200;
            }

            int exposant = 0;

            while(Math.Pow(2,exposant+1) < taille)
            {
                exposant++;
            }
            
            MyImage image = Projet_S4_FORESTIER_A.Fractale.DiamantCarre(exposant);

            GetUniqueName();
            Export exprt = new Export(image, path, "bmp");
        }

        private void GenMandel_Click(object sender, RoutedEventArgs e)
        {
            int largeur = 200;
            int hauteur = 200;
            int nbIt = 40;

            int.TryParse(LMandel.Text, out largeur);
            int.TryParse(HMandel.Text, out hauteur);
            int.TryParse(NbItMandel.Text, out nbIt);

            MyImage fractale = Projet_S4_FORESTIER_A.Fractale.MandelBrot( hauteur, largeur, nbIt);
            
            GetUniqueName();
            Export frct = new Export(fractale, path, "bmp");            
        }

        void GetUniqueName()
        {
            string fileToTest = path + ".bmp";
            string cond = path;
            int n = 1;
            while (File.Exists(fileToTest))
            {
                fileToTest = path + "(" + n + ").bmp";
                //cond = ;
                n++;
            }
            path = path + "(" + n + ")";
        }


    }
}
