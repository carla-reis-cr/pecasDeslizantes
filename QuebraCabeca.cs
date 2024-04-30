using System;
using System.Collections.Generic;

class QuebraCabeca
{
 private int[,] estado;

 public QuebraCabeca(int[,] estadoInicial)
 {
  estado = estadoInicial;
 }

 public bool EstaResolvido()
 {
  int[,] estadoFinal = new int[3, 3] { { 1, 2, 3 }, { 8, 0, 4 }, { 7, 6, 5 } };

  // Verificando se a matriz atual é igual à matriz do estado final
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

  // Encontra a posição da peça vazia
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

  // Verificar movimentos possíveis e adicionar à lista de movimentos
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

 public void ImprimirEstado()
 {
  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    Console.Write(estado[i, j] + " ");
   }
   Console.WriteLine();
  }
 }
}
