// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite a string representando o estado inicial do quebra-cabeça:");
        string entrada = Console.ReadLine();
        int[,] estadoInicial = ConversorMatrizString.StringParaMatriz(entrada);
        QuebraCabeca quebraCabecaInicial = new QuebraCabeca(estadoInicial);

        ResolutorQuebraCabeca.BuscaEmAmplitude(quebraCabecaInicial);
    }
}