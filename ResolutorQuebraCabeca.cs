using System;
using System.Collections.Generic;

public class ResolutorQuebraCabeca
{
 public static bool BuscaEmAmplitude(QuebraCabeca estadoInicial)
 {
  Queue<QuebraCabeca> abertos = new Queue<QuebraCabeca>();
  HashSet<string> fechados = new HashSet<string>();

  abertos.Enqueue(estadoInicial);

  while (abertos.Count > 0)
  {
   QuebraCabeca x = abertos.Dequeue();

   // Imprime o estado atual conforme é removido da fila de abertos
   Console.WriteLine("Estado atual removido de abertos:");
   Console.WriteLine(x.ImprimirEstado());

   if (x.EstaResolvido())
   {
    Console.WriteLine("Estado final encontrado!");
    return true;
   }

   fechados.Add(x.ImprimirEstado());

   List<(QuebraCabeca, string)> filhos = x.MovimentosPossiveis();

   foreach (var (filho, _) in filhos)
   {
    string filhoEstado = filho.ImprimirEstado();
    if (!abertos.Contains(filho) && !fechados.Contains(filhoEstado))
    {
     abertos.Enqueue(filho);
    }
   }
  }

  Console.WriteLine("Nenhum movimento localizou o estado final.");
  return false;
 }
}
