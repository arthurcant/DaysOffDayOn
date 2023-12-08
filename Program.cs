using System;
using System.Text;
using System.IO;

namespace DaysOffDayOn
{
    class Program
    {
        static void Main(string[] args)
        {

            //string line;
            //try
            //{
            //   StreamReader sr = new StreamReader("C:\\Users\\arthu\\OneDrive - Scai Hub\\Área de Trabalho\\projetos\\DaysOffDayOn\\Sample.txt");
            //    line = sr.ReadLine();

            //    while(line != null)
            //    {
            //        Console.WriteLine(line);
            //        line = sr.ReadLine();
            //    }
            //    sr.Close();
            //    Console.ReadLine();

            //    StreamWriter sw = new StreamWriter("C:\\Users\\arthu\\OneDrive - Scai Hub\\Área de Trabalho\\projetos\\DaysOffDayOn\\Test.txt");

            //    sw.WriteLine("Testando o arquivo");
            //    sw.Close();

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: " + e.Message);
            //}

            int opcoes, mes, ano;
            const int DAY = 1;
            string resposta;

            do
            {
                opcoes = MenuPrincipal();

                switch (opcoes)
                {
                    case 1:
                        Console.WriteLine("Hoje você trabalha ? (S - sim/ N - não)");
                        resposta = Console.ReadLine();

                        MenuMostrarMeses();
                        // Acrecentar tratamento de erro aqui
                        // Caso o usuario entre com um mes invalido.
                        Console.WriteLine("Escolha até que o mês Você quer calcular ?");
                        mes = int.Parse(Console.ReadLine());

                        // Aqui também.
                        Console.WriteLine("Até que o ano Você quer calcular ?");
                        ano = int.Parse(Console.ReadLine());

                        DateTime dataEscolhidaPeloUsuario = new DateTime(ano, mes, DAY);

                        ImprimirDiasCalculadosDeTrabalho(resposta, dataEscolhidaPeloUsuario);
                    break;

                    case 0:

                    break;
                }

            } while (opcoes != 0);

        }

        private static void ImprimirDiasCalculadosDeTrabalho(string resposta, DateTime dataEscolhida)
        {
            Console.WriteLine(CalcularDiasDeTrabalho(resposta, dataEscolhida));
        }

        private static StringBuilder CalcularDiasDeTrabalho(string resposta, DateTime dataEscolhida)
        {
            if (resposta.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                return CalcularDiasComBaseTrabalhoHoje(dataEscolhida);
            }
            else if (resposta.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                return CalcularDiasComBaseTrabalhoAmanha(dataEscolhida);
               
            }
            return new StringBuilder("Dias de trabalho não foram calculados com sucesso");
        }

        private static StringBuilder CalcularDiasComBaseTrabalhoHoje(DateTime dataEscolhida)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DateTime dataAtual = DateTime.Now;

            bool mesFoiImprimido = false;
            int mesAtual = 0;
            string stringMesImprimido = "";

            while (dataAtual.Month <= dataEscolhida.Month
                        && dataAtual.Year <= dataEscolhida.Year)
            {
                if (!mesFoiImprimido)
                {
                    stringMesImprimido = ImprimirMeses(dataAtual.Month);
                    mesAtual = dataAtual.Month;
                    stringBuilder.Append($"{stringMesImprimido}:\n");
                    mesFoiImprimido = true;
                }

                stringBuilder.Append($"{dataAtual:D}\n");
                dataAtual = dataAtual.AddDays(2);

                if (dataAtual.Month != mesAtual)
                {
                    mesFoiImprimido = false;
                    stringBuilder.Append($"\n");
                }

            }

            return stringBuilder;

        }
        private static StringBuilder CalcularDiasComBaseTrabalhoAmanha(DateTime dataEscolhida)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DateTime dataAtual = DateTime.Now;

            bool mesFoiImprimido = false;
            int mesAtual = 0;
            string stringMesImprimido = "";

            dataAtual = dataAtual.AddDays(1);
            while (dataAtual.Month <= dataEscolhida.Month
                   && dataAtual.Year <= dataEscolhida.Year)
            {
                if (!mesFoiImprimido)
                {
                    stringMesImprimido = ImprimirMeses(dataAtual.Month);
                    mesAtual = dataAtual.Month;
                    stringBuilder.Append($"{stringMesImprimido}:\n");
                    mesFoiImprimido = true;
                }

                stringBuilder.Append($"{dataAtual:D}\n");
                dataAtual = dataAtual.AddDays(2);

                if (dataAtual.Month != mesAtual)
                {
                    mesFoiImprimido = false;
                    stringBuilder.Append($"\n");
                }
            }
            return stringBuilder;
        }

        private static int MenuPrincipal()
        {
            int opcoes;
            Console.WriteLine();
            Console.WriteLine("1 - Calcular os dias que vou trabalhar.");
            // Console.WriteLine("2 - Ajusta o padrão de quando vou trabalhar");
            // Console.WriteLine("3 - Resetar o padrão ");
            Console.WriteLine("0 - Sair");

            opcoes = int.Parse(Console.ReadLine());

            return opcoes;
        }

        private static void MenuMostrarMeses()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("01 - janeiro");
            Console.WriteLine("02 - fevereiro");
            Console.WriteLine("03 - março");
            Console.WriteLine("04 - abril");
            Console.WriteLine("05 - maio");
            Console.WriteLine("06 - junho");
            Console.WriteLine("07 - julho");
            Console.WriteLine("08 - agosto");
            Console.WriteLine("09 - setembro");
            Console.WriteLine("10 - outubro");
            Console.WriteLine("11 - novembro ");
            Console.WriteLine("12 - dezembro");
        }

        private static string ImprimirMeses(int numeroDoMes)
        {
            switch (numeroDoMes)
            {
                case 1:
                    return "Janeiro";
                break;

                case 2:
                    return "Fevereiro";

                case 3:
                    return "Março";

                case 4:
                    return "Abril";

                case 5:
                    return "Maio";

                case 6:
                    return "Junho";

                case 7:
                    return "Julho";

                case 8:
                    return "Agosto";

                case 9:
                    return "Setembro";

                case 10:
                    return "Outubro";

                case 11:
                    return "Novembro";

                case 12:
                    return "Dezembro";

                default:
                    return "Mês invalido";
            }
        }
    }
}
