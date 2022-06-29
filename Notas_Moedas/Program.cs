using System;

namespace Notas_Moedas
{
    class Program
    {
               
        static int[] CalculaQuantidade(double[] valoresMonetarios, ref double valorDinheiro)
        {
            int[] quantidade = new int[valoresMonetarios.Length];
            double troco = valorDinheiro;
            for (int i = 0; i < valoresMonetarios.Length; i++)
            {
                quantidade[i] = (int)(valorDinheiro / valoresMonetarios[i]);
                troco -= quantidade[i] * valoresMonetarios[i];
                valorDinheiro = Math.Round(troco, 2);
            }
            return quantidade;
        }

        static void ImprimeQuantidade(string texto, int[] quantidade, double[] valoresMonetarios)
        {
            for (int i = 0; i < valoresMonetarios.Length; i++)
            {
                Console.WriteLine($"{quantidade[i]} {texto} de R$ {valoresMonetarios[i]:F2}");
            }
        }

        static void Main(string[] args)
        {
            double[] notas = {100, 50, 20, 10, 5, 2};
            double[] moedas = { 1, 0.5, 0.25, 0.10, 0.05, 0.01 };
            int[] quantidadeNotas = new int[notas.Length];
            int[] quantidadeMoedas = new int[moedas.Length];
            double valorDinheiro = double.Parse(Console.ReadLine());

            quantidadeNotas = CalculaQuantidade(notas, ref valorDinheiro);
            quantidadeMoedas = CalculaQuantidade(moedas, ref valorDinheiro);

            Console.WriteLine("NOTAS: ");
            ImprimeQuantidade("nota(s)", quantidadeNotas, notas);

            Console.WriteLine("MOEDAS: ");
            ImprimeQuantidade("moeda(s)", quantidadeMoedas, moedas);
        }
    }
}
