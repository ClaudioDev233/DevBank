// See https://aka.ms/new-console-template for more information

using DevBank.Entidades;


var sistema = new SistemaBanco();
sistema.CriaListaContas();
sistema.CriaListaTranferencias();

while (true)
{
    try

    {
        Console.Clear();
        Console.WriteLine("Ola! Seja bem vindo ao DevBank!");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("O que deseja fazer hoje?");
        Console.WriteLine("[1] Verificar uma conta já existente?");
        Console.WriteLine("[2] Criar uma nova conta?");
        Console.WriteLine("[3] Sair");
        var opt = Console.ReadLine();


        if (opt == "2")
        {

            sistema.CriarConta();
            Console.WriteLine("Pressione algo para voltar");
            Console.ReadKey();

        }
        if (opt == "1")
        {
            //verificar se a conta existe
            //se a conta existir, colocar ela numa variavel
            // depois listar as opcoes das coisas e assim vai
            var conta = sistema.RetornaContaEspecifica();
            if (conta != null)
            {
                Console.WriteLine(conta.RetornaSaldo());
                conta.Deposito(200);
                Console.WriteLine(conta.RetornaSaldo());
                conta.Transferencia(sistema, conta1, 20);
            }



            Console.WriteLine("Pressione algo para voltar");
            Console.ReadKey();


        }
        else if (opt == "3")
        {
            Console.WriteLine("Até logo");
            break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
