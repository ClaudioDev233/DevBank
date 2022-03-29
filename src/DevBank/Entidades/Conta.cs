
using DevBank.Entidades;
using DevBank.Enum;

namespace DevBank
{
    public abstract class Conta
    {

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Endereco { get; private set; }
        public int NumeroConta { get; private set; }
        public decimal RendaMensal { get; private set; }
        public decimal Saldo { get; protected set; }
        public AgenciasEnum Agencia { get; private set; }
        public TipoContaEnum TipoConta { get; private set; }
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
        public virtual void InformacoesConta()
        {
            Console.WriteLine($"Ola {Nome}, seu saldo no momento é de R${Saldo}. Sua agencia é {Agencia} e o numero da sua conta é {NumeroConta}.\n");
        }
        public void RetornaSaldo()
        {
            Console.WriteLine($"Seu saldo é: {Saldo:C2}.");
        }
        public void Deposito(decimal valor)
        {
            Saldo += valor;
            var transacao = new Transacao(NumeroConta, valor, "Deposito");
            ListaTransacoes.Add(transacao);
            Console.WriteLine($"O depósito no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}.");
        }
        public virtual void Saque(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                var transacao = new Transacao(NumeroConta, valor, "Saque");
                ListaTransacoes.Add(transacao);
                Console.WriteLine($"O saque no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}.");
            }
            throw new Exception($"Não foi possível realizar o saque, pois seu saldo atual é de {Saldo:C2}.");

        }
        public void Extrato()
        {
            if (ListaTransacoes.Count == 0)
            {

                throw new Exception("Ainda não foram efetuadas transações.");
            }
            Console.WriteLine("Suas últimas transações foram:\n");
            foreach (var transacao in ListaTransacoes)
            {
                Console.WriteLine($"Data : {transacao.Data}.");
                Console.WriteLine($"Valor: {transacao.Valor:C2}.");
                Console.WriteLine($"Tipo: {transacao.Tipo}.");
            }
        }
        public virtual Transferencia? Transferencia(SistemaBanco listaContas, int numeroContaDestino, decimal valor, DateTime dataSistema)
        {
            var date = dataSistema;

            var contaDestino = listaContas.ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == numeroContaDestino);

            if (NumeroConta == contaDestino.NumeroConta)
            {
                throw new Exception("Não é possível transferir para sua própria conta.");
            }

            if (valor > Saldo)
            {
                throw new Exception("Saldo insuficiente.");
            }

            Saldo -= valor;
            contaDestino.Saldo += valor;

            var transacao = new Transacao(NumeroConta, contaDestino.NumeroConta, valor, "Transferência");
            ListaTransacoes.Add(transacao);
            contaDestino.ListaTransacoes.Add(transacao);

            Console.WriteLine($"A transferência foi realizada com sucesso, o novo saldo de sua conta é {Saldo:C2}.");

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
                throw new Exception("Nome inválido.");
            }

            Console.WriteLine("Por favor, digite seu endereço:");
            var endereco = Console.ReadLine();
            var validaEndereco = validacao.ValidaEndereço(endereco);

            if (!validaEndereco)
            {
                throw new Exception("Endereço inválido.");
            }

            Console.WriteLine("Digite sua nova renda mensal:");
            var rendaMensal = Console.ReadLine();
            var validaRenda = validacao.ValidaValor(rendaMensal);

            if (!validaRenda)
            {
                throw new Exception("Formato da renda inválido.");
            }

            Console.WriteLine("Para qual agencia deseja migrar?");
            Console.WriteLine("[1] 001 - Florianópolis.");
            Console.WriteLine("[2] 002 - São José.");
            Console.WriteLine("[3] 003 - Biguaçu.");

            var agencia = Int32.Parse(Console.ReadLine());
            if (agencia > 3 || agencia < 1)
            {
                throw new Exception("Agencia não encontrada.");

            }

            Nome = nome;
            Endereco = endereco;
            RendaMensal = decimal.Parse(rendaMensal);
            Agencia = (AgenciasEnum)agencia;

            Console.WriteLine("Alterações feitas com sucesso!");
        }
    }
}