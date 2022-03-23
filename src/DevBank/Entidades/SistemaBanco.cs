using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class SistemaBanco
    {
        public List<Conta> ListaDeContas { get; set; }
        public List<Transferencia> ListaDeTransferencias { get; set; }

        public void CriaListaContas()
        {
            ListaDeContas = new List<Conta>();
        }
        public void AddConta(Conta conta)
        {
            ListaDeContas.Add(conta);
        }
        public void RetornaContas()
        {
            if (ListaDeContas.Count == 0)
                Console.Write("Não existem contas no nosso sistema\n");
            Console.WriteLine($"No momento existem {ListaDeContas.Count} conta(s) registradas:");
            foreach (Conta conta in ListaDeContas)
            {
               
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"\tNumero da Conta: {conta.NumeroConta};");
                Console.WriteLine($"\tProprietário: {conta.Nome};");
                Console.WriteLine($"\tTipo da Conta: {conta.TipoConta};");
                Console.WriteLine($"\tTipo da Conta: {conta.Agencia};");
                Console.WriteLine($"\tSaldo: {conta.Saldo}.");
                Console.WriteLine("--------------------------------\n");
            }

        }
        public void CriaListaTranferencias()
        {
            ListaDeTransferencias = new List<Transferencia>();
        }
        public void AddTranferencia(Transferencia transferencia)
        {
            if (transferencia != null)
                ListaDeTransferencias.Add(transferencia);
        }
        public void RetornaTransferencias()
        {
            if (ListaDeTransferencias.Count == 0)
                Console.Write("Não existem transações no sistema");
            Console.WriteLine($"No momento existem {ListaDeTransferencias.Count} tranferencia(s) registradas:");
            foreach (Transferencia transferencia in ListaDeTransferencias)
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine($"\tProprietário: {transferencia.NumeroContaDestino}");
                Console.WriteLine($"\tNumero da Conta: {transferencia.Valor}");
                Console.WriteLine($"\tSaldo: {transferencia.Data}");
                Console.WriteLine("--------------------------------\n");

            }
        }
        public Conta? CriarConta() // o retorno precisa ser uma conta
        {
            Console.WriteLine("Ok, vamos criar uma nova conta!");

            Console.WriteLine("Por favor, digite seu nome:");
            var nome = Console.ReadLine();
            if(nome.Any(char.IsDigit) == true || nome == "")
            {
                Console.WriteLine("Nome Invalido");
                return null;
            }

            Console.WriteLine("Por favor, digite seu endereço:");
            var endereco = Console.ReadLine();

            Console.WriteLine("Digite seu CPF:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite sua renda mensal para ver as opções de conta disponíveis para você");
            var rendaMensal = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escolha o tipo de conta que deseja abrir:");
            Console.WriteLine("[1] Conta Corrente.");
            Console.WriteLine("[2] Conta Poupança.");
            Console.WriteLine("[3] Conta Investimento.\n");

            var tipoConta = Int32.Parse(Console.ReadLine());
            if (tipoConta > 3 || tipoConta < 1) //mudar isso mais tarde
            {
                Console.WriteLine("Tipo conta escolhido não existe");
                return null; //isso vira um break depois
            }

            Console.WriteLine("Em qual agencia deseja abrir sua conta?");
            Console.WriteLine("[1] 001 - Florianópolis");
            Console.WriteLine("[2] 002 - São José");
            Console.WriteLine("[3] 003 - Biguaçu");

            var agencia = Int32.Parse(Console.ReadLine());
            if (agencia > 3 || agencia < 1) //mudar isso mais tarde
            {
                Console.WriteLine("Agencia não encontrada");
                return null; //isso vira um break depois
            }
            Console.WriteLine("passei");
            if (tipoConta == 1)
            {

                var conta = new ContaCorrente(nome, cpf, endereco, rendaMensal, (DevBank.Enum.AgenciasEnum)agencia, (DevBank.Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                Console.WriteLine("Conta corrente criada com sucesso");
                return null;
            }
            if (tipoConta == 2)
            {

                var conta = new ContaPoupanca(nome, cpf, endereco, rendaMensal, (DevBank.Enum.AgenciasEnum)agencia, (DevBank.Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                Console.WriteLine("Conta Poupança criada com sucesso");
                return null;
            }
            if (tipoConta == 3)
            {

                var conta = new ContaInvestimento(nome, cpf, endereco, rendaMensal, (DevBank.Enum.AgenciasEnum)agencia, (DevBank.Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                Console.WriteLine("Conta Poupança criada com sucesso");
                
            }

            return null;

            // precisa das informacoes e do tipo da conta
        }
        public void ListarTransacoesDeUmCliente(Conta conta)
        {
            conta.Extrato();
        }

        public Conta? RetornaContaEspecifica()
        {
            Console.WriteLine("Olá, digite o numero de sua conta");
            var numeroConta = Int32.Parse(Console.ReadLine());
            var contaExiste = ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == numeroConta);
            if (contaExiste == null)
            {
                Console.WriteLine($"A conta com o nunmero {numeroConta} naõ existe no sistema");
                return null;
            }

            Console.WriteLine($"Olá {contaExiste.Nome}, seja bem vindo novamente!");
            Console.WriteLine($"O que deseja fazer hoje?!");
            return contaExiste;
        }
    }
}
