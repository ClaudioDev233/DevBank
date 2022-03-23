
using DevBank.Entidades;
using DevBank.Enum;

namespace DevBank
{
    public abstract class Conta
    {

        public string Nome { get; set; }
        public string CPF { get; set; } //validar
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroConta { get; set; } //o sistema deverá gerar um número da conta de forma sequencial
        public AgenciasEnum Agencia { get; set; } // aqui é um Enum
        public TipoContaEnum TipoConta { get; set; }
        //quando o cliente criar uma nova conta o sistema deve apresentar em qual das agências sua conta estará vinculada. 
        public decimal Saldo { get; set; }
        public List<Transacao> ListaTransacoes { get; set; }

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



        public abstract dynamic InformaçõesConta();


        public string RetornaSaldo()
        {
            // firstOrDefult na lista de contas que contem o usuario que tem esse numero de conta
            return $"{Saldo}";
        }

        public void Deposito(decimal valor)
        {
            Saldo += valor;
            var transacao = new Transacao(NumeroConta, valor, "Deposito");
            ListaTransacoes.Add(transacao);
        }

        public string Saque(decimal valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
                var transacao = new Transacao(NumeroConta, valor, "Saque");
                ListaTransacoes.Add(transacao);
                return $"O seu saque no valor de {valor:C2} foi realizado com sucesso, seu novo saldo é de {Saldo:C2}";
            }
            return "Não é possivel fazer o saque";

        }

        public void Extrato()
        {
            Console.WriteLine(Nome);
            foreach (var transacao in ListaTransacoes)
            {

                Console.WriteLine(transacao.Data);
                Console.WriteLine(transacao.Valor);
                Console.WriteLine(transacao.Tipo);
            }
        }

        public Transferencia? Transferencia(SistemaBanco listaContas, Conta contaDestino, decimal valor) //nao esquecer de passar a data do sistema
        {
            var date = DateTime.Now;

            #region Verificação se a conta consta no banco de dados

            var contaExiste = listaContas.ListaDeContas.Find(conta => conta.NumeroConta == contaDestino.NumeroConta);
            if (contaExiste == null)
            {
                Console.WriteLine($"A conta com o nunmero {contaDestino.NumeroConta} naõ existe no sistema");
                return null;
            }

            Console.WriteLine($"Passou (conta existe)");
            #endregion

            #region Verifica se o dia não é fim de semana

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Não é possivel realizar transferencias no fim de semana");
                return null;

            } //verifica se é fim de semana
            Console.WriteLine("Vamos prosseguir com a transferencia - Passou (dia da semana)");
            #endregion

            var contaDest = listaContas.ListaDeContas.FirstOrDefault(conta => conta.NumeroConta == contaDestino.NumeroConta); //procura mas nao verifica

            #region Verifica se a conta destino não é a mesma conta que fará a tranferencia

            if (NumeroConta == contaDest.NumeroConta)
            {
                Console.WriteLine("Não pode transferir para sua propria conta");
                return null;
            }

            Console.WriteLine("Passou (não é a mesma conta)");

            #endregion

            #region Verifica se tem saldo disponivel

            if (valor > Saldo)
            {
                Console.WriteLine("SaldoInsuficiente");
                return null;
            }
            Console.WriteLine("Passou (teste saldo)");

            #endregion

            Saldo -= valor;
            contaDest.Saldo += valor;

            var transacao = new Transacao(NumeroConta, contaDestino.NumeroConta, valor, "transferencia");
            ListaTransacoes.Add(transacao);
            contaDestino.ListaTransacoes.Add(transacao);

            Console.WriteLine($"A transferencia foi feita com sucesso, o novo saldo de sua conta é {Saldo:C2}");

            var transferencia = new Transferencia(NumeroConta, contaDestino.NumeroConta, valor);
            return transferencia;
        }

        public void AlteraDados(string nome, string endereco, decimal renda, AgenciasEnum agencia)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = renda;
            Agencia = agencia;


        }
    }
}