// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> estadosIniciais = new List<string>
        {
           "123804765", // exemplo 1
            "283164705", // exemplo 2
            "283104765", // exemplo 3
           "213804756"
            // Adicione outros estados iniciais conforme necessário
        };

        foreach (var entrada in estadosIniciais)
        {
            Console.WriteLine($"Analisando estado inicial: {entrada}");
            int[,] estadoInicial = ConversorMatrizString.StringParaMatriz(entrada);
            QuebraCabeca quebraCabecaInicial = new QuebraCabeca(estadoInicial);

            // Análise para Busca em Amplitude (BFS)
            AnaliseBusca.AnalisarBusca(quebraCabecaInicial, "BFS");

            Thread.Sleep(1000);
            // Análise para Busca pela Melhor Escolha (Best-First Search)
            AnaliseBusca.AnalisarBusca(quebraCabecaInicial, "Best-First");
        }
    }
}
