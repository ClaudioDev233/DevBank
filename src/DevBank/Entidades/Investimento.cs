using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class Investimento
    {
        public Investimento(double valorAplicado, string tipoAplicacao, DateTime dataAplicacao, DateTime dataRetirada)
        {
            ValorAplicado = valorAplicado;
            TipoAplicacao = tipoAplicacao;
            DataAplicacao = dataAplicacao;
            DataRetirada = dataRetirada;
        }

        public double ValorAplicado { get; set; }
        public string TipoAplicacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime DataRetirada { get; set; }

        
    }

}
