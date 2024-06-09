using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class AnaliseBusca
{
 public static void AnalisarBusca(QuebraCabeca quebraCabecaInicial, string tipoBusca)
 {
  Stopwatch stopwatch = new Stopwatch();
  long memoriaInicial = 0, memoriaFinal = 0, memoriaUsada = 0;
  int passos, profundidade;
  bool resultado;

  switch (tipoBusca)
  {
   case "BFS":
    GC.Collect();
    GC.WaitForPendingFinalizers();
    memoriaInicial = ObterUsoDeMemoria();
    stopwatch.Start();

    resultado = ResolutorQuebraCabeca.BuscaEmAmplitude(quebraCabecaInicial, out passos, out profundidade);

    stopwatch.Stop();
    memoriaFinal = ObterUsoDeMemoria();
    memoriaUsada = memoriaFinal - memoriaInicial;

    Console.WriteLine($"Busca em Amplitude (BFS):");
    Console.WriteLine($" Tempo = {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($" Memória = {memoriaUsada} bytes");
    Console.WriteLine($" Passos = {passos}");
    Console.WriteLine($" Profundidade = {profundidade}");
    Console.WriteLine($" Resultado = {(resultado ? "Solução encontrada" : "Solução não encontrada")}");
    break;

   case "Best-First":
    GC.Collect();
    GC.WaitForPendingFinalizers();

    memoriaInicial = ObterUsoDeMemoria();
    stopwatch.Start();

    resultado = ResolutorQuebraCabeca.BuscaMelhorEscolha(quebraCabecaInicial, out passos, out profundidade);

    stopwatch.Stop();
    memoriaFinal = ObterUsoDeMemoria();
    memoriaUsada = memoriaFinal - memoriaInicial;

    Console.WriteLine($"Busca pela Melhor Escolha (Best-First):");
    Console.WriteLine($" Tempo = {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($" Memória = {memoriaUsada} bytes");
    Console.WriteLine($" Passos = {passos}");
    Console.WriteLine($" Profundidade = {profundidade}");
    Console.WriteLine($" Resultado = {(resultado ? "Solução encontrada" : "Solução não encontrada")}");
    break;

   default:
    Console.WriteLine("Tipo de busca desconhecido.");
    break;
  }
  // Imprimir caminho da solução após a análise
  if (ResolutorQuebraCabeca.CaminhoSolucao != null && ResolutorQuebraCabeca.CaminhoSolucao.Any())
  {
   Console.WriteLine("Caminho para a solução:");
   foreach (var estado in ResolutorQuebraCabeca.CaminhoSolucao)
   {
    Console.WriteLine("[" + estado + "]");
   }
  }
 }

 private static long ObterUsoDeMemoria()
 {
  using (Process processo = Process.GetCurrentProcess())
  {
   return processo.WorkingSet64;
  }
 }
}
