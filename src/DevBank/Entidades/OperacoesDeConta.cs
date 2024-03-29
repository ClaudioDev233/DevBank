﻿using System;
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
            Console.Clear();
            conta.InformacoesConta();
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
                Console.Clear();
                Console.WriteLine("Pressione algo para voltar");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.Clear();
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
                Console.Clear();
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
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Efetuando transferencia");

                
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
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
            }
        }
        public void OperacaoInvestimento(SistemaBanco sistema, ContaInvestimento conta, Validacoes validacoes, DateTime dataSistema)
        {
            Console.Clear();
            conta.InformacoesConta();

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
                Console.Clear();
                Console.WriteLine("Pressione algo para voltar.");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Efetuando saque, insira o valor:");
                var valorSaque = Console.ReadLine();
                var validaSaque = validacoes.ValidaValor(valorSaque);
                if (validaSaque == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido.");

                }
                conta.Saque(Decimal.Parse(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.Clear();
                Console.WriteLine("Efetuando depósito, insira o valor:");
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
                Console.Clear();
                Console.WriteLine("Verificando saldo ....");
                conta.RetornaSaldo();
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.Clear();
                Console.WriteLine("Verificando extrato ....");
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.Clear();
                Console.WriteLine("Efetuando transferência");

                
                var contaDestino = sistema.ProcuraContaNaListaGeralDeContas(validacoes);
                Console.Write(" de destino:");

                Console.WriteLine("Qual o valor da transferência?");
                var valorTransferencia = Console.ReadLine();
                var validaTransferencia = validacoes.ValidaValor(valorTransferencia);
                if (validaTransferencia == false)
                {
                    throw new Exception("O valor digitado é inválido.");

                }
                if (contaDestino == null || valorTransferencia == null)
                {
                    throw new Exception("Não é possivel continuar a transação pois os dados inseridos são inválidos");
                }
                var validaDiaDaSemana = validacoes.validaDiaDaSemana(dataSistema);
                if (!validaDiaDaSemana)
                    throw new Exception("Não é possivel realizar transferências no fim de semana.");

                var novaTranferencia = conta.Transferencia(sistema, contaDestino, Decimal.Parse(valorTransferencia), dataSistema);
                sistema.AddTranferencia(novaTranferencia);
                Console.ReadKey();
            }
            if (option == "6")
            {
                Console.Clear();
                Console.WriteLine("Qual o tipo de investimento que deseja realizar?");
                Console.WriteLine("1 LCI - Permanência minima 6 meses - 8% ao ano.");
                Console.WriteLine("2 LCA - Permanência minima 12 meses - 9% ao ano.");
                Console.WriteLine("3 CDB - Permanência minima 36 meses - 10% ao ano.");
                var tipoInvestimento = validacoes.ValidaEscolha(Console.ReadLine());
                if(tipoInvestimento == null)
                    throw new Exception("Tipo de investimento inválido.");

                Console.WriteLine("Qual o valor do investimento?");
                var valorInvestimento = Console.ReadLine();
                bool validaInvestimento = validacoes.ValidaValor(valorInvestimento);
                if (validaInvestimento == false)
                {
                    throw new Exception("Erro, o valor inserido é inválido.");

                }
                Console.WriteLine("Quantos meses deseja deixar o valor investido?");
                var tempoInvestimento = Console.ReadLine();
                var validaTempoInvestimento =validacoes.ValidaInteiro(tempoInvestimento);
                string nomeInvestimento = "";
                if (!validaTempoInvestimento)
                    throw new Exception("Erro");
                if(tipoInvestimento == "1")
                {
                conta.LCI(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento));
                    nomeInvestimento = "LCI";
                }
                if (tipoInvestimento == "2")
                {
                    conta.LCA(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento));
                    nomeInvestimento = "LCA";
                }
                if (tipoInvestimento == "3")
                {
                    conta.CDB(Decimal.Parse(valorInvestimento), dataSistema, int.Parse(tempoInvestimento));
                    nomeInvestimento = "CDB";
                }

                Console.WriteLine("Deseja realizar o investimento simulado?");
                Console.WriteLine("[1] Sim.");
                Console.WriteLine("[2] Não.");
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
                Console.Clear();
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
                Console.ReadKey();
            }
            if(option == "8")
            {
                Console.Clear();
                conta.ListarInvestimento();
            }
            
            
        }
        public void OperacaoCorrente(SistemaBanco sistema, ContaCorrente conta, Validacoes validacoes, DateTime dataSistema)
        {
            Console.Clear();
            conta.InformacoesConta();
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
                Console.Clear();
                Console.WriteLine("Pressione algo para voltar.");
                Console.ReadKey();
            }
            if (option == "1")
            {
                Console.Clear();
                Console.WriteLine("Efetuando saque, insira o valor:");
                var valorSaque = Console.ReadLine();
                var validaSaque = validacoes.ValidaValor(valorSaque);
                if (validaSaque == false)
                {
                    throw new Exception("Erro, o valor inserido é invalido.");
                    
                }
                conta.Saque(Decimal.Parse(valorSaque));

                Console.ReadKey();
            }
            if (option == "2")
            {
                Console.Clear();
                Console.WriteLine("Efetuando depósito, insira o valor:");
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
                Console.Clear();
                Console.WriteLine("Verificando saldo ....");
                conta.RetornaSaldo();
                Console.ReadKey();
            }
            if (option == "4")
            {
                Console.Clear();
                conta.InformacoesConta();
                conta.Extrato();
                Console.ReadKey();
            }
            if (option == "5")
            {
                Console.Clear();
                Console.WriteLine("Efetuando transferencia");

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
                Console.Clear();
                conta.ValorChequeEspecial();
                Console.ReadKey();

            }
            if (option == "7")
            {
                Console.Clear();
                Console.WriteLine("Alterar Dados");
                conta.AlteraDados(validacoes);
                Console.ReadKey();
            }
        }
    }
}
