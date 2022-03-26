//Iremos criar as instâncias dos objetos. As classes são os modelos, e os objetos são criados com base nesses modelos. Daremos "ctrl + ." no tipo de objeto (o objeto "PessoaFisica") para fazer o "using".

using CadastroPessoasClientLab.classes;

//tipo de dado + nome ("pf") + = + new + tipo de dado + (); significa que dentro do objeto "pf" do tipo "PessoaFisica" está sendo criada uma nova instância desse mesmo tipo.
PessoaFisica pf = new PessoaFisica();

//atribuição do valor
pf.Nome = "Adriano"; //foi salvo o valor "Adriano" no atributo "nome"
pf.Rendimento = 10000.5f; //é preciso colocar o "f" após o numero decimal para converter em float, pois o sistema automaticamente entende decimal como double

Console.WriteLine(pf.Nome); //será escrito no console o valor que está salvo em "pf"

//atalho para Console.WriteLine(): "cwl"

Console.WriteLine($"Nome: {pf.Nome} Rendimento: {pf.Rendimento}"); //interpolação
Console.WriteLine("Nome: " + pf.Nome + " Rendimento: " + pf.Rendimento); //concatenação

