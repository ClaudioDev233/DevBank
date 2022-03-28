// See https://aka.ms/new-console-template for more information

using DevBank.Entidades;


var sistema = new SistemaBanco();
var validacoes = new Validacoes();
var dataSistema = DateTime.Now;
var operacoes = new OperacoesDeConta();
sistema.CriaListaContas();
sistema.CriaListaTranferencias();
var conta1 = new ContaCorrente("Claudio", "sdhasuid", "dudsadhusa", 3000, DevBank.Enum.AgenciasEnum.Florianópolis, DevBank.Enum.TipoContaEnum.Corrente,0);
sistema.ListaDeContas.Add(conta1);
sistema.ListaDeContasCorrente.Add(conta1);
while (true)
{
    try

    {
        Console.Clear();
        Console.WriteLine(dataSistema);

        Console.WriteLine("Ola! Seja bem vindo ao DevBank!");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("O que deseja fazer hoje?");
        Console.WriteLine("[1] Criar uma nova conta?");
        Console.WriteLine("[2] Verificar uma conta já existente?");
        Console.WriteLine("[3] Listar contas");
        Console.WriteLine("[4] Listar contas negativadas");
        Console.WriteLine("[5] Total do valor investido");
        Console.WriteLine("[6] Transações de um cliente específico");
        Console.WriteLine("[7] Viagem no tempo");
        Console.WriteLine("[0] Sair");
        var opt = Console.ReadLine();


        if (opt == "1")
        {
            Console.Clear();
            sistema.CriarConta(validacoes);
            Console.WriteLine("Pressione algo para voltar");
            Console.ReadKey();



        }

        if (opt == "2")
        {
            Console.Clear();
            

            var numeroDaConta = sistema.ProcuraContaNaListaGeralDeContas(validacoes);
            if (numeroDaConta == null)
            {

                throw new Exception("Conta não encontrada");
               

            }
               
            var conta = sistema.RetornaContaEspecifica(numeroDaConta);
           
            if (conta != null && conta.TipoConta == DevBank.Enum.TipoContaEnum.Poupança)
            {
                var contaPoupanca = sistema.RetornaContaDoTipo("Poupança", numeroDaConta);
               
                operacoes.OperacaoPoupanca(sistema, contaPoupanca, validacoes, dataSistema);

            }
            if (conta != null && conta.TipoConta == DevBank.Enum.TipoContaEnum.Investimento)
            {
                var contaInvestimento = sistema.RetornaContaDoTipo("Investimento", numeroDaConta);
                operacoes.OperacaoInvestimento(sistema, contaInvestimento, validacoes, dataSistema);

            }
            if (conta != null && conta.TipoConta == DevBank.Enum.TipoContaEnum.Corrente)
            {
                var contaCorrente = sistema.RetornaContaDoTipo("Corrente", numeroDaConta);
                operacoes.OperacaoCorrente(sistema, contaCorrente, validacoes, dataSistema);

            }
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        } 
        if (opt == "3")
        {

            sistema.RetornaContas(validacoes);
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();

          
        }
        if (opt == "4")
        {

            Console.WriteLine("[4] Listar contas negativadas");
            sistema.RetornaContasNegativadas();
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        } //funciona
        if (opt == "5")
        {

            Console.WriteLine("[5] Total do valor investido");
            sistema.RetornaValorInvestimentos();
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        } 

        if (opt == "6")
        {
            
         var numeroConta =  sistema.ProcuraContaNaListaGeralDeContas(validacoes);
            var conta = sistema.RetornaContaEspecifica(numeroConta);
            if(conta != null)
            sistema.ListarTransacoesDeUmCliente(conta);

            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        }

        if (opt == "7")
        {
            Console.WriteLine("Viagem no tempo");
            var novaData = dataSistema.AddMonths(6);
            Console.WriteLine(dataSistema =novaData);
            Console.ReadKey();
        }
        else if (opt == "0")
        {
            Console.WriteLine("Até logo");
            break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
    }

}
