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

        public int NumeroContaOrigem {get;set;}
        public int NumeroContaDestino { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
    }
}
