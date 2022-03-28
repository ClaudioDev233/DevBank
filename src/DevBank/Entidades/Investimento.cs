using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class Investimento
    {
        public Investimento(decimal valorAplicado, string tipoAplicacao, DateTime dataAplicacao, DateTime dataRetirada)
        {
            ValorAplicado = valorAplicado;
            TipoAplicacao = tipoAplicacao;
            DataAplicacao = dataAplicacao;
            DataRetirada = dataRetirada;
        }

        public decimal ValorAplicado { get; private set; }
        public string TipoAplicacao { get; private set; }
        public DateTime DataAplicacao { get; private set; }
        public DateTime DataRetirada { get; private set; }

        
    }

}
