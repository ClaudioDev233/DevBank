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



        } // falta validar as outras opcoes
        if (opt == "2")
        {
            Console.Clear();
            

            var numeroDaConta = sistema.ProcuraContaNaListaGeralDeContas(validacoes);
            if (numeroDaConta == null)
            {

                
                Console.WriteLine("Pressione algo para retornar ao inicio");
                Console.ReadKey();//verificar se a conta existe no DB de contas - ok

            }
               
            var conta = sistema.RetornaContaEspecifica(numeroDaConta);
            //ver qual é o tipo dessa conta

            //suponhetamos que a conta existe no sistema, vai me retornar um inteiro que é o numero da conta
            if (conta != null && conta.TipoConta == DevBank.Enum.TipoContaEnum.Poupança)
            {
                var contaPoupanca = sistema.RetornaContaDoTipo("Poupança", numeroDaConta);
                //aqui dentro eu procuro a conta na lista do seu tipo, no caso popança
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
        } // funciona - checar 
        if (opt == "3")
        {

            sistema.RetornaContas(validacoes);
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();

           //ok
        } // lista e passa nos testes
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
            Console.WriteLine(sistema.RetornaValorInvestimentos());
            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        } //precisa mudar o resto das contas

        if (opt == "6")
        {
            
         var numeroConta =  sistema.ProcuraContaNaListaGeralDeContas(validacoes);
            var conta = sistema.RetornaContaEspecifica(numeroConta);
            if(conta != null)
            sistema.ListarTransacoesDeUmCliente(conta);

            Console.WriteLine("Pressione algo para retornar ao inicio");
            Console.ReadKey();
        } 
       
        else if(opt == "0")
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
