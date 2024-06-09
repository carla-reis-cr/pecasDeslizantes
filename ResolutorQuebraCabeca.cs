using System;
using System.Collections.Generic;
using System.Linq;

public class ResolutorQuebraCabeca
{
 public static bool BuscaEmAmplitude(QuebraCabeca estadoInicial)
 {
  Queue<QuebraCabeca> abertos = new Queue<QuebraCabeca>();
  HashSet<string> fechados = new HashSet<string>();
  Dictionary<string, string> pais = new Dictionary<string, string>();

  abertos.Enqueue(estadoInicial);
  pais[estadoInicial.ImprimirEstado()] = null;

  while (abertos.Count > 0)
  {
   QuebraCabeca x = abertos.Dequeue();

   // Imprime o estado atual conforme é removido da fila de abertos
   // Console.WriteLine("Estado atual removido de abertos:");
   //Console.WriteLine(x.ImprimirEstado());

   if (x.EstaResolvido())
   {
    Console.WriteLine("Estado final encontrado!");
    ImprimirCaminho(pais, x.ImprimirEstado());
    return true;
   }

   fechados.Add(x.ImprimirEstado());

   List<(QuebraCabeca, string)> filhos = x.MovimentosPossiveis();

   foreach (var (filho, _) in filhos)
   {
    string filhoEstado = filho.ImprimirEstado();
    if (!fechados.Contains(filhoEstado))
    {
     abertos.Enqueue(filho);
     pais[filhoEstado] = x.ImprimirEstado();
    }
   }
  }

  Console.WriteLine("Nenhum movimento localizou o estado final.");
  return false;
 }

 public static bool BuscaMelhorEscolha(QuebraCabeca estadoInicial)
 {
  List<QuebraCabeca> abertos = new List<QuebraCabeca> { estadoInicial };
  HashSet<string> fechados = new HashSet<string>();
  Dictionary<string, string> pais = new Dictionary<string, string>();

  pais[estadoInicial.ImprimirEstado()] = null;

  while (abertos.Count > 0)
  {
   // Ordena a lista de abertos pelo valor heurístico (menor valor à esquerda)
   abertos = abertos.OrderBy(x => x.ValorTotal()).ToList();
   QuebraCabeca x = abertos.First();
   abertos.RemoveAt(0);

   // Imprime o estado atual conforme é removido de abertos
   // Console.WriteLine("Estado atual removido de abertos:");
   // Console.WriteLine(x.ImprimirEstado());

   if (x.EstaResolvido())
   {
    Console.WriteLine("Estado final encontrado!");
    ImprimirCaminho(pais, x.ImprimirEstado());
    return true;
   }

   fechados.Add(x.ImprimirEstado());

   List<(QuebraCabeca, string)> filhos = x.MovimentosPossiveis();

   foreach (var (filho, _) in filhos)
   {
    string filhoEstado = filho.ImprimirEstado();
    if (!fechados.Contains(filhoEstado) && !abertos.Any(e => e.ImprimirEstado() == filhoEstado))
    {
     pais[filhoEstado] = x.ImprimirEstado();
     abertos.Add(filho);
    }
    else if (abertos.Any(e => e.ImprimirEstado() == filhoEstado && e.custo > filho.custo))
    {
     var existente = abertos.First(e => e.ImprimirEstado() == filhoEstado);
     abertos.Remove(existente);
     abertos.Add(filho);
    }
    else if (fechados.Contains(filhoEstado) && abertos.All(e => e.ImprimirEstado() != filhoEstado))
    {
     if (filho.custo < x.custo)
     {
      fechados.Remove(filhoEstado);
      pais[filhoEstado] = x.ImprimirEstado();
      abertos.Add(filho);
     }
    }
   }
  }

  Console.WriteLine("Nenhum movimento localizou o estado final.");
  return false;
 }


 private static void ImprimirCaminho(Dictionary<string, string> pais, string estadoFinal)
 {
  Stack<string> caminho = new Stack<string>();
  string estadoAtual = estadoFinal;

  while (estadoAtual != null)
  {
   caminho.Push(estadoAtual);
   estadoAtual = pais[estadoAtual];
  }

  Console.WriteLine("Caminho para a solução:");
  while (caminho.Count > 0)
  {
   Console.WriteLine("[" + caminho.Pop() + "]");
  }
 }
}