using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace Joguinhodaforca.app
{
    internal class Program
    {
        static string[] palavras = {"ABACATE","ABACAXI", "ACEROLA", "AÇAI", "ARAÇA", "BACABA", "BACURI", "BANANA",
            "CAJA", "CAJU", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO","MAÇA", "MANGABA",
            "MANGA", "MARACUJA", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };

        static string palavra = " ", letra = " ";

        static int tentativas = 0;
        static int completo= 0;
        static int posicao = 0;

        static bool sair = false;
        static int limitedeErros = 5;
        static string[] quebrada = new string[palavra.Length];

        static string PalavraAleatoria()
        {
            Random palavraRandom= new Random();
            int escolha = palavraRandom.Next(0, 31);
            palavra = palavras[escolha];

            return palavra;
        }


        static void FazerOjogo()
        {
            while ( sair != false ) 
            {
                Console.Clear();
                Console.WriteLine("Erros: {0} de {1}", tentativas, limitedeErros);

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (quebrada[i] != null)
                    {
                        Console.WriteLine(quebrada[i] + " ");
                    }
                    else
                    {
                        Console.WriteLine("_ ");
                    }


                    Console.WriteLine("\nEscolha a posição da letra: ");
                    posicao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a letra!");
                    letra = Console.ReadLine();

                    if (palavra.ElementAt(posicao - 1) == letra.ElementAt(0)) ;
                    {
                        quebrada[posicao - 1] = letra;
                        completo++;

                    }

                    {
                        tentativas++;
                    }
                }

                if (tentativas >= limitedeErros)
                {
                    sair = true;
                }
                if ( completo == palavra.Length)
                {
                    sair = true;
                }
                
            }

            if (completo == palavra.Length)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Parabéns, a palavra era {0}! " , palavra);
                Console.ResetColor();
            }
            else if ( tentativas == limitedeErros )
            {
                Console.Clear ();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você errou todas as tentativas!!");
                Console.ResetColor();

            }

           




        }











        static void Main(string[] args)
        {

            PalavraAleatoria();
            
            
            
            while (sair != false)
            {
                Console.Clear();
                Console.WriteLine("Erros: {0} de {1}", tentativas, limitedeErros);

                for (int i = 0; i < palavra.Length; i++)
                {
                    if (quebrada[i] != null)
                    {
                        Console.WriteLine(quebrada[i] + " ");
                    }
                    else
                    {
                        Console.WriteLine("_ ");
                    }


                    Console.WriteLine("\nEscolha a posição da letra: ");
                    posicao = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a letra!");
                    letra = Console.ReadLine();

                    if (palavra.ElementAt(posicao - 1) == letra.ElementAt(0)) ;
                    {
                        quebrada[posicao - 1] = letra;
                        completo++;

                    }

                    {
                        tentativas++;
                    }
                }

                if (tentativas >= limitedeErros)
                {
                    sair = true;
                }
                if (completo == palavra.Length)
                {
                    sair = true;
                }

            }

            if (completo == palavra.Length)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Parabéns, a palavra era {0}! ", palavra);
                Console.ResetColor();
            }
            else if (tentativas == limitedeErros)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Você errou todas as tentativas!!");
                Console.ResetColor();

            }

        }
    }
}