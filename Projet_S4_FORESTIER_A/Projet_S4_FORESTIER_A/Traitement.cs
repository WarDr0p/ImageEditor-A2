using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public static class Traitement
    {
        /// <summary>
        /// Met l'image en paramètre en noir et blanc
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static MyImage NoirBlanc(MyImage image)
        {
            MyImage result = new MyImage(image.GetPixels.GetLength(0), image.GetPixels.GetLength(1));
            for(int i= 0; i < image.GetPixels.GetLength(0); i++)
            {
                for(int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    result.GetPixels[i, j] = image.GetPixels[i, j];
                    result.GetPixels[i, j].ToNoirBlanc();
                }
            }
            return result;
        }

        /// <summary>
        /// Tourne l'image précisée en paramètre
        /// </summary>
        /// <param name="image">Image à retourner</param>
        /// <param name="degres">nombre de degrés pour tourne rl'image</param>
        /// <returns></returns>
        public static MyImage RotateDegrees(MyImage image, int degres)
        {
            //MyImage result = image;
            int nbRot = degres / 90;
            while(nbRot > 0)
            {
                nbRot--;
                image = Traitement.Rotate(image);
            }

            return image;
        }

        /// <summary>
        /// Tourne l'image précisée en paramètre de 90°
        /// </summary>
        /// <param name="image">image à retourner</param>
        /// <returns></returns>
        static MyImage Rotate(MyImage image)
        {
            MyImage result = new MyImage(image.GetPixels.GetLength(1), image.GetPixels.GetLength(0));
            for (int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    result.GetPixels[result.GetPixels.GetLength(0)-1-j, i] = image.GetPixels[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Agrandi l'image précisé en paramètre 
        /// </summary>
        /// <param name="image">Image à agrandir</param>
        /// <param name="coeff">Coefficient d'agrandissement</param>
        /// <returns></returns>
        public static MyImage Agrandir(MyImage image, double coeff)
        {
            int tailleLignes = (int) (image.GetPixels.GetLength(0) * coeff);  
            int tailleColonnes = (int) (image.GetPixels.GetLength(1) * coeff);

            tailleColonnes = tailleColonnes - (tailleColonnes % 4);
            tailleLignes = tailleLignes - (tailleLignes % 4);

           

            MyImage result = new MyImage(tailleLignes, tailleColonnes);
            
            for(int i = 0; i < tailleLignes; i++)
            {
                for(int j = 0; j < tailleColonnes; j++)
                {
                    result.GetPixels[i, j] = image.GetPixels[(int)(i / coeff), (int)(j / coeff)];
                }
            }

            return result;
            
        }
        
        /// <summary>
        /// Rétréci l'imga précisée en paramètre
        /// </summary>
        /// <param name="image">Image à rétrécir</param>
        /// <param name="coeff">Coeeficient de rétrécissement</param>
        /// <returns></returns>
        public static MyImage Retrecir(MyImage image, double coeff)
        {
            int tailleLignes = (int)(image.GetPixels.GetLength(0) / coeff);
            int tailleColonnes = (int)(image.GetPixels.GetLength(1) / coeff);

            tailleColonnes = tailleColonnes -  (tailleColonnes % 4);
            tailleLignes = tailleLignes - (tailleLignes % 4);

            MyImage result = new MyImage(tailleLignes, tailleColonnes);

            for (int i = 0; i < tailleLignes; i++)
            {
                for (int j = 0; j < tailleColonnes; j++)
                {
                    result.GetPixels[i, j] = image.GetPixels[(int)(i * coeff), (int)(j * coeff)];
                }
            }

            return result;

        }

        /// <summary>
        /// Génère un Miroir horizontal par rapport à l'image pécisée en paramètre
        /// </summary>
        /// <param name="image">Image à traiter</param>
        /// <returns></returns>
        public static MyImage MirroirHorizontal(MyImage image)
        {
            MyImage result = new MyImage(image.GetPixels.GetLength(0), image.GetPixels.GetLength(1));
            for (int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    result.GetPixels[i,image.GetPixels.GetLength(1) - j-1] = image.GetPixels[i, j];                   
                }
            }
            return result;
        }

        /// <summary>
        /// Génère un Miroir Vertical par rapport à l'image pécisée en paramètre
        /// </summary>
        /// <param name="image">Image à traiter</param>
        /// <returns></returns>
        public static MyImage MirroirVertical(MyImage image)
        {
            MyImage result = new MyImage(image.GetPixels.GetLength(0), image.GetPixels.GetLength(1));
            for (int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    result.GetPixels[image.GetPixels.GetLength(0) -1 -i,j] = image.GetPixels[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Applique une matrice de convolusion pour faire ressortir l'attribut présicé en paramètre
        /// </summary>
        /// <param name="image">Image à traiter</param>
        /// <param name="mode">Contraste/1 Flou/2 Renforcement Contour/3 Detection Contour/4 Repoussage/5</param>
        /// <returns></returns>
        public static MyImage Convolution(MyImage image, string mode)
        {
            int[,] convMat = { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            switch (mode)
            {
                case "Contraste":
                    convMat = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                    break;
                        
                case "1":
                    convMat = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                    break;



                case "Flou":
                    convMat = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
                    break;

                case "2":
                    convMat = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
                    break;



                case "Renforcement contour":
                    convMat = new int[,] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };
                    break;

                case "3":
                    convMat = new int[,] { { 0, 0, 0 }, { -1, 1, 0 }, { 0, 0, 0 } };
                    break;



                case "Detection contour ":
                    convMat = new int[,] { { 0, 1, 0 }, { 1,- 4, 1 }, { 0, 1, 0 } };
                    break;

                case "4":
                    convMat = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
                    break;



                case "Repoussage ":
                    convMat = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
                    break;

                case "5":
                    convMat = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };
                    break;
                
            }
            MyImage result = new MyImage(image.GetPixels.GetLength(0), image.GetPixels.GetLength(1));
            for (int i = 0; i < image.GetPixels.GetLength(0); i ++)
            {
                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    result.GetPixels[i, j] = new Pixel(0,0,0);
                }
            }
           

            for (int i = 1; i < image.GetPixels.GetLength(0) -1; i++)
            {
                for (int j = 1; j < image.GetPixels.GetLength(1) -1; j++)
                {
                    int[] determinant = { 0, 0, 0 };
                    for (int ligneRelative = -1;  ligneRelative < 2; ligneRelative++)
                    {
                        
                        for (int colonneRelative = -1; colonneRelative < 2; colonneRelative++)
                        {
                            int ligneFinale = i + ligneRelative;
                            int colonneFinale = j + colonneRelative;

                            int determinantRed = convMat[ligneRelative+1, colonneRelative+1] * image.GetPixels[ligneFinale, colonneFinale].Red;
                            int determinantGreen = convMat[ligneRelative+1, colonneRelative+1] * image.GetPixels[ligneFinale, colonneFinale].Green;
                            int determinantBlue = convMat[ligneRelative+1, colonneRelative+1] * image.GetPixels[ligneFinale, colonneFinale].Blue;

                            // Pixel det = new Pixel(result.GetPixels[i, j].Red + determinantRed, result.GetPixels[i, j].Green + determinantGreen, result.GetPixels[i, j].Blue + determinantBlue);
                            determinant[0] = determinant[0] + determinantRed;
                            determinant[1] = determinant[1] + determinantGreen;
                            determinant[2] = determinant[2] + determinantBlue;
                            
                            
                        }
                        if (ligneRelative == 1)
                        {
                            if (mode == "Flou" || mode == "2")
                            {
                                determinant[0] = determinant[0] / 1;
                                determinant[1] = determinant[1] / 1;
                                determinant[2] = determinant[2] / 1;
                            }
                           result.GetPixels[i, j] = new Pixel(Utils.Normaliser(determinant[0]), Utils.Normaliser(determinant[1]), Utils.Normaliser(determinant[2]));
                        }
                    }

                }
            }
            /*
            for(int j = 0; j < result.GetPixels.GetLength(1); j++)
            {
                result.GetPixels[0, j] = nul;
                result.GetPixels[result.GetPixels.GetLength(0)-1, j] = nul;
            }

            for (int i = 0; i < result.GetPixels.GetLength(0); i++)
            {
                result.GetPixels[i,0] = nul;
                result.GetPixels[i,result.GetPixels.GetLength(1)-1] = nul;
            }
            */

            return result;
        }

        /// <summary>
        /// Génère l'histogramme associé à l'image précisée en paramètre
        /// </summary>
        /// <param name="image">Image à traiter</param>
        /// <returns></returns>
        public static MyImage Histogramme(MyImage image)
        {
            MyImage histo = new MyImage(image.GetPixels.GetLength(0), image.GetPixels.GetLength(1));
            for(int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                int[] somme = { 0, 0, 0 };
                for(int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    somme[0] = somme[0] + image.GetPixels[i, j].Red;
                    somme[1] = somme[1] +  image.GetPixels[i, j].Green;
                    somme[2] = somme[2] +  image.GetPixels[i, j].Blue;
                }
                int[] hauteur = { somme[0] / 255, somme[1] / 255, somme[2] / 255 };

                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    int red = 0;
                    int blue = 0;
                    int green = 0;

                    if(j <= hauteur[0])
                    {
                        red = 255;
                    }

                    if (j <= hauteur[1])
                    {
                        green = 255;
                    }

                    if (j <= hauteur[2])
                    {
                        blue = 255;
                    }
                    

                    histo.GetPixels[i, j] = new Pixel(red, green, blue);
                }

            }
            return histo;
        }

        /// <summary>
        /// Insère de manière sthénographique l'imageAcrypter dans l'image support
        /// </summary>
        /// <param name="imageSupport">Image de support</param>
        /// <param name="imageACrypter">Image à cacher</param>
        /// <returns></returns>
        public static MyImage Crypter(MyImage imageSupport, MyImage imageACrypter)
        {
            //On resize l'image si elle est trop grande
            if((imageSupport.GetPixels.GetLength(0) < imageACrypter.GetPixels.GetLength(0))||(imageSupport.GetPixels.GetLength(1) < imageACrypter.GetPixels.GetLength(1)))
            {
                float rapport1 = imageACrypter.GetPixels.GetLength(0) / imageSupport.GetPixels.GetLength(0);
                float rapport2 = imageACrypter.GetPixels.GetLength(1) / imageSupport.GetPixels.GetLength(1);
                float rapportFinal = rapport2;
                if (rapport1 > rapport2)
                {
                    rapportFinal = rapport1;          
                }
                imageACrypter = Traitement.Retrecir(imageACrypter, rapportFinal +1);
            }

            // d'abord on met tous les pixels à modulo 16 sur la première image
            for (int i  = 0; i < imageSupport.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < imageSupport.GetPixels.GetLength(1); j++)
                {
                    imageSupport.GetPixels[i, j].Red -= imageSupport.GetPixels[i, j].Red % 16;
                    imageSupport.GetPixels[i, j].Green -= imageSupport.GetPixels[i, j].Green % 16;
                    imageSupport.GetPixels[i, j].Blue -= imageSupport.GetPixels[i, j].Blue % 16;
                }

            }

            //puis on ajoute la deuxième image dans la 1ère
            for (int i = 0; i < imageACrypter.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < imageACrypter.GetPixels.GetLength(1); j++)
                {
                    imageSupport.GetPixels[i, j].Red += imageACrypter.GetPixels[i, j].Red / 16;
                    imageSupport.GetPixels[i, j].Green += imageACrypter.GetPixels[i, j].Green / 16;
                    imageSupport.GetPixels[i, j].Blue += imageACrypter.GetPixels[i, j].Blue / 16;
                }

            }

            return imageSupport;
        }

        /// <summary>
        /// Décrypte de manière sthénographique l'image précisée en paramètre
        /// </summary>
        /// <param name="imageADecrypter">Image à décrypter</param>
        /// <returns></returns>
        public static MyImage Decrypter(MyImage imageADecrypter)
        {
            MyImage result = new MyImage(imageADecrypter.GetPixels.GetLength(0), imageADecrypter.GetPixels.GetLength(1));

            for (int i = 0; i < imageADecrypter.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < imageADecrypter.GetPixels.GetLength(1); j++)
                {
                    Pixel pxl = imageADecrypter.GetPixels[i, j];
                    result.GetPixels[i,j] = new Pixel((pxl.Red % 16)*16, (pxl.Green % 16)*16, (pxl.Green%16)*16);
                }
            }
            return result;
        }      
    }
}
