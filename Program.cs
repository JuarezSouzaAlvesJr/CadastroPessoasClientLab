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

List<PessoaFisica> listaPf = new List<PessoaFisica>();
List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

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
            PessoaFisica metodoPf = new PessoaFisica();
            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
            ===================================
            |  Escolha uma das opções abaixo  |
            |---------------------------------|
            |   1 - Cadastrar pessoa física   |
            |   2 - Listar pessoa física      |
            |                                 |
            |   0 - Voltar ao menu anterior   |
            ===================================
            ");

                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome a ser cadastrado:");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento no formato DD/MM/AAAA:");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNasc(dataNasc);
                            if (dataValida)
                            {
                                novaPf.dataNasc = dataNasc;
                            }
                            else
                            {
                                Console.WriteLine($"Data inválida. Digite uma nova data.");

                            }
                        } while (!dataValida); //"!dataValida" é o mesmo que "dataValida == false". A repetição do DO...WHILE ocorrerá enquanto a data inserida pelo usuário for inválida.

                        Console.WriteLine($"Digite o CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (somente números)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? Digite S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.enderecoComercial = true;
                        }
                        else
                        {
                            novoEnd.enderecoComercial = false;
                        }

                        novaPf.endereco = novoEnd;

                        //Agora, vamos adicionar essa pessoa cadastrada na lista.
                        listaPf.Add(novaPf);
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Thread.Sleep(3000);

                        break;

                    case "2": //vai listar cada pessoa física presente na lista
                        Console.Clear();

                        if (listaPf.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPf)
                            {
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                CPF: {cadaPessoa.cpf}
                                Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")} 
                                Valor de imposto a ser pago: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");

                                Console.WriteLine("Aperte ENTER para continuar.");
                                Console.ReadLine();

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(3000);
                        }

                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida! Por favor, digite um número entre as opções disponíveis.");
                        Thread.Sleep(3000);
                        break;
                }


            } while (opcaoPf != "0");


            //ESSA FOI A PRIMEIRA PARTE QUE FIZEMOS NO "PROGRAM"
            //Iremos criar as instâncias dos objetos. As classes são os modelos, e os objetos são criados com base nesses modelos. Daremos "ctrl + ." no tipo de objeto (o objeto "PessoaFisica") para fazer o "using".

            // tipo de dado + nome ("novaPf") + = + new + tipo de dado + (); significa que dentro do objeto "novaPf" do tipo "PessoaFisica" está sendo criada uma nova instância desse mesmo tipo.
            // PessoaFisica novaPf = new PessoaFisica(); //instância para receber valores
            // PessoaFisica metodoPf = new PessoaFisica(); //instância criada apenas para executar os métodos
            // Endereco novoEnd = new Endereco();

            // //atribuição do valor
            // novaPf.nome = "Adriano"; //foi salvo o valor "Adriano" no atributo "nome"
            // novaPf.dataNasc = new DateTime(1995, 06, 17);
            // novaPf.cpf = "1234567890";
            // novaPf.rendimento = 5000.5f; //é preciso colocar o "f" após o numero decimal para converter em float, pois o sistema automaticamente entende decimal como double
            // novaPf.endereco = novoEnd; //O objeto "novaPf" recebe os atributos do objeto "novoEnd".

            // novoEnd.logradouro = "Rua Dinamarca";
            // novoEnd.numero = 180;
            // novoEnd.complemento = "apt. 14";
            // novoEnd.enderecoComercial = false;

            Console.Clear();
            // Console.WriteLine(novaPf.nome); //será escrito no console o valor que está salvo em "novaPf"

            // //atalho para Console.WriteLine(): "cwl"

            // Console.WriteLine($"Nome: {novaPf.nome} Rendimento: {novaPf.rendimento}"); //interpolação
            // Console.WriteLine("Nome: " + novaPf.nome + " Rendimento: " + novaPf.rendimento); //concatenação

            // Console.WriteLine($"{metodoPf.ValidarDataNasc("17/06/1995")}");


            // Console.WriteLine(@$"
            // Nome: {novaPf.nome}
            // CPF: {novaPf.cpf}
            // Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}
            // Rendimento: {novaPf.rendimento.ToString("C")} 
            // Valor de imposto a ser pago: {metodoPf.PagarImposto(novaPf.rendimento).ToString("C")}
            // Maior de idade: {(metodoPf.ValidarDataNasc(novaPf.dataNasc) ? "Sim" : "Não")}
            // ");
            // //"ToString" com o argumento "C" para exibir o valor conforme o padrão monetário de real, moeda local do Brasil

            // Console.WriteLine("Aperte ENTER para continuar.");
            // Console.ReadLine();

            break;

        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();
            string? opcaoPj;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
            =====================================
            |  Escolha uma das opções abaixo    |
            |-----------------------------------|
            |   1 - Cadastrar pessoa jurídica   |
            |   2 - Listar pessoa jurídica      |
            |                                   |
            |   0 - Voltar ao menu anterior     |
            =====================================
            ");

                opcaoPj = Console.ReadLine();

                switch (opcaoPj)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEnd = new Endereco();

                        Console.WriteLine($"Digite o nome a ser cadastrado:");
                        novaPj.nome = Console.ReadLine();

                        bool cnpjValido;
                        do
                        {
                            Console.WriteLine($"Digite o CNPJ da empresa");
                            string? cnpj = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpj);
                            if (cnpjValido)
                            {
                                novaPj.cnpj = cnpj;
                            }
                            else
                            {
                                Console.WriteLine($"CNPJ inválido. Digite um novo CNPJ.");

                            }
                        } while (!cnpjValido); //"!cnpjValido" é o mesmo que "cnpjValido == false". A repetição do DO...WHILE ocorrerá enquanto o CNOJ inserido pelo usuário for inválido.

                        Console.WriteLine($"Digite a razão social");
                        novaPj.razaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (somente números)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? Digite S ou N");
                        string endCom = Console.ReadLine().ToUpper();
                        if (endCom == "S")
                        {
                            novoEnd.enderecoComercial = true;
                        }
                        else
                        {
                            novoEnd.enderecoComercial = false;
                        }

                        novaPj.endereco = novoEnd;

                        //Agora, vamos adicionar essa pessoa cadastrada na lista.
                        listaPj.Add(novaPj);
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Thread.Sleep(3000);
                        
                        break;

                        case "2": //vai listar cada pessoa física presente na lista
                        Console.Clear();

                        if (listaPj.Count > 0)
                        {
                            foreach (PessoaJuridica cadaPessoa in listaPj)
                            {
                                Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                CNPJ: {cadaPessoa.cnpj}
                                Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")} 
                                Valor de imposto a ser pago: {metodoPj.PagarImposto(cadaPessoa.rendimento).ToString("C")}
                                ");

                                Console.WriteLine("Aperte ENTER para continuar.");
                                Console.ReadLine();

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(3000);
                        }

                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida! Por favor, digite um número entre as opções disponíveis.");
                        Thread.Sleep(3000);
                        break;
                }


            } while (opcaoPj != "0");


            // PessoaJuridica metodoPj = new PessoaJuridica();
            // PessoaJuridica novaPj = new PessoaJuridica();
            // Endereco endPj = new Endereco();

            // novaPj.nome = "Nome da empresa";
            // novaPj.rendimento = 50000.5f;
            // novaPj.razaoSocial = "Nome jurídico da empresa";
            // novaPj.Cnpj = "00.000.000/0001-00";
            // novaPj.endereco = endPj;

            // endPj.logradouro = "Rua Finlândia";
            // endPj.numero = 360;
            // endPj.complemento = "andar 5";
            // endPj.enderecoComercial = true;

            // Console.Clear();
            // Console.WriteLine(@$"
            // Nome: {novaPj.nome}
            // Razão Social: {novaPj.razaoSocial}
            // CNPJ: {novaPj.Cnpj}
            // CHPJ válido: {metodoPj.ValidarCnpj(novaPj.Cnpj)}
            // Endereço: {novaPj.endereco.logradouro}, {novaPj.endereco.numero}
            // Rendimento: {novaPj.rendimento.ToString("C")} 
            // Valor de imposto a ser pago: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
            // ");

            // Console.WriteLine(metodoPj.ValidarCnpj("00000000000100"));

            // Console.WriteLine("Aperte ENTER para continuar.");
            // Console.ReadLine();

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