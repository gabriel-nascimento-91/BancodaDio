using System;
namespace BancoDaDio
{
  public class Conta
  {
    private TipoConta TipoConta { get; set; }
    private double Credito { get; set; }
    private double Saldo { get; set; }
    private string Nome { get; set; }

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
      this.Nome = nome;
      this.Saldo = saldo;
      this.Credito = credito;
      this.TipoConta = tipoConta;
    }

    public bool Sacar(double valorSaque)
    {
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo Insuficiente!");
        return false;
      }
      this.Saldo -= valorSaque;

      Console.WriteLine($"Saldo atual da conta {this.Nome} é {this.Saldo}");
      return true;
    }

    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine($"Saldo atual da conta {this.Nome} é {this.Saldo}");
    }

    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
      if (this.Sacar(valorTransferencia))
      {
        contaDestino.Depositar(valorTransferencia);
      }
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "Tipo da Conta: " + this.TipoConta + " || ";
        retorno += "Nome: " + this.Nome + " || ";
        retorno += "Saldo: " + this.Saldo + " || ";
        retorno += "Crédito: " + this.Credito;
        return retorno;
    }
  }
}