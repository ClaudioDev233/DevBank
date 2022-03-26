using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBank.Entidades
{
    public class OperacoesDeConta
    {
        public void OperacaoPoupanca(SistemaBanco sistema, ContaPoupanca conta, Validacoes validacoes, DateTime dataSistema)
        {
            Console.WriteLine("[1] Saque");
            Console.WriteLine("[2] Deposito");
            Console.WriteLine("[3] Verificar Saldo");
            Console.WriteLine("[4] Extrato");
            Console.WriteLine("[5] Transferencia");
            Console.WriteLine("[6] Simulação de rendimentos");
            Console.WriteLine("[7] Alterar Dados");
            Console.WriteLine("[0] Sair");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("Pressione algo para voltar");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.WriteLine("Efetuando saque, insira o valor:");
                var valorSaque = validacoes.ValidaValor(Console.ReadLine());
                if (valorSaque == null)
                {

                    Console.WriteLine("Pressione algo para voltar");
                    Console.ReadKey();
                }
                Console.WriteLine(conta.Saque(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = validacoes.ValidaValor(Console.ReadLine());
                if (valorDeposito == null)
                {
                    throw new Exception("O valor inserido é invalido");
                }
                Console.WriteLine(conta.Deposito(valorDeposito));
                Console.ReadKey();
            }
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                Console.WriteLine(conta.RetornaSaldo());
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.WriteLine("Verificando extrato ....");
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                Console.WriteLine("Qual o numero da conta de destino?");
                var contaDestino = validacoes.ValidaConta(Console.ReadLine());

                Console.WriteLine("Qual o valor da transf?");
                var valorTransferencia = validacoes.ValidaValor(Console.ReadLine());

                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var novaTranferencia = conta.Transferencia(sistema, contaDestino, valorTransferencia, dataSistema);
                sistema.AddTranferencia(novaTranferencia);
            }
            if (option == "6")
            {
                Console.WriteLine("Iniciando simulação");

                Console.WriteLine("Qual o valor que deseja investir?");
                var valorPoupanca = validacoes.ValidaValor(Console.ReadLine());
                Console.WriteLine("Quanto tempo deseja deixar seu dinheiro investido?");
                var tempo = validacoes.ValidaInteiro(Console.ReadLine());
                if (valorPoupanca == null || tempo == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                conta.Simulacao(valorPoupanca, dataSistema, tempo);
            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
            }
        }
        public void OperacaoInvestimento(SistemaBanco sistema, ContaInvestimento conta, Validacoes validacoes, DateTime dataSistema)
        {

            Console.WriteLine("[1] Saque");
            Console.WriteLine("[2] Deposito");
            Console.WriteLine("[3] Verificar Saldo");
            Console.WriteLine("[4] Extrato");
            Console.WriteLine("[5] Tranferencia");
            Console.WriteLine("[6] Realizar investimentos");
            Console.WriteLine("[7] Alterar Dados");
            Console.WriteLine("[0] Sair");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("Pressione algo para voltar");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.WriteLine("Efetuando saque, insira o valor:");
                var valorSaque = validacoes.ValidaValor(Console.ReadLine());
                if (valorSaque == null)
                {
                    throw new Exception("Erro, o valor inserido é invalido");
                   
                }
                Console.WriteLine(conta.Saque(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = validacoes.ValidaValor(Console.ReadLine());
                if (valorDeposito == null)
                {
                    throw new Exception("Erro, o valor inserido é invalido");
                    
                }
                Console.WriteLine(conta.Deposito(valorDeposito));
                Console.ReadKey();
            }
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                Console.WriteLine(conta.RetornaSaldo());
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.WriteLine("Verificando extrato ....");
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                Console.WriteLine("Qual o numero da conta de destino?");
                var contaDestino = validacoes.ValidaConta(Console.ReadLine());

                Console.WriteLine("Qual o valor da transf?");
                var valorTransferencia = validacoes.ValidaValor(Console.ReadLine());

                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception ("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                    
                   
                }
                var novaTranferencia = conta.Transferencia(sistema, contaDestino, valorTransferencia, dataSistema);
                sistema.AddTranferencia(novaTranferencia);
            }
            if (option == "6")
            {
                Console.WriteLine("qual tipo de investimento voce deseja fazer?");
                Console.WriteLine("1 LCI");
                Console.WriteLine("2 lca");
                Console.WriteLine("3 lca");
                var escolha = validacoes.ValidaEscolha(Console.ReadLine());
                if(escolha == null)
                    Console.WriteLine("Tipo de investimento invalido");
                Console.WriteLine("Qual o valor do investimento??");
                var valorInvestimento = validacoes.ValidaValor(Console.ReadLine());
                Console.WriteLine("insira o numero de meses que deixará seu valor investido:");
                var tempoInvestimento = validacoes.ValidaInteiro(Console.ReadLine());

                Console.WriteLine(conta.LCI(valorInvestimento, dataSistema, tempoInvestimento));
                Console.WriteLine("Deseja investir o valor?");

            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
            }
            Console.ReadKey();
        }
        public void OperacaoCorrente(SistemaBanco sistema, ContaCorrente conta, Validacoes validacoes, DateTime dataSistema)
        {

            Console.WriteLine("[1] Saque");
            Console.WriteLine("[2] Deposito");
            Console.WriteLine("[3] Verificar Saldo");
            Console.WriteLine("[4] Extrato");
            Console.WriteLine("[5] Tranferencia");
            Console.WriteLine("[6] Valor cheque especial");
            Console.WriteLine("[7] Alterar Dados");
            Console.WriteLine("[0] Sair");
            var option = Console.ReadLine();
            if (option == "0")
            {
                Console.WriteLine("Pressione algo para voltar");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.WriteLine("Efetuando saque, insira o valor:");
                var valorSaque = validacoes.ValidaValor(Console.ReadLine());
                if (valorSaque == null)
                {
                    throw new Exception("Erro, o valor inserido é invalido");
                    
                }
                Console.WriteLine(conta.Saque(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = validacoes.ValidaValor(Console.ReadLine());
                if (valorDeposito == null)
                {
                    Console.WriteLine("Erro, o valor inserido é invalido");
                    Console.WriteLine("Pressione algo para voltar");
                    Console.ReadKey();
                }
                Console.WriteLine(conta.Deposito(valorDeposito));
                Console.ReadKey();
            }
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                Console.WriteLine(conta.RetornaSaldo());
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.WriteLine("Verificando extrato ....");
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                Console.WriteLine("Qual o numero da conta de destino?");
                var contaDestino = validacoes.ValidaConta(Console.ReadLine());

                Console.WriteLine("Qual o valor da transf?");
                var valorTransferencia = validacoes.ValidaValor(Console.ReadLine());

                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var novaTranferencia = conta.Transferencia(sistema, contaDestino, valorTransferencia, dataSistema);
                sistema.AddTranferencia(novaTranferencia);
            }
            if (option == "6")
            {
                conta.ValorChequeEspecial();
                
            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
            }
        }
    }
}
