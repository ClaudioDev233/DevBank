using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class Validacoes
    {
        public bool ValidaValor(string valor)
        {
            if (valor.Any(char.IsLetter) || valor.Any(char.IsWhiteSpace) || valor == "" || valor == null)
                throw new Exception("O valor digitado é inválido");
            return true;
            //Decimal.TryParse(valor, out decimal valorTransacao);
            //if (validaValor == true)
            // return valorTransacao;
            // throw new Exception("Valor digitado é inválido");
        }
        public dynamic? ValidaConta(string numeroConta)
        {
            if (numeroConta.Any(char.IsLetter) || numeroConta.Any(char.IsWhiteSpace) || numeroConta == "")
                return null;
            var validaNumeroConta = Int32.TryParse(numeroConta, out int numeroContaValido);
            if (validaNumeroConta == true)
                return numeroContaValido;
            return null;
        }
        public dynamic? ValidaInteiro(string inteiro)
        {
            if (inteiro.Any(char.IsLetter) || inteiro.Any(char.IsWhiteSpace) || inteiro == "")
                return null;
            var validaNumero = Int32.TryParse(inteiro, out int numeroInteiroValido);
            if (validaNumero == true)
                return numeroInteiroValido;
            return null;
        }
        public string ValidaEscolha(string texto)
        {
            if (texto.Any(char.IsLetter) || texto.Any(char.IsWhiteSpace) || texto == "")
                throw new Exception("Opção inválida");
            return texto;
        }

        public bool ValidaNome(string nome)
        {
            if (nome.Any(char.IsDigit) == true || nome == "" || nome == null)
                throw new Exception("O nome inserido é inválido");
            return true;
        }
        
        public bool ValidaEndereço(string endereço)
        {
            if (endereço.Any(char.IsDigit) == true || endereço == ""|| endereço == null)
                throw new Exception("O endereço inserido é inválido");
            return true;
        }
        //public bool ValidaCPF(int cpf)

    }
}
