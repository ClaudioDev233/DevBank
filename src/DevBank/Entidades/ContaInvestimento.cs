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

        public void Simulacao(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia)).Month;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.4994 / 100, dataFimInvestimento);
            decimal montante = valorInvestido * jurosPeloTempo;
            Console.WriteLine($"Em {tempoDePermanencia} meses, o investimento de {valorInvestido:C2} renderá{(montante - valorInvestido):C2}, ou um total de {montante:C2}");
        }
        public string LCI(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {
            // digitar o tempo que quer simular, o minimo são 6 meses
            //depois verificar se o saldo da conta possui o valor do montante para realizar o investimento
            //se sim gera um novo investimento a partir da simulacao
            //se nao gera um erro
            if (tempoDePermanencia < 6)
            {

                throw new Exception("Não é possivel realizar a simulação, pois o tempo minimo de permanencia sao 6 meses") ;
            }
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia));
            var diferencaEmDias = (dataFimInvestimento - dataSistema).Days;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.0214f/ 100, diferencaEmDias);
            decimal montante = valorInvestido * jurosPeloTempo;            
            return $"O seu dinheiro renderá : {montante:c2}";

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

      
    }
}
