using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    class Rendering
    {
        /// <summary>
        /// Agrandi une image avec un facteur de 5;
        /// </summary>
        /// <param name="image">Image à agrandir</param>
        /// <returns></returns>
        public static MyImage AgrandirCarte(MyImage image)
        {
            Pixel[,] result = new Pixel[image.GetPixels.GetLength(0) * 5, image.GetPixels.GetLength(1) * 5];
            for (int i = 0; i < image.GetPixels.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetPixels.GetLength(1); j++)
                {
                    for(int contourI = 0; contourI < 5; contourI++)
                    {
                        for (int contourJ = 0; contourJ < 5; contourJ++)
                        {
                            result[i * 5 + contourI, j * 5 + contourJ] = image.GetPixels[i, j];
                        }
                    }
                }
            }
            return new MyImage(result);
        }

        /*static MyImage RotateZ(int[,,] objet)
        {
            
                        
        }

        static int[] RotatePoint()
        {

        }

        static int[] MultiplyMatrix(int[] Matrice1, int[,] Matrice2)
        {
            for(int i = 0; i < Matrice1.Length)
            {

            }
        }
        */
    }
}
