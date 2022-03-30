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
        public List<Investimento> ListaInvestimentos { get; private set; }


        public ContaInvestimento(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta) : base(nome, cPF, endereco, rendaMensal, agencia, tipoConta, numeroConta)
        {
            ListaInvestimentos = new List<Investimento>();
        }

        public void LCI(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {

            if (tempoDePermanencia < 6)
            {

                throw new Exception("Não foi possível realizar a simulação, pois o tempo mínimo de permanência é de 6 meses");
            }
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia));
            var diferencaEmDias = (dataFimInvestimento - dataSistema).Days;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.0214f / 100, diferencaEmDias);
            decimal montante = valorInvestido * jurosPeloTempo;
            Console.WriteLine($"O seu investimento no valor de {valorInvestido:c2} renderá um total de : { montante - valorInvestido:c2}, ou aproximadamente {(montante - valorInvestido) / diferencaEmDias:c2} por dia.");

        }
        public void LCA(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {

            if (tempoDePermanencia < 12)
            {

                throw new Exception("Não é possivel realizar a simulação, pois o tempo minimo de permanencia são 12 meses");
            }
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia));
            var diferencaEmDias = (dataFimInvestimento - dataSistema).Days;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.0239F / 100, diferencaEmDias);
            decimal montante = valorInvestido * jurosPeloTempo;
            Console.WriteLine($"O seu investimento no valor de {valorInvestido:c2} renderá um total de : { montante - valorInvestido:c2}, ou aproximadamente {(montante - valorInvestido) / diferencaEmDias:c2} por dia.");
        }
        public void CDB(decimal valorInvestido, DateTime dataSistema, int tempoDePermanencia)
        {

            if (tempoDePermanencia < 12)
            {

                throw new Exception("Não é possivel realizar a simulação, pois o tempo minimo de permanencia são 12 meses");
            }
            var dataFimInvestimento = dataSistema.AddMonths((tempoDePermanencia));
            var diferencaEmDias = (dataFimInvestimento - dataSistema).Days;
            var jurosPeloTempo = (decimal)Math.Pow(1 + 0.0265F / 100, diferencaEmDias);
            decimal montante = valorInvestido * jurosPeloTempo;
            Console.WriteLine($"O seu investimento no valor de {valorInvestido:c2} renderá um total de : { montante - valorInvestido:c2}, ou aproximadamente {(montante - valorInvestido) / diferencaEmDias:c2} por dia.");
        }
        public void ListarInvestimento()
        {
            if (ListaInvestimentos.Count == 0)
                throw new Exception("Não existem investimentos");
            foreach (var investimento in ListaInvestimentos)
            {
                Console.WriteLine(investimento.DataAplicacao);
                Console.WriteLine(investimento.ValorAplicado);
            }
        }

    }
}
