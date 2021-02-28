using System;

namespace OneTetris
{
    public static class Peca
    {

        
        public static string[] CriarPeca()
        {
            string simbolo = "#";
            var peca = new string[4];

            for (int i = 0; i < peca.Length; i++)
            {
                peca[i] = simbolo;
            }
            return peca;
        }

        public static string[,] CriarPeca2()
        {
            string simbolo = "#";
            var peca2 = new string[2,2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    peca2[i, j] = simbolo;
                }
                Console.WriteLine();
            }
            return peca2;
        }

  
    }
}
