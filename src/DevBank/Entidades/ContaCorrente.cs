using DevBank.Enum;

namespace DevBank.Entidades
{
    public class ContaCorrente : Conta
    {
        
        public ContaCorrente(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta) : base(nome, cPF, endereco, rendaMensal, agencia, tipoConta, numeroConta)
        {
            ChequeEspecial = 0.1M * (rendaMensal);
        }

        public decimal ChequeEspecial { get ; private set; }

        public void ValorChequeEspecial()
        {
            Console.WriteLine($"O valor do seu cheque especial é : {ChequeEspecial:C2}");
        }
        public override void Saque(decimal valor)
        {
            if (valor > Saldo + ChequeEspecial)
            {
            throw new Exception($"Não foi possivel realizar o saque pois seu saldo atual é de {Saldo:C2} e seu limite do cheque especial é de {ChequeEspecial:C2}");
                
            }
            Saldo -= valor;
            ChequeEspecial = (Saldo + ChequeEspecial) - valor;
            var transacao = new Transacao(NumeroConta, valor, "Saque");
            ListaTransacoes.Add(transacao);
            Console.WriteLine($"O saque no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}");

        }

        public override void InformacoesConta()
        {
            Console.WriteLine($"Ola {Nome}, seu saldo no momento é de R${Saldo}. Sua agencia é {Agencia} e o numero da sua conta é {NumeroConta},\n seu limite do cheque especial é {ChequeEspecial}");
        }

       
    }
}
