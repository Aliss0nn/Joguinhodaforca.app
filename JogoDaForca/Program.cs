namespace JogoDaForca
{
    internal class Program
    {
        static string[] palavraSecreta = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE",
            "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA",
            "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA",
            "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };


        static char[] letras = new char[10], palavraFeita = new char[10];
        static int Tentativas = 5, contador = 0;
        static char letraDigitada;
        static string strLetra, palavra, opcao, palavraChute;
        static int quantidadedeErros;

        private static void DesenharForca(int quantidadeErros)
        {
            
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoDireito = quantidadeErros >= 3 ? @"\" : " ";
            string pernas = quantidadeErros >= 4 ? "/ \\" : " ";
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

        static char[] EscolherPalavra()
        {
            Random numeroRand = new Random();
            palavra = palavraSecreta[numeroRand.Next(0, 31)];
            letras = palavra.ToCharArray();

            return letras;

        }

        static bool ChutarPalavra()
        {
            Console.WriteLine("\nQuer chutar a palavra?  [S] [N]");
            opcao = Console.ReadLine();

            if (opcao == "S" || opcao == "s")
            {
                Console.WriteLine("Qual é a palavra? ");
                palavraChute = Console.ReadLine().ToUpper();

                if (palavraChute == palavra)
                {
                    Console.WriteLine("Parabens voce acertou!"); 
                }
                else
                {
                    Console.WriteLine("Voce errou xD");
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

        static bool VerificarTentativas()
        {

            if (contador == Tentativas)
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

        static char[] VerificarSeaLetraEstaCerta()
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

        static void MontarOJogo()
        {
            while (VerificarTentativas())
            {

                DesenharForca(quantidadedeErros);
                LetraDigitada();
                VerificarSeaLetraEstaCerta();
                MostrarPalavra();

                if (ChutarPalavra() == true)
                {
                    break;
                }

                contador++;
            }
        }

        static void Main(string[] args)
        {
            DesenharForca(quantidadedeErros);
            EscolherPalavra();
            MontarOJogo();

        }
    }
}