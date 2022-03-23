using DevBank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class ContaInvestimento : Conta
    {
        public List<Investimento> ListaInvestimentos { get; set; }
        public ContaInvestimento(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta) : base(nome, cPF, endereco, rendaMensal, agencia,tipoConta, numeroConta)
        {
            ListaInvestimentos = new List<Investimento>();
        }

        // no caso dos 3 o rendimento é diario
        //lci 8% aa tempo minimo 6 meses // mensal //0,0214% diario
        //lca 9%aa tempo minimo 12 meses
        //CDB 10%aa tempo minimo 36 meses

        //indicar valor aplicado
        // tempo minimo da aplicacao
        // se for LCI ou LCA valor da CDI (11,65% aa)
        // mensagem perguntanto se deseja investic (criar uma classe investimentos)

        public void LCI()
        {
            var dataHoje = DateTime.Now;
            var dataFimInvestimento = dataHoje.AddMonths(6);
            var diferencaEmDias = (dataFimInvestimento-dataHoje).Days;

            // digitar o tempo que quer simular, o minimo são 6 meses

            var capital = 1000;
            double juros = 0.0214f/100;
            var rendimento =(decimal)Math.Pow(juros + 1, diferencaEmDias);
            var montante = capital * rendimento;
            Console.WriteLine(montante);


        }

        public void LCA()
        {
            var dataHoje = new DateTime();
            var dataFimInvestimento = dataHoje.AddMonths(12);
            var diferencaEmDias = (dataFimInvestimento - dataHoje).Days;

            // digitar o tempo que quer simular, o minimo são 6 meses

            double capital = 1000;
            double juros = 0.0239F / 100;
            double rendimento = Math.Pow(juros + 1, diferencaEmDias);
            var montante = capital * rendimento;
            Console.WriteLine(montante);

            var novoInvestimento = new Investimento(capital, "LCA", dataHoje, dataFimInvestimento);
            ListaInvestimentos.Add(novoInvestimento);
        }
        public void CDB()
        {
            var dataHoje = new DateTime();
            var dataFimInvestimento = dataHoje.AddMonths(36);
            var diferencaEmDias = (dataFimInvestimento - dataHoje).Days;

            // digitar o tempo que quer simular, o minimo são 6 meses

            double capital = 1000;
            double juros = 0.0265F / 100;
            double rendimento = Math.Pow(juros + 1, diferencaEmDias);
            var montante = capital * rendimento;
            Console.WriteLine(montante);


        }

        public override dynamic InformaçõesConta() => $"Olá {Nome}";
    }
}
