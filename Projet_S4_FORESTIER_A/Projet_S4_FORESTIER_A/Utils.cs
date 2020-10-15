using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_S4_FORESTIER_A
{
    public class Utils
    {
            //Stocke les externsiosn prises en charges par le programme
            static string[] extensions = { "BMP", "CSV" };

            public static string[] Extensions { get { return extensions; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="separateur"></param>
        /// <returns></returns>
        public static string AfficherTableauBytes(byte[] tableau, string separateur)
        {
            string result = "";
            for (int i = 0; i < tableau.Length; i++)
            {
                result += tableau[i];
                if (i != tableau.Length - 1)
                {
                    result += separateur;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableau"></param>
        /// <param name="separateur"></param>
        /// <returns></returns>
        public static void AfficherMatInt(int[,] tableau)
        {

            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                Console.Write('\n');
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    Console.Write(" " + tableau[i, j]);
                }
            }
            Console.ReadKey();
        }



        /// <summary>
        /// Permet d'obtenir l'extension du fichier
        /// </summary>
        /// <param name="fileName">Non tu fichier à analyser</param>
        /// <returns></returns>
        public static string GetExtension(string fileName)
            {
                string extension = "";
                for (int i = 3; i > 0; i--)
                {
                    extension = extension + fileName[fileName.Length - i];
                }
                return extension;
            }

        /// <summary>
        /// Retourne le tableau placé en paramètre sous forme de caractères
        /// </summary>
        /// <param name="tableau">Tableau à Afficher</param>
        /// <param name="separateur">Chaine de caractère qui doit séparer chaque élément</param>
        public static string AfficherTableau(Object[] tableau, string separateur)
        {
            string result = "";
            for(int i = 0; i < tableau.Length; i++)
            {
                result += tableau[i];
                if (i != tableau.Length - 1)
                {
                    result += separateur;
                }
            }

            return result;
        }
        
        /// <summary>
        /// Un pixel ne pas être plus blanc que blnac ou noir que noir = Normaliser
        /// </summary>
        /// <param name="couleur">Composante à vérifier</param>
        /// <returns></returns>
        public static int Normaliser(int couleur)
        {
            if(couleur < 0)
            {
                couleur = 0;
            }else if(couleur > 255)
            {
                couleur = 255;
            }

            return couleur;

        
        }

        /// <summary>
        /// Vérifie que les coordonnées placées en paramètre appartiennent bien à la matrice
        /// </summary>
        /// <param name="tab">Matrice de référence</param>
        /// <param name="i">1ère composante à vérifier</param>
        /// <param name="j">2éme composante à vérifier</param>
        /// <returns></returns>
        public static bool AppartientMatrice(int[,] tab,int i, int j)
        {
            bool appartientMatrice = false;
            if ((i >= 0) && (j >= 0) && (i < tab.GetLength(0)) && (j < tab.GetLength(1)))appartientMatrice = true;

            return appartientMatrice;        
        }
        
    }
}
