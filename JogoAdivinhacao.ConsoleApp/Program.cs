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

int numeroAleatorio = 0;

bool deveContinuar = true;

while (deveContinuar)
{

  //Console.Clear();

  Console.WriteLine("----------------------");
  Console.WriteLine(" Jogo da Adivinhação");
  Console.WriteLine("----------------------");
  Console.WriteLine();

  // >> JOGADOR ESCOLHE A DIFICULDADE <<
  Console.WriteLine("----------------------");
  Console.WriteLine("Escolha a dificuldade:");
  Console.WriteLine("1 - Fácil - 10 tentativas");
  Console.WriteLine("2 - Médio - 7 tentativas");
  Console.WriteLine("3 - Difícil - 5 tentativas");
  Console.WriteLine("----------------------");

  string dificuldadeEscolhida = Console.ReadLine();

  int tentativasMaximas;

  switch (dificuldadeEscolhida)
  {
    case "1":
      numeroAleatorio = RandomNumberGenerator.GetInt32(1, 31);
      tentativasMaximas = 10;
      break;

    case "2":
      numeroAleatorio = RandomNumberGenerator.GetInt32(1, 61);
      tentativasMaximas = 7;
      break;

    case "3":
      numeroAleatorio = RandomNumberGenerator.GetInt32(1, 101);
      tentativasMaximas = 5;
      break;

    default:
      Console.WriteLine("-------------------------------------------------");
      Console.WriteLine("Por favor, selecione uma dificuldade entre 1 e 3.");
      Console.WriteLine("-------------------------------------------------");
      System.Console.WriteLine("Pressione ENTER para continuar...");
      continue;
  }

  int[] numerosDigitados = new int[tentativasMaximas];
  int contadorNumerosDigitados = 0;

  int pontuacao = 1000;

  for (int tentativaAtual = 1; tentativaAtual <= tentativasMaximas; tentativaAtual++)
  {

    Console.WriteLine("----------------------");
    Console.WriteLine(" Jogo da Adivinhação");
    Console.WriteLine("----------------------");
    Console.WriteLine($"Tentativa {tentativaAtual} de {tentativasMaximas}.");
    Console.WriteLine();

    // >> JOGADOR CHUTA UM NÚMERO <<
    Console.WriteLine("Digite um número: ");
    int chuteJogador = Convert.ToInt32(Console.ReadLine());

    // >> COMPARANDO OS NÚMEROS NO HISTÓRICO DE TENTATIVAS DO USUÁRIO <<

    bool numeroRepetido = false;

    for (int indiceAtual = 0; indiceAtual < numerosDigitados.Length; indiceAtual++)
    {
      if (numerosDigitados[indiceAtual] == chuteJogador)
      {
        numeroRepetido = true;
        break;
      }
    }

    if (numeroRepetido == true)
    {
      System.Console.WriteLine("Você já digitou esse número. Tente novamente.");
      System.Console.WriteLine("---------------------------------------------");
      System.Console.Write("Digite ENTER para continuar...");
      Console.ReadLine();

      tentativaAtual--;
      continue;
    }

    // >> GUARDAR NÚMERO NA MEMÓRIA <<

    if (contadorNumerosDigitados < numerosDigitados.Length)
    {
      numerosDigitados[contadorNumerosDigitados] = chuteJogador;
      contadorNumerosDigitados++;
    }

    else
    {
      numerosDigitados = new int[tentativasMaximas];
      contadorNumerosDigitados = 0;

      numerosDigitados[contadorNumerosDigitados] = chuteJogador;
      contadorNumerosDigitados++;
    }


    if (chuteJogador == numeroAleatorio)
    {
      System.Console.WriteLine("Parabéns! Você acertou! O número secreto era: " + numeroAleatorio);
      break;
    }

    else if (chuteJogador < numeroAleatorio)
    {
      Console.WriteLine("O número chutado é MENOR que o número secreto.");
    }

    else if (chuteJogador > numeroAleatorio)
    {
      System.Console.WriteLine("O número chutado é MAIOR que o número secreto.");
    }

    int diferencaNumerica = Math.Abs(numeroAleatorio - chuteJogador);

    if (diferencaNumerica >= 10)
    {
      pontuacao -= 100;
    }

    else if (diferencaNumerica >= 5)
    {
      pontuacao -= 50;
    }

    else
    {
      pontuacao -= 20;
    }

    System.Console.WriteLine("-------------------------");
    System.Console.WriteLine("PONTUAÇÃO: " + pontuacao);
    System.Console.WriteLine("-------------------------"); ;
    Console.WriteLine("Digite ENTER para a próxima tentativa.");
    Console.ReadLine();
  }

}

System.Console.WriteLine();
Console.Write("Deseja continuar jogando? [S/N]");
string desejaContinuar = Console.ReadLine().ToUpper();

if (desejaContinuar != "S")
{
  deveContinuar = false;
}

Console.ReadLine();