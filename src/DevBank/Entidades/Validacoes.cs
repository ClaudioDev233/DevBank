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
        public bool ValidaInteiro(string inteiro)
        {
            if (inteiro.Any(char.IsLetter) || inteiro.Any(char.IsWhiteSpace) || inteiro == "")
                throw new Exception("Formato inválido");
            return true;
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
        

        public bool validaCPF(string cpf)
        {
            if (cpf.Any(char.IsLetter) || cpf.Any(char.IsWhiteSpace) || cpf == "" || cpf == null)
                throw new Exception("Cpf não foi digitado corretamente");

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        
        public bool validaDiaDaSemana(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new Exception("Não é possivel realizar transferencias no fim de semana");

            }
            return true;
        }


    }
}

