using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class Import
    {
        Pixel[,] imageComplete;
        string fileName;

        public Import(String fileName)
        {
            this.fileName = fileName;
            bool importe = false;
            do
            {
                if (File.Exists(fileName))
                {
                    string extension = Utils.GetExtension(fileName);
                    if (extension == "bmp")
                    {
                        ImportBMP(fileName);
                        importe = true;
                    }
                    else if (extension == "csv")
                    {
                        ImportCSV(fileName);
                        importe = true;
                    }
                    else
                    {
                        Console.WriteLine("Désolé l'extension de votre fichier semble invalide ou non prise en charge par le programme. \nMerci de spécifier un autre fichier : ");
                        fileName = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Désolé votre fichier n'est pas compris dans le dossier debug, merci de l'ajouter et de préciser son nom : ");
                    fileName = Console.ReadLine();
                }

            } while (!importe);
        }

        /// <summary>
        /// Permet d'obtenir l'image importée
        /// </summary>
        public Pixel[,] ImageComplete { get { return imageComplete; } }



        /// <summary>
        /// Importe un fichier bmp
        /// </summary>
        /// <param name="fileName">Nom du fichier à importer</param>
        void ImportBMP(string fileName)
        {
            byte[] file = File.ReadAllBytes(fileName);
            int offset = Convertir_Endian_To_Int(file,10,13);
            int hauteur = Convertir_Endian_To_Int(file,22,25);
            int largeur = Convertir_Endian_To_Int(file,18,21);
            int nbBitsPixels = Convertir_Endian_To_Int(file,28,29);
            byte[] image = ReduireTabByte(file, offset);
            imageComplete = GetImage(image, largeur, hauteur);

        }

        /// <summary>
        /// Importe un fichier CSV
        /// </summary>
        /// <param name="Filename">Nom du fichier à importer</param>
        void ImportCSV(string Filename)
        {

        }

        /// <summary>
        /// Convertit des bytes à partir d'un tableau de bytes en entier
        /// </summary>
        /// <param name="tab">Tableau d'extraction</param>
        /// <param name="deb">Premier Byte de la chaine</param>
        /// <param name="fin">Dernier Byte de la chaine</param>
        /// <returns>Retourne l'entier associé aux bytes</returns>
        public int Convertir_Endian_To_Int(byte[] tab, int deb, int fin)
        {
            int number;
            int resultat = 0;
            int total = 0;

            for (int i = deb; i < fin + 1; i++)
            {
                number = (int) Math.Pow(256, i - deb);
                resultat = (number * tab[i]);
                total += resultat;
            }
            return total;
        }

        /// <summary>
        /// Extrait un nouveau tableau d'un tableau existant à partir du carctère spécifié
        /// </summary>
        /// <param name="tab">Tableau de base</param>
        /// <param name="deb">Position du premier caractère à inclure dans le nouveau tableau</param>
        /// <returns></returns>
        public byte[] ReduireTabByte(byte[] tab, int deb)
        {

            byte[] newtab = new byte [tab.Length - deb];
            for(int i = 0; i < newtab.Length; i++)
            {
                newtab[i] = tab[i + deb];
            }
            return newtab;
        }

        /// <summary>
        /// Extrait l'image associé à un tableau de bytes
        /// </summary>
        /// <param name="image">chaine de bytes contenant l'image</param>
        /// <param name="largeur">largeur de l'image</param>
        /// <param name="hauteur">hauteur de l'image</param>
        /// <returns>Matrice de pixel associée à l'image</returns>
        public Pixel[,] GetImage(byte[] image, int largeur, int hauteur) {
            
            Pixel[,] MatricePixels = new Pixel[largeur, hauteur];

            for (int i = 0; i < largeur; i++)
            {
                for (int j = 0; j < hauteur; j++)
                {
                    int idred = (j * largeur*3) + (i * 3);
                    int idgreen = idred + 1;
                    int idblue = idgreen + 1;
                    MatricePixels[i, j] = new Pixel((int)image[idred], (int)image[idgreen], (int)image[idblue]);
                }
            }

            return MatricePixels;
            
        }
    }
}
