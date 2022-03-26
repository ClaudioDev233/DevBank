﻿
using DevBank.Entidades;
using DevBank.Enum;

namespace DevBank
{
    public abstract class Conta
    {

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Endereco { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumeroConta { get; private set; }
        public AgenciasEnum Agencia { get; private set; }
        public TipoContaEnum TipoConta { get; private set; }
        public decimal Saldo { get; protected set; }
        public List<Transacao> ListaTransacoes { get; private set; }
        public Conta(string nome, string cPF, string endereco, decimal rendaMensal, AgenciasEnum agencia, TipoContaEnum tipoConta, int numeroConta)
        {
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
            Saldo = 0;
            NumeroConta = numeroConta + 1;
            TipoConta = tipoConta;
            ListaTransacoes = new List<Transacao>();

        }
        public virtual dynamic InformaçõesConta()
        {
            return $"Ola {Nome}, seu saldo no momento é de R${Saldo}. Sua agencia é {Agencia} e o numero da sua conta é {NumeroConta}";
        }
        public string RetornaSaldo()
        {
            return $"Seu saldo é: {Saldo:C2}";
        }
        public string Deposito(decimal valor)
        {
            Saldo += valor;
            var transacao = new Transacao(NumeroConta, valor, "Deposito");
            ListaTransacoes.Add(transacao);
            return $"O depósito no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}";
        }
        public virtual string Saque(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                var transacao = new Transacao(NumeroConta, valor, "Saque");
                ListaTransacoes.Add(transacao);
                return $"O saque no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}";
            }
            throw new Exception($"Não foi possivel realizar o saque pois seu saldo atual é de {Saldo:C2}");

        }
        public void Extrato()
        {
            if (ListaTransacoes.Count == 0)
            {

                throw new Exception("Ainda não foram efetuadas transações.aqui");
            }
            Console.WriteLine("Suas ultimas transações foram:");
            foreach (var transacao in ListaTransacoes)
            {
                Console.WriteLine($"Data : {transacao.Data}");
                Console.WriteLine($"Valor: {transacao.Valor:C2}");
                Console.WriteLine($"Tipo: {transacao.Tipo}");
            }
        }
        public virtual Transferencia? Transferencia(SistemaBanco listaContas, int numeroContaDestino, decimal valor, DateTime dataSistema) //nao esquecer de passar a data do sistema
        {
            var date = dataSistema;
            //colocar do lado de fora talvez? 

            #region Verificação se a conta consta no banco de dados 

            var contaExiste = listaContas.ListaDeContas.Find(conta => conta.NumeroConta == numeroContaDestino);
            if (contaExiste == null)
            {
                throw new Exception($"A conta com o nunmero {numeroContaDestino} naõ existe no sistema");

            }


            #endregion

            #region Verifica se o dia não é fim de semana

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new Exception("Não é possivel realizar transferencias no fim de semana");

            }

            #endregion

            var contaDestino = listaContas.ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == contaExiste.NumeroConta); //procura mas nao verifica

            #region Verifica se a conta destino não é a mesma conta que fará a tranferencia

            if (NumeroConta == contaDestino.NumeroConta)
            {
                throw new Exception("Não pode transferir para sua propria conta");

            }



            #endregion

            #region Verifica se tem saldo disponivel

            if (valor > Saldo)
            {
                throw new Exception("Saldo Insuficiente");

            }

            #endregion

            Saldo -= valor;
            contaDestino.Saldo += valor;

            var transacao = new Transacao(NumeroConta, contaDestino.NumeroConta, valor, "transferencia");
            ListaTransacoes.Add(transacao);
            contaDestino.ListaTransacoes.Add(transacao);

            Console.WriteLine($"A transferencia foi feita com sucesso, o novo saldo de sua conta é {Saldo:C2}");

            var transferencia = new Transferencia(NumeroConta, contaDestino.NumeroConta, valor);
            return transferencia;
        }

        public void AlteraDados(Validacoes validacao)

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



            Console.WriteLine("Digite sua nova renda mensal");
            var rendaMensal = Console.ReadLine();
            var validaRenda = validacao.ValidaValor(rendaMensal);

            if (!validaRenda)
            {
                throw new Exception("Formato da renda inválido");
            }

            Console.WriteLine("Para qual agencia edseja migrar?");
            Console.WriteLine("[1] 001 - Florianópolis");
            Console.WriteLine("[2] 002 - São José");
            Console.WriteLine("[3] 003 - Biguaçu");

            var agencia = Int32.Parse(Console.ReadLine());
            if (agencia > 3 || agencia < 1)
            {
                throw new Exception("Agencia não encontrada");

            }

            Nome = nome;
            Endereco = endereco;
            RendaMensal = decimal.Parse(rendaMensal);
            Agencia = (AgenciasEnum)agencia;

            Console.WriteLine("Alterações feitas com sucesso!");
        }
    }
}