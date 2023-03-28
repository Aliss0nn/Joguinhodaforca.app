using System.Collections.Concurrent;

namespace joguinhodaforca2._0
{    
    internal class Program
    {
       static string[] palavraSecreta =
            { "ABACATE", "ABACAXI", "ACEROLA",
            "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI",
            "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA",
            "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA",
            "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
            "MARACUJÁ", 
            "MURICI",
            "PEQUI", 
            "PITANGA", 
            "PITAYA",
            "SAPOTI",
            "TANGERINA", "UMBU", "UVA", "UVAIA" };

        static char[] letras = new char[10], palavraFeita = new char[10];
        static int quantidadeDeTentativas = 5, contador = 0;
        static char letraDigitada;
        static string strLetra, palavra, opcao, palavraChute;
        static int quantidadedeErros;

        private static void DesenharForca(int quantidadedeErros)
        {

            string cabecaDoBoneco = quantidadedeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadedeErros >= 3 ? "/" : " ";
            string tronco = quantidadedeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadedeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadedeErros >= 3 ? @"\" : " ";
            string pernas = quantidadedeErros >= 4 ? "/ \\" : " ";

            Console.Clear();
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }

        private static char[] EscolheraPalavra()
        {
            Random random = new Random();
            palavra = palavraSecreta[random.Next(0, 31)];
            letras = palavra.ToCharArray();

            return letras;
        }
        
        static bool ChutarPalavra()
        {
            Console.WriteLine("\nDeseja chutar a palavra? [S] [N] ");
            opcao = Console.ReadLine();

            if (opcao == "S" || opcao == "s")
            {
                Console.WriteLine("Digite a palavra correta: ");
                palavraChute = Console.ReadLine().ToUpper();

                if (palavraChute == palavra)
                {                   
                    Console.WriteLine("Parabens voce acertou!");                   
                }
                else
                {
                    Console.WriteLine("Voce Errou xD");
                    Console.WriteLine($"A palavra era {palavra}");
                }

                return true;
            }
            else if (opcao == "N" || opcao == "n")
            {
                return false;
            }

            return ChutarPalavra();
        }

        static char LetraDigitada()
        {
            Console.WriteLine("\nDigite uma letra: ");
            strLetra = Console.ReadLine().ToUpper();
            letraDigitada = char.Parse(strLetra);

            return letraDigitada;
        }

        static bool VerificarChutes()
        {
            if (contador == quantidadeDeTentativas)
            {
                Console.WriteLine("Voce perdeu xD");
                Console.WriteLine($"A palabra era {palavra}");
                return false;
            }

            else
            {
                return true;
            }



        }


        static void MostrarPalavra()
        {
            for (int i = 0; i < palavraFeita.Length; i++)
            {
                Console.Write(palavraFeita[i]);
            }
        }

        static void MontarJogo()
        {
            while (VerificarChutes())
            {
                DesenharForca(quantidadedeErros);
                LetraDigitada();
                VerificarSeAcertouALetra();
                MostrarPalavra();
                if (ChutarPalavra() == true)
                {
                    break;
                }


                contador++;
            }
        }


        static char[] VerificarSeAcertouALetra()
        {
            for (int i = 0; i < letras.Length; i++)
            {
                if (letras[i] == letraDigitada)
                {                   
                    palavraFeita[i] = letraDigitada;                 
                    continue;
                }


                else if (letras[i] != letraDigitada)

                {
                    if (palavraFeita[i] == 0)
                    {
                        palavraFeita[i] = '_';
                        continue;
                    }

                    else if (letras[i] == '_')
                    {
                        continue;
                    }
                    else
                    {
                        continue;
                    }



                }

            }
            return palavraFeita;




        }
        
        static void Main(string[] args)
        {
            DesenharForca(quantidadedeErros);
            EscolheraPalavra();
            MontarJogo();

        }  
    }
}