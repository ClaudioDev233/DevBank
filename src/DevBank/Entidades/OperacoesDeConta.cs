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
                var valorSaque = Console.ReadLine();
                var validaSaque = validacoes.ValidaValor(valorSaque);
                if (validaSaque == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido");

                }
                conta.Saque(Decimal.Parse(valorSaque));

                Console.ReadKey();
            } 
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = Console.ReadLine();
                var validaDeposito = validacoes.ValidaValor(valorDeposito);
                if (validaDeposito == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
               conta.Deposito(Decimal.Parse(valorDeposito));

                Console.ReadKey();
            } 
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                conta.RetornaSaldo();
                Console.ReadKey();
            }
            if (option == "4")
            {
                conta.InformacoesConta();
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                Console.WriteLine("Qual o numero da conta de destino?");
                var contaDestino = validacoes.ValidaConta(Console.ReadLine());

                Console.WriteLine("Qual o valor da transferencia?");
                var valorTransferencia = Console.ReadLine();
                var validaTransferencia = validacoes.ValidaValor(valorTransferencia);
                if (validaTransferencia == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var novaTranferencia = conta.Transferencia(sistema, contaDestino, Decimal.Parse(valorTransferencia), dataSistema);
                sistema.AddTranferencia(novaTranferencia);
            }
            if (option == "6")
            {
                Console.WriteLine("Iniciando simulação");

                Console.WriteLine("Qual o valor da transf?");
                var valorTransferencia = Console.ReadLine();
                var validaTransferencia = validacoes.ValidaValor(valorTransferencia);
                if (validaTransferencia == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }


                Console.WriteLine("Qual o valor que deseja investir?");
                var valorPoupanca = Console.ReadLine();
                var validaPoupanca = validacoes.ValidaValor(valorPoupanca);
                if (validaPoupanca == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                Console.WriteLine("Quanto tempo deseja deixar seu dinheiro investido?");
                var tempo = Console.ReadLine();
                var validaTempo = validacoes.ValidaInteiro(tempo);
                if (valorPoupanca == null || tempo == null || validaTempo == false)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                conta.Simulacao(Decimal.Parse(valorPoupanca), dataSistema, int.Parse(tempo));
            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
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
                var valorSaque = Console.ReadLine();
                var validaSaque = validacoes.ValidaValor(valorSaque);
                if (validaSaque == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido");

                }
                conta.Saque(Decimal.Parse(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = Console.ReadLine();
                var validaDeposito = validacoes.ValidaValor(valorDeposito);
                if (validaDeposito == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                conta.Deposito(Decimal.Parse(valorDeposito));

                Console.ReadKey();
            }
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                conta.RetornaSaldo();
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.WriteLine("Verificando extrato ....");
                conta.InformacoesConta();
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                // var contaDestino = validacoes.ValidaConta(Console.ReadLine());
                var contaDestino = sistema.ProcuraContaNaListaGeralDeContas(validacoes);
                Console.Write(" de destino:");

                Console.WriteLine("Qual o valor da transferencia?");
                var valorTransferencia = Console.ReadLine();
                var validaTransferencia = validacoes.ValidaValor(valorTransferencia);
                if (validaTransferencia == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var validaDiaDaSemana = validacoes.validaDiaDaSemana(dataSistema);
                if (!validaDiaDaSemana)
                    throw new Exception("Não é possivel realizar transferencias no fim de semana");

                var novaTranferencia = conta.Transferencia(sistema, contaDestino, Decimal.Parse(valorTransferencia), dataSistema);
                sistema.AddTranferencia(novaTranferencia);
                Console.ReadKey();
            }
            if (option == "6")
            {
                Console.WriteLine("qual tipo de investimento voce deseja fazer?");
                Console.WriteLine("1 LCI - Permanencia minima 6 meses");
                Console.WriteLine("2 LCA - Permanencia minima 12 meses");
                Console.WriteLine("3 CDB - Permanencia minima 36 meses");
                var tipoInvestimento = validacoes.ValidaEscolha(Console.ReadLine());
                if(tipoInvestimento == null)
                    throw new Exception("Tipo de investimento invalido");

                Console.WriteLine("Qual o valor do investimento??");
                var valorInvestimento = Console.ReadLine();
                bool validaInvestimento = validacoes.ValidaValor(valorInvestimento);
                if (validaInvestimento == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido");

                }
                Console.WriteLine("insira o numero de meses que deixará seu valor investido:");
                var tempoInvestimento = Console.ReadLine();
                var validaTempoInvestimento =validacoes.ValidaInteiro(tempoInvestimento);
                string nomeInvestimento = "";
                if (!validaTempoInvestimento)
                    throw new Exception("Erro");
                if(tipoInvestimento == "1")
                {
                 Console.WriteLine(conta.LCI(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento)));
                    nomeInvestimento = "LCI";
                }
                if (tipoInvestimento == "2")
                {
                    Console.WriteLine(conta.LCA(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento)));
                    nomeInvestimento = "LCA";
                }
                if (tipoInvestimento == "3")
                {
                    Console.WriteLine(conta.CDB(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento)));
                    nomeInvestimento = "CDB";
                }

                Console.WriteLine("Deseja investir o valor?");
                Console.WriteLine("[1] Sim");
                Console.WriteLine("[2] Não");
                var escolha = validacoes.ValidaEscolha(Console.ReadLine());
                if (escolha == null || escolha == "2")
                    throw new Exception("O investimento não será realizado.");
                var novoInvestimento = new Investimento(Decimal.Parse(valorInvestimento), nomeInvestimento, dataSistema, dataSistema.AddMonths(int.Parse(tempoInvestimento)));
                sistema.AddInvestimento(novoInvestimento);
                conta.ListaInvestimentos.Add(novoInvestimento);
                conta.ListaTransacoes.Add(new Transacao(conta.NumeroConta, Decimal.Parse(valorInvestimento), "Investimento"));
                Console.WriteLine($"Seu investimento do tipo {nomeInvestimento} foi realizado com sucesso!");
                Console.ReadKey();
            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
                Console.ReadKey();
            }
            if(option == "8")
            {
                conta.ListarInvestimento();
            }
            
            
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
                var valorSaque = Console.ReadLine();
                var validaSaque = validacoes.ValidaValor(valorSaque);
                if (validaSaque == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido");
                    
                }
                conta.Saque(Decimal.Parse(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.WriteLine("Efetuando deposito, insira o valor:");
                var valorDeposito = Console.ReadLine();
                var validaDeposito = validacoes.ValidaValor(valorDeposito);
                if (validaDeposito == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                conta.Deposito(Decimal.Parse(valorDeposito));

                Console.ReadKey();
            }
            if (option == "3")
            {
                Console.WriteLine("Verificando saldo ....");
                conta.RetornaSaldo();
                Console.ReadKey();
            }
            if (option == "4")
            {
                conta.InformacoesConta();
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.WriteLine("Efetuando transferencia");

                Console.WriteLine("Qual o numero da conta de destino?");
                var contaDestino = validacoes.ValidaConta(Console.ReadLine());

                Console.WriteLine("Qual o valor da transf?");
                var valorTransferencia = Console.ReadLine();
                var validaTransferencia = validacoes.ValidaValor(valorTransferencia);
                if (validaTransferencia == false)
                {
                    throw new Exception("O valor digitado é inválido");

                }
                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var novaTranferencia = conta.Transferencia(sistema, contaDestino, Decimal.Parse(valorTransferencia), dataSistema);
                sistema.AddTranferencia(novaTranferencia);
                Console.ReadKey();

            }
            
            if (option == "6")
            {
                conta.ValorChequeEspecial();
                Console.ReadKey();

            }
            if (option == "7")
            {
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
                Console.ReadKey();
            }
        }
    }
}
