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
    /// Logique d'interaction pour Traitement.xaml
    /// </summary>
    public partial class Traitement : Window
    {
        string path;
        bool imageCacher;
        string imageCacherName;

        public Traitement(string path)
        {
            this.imageCacher = false;
            this.path = path;
            InitializeComponent();
            TextAgrandir.Text = Convert.ToString(SldrAgrandir.Value);
            TextRetrecir.Text = Convert.ToString(SldrRetrecir.Value);
            TextRotate.Text = Convert.ToString(SldrRotate.Value);
            Img.Source = new BitmapImage(new Uri(path));    
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Processing process = new Processing();
            process.Show();
            MyImage imageInit = new MyImage(new Import(path).ImageComplete);
            MyImage imageFinale = new MyImage(2,2);
            string name = InputName.Text;
            if (InputName.Text == "")
            {
                name = "DefaultName";
            }
            else if (InputName.Text == null)
            {
                name = "DefaultName";
            }


            
            if (sender == BtnAg)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.Agrandir(imageInit, SldrAgrandir.Value);
            }else if (sender == BtnConv)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.Convolution(imageInit, Convert.ToString((int)SldrMode.Value));
            }else if (sender == BtnCrypt)
            {
                if(imageCacher)
                {
                    MyImage imageACrypter = new MyImage(new Import(imageCacherName).ImageComplete);
                    imageFinale = Projet_S4_FORESTIER_A.Traitement.Crypter(imageInit, imageACrypter);
                }
                else
                {
                    MsgError.Text = "Merci de sélectionner une image";
                }
                
                
            }
            else if (sender == BtnDecrypt)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.Decrypter(imageInit);
            }
            else if (sender == BtnHisto)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.Histogramme(imageInit);
            }
            else if (sender == BtnMirHoz)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.MirroirHorizontal(imageInit);
            }
            else if (sender == BtnMirVert)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.MirroirVertical(imageInit);
            }
            else if (sender == BtnNB)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.NoirBlanc(imageInit);
            }
            else if (sender == BtnRet)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.Retrecir(imageInit, SldrRetrecir.Value);
            }
            else if (sender == BtnRot)
            {
                imageFinale = Projet_S4_FORESTIER_A.Traitement.RotateDegrees(imageInit, (int)SldrRotate.Value);
            }

            path = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Projet_S4_FORESTIER_A\bin\debug\"+name);
            Console.Write(path);
            GetUniqueName();
            Console.WriteLine(path);

            Export export = new Export(imageFinale, path, "bmp");
            Img.Source = new BitmapImage(new Uri(path+".bmp"));
            process.Close();
            path = path + ".bmp";
        }

        void GetUniqueName()
        {
            string fileToTest = path + ".bmp";
            string cond = path;
            int n = 1;
            while (File.Exists(fileToTest))
            {
                fileToTest = path + "(" + n + ").bmp";
                cond = path + "(" + n + ")";
                n++;
            }
            path = cond;
        }

        private void SldrRetrecir_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try { TextRetrecir.Text = Convert.ToString(SldrRetrecir.Value); } catch { }
        }

        private void SldrAgrandir_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try { TextAgrandir.Text = Convert.ToString(SldrAgrandir.Value); } catch { }
        }

        private void SldrRotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try { TextRotate.Text = Convert.ToString(SldrRotate.Value); } catch { }
        }

        private void BtnImageACacher_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"Projet_S4_FORESTIER_A\bin\debug");
            dlg.DefaultExt = ".bmp"; // Default file extension
            dlg.Filter = "Images (.bmp)|*.bmp"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                imageCacher = true;
                imageCacherName = dlg.FileName;
            }
        }

        private void BtnClickQuit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
