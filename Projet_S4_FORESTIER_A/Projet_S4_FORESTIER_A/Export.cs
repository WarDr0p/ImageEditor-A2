using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class Export
    {

        MyImage image;
        string fileName;

        public Export(MyImage image, String name, String extension)
        {
            bool exporte = false;
            this.image = image;
            while (!exporte)
            {
                    exporte = true;
                GetUniqueName(name, extension);
                    extension = extension.ToLower();
                    switch (extension)
                    {
                        case "bmp":
                        ExportBMP();
                            break;

                        case "csv":
                        ExportCSV();
                            break;

                        default:
                        Console.Write("\nCette extension n'est pas prise en compte par le programme voici la liste des extensions prises en compte par le programme " + Utils.AfficherTableau(Utils.Extensions, ", ") + "\n veuillez préciser une extension :");
                            extension = Console.ReadLine();
                            exporte = false;
                            break;
                    }
            }
        }

        /// <summary>
        /// Export l'image précisée en paramètre en BMP
        /// </summary>
        private void ExportBMP()
        {
            MyImage toExport = new MyImage(image.GetPixels.GetLength(0)-(image.GetPixels.GetLength(0)%4), image.GetPixels.GetLength(1) );
            for(int i = 0; i < toExport.GetPixels.GetLength(0); i++)
            {
                for(int j = 0; j < toExport.GetPixels.GetLength(1); j++)
                {
                    toExport.GetPixels[i, j] = image.GetPixels[i, j];
                }
            }
            image = toExport;
            int LongueurTableau = 54 + (image.GetPixels.Length * 3);
            byte[] imageBytes = new byte[LongueurTableau];
            //On précise l'extensions du Fichier (BM)
            imageBytes[0] = 66;
            imageBytes[1] = 77;

            //On précise la taille du fichier
            AjouterParam(imageBytes.Length, imageBytes, 4, 2);


            //Taille Offset
            imageBytes[10] = 54;

            //Taille de la seconde partie du header
            imageBytes[14] = 40;

            //On indique la taille en largeur puis en hauteur
            AjouterParam(image.GetPixels.GetLength(0), imageBytes, 2, 18);
            AjouterParam(image.GetPixels.GetLength(1), imageBytes, 2, 22);

            //Nombre de plans
            imageBytes[26] = 1;

            //Nombre de bits par couleur
            imageBytes[28] = 24;

            AjouterImage(imageBytes);
            File.WriteAllBytes(fileName, imageBytes);

        }
            


        void ExportCSV()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Génère un nom n'existant pas à une image
        /// </summary>
        /// <param name="name">Nom à vérifier</param>
        /// <param name="extension">Extension du fichier</param>
        void GetUniqueName(string name, string extension)
        {
            string fileToTest = name +"."+extension;
            int n = 1;
            while (File.Exists(fileToTest))
            {
                fileToTest = name + "(" + n + ")."+extension;
                n++;
            }
            fileName = fileToTest;
        }

        /// <summary>
        /// Convertit  des entiers au format little Endian
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        byte[] Int_To_Endian(int nombre)
        {
            int i = 0;
            while (i >= 0)
            {
                i++;
                if (nombre < Math.Pow(256, i)) break;
            }


            byte[] littleEndian = new byte[i + 1];
            int reste = nombre;
            while (i > 0) 
            {
                i--;
                littleEndian[i] = Convert.ToByte(reste / (int)Math.Pow(256, i));

                reste = reste % (int)Math.Pow(256, i);
                
                
            }
            return littleEndian;
        }

        /// <summary>
        /// Ajoute le paramètre spécifiés en paramètre à la chaine d'export
        /// </summary>
        /// <param name="nombre">Paramètre / nombre à ajouter</param>
        /// <param name="imageBytes">Tableau de bytes d'export</param>
        /// <param name="tailleParamBytes">Taille allouée à ce paramètre</param>
        /// <param name="indiceDebut">Indice de départ du paramètre</param>
        void AjouterParam(int nombre,byte[] imageBytes,int tailleParamBytes, int indiceDebut)
        {
            byte[] IndaAjouter = Int_To_Endian(nombre);
            int max = IndaAjouter.Length;
            if (IndaAjouter.Length > tailleParamBytes)max = tailleParamBytes;

            for (int i = 0; i < max; i++)
            {
                imageBytes[i+indiceDebut] = IndaAjouter[i];
            }
        }

        /// <summary>
        /// Ajoute une image au tableau de byte à exporter
        /// </summary>
        /// <param name="bytesExport"></param>
        void AjouterImage(byte[] bytesExport)
        {
            for (int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                for(int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    int indice = 54 + (i * 3) + (j * image.GetPixels.GetLength(0) * 3);
                    bytesExport[indice] = (byte) image.GetPixels[i, j].Red;
                    bytesExport[indice+1] = (byte)image.GetPixels[i, j].Green;
                    bytesExport[indice+2] = (byte)image.GetPixels[i, j].Blue;
                }
            }
        }
    }
}
