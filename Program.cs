using System;

class Program
{
    static void Main(string[] args)
    {

        bool encontrouQuebraCabeca = false;

        Console.WriteLine("Digite a string representando o estado inicial do quebra-cabeça:");
        string entrada = Console.ReadLine();

        int[,] estadoInicial = StringParaMatriz(entrada);

        QuebraCabeca quebraCabecaInicial = new QuebraCabeca(estadoInicial);
        List<(QuebraCabeca, string)> movimentos = quebraCabecaInicial.MovimentosPossiveis();

        Console.WriteLine("Estado inicial:");
        quebraCabecaInicial.ImprimirEstado();
        Console.WriteLine();

        if (quebraCabecaInicial.EstaResolvido())
        {
            encontrouQuebraCabeca = true;
            Console.WriteLine("Quebra cabeça inicial já é o Estado Final");
        }
        else
        {
            foreach (var (proximoEstado, movimento) in movimentos)
            {
                Console.WriteLine($"Movimento: {movimento}");
                proximoEstado.ImprimirEstado();
                if (proximoEstado.EstaResolvido())
                {
                    encontrouQuebraCabeca = true;
                    Console.WriteLine("Estado final encontrado!");
                }
                Console.WriteLine();
            }
        }
        if (!encontrouQuebraCabeca)
        {
            Console.WriteLine("Nenhum movimento localizou o estado final.");
        }
    }
    static int[,] StringParaMatriz(string estado)
    {
        int[,] matriz = new int[3, 3];

        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matriz[i, j] = estado[index] - '0'; // Converter o caractere para inteiro
                index++;
            }
        }

        return matriz;
    }

}