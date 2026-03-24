using System.Security.Cryptography;
/*
v1

Iremos fazer um jogo onde o usuário terá chances de acertar um número aleatório decidido pelo sistema.

Input (Entrada de Dados)O usuário digita número inteiro

Processamento
O sistema compara o número digitado com um número inteiro aleatório

Output (Saída de Dados)
O sistema informará o usuário se o mesmo acertou ou não, podendo incluir dicas sobre a proximidade do "chute"
*/

using System.Runtime.Intrinsics.Arm;

// >> SISTEMA GERA UM NÚMERO ALEATÓRIO <<

int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 101);

bool deveContinuar = true;

while (deveContinuar)
{

  Console.WriteLine("----------------------");
  Console.WriteLine(" Jogo da Adivinhação");
  Console.WriteLine("----------------------");
  Console.WriteLine();

  // >> JOGADOR CHUTA UM NÚMERO <<
  Console.WriteLine("Digite um número: ");
  int chuteJogador = Convert.ToInt32(Console.ReadLine);

  if (chuteJogador == numeroAleatorio)
  {
    System.Console.WriteLine("Parabéns! Você acertou! O número secreto era: " + numeroAleatorio);
  }

  else if (chuteJogador < numeroAleatorio)
  {
    Console.WriteLine("O número chutado é MENOR que o número secreto.");
  }

  else if (chuteJogador > numeroAleatorio)
  {
    System.Console.WriteLine("O número chutado é MAIOR que o número secreto.");
  }

}

System.Console.WriteLine();
Console.Write("Deseja continuar jogando? [S/N]");
string desejaContinuar = Console.ReadLine().ToUpper();

if (desejaContinuar != "s")
{
  deveContinuar = false;
}

Console.ReadLine();