using DevBank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class ContaCorrente : Conta
    {
        private decimal _chequeEspecial;

        public ContaCorrente(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta) : base(nome, cPF, endereco, rendaMensal, agencia, tipoConta, numeroConta)
        {
            ChequeEspecial = CalculaValorChequeEspecial(rendaMensal);
        }

        public decimal ChequeEspecial { get => _chequeEspecial; set => _chequeEspecial = value; }

        private decimal CalculaValorChequeEspecial(decimal rendaMensal)
        {
            //o valor do chque especial é 10% da renda mensal
            // então o saldo desse cliente é Saldo mensal + cheque especial
            // logo, ele pode ficar XReais negativo por conta do cheque especial

            return 0.1M * (rendaMensal);

        }

        public override string InformaçõesConta()
        {
            return $"Ola {Nome}, seu saldo no momento é de R${Saldo}. Sua agencia é {Agencia} e o numero da sua conta é {NumeroConta}, seu limite do cheque especial é {ChequeEspecial}";
        }

       
    }
}
