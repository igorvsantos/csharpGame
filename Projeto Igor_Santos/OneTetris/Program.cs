using System;


namespace OneTetris
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ecra inicial do jogo

            Console.WriteLine("Bem vindo ao OneTetris!");
            Console.WriteLine("Introduza o seu nome e pressione ENTER");
            string nome = Console.ReadLine();

            //Cores do Jogo
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            //Tabuleiro de Jogo 
            var recipiente = Recipiente.Criar();
            Recipiente.Display(recipiente);

            
            var peca = Peca.CriarPeca();
            var peca2 = Peca.CriarPeca2();
           
            int inicioX = 0;
            int inicioY = 3;

            int linha = 0;
            int score = 0;
            
            bool ocupado = false;
            bool fim = false;

            do
            {
                int x = inicioX;
                int y = inicioY;

                //Definir o começo random da peça
                Random rnd = new Random();
                string[] aleatorio = { "w", "s" };
                int index = rnd.Next(aleatorio.Length);

                //limite superior
                if (recipiente[x + 1, y] != " ")
                    fim = true;

                //Movimentação das Peças
                if (aleatorio[index] == "s")
                {
                    Recipiente.Mover(recipiente, peca, x, y);                   
                    Info(recipiente, linha, score);

                    do
                    {
                        ConsoleKeyInfo info = Console.ReadKey();
                        if (info.Key == ConsoleKey.DownArrow)
                        {
                            Recipiente.EliminarPosicao(recipiente, peca, x, y);
                            x++;
                            Recipiente.Mover(recipiente, peca, x, y);

                            if (recipiente[x + 1, y] != " ")
                            {
                                ocupado = true;
                                if (Recipiente.verificarLinhas(recipiente) == true)
                                {
                                    int i = x;
                                    for (x = i; x > 0; x--)
                                    {
                                        for (y = 1; y < recipiente.GetLength(1)-1; y++)
                                        {
                                            recipiente[x, y] = recipiente[x - 1, y];
                                        }
                                    }

                                    linha++;
                                    score = linha * linha * 100;
                                    break;
                                }
                                break;

                            }


                            if (recipiente[x + 1, y + peca.Length - 1] != " ")
                            {
                                ocupado = true;
                                break;
                            }
                            if (recipiente[x + 1, y + peca.Length - 2] != " ")
                            {
                                ocupado = true;
                                break;
                            }
                          


                            Info(recipiente, linha, score);
                        }
                        else if (info.Key == ConsoleKey.LeftArrow)
                        {
                            Recipiente.EliminarPosicao(recipiente, peca, x, y);
                            y--;
                            if (recipiente[x, y] != " ")
                            {
                                y++;
                                Recipiente.Mover(recipiente, peca, x, y);
                            }
                            else
                            {
                                Recipiente.Mover(recipiente, peca, x, y);
                            }

                            Info(recipiente, linha, score);

                        }
                        else if (info.Key == ConsoleKey.RightArrow)
                        {
                            Recipiente.EliminarPosicao(recipiente, peca, x, y);
                            y++;

                            if (recipiente[x, y + (peca.Length - 1)] != " ")
                            {
                                y--;
                                Recipiente.Mover(recipiente, peca, x, y);

                            }
                            else
                            {
                                Recipiente.Mover(recipiente, peca, x, y);
                            }

                            Info(recipiente, linha, score);
                        }

                        else if (info.Key == ConsoleKey.Escape)
                        {
                            fim = true;
                            break;
                        }

                    } while (ocupado == false || ocupado == true);
                }

                else if (aleatorio[index] == "w")
                {
                    Recipiente.Mover2(recipiente, peca2, x, y);
                    Info(recipiente, linha, score);

                    do
                    {
                        ConsoleKeyInfo info = Console.ReadKey();
                        if (info.Key == ConsoleKey.DownArrow)
                        {
                            Recipiente.EliminarPosicao2(recipiente, peca2, x, y);
                            x++;
                            Recipiente.Mover2(recipiente, peca2, x, y);

                            if (recipiente[x + peca2.GetLength(0), y] != " ")
                            {
                                ocupado = true;
                                if (Recipiente.verificarLinhas(recipiente) == true)
                                {
                                    int i = x + 1;
                                    for (x = i; x > 0; x--)
                                    {
                                        for (y = 1; y < recipiente.GetLength(1)-1; y++)
                                        {
                                            recipiente[x, y] = recipiente[x - 1, y];

                                        }
                                    }

                                    linha++;
                                    score = linha * linha * 100;
                                    break;
                                }
                                break;
                            }

                            if (recipiente[x + peca2.GetLength(0), y + 1] != " ")
                            {
                                ocupado = true;
                                break;
                            }

                            Info(recipiente, linha, score);
                        }
                        else if (info.Key == ConsoleKey.RightArrow)
                        {
                            Recipiente.EliminarPosicao2(recipiente, peca2, x, y);
                            y++;
                            if (recipiente[x, y + (peca2.GetLength(1) - 1)] != " ")
                            {
                                y--;
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }
                            else if (recipiente[x + (peca2.GetLength(1) - 1), y + (peca2.GetLength(1) - 1)] != " ")
                            {
                                y--;
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }
                            else
                            {
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }

                            Info(recipiente, linha, score);
                        }
                        else if (info.Key == ConsoleKey.LeftArrow)
                        {
                            Recipiente.EliminarPosicao2(recipiente, peca2, x, y);
                            y--;

                            if (recipiente[x, y] != " ")
                            {
                                y++;
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }
                            else if (recipiente[x + (peca2.GetLength(1) - 1), y] != " ")
                            {
                                y++;
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }
                            else
                            {
                                Recipiente.Mover2(recipiente, peca2, x, y);
                            }
                            Info(recipiente, linha, score);

                        }


                        else if (info.Key == ConsoleKey.Escape)
                        {
                            fim = true;
                            break;
                        }

                    } while (ocupado == false || ocupado == true);

                }
            } while (fim != true);


            //Ecrã final do Jogo
            Console.Clear();
            if (score > 0)
            {
                Console.WriteLine("PParabéns " + nome + "! Conseguiste fazer: ");
                Console.WriteLine(linha + " Linhas");
                Console.WriteLine("E obtiveste um Score de: " + score);
            }
            else if (score == 0)
            {
                Console.WriteLine("UUps.." + nome + " Não fizeste nenhum ponto!! Tenta Novamente!" );
               
            }
        }

        // Limpar Consola, Mostrar Recipiente e Pontuação
        public static void Info(string[,] recipiente, int linha, int score)
        {
            Console.Clear();
            Recipiente.Display(recipiente);
            Console.WriteLine("Linhas feitas: " + linha);
            Console.WriteLine("Score: " + score);         
        }

    }
}
