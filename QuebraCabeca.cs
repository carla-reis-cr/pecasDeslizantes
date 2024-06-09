using System;
using System.Collections.Generic;

public class QuebraCabeca
{
 public int[,] estado;
 public int custo;
 public int heuristica;

 public QuebraCabeca(int[,] estadoInicial)
 {
  estado = estadoInicial;
  custo = 0;
  heuristica = CalcularHeuristicaEuclidiana();
 }

 public bool EstaResolvido()
 {
  int[,] estadoFinal = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };

  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    if (estado[i, j] != estadoFinal[i, j])
    {
     return false;
    }
   }
  }

  return true;
 }

 public List<(QuebraCabeca, string)> MovimentosPossiveis()
 {
  List<(QuebraCabeca, string)> movimentos = new List<(QuebraCabeca, string)>();

  int linhaVazia = -1;
  int colunaVazia = -1;
  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    if (estado[i, j] == 0)
    {
     linhaVazia = i;
     colunaVazia = j;
     break;
    }
   }
  }

  if (linhaVazia > 0)
  {
   int[,] novoEstado = (int[,])estado.Clone();
   TrocarPosicao(ref novoEstado, linhaVazia, colunaVazia, linhaVazia - 1, colunaVazia);
   movimentos.Add((new QuebraCabeca(novoEstado), "Mover para cima"));
  }
  if (linhaVazia < 2)
  {
   int[,] novoEstado = (int[,])estado.Clone();
   TrocarPosicao(ref novoEstado, linhaVazia, colunaVazia, linhaVazia + 1, colunaVazia);
   movimentos.Add((new QuebraCabeca(novoEstado), "Mover para baixo"));
  }
  if (colunaVazia > 0)
  {
   int[,] novoEstado = (int[,])estado.Clone();
   TrocarPosicao(ref novoEstado, linhaVazia, colunaVazia, linhaVazia, colunaVazia - 1);
   movimentos.Add((new QuebraCabeca(novoEstado), "Mover para esquerda"));
  }
  if (colunaVazia < 2)
  {
   int[,] novoEstado = (int[,])estado.Clone();
   TrocarPosicao(ref novoEstado, linhaVazia, colunaVazia, linhaVazia, colunaVazia + 1);
   movimentos.Add((new QuebraCabeca(novoEstado), "Mover para direita"));
  }

  return movimentos;
 }

 private void TrocarPosicao(ref int[,] matriz, int linhaOrigem, int colunaOrigem, int linhaDestino, int colunaDestino)
 {
  int temp = matriz[linhaOrigem, colunaOrigem];
  matriz[linhaOrigem, colunaOrigem] = matriz[linhaDestino, colunaDestino];
  matriz[linhaDestino, colunaDestino] = temp;
 }

 public int ValorTotal()
 {
  return custo + heuristica;
 }

 private int CalcularHeuristicaEuclidiana()
 {
  int[,] estadoFinal = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };
  double euclidiana = 0.0;

  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    int valor = estado[i, j];
    if (valor != 0)
    {
     (int x, int y) = EncontrarPosicao(estadoFinal, valor);
     euclidiana += Math.Sqrt(Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
    }
   }
  }

  return (int)euclidiana;
 }

 private (int, int) EncontrarPosicao(int[,] estado, int valor)
 {
  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    if (estado[i, j] == valor)
    {
     return (i, j);
    }
   }
  }
  return (-1, -1); // Valor não encontrado
 }

 public string ImprimirEstado()
 {
  return ConversorMatrizString.MatrizParaString(estado);
 }
}
