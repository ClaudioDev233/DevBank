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
        public void Simulacao(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia)).Month;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.4994/ 100, dataFimInvestimento);
            decimal montante = valorInvestido * jurosPeloTempo;
            Console.WriteLine($"Em {tempoDePermanencia} meses, o investimento de {valorInvestido:C2} renderá{(montante - valorInvestido):C2}, ou um total de {montante:C2}");
        }

       
    }
}
