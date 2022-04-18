using CadastroPessoasClientLab.classes;

//Criação da estrutura de menu no Program.
Console.Clear();
Console.WriteLine(@$"
=======================================
| Bem vindo ao sistema de cadastro de |
|   pessoas físicas e jurídicas       |
=======================================
");

//para mudar a cor do fundo e da fonte da barra de carregamento.
static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.DarkRed;

    Console.Write(texto);
    for (var i = 0; i < 6; i++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }
    Console.ResetColor(); //resetando para voltar ao padrão de cores original do sistema
}

BarraCarregamento("Carregando", 500); //chamada da função
Console.Clear();


//O menu com as escolhas do usuário ficará dentro de uma estrutura de repetição para que permaneça aparecendo na página até o usuário decidir e ser encaminhado para a próxima etapa. Usaremos o "do...while" pq o menu deve aparecer pelo menos uma vez e voltar a aparecer sempre que o sistema for encerrado.

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
===================================
|  Escolha uma das opções abaixo  |
|---------------------------------|
|      1 - pessoa física          |
|      2 - pessoa jurídica        |
|                                 |
|      0 - sair                   |
===================================
");

    opcao = Console.ReadLine(); //a variável "opcao" receberá o valor que for digitado pelo usuário

    switch (opcao)
    {
        case "1":
            //Iremos criar as instâncias dos objetos. As classes são os modelos, e os objetos são criados com base nesses modelos. Daremos "ctrl + ." no tipo de objeto (o objeto "PessoaFisica") para fazer o "using".

            // tipo de dado + nome ("novaPf") + = + new + tipo de dado + (); significa que dentro do objeto "novaPf" do tipo "PessoaFisica" está sendo criada uma nova instância desse mesmo tipo.
            PessoaFisica novaPf = new PessoaFisica(); //instância para receber valores
            PessoaFisica metodoPf = new PessoaFisica(); //instância criada apenas para executar os métodos
            Endereco novoEnd = new Endereco();

            //atribuição do valor
            novaPf.nome = "Adriano"; //foi salvo o valor "Adriano" no atributo "nome"
            novaPf.dataNasc = new DateTime(1995, 06, 17);
            novaPf.cpf = "1234567890";
            novaPf.rendimento = 5000.5f; //é preciso colocar o "f" após o numero decimal para converter em float, pois o sistema automaticamente entende decimal como double
            novaPf.endereco = novoEnd; //O objeto "novaPf" recebe os atributos do objeto "novoEnd".

            novoEnd.logradouro = "Rua Dinamarca";
            novoEnd.numero = 180;
            novoEnd.complemento = "apt. 14";
            novoEnd.enderecoComercial = false;

            Console.Clear();
            Console.WriteLine(novaPf.nome); //será escrito no console o valor que está salvo em "novaPf"

            //atalho para Console.WriteLine(): "cwl"

            Console.WriteLine($"Nome: {novaPf.nome} Rendimento: {novaPf.rendimento}"); //interpolação
            Console.WriteLine("Nome: " + novaPf.nome + " Rendimento: " + novaPf.rendimento); //concatenação

            Console.WriteLine($"{metodoPf.ValidarDataNasc(novaPf.dataNasc)}");
            Console.WriteLine($"{metodoPf.ValidarDataNasc("17/06/1995")}");


            Console.WriteLine(@$"
            Nome: {novaPf.nome}
            CPF: {novaPf.cpf}
            Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
            ");

            Console.WriteLine("Aperte ENTER para continuar.");
            Console.ReadLine();

            break;

        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();
            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco endPj = new Endereco();

            novaPj.nome = "Nome da empresa";
            novaPj.rendimento = 50000.5f;
            novaPj.razaoSocial = "Nome jurídico da empresa";
            novaPj.Cnpj = "00.000.000/0001-00";
            novaPj.endereco = endPj;

            endPj.logradouro = "Rua Finlândia";
            endPj.numero = 360;
            endPj.complemento = "andar 5";
            endPj.enderecoComercial = true;

            Console.Clear();
            Console.WriteLine(@$"
            Nome: {novaPj.nome}
            Razão Social: {novaPj.razaoSocial}
            CNPJ: {novaPj.Cnpj}
            CHPJ válido: {metodoPj.ValidarCnpj(novaPj.Cnpj)}
            Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}
            ");

            Console.WriteLine(metodoPj.ValidarCnpj("00000000000100"));

            Console.WriteLine("Aperte ENTER para continuar.");
            Console.ReadLine();

            break;

        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");
            BarraCarregamento("Finalizando", 300);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida! Por favor, digite um número entre as opções disponíveis.");
            Thread.Sleep(3000);
            break;
    }
} while (opcao != "0"); //enquanto a variável "opcao" receber um valor diferente de zero, o DO...WHILE será executado 