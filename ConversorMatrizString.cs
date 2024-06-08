public class ConversorMatrizString
{
 public static int[,] StringParaMatriz(string estado)
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

 public static string MatrizParaString(int[,] matriz)
 {
  string estado = "";

  for (int i = 0; i < 3; i++)
  {
   for (int j = 0; j < 3; j++)
   {
    estado += matriz[i, j].ToString();
    if (i != 2 || j != 2) // Adiciona vírgula se não for o último elemento
    {
     estado += ",";
    }
   }
  }

  return estado;
 }
}
