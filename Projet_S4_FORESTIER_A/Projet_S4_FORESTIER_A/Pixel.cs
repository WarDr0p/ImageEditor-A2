using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class Pixel
    {
        int red;
        int green;
        int blue;

        /// <summary>
        /// Crée un pixel de la couleur spécifiée en paramètre
        /// Mettre tous les pixels à la même couleur pour un pixel en niveau de gris
        /// </summary>
        /// <param name="red">Composante rouge</param>
        /// <param name="green">Composante bleue</param>
        /// <param name="blue">Composante verte</param>
        public Pixel(int red, int green, int blue)
        {
            this.red = red;
            this.blue = blue;
            this.green = green;
        }

        //Mets le pixel en noir en blanc
        public void ToNoirBlanc()
        {
            int val = (red + green + blue)/3;
            red = val;
            green = val;
            blue = val;
        }

        public int Red { get { return red; } set { red = value; } }
        public int Green { get { return green; } set { green = value; } }
        public int Blue { get { return blue; } set { blue = value; } }




    }
}
