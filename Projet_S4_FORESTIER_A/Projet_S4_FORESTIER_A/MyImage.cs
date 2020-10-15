using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class MyImage
    {
        Pixel[,] imageComplete;

        /// <summary>
        /// Constructeur 1
        /// </summary>
        /// <param name="imageComplete">matrice de pixels</param>
        public MyImage(Pixel[,] imageComplete)
        {
            this.imageComplete = imageComplete;
        }

        /// <summary>
        /// Constructeur 2
        /// </summary>
        /// <param name="hauteur">hauteur de l'image désirée</param>
        /// <param name="largeur">largeur de l'image désirée</param>
        public MyImage(int hauteur, int largeur)
        {
            Pixel[,] matPixel = new Pixel[hauteur, largeur];
            Pixel nul = new Pixel(0, 0, 0);

            for(int i = 0; i < matPixel.GetLength(0); i++)
            {
                for(int j = 0; j < matPixel.GetLength(1); j++)
                {
                    matPixel[i, j] = nul;
                }
            }
            this.imageComplete = matPixel;
        }

        /// <summary>
        /// Propriété pour récupérer les bits image d'une image
        /// </summary>
        public Pixel[,] GetPixels { get { return imageComplete; } }

        /// <summary>
        /// Affiche l'image de l'instance 
        /// </summary>
        /// <param name="color">Couleur des pixels à afficher (Red / Blue / Green / All)</param>
        public void AfficherImage(String color)
        {
            for (int i = 0; i < imageComplete.GetLength(0); i++)
            {
                Console.Write("\n");
                for (int j = 0; j < imageComplete.GetLength(1); j++)
                {
                    color = color.ToLower();
                    switch(color){
                        case "red":
                            Console.Write(imageComplete[i, j].Red + " ");
                            break;

                        case "green":
                            Console.Write(imageComplete[i, j].Green + " ");
                            break;

                        case "blue":
                            Console.Write(imageComplete[i, j].Blue + " ");
                            break;

                        default:
                            Console.Write(imageComplete[i, j].Red + " "+ imageComplete[i, j].Green + " "+ imageComplete[i, j].Blue +";");
                            break;
                    }
                    
                }
            }
            Console.ReadKey();
        }

    }
}
