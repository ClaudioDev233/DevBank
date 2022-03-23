using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class Transferencia
    {
        public Transferencia(int numeroContaOrigem, int numeroContaDestino, decimal valor)
        {
            NumeroContaOrigem = numeroContaOrigem;
            NumeroContaDestino = numeroContaDestino;
            Valor = valor;
            Data = DateTime.Now;
        }

        public int NumeroContaOrigem { get; private set; }
        public int NumeroContaDestino { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
    }
}
