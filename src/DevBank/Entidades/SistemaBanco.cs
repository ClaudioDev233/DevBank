using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class SistemaBanco
    {
         

        public List<Conta> ListaDeContas { get; private set; }
        public List<ContaCorrente> ListaDeContasCorrente { get; private set; }
        public List<ContaPoupanca> ListaDeContasPoupanca { get; private set; }
        public List<ContaInvestimento> ListaDeContasInvestimento { get; private set; }
        public List<Transferencia> ListaDeTransferencias { get; private set; }
        public List<Investimento> ListaDeInvestimentos { get; private set; }

        public void CriaListaContas()
        {
            ListaDeContas = new List<Conta>();
            ListaDeContasCorrente = new List<ContaCorrente>();
            ListaDeContasInvestimento = new List<ContaInvestimento>();
            ListaDeContasPoupanca = new List<ContaPoupanca>();
            ListaDeInvestimentos = new List<Investimento>();
        }
        public void RetornaContas(Validacoes validacao)
        {
            if (ListaDeContas.Count == 0)
            {
                throw new Exception("Não há contas no sistema!");
                
            }

            Console.WriteLine($"No momento existem {ListaDeContas.Count} conta(s) registradas.\n");
            Console.WriteLine("Qual tipo conta de deseja listar?");
            Console.WriteLine("[1] Contas Correntes");
            Console.WriteLine("[2] Contas Poupança");
            Console.WriteLine("[3] Contas Investimento");
            string tipoConta = validacao.ValidaEscolha(Console.ReadLine());
            string tipo = tipoConta;

            switch (tipo)
            {
                case "1":
                    if (ListaDeContasCorrente.Count == 0)
                    {
                        throw new Exception("Atualmente não existem contas do tipo Corrente registradas no sistema");

                    }
                    foreach (ContaCorrente conta in ListaDeContasCorrente)
                    {

                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"\tNumero da Conta: {conta.NumeroConta};");
                        Console.WriteLine($"\tProprietário: {conta.Nome};");
                        Console.WriteLine($"\tTipo da Conta: {conta.TipoConta};");
                        Console.WriteLine($"\tTipo da Conta: {conta.Agencia};");
                        Console.WriteLine($"\tSaldo: {conta.Saldo}.");
                        Console.WriteLine("--------------------------------\n");
                    }
                   
                    break;

                case "2":
                    if (ListaDeContasPoupanca.Count == 0)
                    {
                        Console.WriteLine("Atualmente não existem contas do tipo Poupança registradas no sistema");

                    }
                    foreach (ContaPoupanca conta in ListaDeContasPoupanca)
                    {

                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"\tNumero da Conta: {conta.NumeroConta};");
                        Console.WriteLine($"\tProprietário: {conta.Nome};");
                        Console.WriteLine($"\tTipo da Conta: {conta.TipoConta};");
                        Console.WriteLine($"\tTipo da Conta: {conta.Agencia};");
                        Console.WriteLine($"\tSaldo: {conta.Saldo}.");
                        Console.WriteLine("--------------------------------\n");
                    }

                    break;

                case "3":
                    if (ListaDeContasInvestimento.Count == 0)
                    {
                        Console.WriteLine("Atualmente não existem contas do tipo Investimento registradas no sistema");


                    }
                    foreach (ContaInvestimento conta in ListaDeContasInvestimento)
                    {

                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"\tNumero da Conta: {conta.NumeroConta};");
                        Console.WriteLine($"\tProprietário: {conta.Nome};");
                        Console.WriteLine($"\tTipo da Conta: {conta.TipoConta};");
                        Console.WriteLine($"\tTipo da Conta: {conta.Agencia};");
                        Console.WriteLine($"\tSaldo: {conta.Saldo}.");
                        Console.WriteLine("--------------------------------\n");
                    }

                    break;
                    


                default:
                    break;
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
        public void AddInvestimento(Investimento investimento)
        {
            if (investimento == null)
            throw new Exception("Investimento não pode ser criado");
                ListaDeInvestimentos.Add(investimento);
        }
        public string RetornaValorInvestimentos()
        {
            if(ListaDeContasInvestimento.Count == 0)
            throw new Exception("Não existem investimentos");

             var soma = ListaDeInvestimentos.Sum(investimento => investimento.ValorAplicado);
            if(soma == 0)
            {
                throw new Exception($"{soma:C2}");
            }
            return $"{soma:C2}";
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
        public void CriarConta(Validacoes validacao) //criar validacoes e colocar aqui, no caso é validacao cpf endereco renda tipo de conta e agencia
        {
            Console.WriteLine("Ok, vamos criar uma nova conta!");

            Console.WriteLine("Por favor, digite seu nome:");
            var nome = Console.ReadLine();
            var validaNome = validacao.ValidaNome(nome);
            if (!validaNome)
            {
                throw new Exception("Nome Invalido");  
            }

            Console.WriteLine("Por favor, digite seu endereço:");
            var endereco = Console.ReadLine();
            var validaEndereco = validacao.ValidaEndereço(endereco);

            if (!validaEndereco)
            {
                throw new Exception("Endereço inválido");
            }

            Console.WriteLine("Digite seu CPF:");
            var cpf = Console.ReadLine();

            Console.WriteLine("Digite sua renda mensal para ver as opções de conta disponíveis para você");
            var rendaMensal = Console.ReadLine();
            var validaRenda = validacao.ValidaValor(rendaMensal);

            if (!validaRenda)
            {
                throw new Exception("Formato da renda inválido");
            }

            Console.WriteLine("Escolha o tipo de conta que deseja abrir:");
            Console.WriteLine("[1] Conta Corrente.");
            Console.WriteLine("[2] Conta Poupança.");
            Console.WriteLine("[3] Conta Investimento.\n");

            var tipoConta = Int32.Parse(Console.ReadLine());
            if (tipoConta > 3 || tipoConta < 1) //mudar isso mais tarde
            {
                throw new Exception("Tipo conta escolhido não existe");
                
            }

            Console.WriteLine("Em qual agencia deseja abrir sua conta?");
            Console.WriteLine("[1] 001 - Florianópolis");
            Console.WriteLine("[2] 002 - São José");
            Console.WriteLine("[3] 003 - Biguaçu");

            var agencia = Int32.Parse(Console.ReadLine());
            if (agencia > 3 || agencia < 1)
            {
                throw new Exception("Agencia não encontrada");
               
            }
            
            if (tipoConta == 1)
            {

                var conta = new ContaCorrente(nome, cpf, endereco, Decimal.Parse(rendaMensal), (Enum.AgenciasEnum)agencia, (Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                ListaDeContasCorrente.Add(conta);
                Console.WriteLine("Conta corrente criada com sucesso");
               
            }
            if (tipoConta == 2)
            {

                var conta = new ContaPoupanca(nome, cpf, endereco, Decimal.Parse(rendaMensal), (Enum.AgenciasEnum)agencia, (Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                ListaDeContasPoupanca.Add(conta);
                Console.WriteLine("Conta Poupança criada com sucesso");
                
            }
            if (tipoConta == 3)
            {

                var conta = new ContaInvestimento(nome, cpf, endereco, Decimal.Parse(rendaMensal), (Enum.AgenciasEnum)agencia, (Enum.TipoContaEnum)tipoConta, ListaDeContas.Count);
                ListaDeContas.Add(conta);
                ListaDeContasInvestimento.Add(conta);
                Console.WriteLine("Conta Poupança criada com sucesso");

            }
    
        }
        public void ListarTransacoesDeUmCliente(Conta conta)
        {
      
                conta.Extrato();

              
        }
        public Conta? RetornaContaEspecifica(int numeroConta)
        {

            var contaExiste = ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == numeroConta);
            if (contaExiste == null)
                throw new Exception("");

            //Console.WriteLine($"Olá {contaExiste.Nome}, seja bem vindo novamente a sua conta {contaExiste.TipoConta}!"); tirar isso daqui?
            //Console.WriteLine($"O que deseja fazer hoje?!");
            return contaExiste;
        }
        public dynamic? ProcuraContaNaListaGeralDeContas(Validacoes validacao)
        {
            Console.WriteLine("Olá, digite o numero de sua conta");
            var numeroConta = validacao.ValidaInteiro(Console.ReadLine());
            var contaExiste = ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == numeroConta);
            if (contaExiste == null)
            {
                throw new Exception($"A conta de número {numeroConta} não existe no sistema");
                
            }
            return numeroConta;
        }
        public Conta RetornaContaDoTipo(string tipoConta, int numeroConta) // mudar 
        {
            var tipo = tipoConta;
            switch (tipo)
            {
                case "Poupança":
                    return ListaDeContasPoupanca.FirstOrDefault(conta => conta.NumeroConta == numeroConta);

                case "Corrente":
                    return ListaDeContasCorrente.FirstOrDefault(conta => conta.NumeroConta == numeroConta);

                case "Investimento":
                    return ListaDeContasInvestimento.FirstOrDefault(conta => conta.NumeroConta == numeroConta);

                default:

                    break;
            }
            throw new Exception("Nenhuma conta foi encontrada");
        }
        public void RetornaContasNegativadas()
        {
            
            if (ListaDeContasCorrente.Count != 0)
            {
                var listaContasNegativas = ListaDeContasCorrente.FindAll(contas => contas.Saldo < 0);
                if (listaContasNegativas.Count == 0)
                {
                    
                   throw new Exception ("Não existem contas negativas no sistema. dentro");
                }

                Console.WriteLine($"No momento existe(m){listaContasNegativas.Count} conta(s) no sistema sendo elas: \n");
                foreach (var conta in listaContasNegativas)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"\tNumero da Conta: {conta.NumeroConta};");
                    Console.WriteLine($"\tProprietário: {conta.Nome};");
                    Console.WriteLine($"\tTipo da Conta: {conta.TipoConta};");
                    Console.WriteLine($"\tTipo da Conta: {conta.Agencia};");
                    Console.WriteLine($"\tSaldo: {conta.Saldo:c2}.");
                    Console.WriteLine("--------------------------------\n");
                }

                throw new Exception("Pressione algo para voltar");
            }


            throw new Exception ("Não existem contas negativas no sistema.");
           
        }
    }
}
