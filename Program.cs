using System;
using System.Collections.Generic;

namespace BancoDaDio
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {

      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirContas();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços e volte sempre!");
    }

    private static void Sacar()
    {
        Console.WriteLine("Informe o número da conta: ");
        int numConta = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Informe o valor que deseja sacar: ");
        double valorSacar = double.Parse(Console.ReadLine());

        listaContas[numConta].Sacar(valorSacar);

    }
    private static void Transferir()
    {
        Console.WriteLine("Informe o número da conta de origem: ");
        int numConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o número da conta de destino: ");
        int contaDestino = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Informe o valor que deseja transferir: ");
        double valorSacar = double.Parse(Console.ReadLine());

        listaContas[numConta].Transferir(valorSacar,listaContas[contaDestino]);
    }
    private static void Depositar()
    {
        Console.WriteLine("Informe o número da conta: ");
        int numConta = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Informe o valor que deseja depositar: ");
        double valorDepositar = double.Parse(Console.ReadLine());

        listaContas[numConta].Depositar(valorDepositar);
    }

    private static void ListarContas()
    {
      Console.WriteLine("Lista de contas cadastradas:\n");
      if(listaContas.Count == 0)
      {
          Console.WriteLine("Nenhuma conta cadastrada");
          return;
      }
      for (int i = 0; i < listaContas.Count; i++)
      {
          Conta conta = listaContas[i];
          Console.Write($"#{i} - ");
          Console.WriteLine(conta);
      } 
    }

    private static void InserirContas()
    {
      Console.WriteLine("Inserir nova conta");

      Console.Write("Digite 1 para Conta Física e 2 para Jurídica: ");
      int inputTipoConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o nome do cliente: ");
      string inputNome = Console.ReadLine();

      Console.Write("Digite o saldo inicial: ");
      double inputSaldo = double.Parse(Console.ReadLine());

      Console.Write("Digite o crédito: ");
      double inputCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta)inputTipoConta,
                                    saldo: inputSaldo,
                                    credito: inputCredito,
                                    nome: inputNome);
      listaContas.Add(novaConta);
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Bem-vindo ao Banco da Dio!");
      Console.WriteLine("Escolha umas das opções abaixo:");

      Console.WriteLine("1 - Listar contas");
      Console.WriteLine("2 - Inserir nova conta");
      Console.WriteLine("3 - Realizar transferência");
      Console.WriteLine("4 - Realizar saque");
      Console.WriteLine("5 - Realizar deposito");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
