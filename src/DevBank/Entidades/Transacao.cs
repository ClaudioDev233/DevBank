using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class Transacao
    {
        public Transacao(int numeroContaOrigem, int numeroContaDestino, decimal valor, string tipo)
        {
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
            Tipo = tipo;
            Data = DateTime.Now;
        }

        public Transacao(int numeroContaOrigem, decimal valor, string tipo)
        {
            NumeroContaOrigem = numeroContaOrigem;
            Valor = valor;
            Tipo = tipo;
            Data = DateTime.Now;
        }

        public int NumeroContaOrigem {get;private set;}
        public int NumeroContaDestino { get; private set; }
        public decimal Valor { get;private set; }
        public string Tipo { get; private set; }
        public DateTime Data { get; private set; }
    }
}
