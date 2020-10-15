using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class Fractale
    {
        /// <summary>
        /// Génère une fractale en suivant l'algorithme de diamant carré
        /// </summary>
        /// <param name="exposant">Correspond à la taille de l'image en appliquant la relation taille = 2^(n) + 1</param>
        /// <returns></returns>
        public static MyImage DiamantCarre(int exposant)
        {
            int taille = (int)Math.Pow(2, exposant)+1;
            int[,] profilTerrain = new int[taille, taille];
            Random r = new Random();
            profilTerrain[0, 0] = r.Next(0, 255);
            profilTerrain[taille-1,taille-1] = r.Next(0, 255);
            profilTerrain[0, taille-1] = r.Next(0, 255);
            profilTerrain[taille-1, 0] = r.Next(0, 255);
            int espace = taille;
            int pasres = taille - 1;

            while (espace > 1)
            {
                espace = espace / 2;

                //Pour chaque diamant de largeur espace on fait l'étape du losange
                for (int i = espace; i < taille; i += pasres)
                {
                    for (int j = espace; j < taille; j += pasres)
                    {
                        int moyenne = (profilTerrain[i - espace, j - espace] +
                                        profilTerrain[i + espace, j + espace] +
                                        profilTerrain[i - espace, j + espace] +
                                        profilTerrain[i + espace, j - espace])/4;

                        profilTerrain[i, j] = Utils.Normaliser(moyenne + r.Next(-espace, espace));
                    }
                }

                //Pour chaque carré de largeur espace on fait l'étape du carré
                int decalage = 0;
                for(int i = 0; i < taille; i+= espace)
                {
                    if(decalage == 0)
                    {
                        decalage = espace;
                    }
                    else
                    {
                        decalage = 0;
                    }
                    for(int j = decalage; j < taille; j+= pasres)
                    {
                        int somme = 0;
                        int n = 0;

                        if(Utils.AppartientMatrice(profilTerrain,i-espace,j))
                        {
                            somme = somme + profilTerrain[i - espace, j];
                            n++;
                        }

                        if (Utils.AppartientMatrice(profilTerrain, i + espace, j))
                        {
                            somme = somme + profilTerrain[i + espace, j];
                            n++;
                        }

                        if (Utils.AppartientMatrice(profilTerrain, i , j-espace))
                        {
                            somme = somme + profilTerrain[i, j-espace];
                            n++;
                        }

                        if (Utils.AppartientMatrice(profilTerrain, i, j + espace))
                        {
                            somme = somme + profilTerrain[i, j + espace];
                            n++;
                        }

                        profilTerrain[i, j] = Utils.Normaliser((somme / n) + r.Next(-espace, espace));
                    }
                }
                pasres = espace;               
            }

                //Utils.AfficherMatInt(profilTerrain);

                Pixel[,] matPxl = new Pixel[taille, taille];
            for(int i = 0; i < taille; i++)
            {
                for(int j = 0; j < taille; j++)
                {
                        matPxl[i, j] = new Pixel(profilTerrain[i, j], profilTerrain[i, j], profilTerrain[i, j]);                  
                }
            }
            return new MyImage(matPxl);
        }

        /// <summary>
        /// Génère une Fractale de Mandelbrot
        /// </summary>
        /// <param name="largeur">Largeur de la fractale</param>
        /// <param name="hauteur">Hauteur de la fractale</param>
        /// <param name="nbIterations">Correspond au niveau de flou de l'image</param>
        /// <returns></returns>
        public static MyImage MandelBrot(int largeur, int hauteur, int nbIterations)
        {
            MyImage image = new MyImage(hauteur, largeur);
            Pixel nul = new Pixel(0, 0, 0);
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    image.GetPixels[i, j] = nul;
                }
            }

            double x1 = -2.1;
            double x2 = 0.6;
            double y1 = -1.2;
            double y2 = 1.2;

            double zoomJ = largeur / (y2 - y1);
            double zoomI = hauteur / (x2 - x1);

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {



                    double [] c = { ((i/zoomI) + y1), ((j/zoomJ) + x1) };
                    double [] z = { 0, 0 };

                    int iterations = 0;

                    while (((z[0] * z[0]) + (z[1] * z[1]) < 4) && (iterations < nbIterations))
                    {

                        double passageRe = (Math.Pow(z[0], 2) - Math.Pow(z[1], 2) + c[0]);
                        double passageIm = 2 * z[0] * z[1] + c[1];

                        z[0] = passageRe;
                        z[1] = passageIm;

                        iterations++;
                    }

                    if (iterations == nbIterations)
                    {
                        image.GetPixels[i, j] = new Pixel(255, 255, 255);
                    }
                }
            }
            return image;
        }

    }
}
