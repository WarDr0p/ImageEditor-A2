using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pixel[,] pixel1 = new Import("coco.bmp").ImageComplete;
            //Pixel[,] pixel2 = new Import("lena.bmp").ImageComplete;
            //MyImage image1 = new MyImage(pixel1);
            //MyImage image2 = new MyImage(pixel2);

            //Export export = new Export(Fractale.DessinerFractale(270, 240, 50), "test", "bmp");
            //Export export = new Export(Fractale.DessinerFractale(270,240, 50), "test", "bmp");
            
            for(int i = 0; i < 20; i++)
            {
                Export export = new Export(Fractale.DiamantCarre(10), "test", "bmp");
            }
            Console.ReadKey();
                       
        }
    }
}
