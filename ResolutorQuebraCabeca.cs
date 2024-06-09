// ResolutorQuebraCabeca.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class ResolutorQuebraCabeca

{
 public static List<string> CaminhoSolucao { get; private set; }
 public static bool BuscaEmAmplitude(QuebraCabeca estadoInicial, out int passos, out int profundidade)
 {
  Queue<QuebraCabeca> abertos = new Queue<QuebraCabeca>();
  HashSet<string> fechados = new HashSet<string>();
  Dictionary<string, (string, int)> pais = new Dictionary<string, (string, int)>();

  abertos.Enqueue(estadoInicial);
  pais[estadoInicial.ImprimirEstado()] = (null, 0);
  passos = 0;
  profundidade = 0;

  while (abertos.Count > 0)
  {
   QuebraCabeca x = abertos.Dequeue();

   // Imprime o estado atual conforme é removido da fila de abertos
   // Console.WriteLine("Estado atual removido de abertos:");
   // Console.WriteLine(x.ImprimirEstado());

   if (x.EstaResolvido())
   {
    // Console.WriteLine("Estado final encontrado!");
    passos = CalcularPassos(pais, x.ImprimirEstado());
    profundidade = pais[x.ImprimirEstado()].Item2;
    ImprimirCaminho(pais, x.ImprimirEstado());
    return true;
   }

   fechados.Add(x.ImprimirEstado());

   List<(QuebraCabeca, string)> filhos = x.MovimentosPossiveis();

   foreach (var (filho, _) in filhos)
   {
    string filhoEstado = filho.ImprimirEstado();
    int novaProfundidade = pais[x.ImprimirEstado()].Item2 + 1;

    if (!fechados.Contains(filhoEstado) && !abertos.Any(e => e.ImprimirEstado() == filhoEstado))
    {
     pais[filhoEstado] = (x.ImprimirEstado(), novaProfundidade);
     abertos.Enqueue(filho);
    }
   }
  }

  Console.WriteLine("Nenhum movimento localizou o estado final.");
  return false;
 }

 public static bool BuscaMelhorEscolha(QuebraCabeca estadoInicial, out int passos, out int profundidade)
 {

  List<QuebraCabeca> abertos = new List<QuebraCabeca> { estadoInicial };
  HashSet<string> fechados = new HashSet<string>();
  Dictionary<string, (string, int)> pais = new Dictionary<string, (string, int)>();

  pais[estadoInicial.ImprimirEstado()] = (null, 0);
  passos = 0;
  profundidade = 0;

  while (abertos.Count > 0)
  {
   // Ordena a lista de abertos pelo valor heurístico (menor valor à esquerda)
   abertos = abertos.OrderBy(x => x.ValorTotal()).ToList();
   QuebraCabeca x = abertos.First();
   abertos.RemoveAt(0);

   // Imprime o estado atual conforme é removido de abertos
   //  Console.WriteLine("Estado atual removido de abertos:");
   // Console.WriteLine(x.ImprimirEstado());

   if (x.EstaResolvido())
   {
    // Console.WriteLine("Estado final encontrado!");
    passos = CalcularPassos(pais, x.ImprimirEstado());
    profundidade = pais[x.ImprimirEstado()].Item2;
    ImprimirCaminho(pais, x.ImprimirEstado());
    return true;
   }

   fechados.Add(x.ImprimirEstado());

   List<(QuebraCabeca, string)> filhos = x.MovimentosPossiveis();

   foreach (var (filho, _) in filhos)
   {
    string filhoEstado = filho.ImprimirEstado();
    int novaProfundidade = pais[x.ImprimirEstado()].Item2 + 1;

    if (!fechados.Contains(filhoEstado) && !abertos.Any(e => e.ImprimirEstado() == filhoEstado))
    {
     pais[filhoEstado] = (x.ImprimirEstado(), novaProfundidade);
     abertos.Add(filho);
    }
    else if (abertos.Any(e => e.ImprimirEstado() == filhoEstado && e.custo > filho.custo))
    {
     var existente = abertos.First(e => e.ImprimirEstado() == filhoEstado);
     abertos.Remove(existente);
     pais[filhoEstado] = (x.ImprimirEstado(), novaProfundidade);
     abertos.Add(filho);
    }
    else if (fechados.Contains(filhoEstado) && abertos.All(e => e.ImprimirEstado() != filhoEstado))
    {
     if (filho.custo < x.custo)
     {
      fechados.Remove(filhoEstado);
      pais[filhoEstado] = (x.ImprimirEstado(), novaProfundidade);
      abertos.Add(filho);
     }
    }
   }
  }

  Console.WriteLine("Nenhum movimento localizou o estado final.");
  passos = 0;
  profundidade = 0;
  return false;
 }

 private static int CalcularPassos(Dictionary<string, (string, int)> pais, string estadoFinal)
 {
  int passos = 0;
  string estadoAtual = estadoFinal;

  while (estadoAtual != null)
  {
   passos++;
   estadoAtual = pais[estadoAtual].Item1;
  }

  return passos - 1; // Subtrai 1 porque o primeiro estado não conta como um passo
 }

 private static void ImprimirCaminho(Dictionary<string, (string, int)> pais, string estadoFinal)
 {
  CaminhoSolucao = new List<string>();
  string estadoAtual = estadoFinal;

  while (estadoAtual != null)
  {
   CaminhoSolucao.Insert(0, estadoAtual); // Insere no início para manter a ordem correta
   estadoAtual = pais[estadoAtual].Item1;
  }
  //Console.WriteLine("Caminho para a solução:");
  // while (caminho.Count > 0)
  //{
  // Console.WriteLine("[" + caminho.Pop() + "]");
  //}
 }
}
