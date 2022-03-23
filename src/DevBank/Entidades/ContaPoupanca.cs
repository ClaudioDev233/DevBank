using DevBank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta) : base(nome, cPF, endereco, rendaMensal, agencia, tipoConta, numeroConta)
        {
           
        }

        //6,17%
        //quanto rende a poupança por mês?
        // montante = C x((1+i)^T 
        public void Simulacao()
        {
            Console.WriteLine("Digite o tempo que deseja manter o valor aplicado");
            var tempo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a aplicado");
            var valorInvestimento = Decimal.Parse(Console.ReadLine());
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.5002/100, tempo);
            var montante = valorInvestimento * jurosPeloTempo;
            Console.WriteLine($"Em {tempo} meses, o investimento de {valorInvestimento:C2} renderá{(montante - valorInvestimento):C2}, ou um total de {montante:C2}");
        }

        public override string InformaçõesConta()
        {
            return $"Ola {Nome}, seu saldo no momento é de R${Saldo}. Sua agencia é {Agencia} e o numero da sua conta é {NumeroConta}";
        }
    }
}
