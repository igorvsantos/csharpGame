using System;
using System.Globalization;

namespace OneTetris
{
    public static class Recipiente
    {
        const int numLinhas = 21;
        const int numColunas = 12;


        //Criaçao do tabuleiro de jogo
        public static string[,] Criar()
        {
            var recipiente = new string[numLinhas, numColunas];

            int linhas = recipiente.GetLength(0);
            int colunas = recipiente.GetLength(1);

            for (int i = 0; i < recipiente.GetLength(0); i++)
            {
                for (int j = 0; j < recipiente.GetLength(1); j++)
                {
                    if (i == linhas - 1 && j == 0)
                    {
                        recipiente[i, j] = "╚";
                    }
                    else if (i == linhas - 1 && j == colunas - 1)
                    {
                        recipiente[i, j] = "╝";
                    }
                    else if (j == colunas - 1 || j == 0)
                    {
                        recipiente[i, j] = "║";
                    }
                    else if (i == linhas - 1)
                    {
                        recipiente[i, j] = "═";
                    }
                    else
                        recipiente[i, j] = " ";
                }            
            }

            return recipiente;
        }

        public static void Display(string[,] recipiente)
        {


            for (int i = 0; i < recipiente.GetLength(0); i++)
            {
                for (int j = 0; j < recipiente.GetLength(1); j++)
                {                  
                   Console.Write(recipiente[i,j]);
                }
                Console.WriteLine();
            }
        }

        
        // Movimentação das peças pelo tabuleiro de jogo
        public static void EliminarPosicao(string[,] recipiente, string[] peca, int x, int y)
        {         

            for (int i = 0; i < peca.Length; i++, y++)
            {
                recipiente[x, y] = " ";
            }
        }

        public static void EliminarPosicao2(string[,] recipiente, string[,] peca2, int x, int y)
        {
            for (int i = 0; i < peca2.GetLength(0); i++,x++)
            {
                for (int j = 0, ye=y; j < peca2.GetLength(1); j++,ye++)
                {
                    recipiente[x, ye] = " ";
                }              
            }
        }

        public static void Mover(string[,] recipiente, string[] peca, int x, int y)
        {

            for (int i = 0; i < peca.Length; i++,y++)
            {
                recipiente[x, y] = peca[i];
            }
        }

        public static void Mover2(string[,] recipiente, string[,]peca2, int x, int y)
        {
                     
            for (int i = 0; i < peca2.GetLength(0); i++,x++)
            {         
                for (int j = 0, aux = y; j < peca2.GetLength(1); j++, aux++)
                {
                    recipiente[x,aux] = peca2[i, j];
                }
                            
            }
        }


        //Verificaçao de Linhas no tabuleiro de jogo
        public static bool verificarLinhas(string[,] recipiente)
        {
            var linha = recipiente.GetLength(0);
            var coluna = recipiente.GetLength(1);
            string simbolo = "#";

            bool completo = false;
            for (int x= 0; x < linha -1; x++)
            {

                for (int y = 1; y < coluna -1; y++)
                {
                    completo = false;
                    if (recipiente[x, y] == simbolo)
                        completo = true;
                    else
                    {
                        completo = false;
                        break;
                    }
                }

                if (completo)
                    return true;
            }

            return false;
        }


    }
}
