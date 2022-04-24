/*Os atributos da classe "pessoaFisica" são CPF e data de nascimento.
É preciso fazer a herança da interface "IPessoaFisica" e da classe mãe (a classe "Pessoa"). A classe base deve vir antes da interface. Só usamos um símbolo de herança (o dois-pontos) e separamos com vírgula os arquivos de onde foi feita a herança.

Tudo isso deve ser feito também na "pessoaJuridica"
*/

using CadastroPessoasClientLab.interfaces;

namespace CadastroPessoasClientLab.classes
{
    public class PessoaFisica : Pessoa , IPessoaFisica
    {
        public string? cpf { get; set; }

        public DateTime dataNasc { get; set; }


        //override = sobrescrito
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return rendimento*0.02f; //2% do rendimento
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                return rendimento*0.035f; //3,5% do rendimento
            }
            else
            {
                return rendimento*0.05f; //acima de 6000, paga-se 5% do rendimento
            }
        }


        //Criação do método de validação da data de nascimento. Apagamos o "throw new NotImplementedException();"
        public bool ValidarDataNasc(DateTime dataNasc) //Esse método deve retornar se a idade é maior que 18 anos ou não, ou seja, true (verdadeiro) ou false (falso). Por isso, usamos o "bool".
        {
            DateTime dataAtual = DateTime.Today; //Criamos a variável "dataAtual" para armazenar a data do sistema no momento em que usuário fará a inserção dos dados.
            
            //A diferença entre as datas retornará um valor em dias, meses e anos, ou seja, o resultado será do tipo DateTime. Iremos converter o resultado para dias apenas, usando o recurso 'TotalDays'. Depois, dividiremos esse valor por 365 (número de dias de um ano). O resultado será um número decimal que pode ter várias casas decimais. Então, iremos armazenar numa variável do tipo 'double'
            double anos = (dataAtual - dataNasc).TotalDays / 365;
            
            Console.WriteLine($"{anos}");
            

            if (anos >= 18) 
            {
                return true;
            } 
            
            return false;
            
        }


        //O polimorfismo permite a existência de dois métodos com o mesmo nome desde que eles contenham argumentos diferentes. Vamos criar outro método de validação da data de nascimento, mas com um argumento do tipo string caso o usuário insita o dato que não esteja no formato de data.

        public bool ValidarDataNasc(string dataNasc){

            //criaremos uma variável do tipo DateTime para armazenar o resultado da conversão do dado do tipo string
            DateTime dataConvertida;

            // "DateTime.TryParse(dataNasc, out dataConvertida)" irá transformar o dado do tipo string em um dado do tipo dateTime
            //Colocamos esse método dentro do "if" porque ele retorna um resultado booleano. Iremos avaliar o resultado dessa tentativa de conversão. Se foi possível fazer a conversão em um dado dateTime, iremos aplicar a mesma lógica feita anteriormente para validar a data de nascimento. Então, co

            if (DateTime.TryParse(dataNasc, out dataConvertida)) 
            {
                // Se foi possível fazer a conversão em um dado dateTime, iremos aplicar a mesma lógica feita anteriormente para validar a data de nascimento. Então, aqui vai essa lógica:

                DateTime dataAtual = DateTime.Today; 

                double anos = (dataAtual - dataConvertida).TotalDays / 365;
            
                Console.WriteLine($"{anos}");

                if (anos >= 18 && anos < 120) 
                {
                return true;
                } 
            
                return false;
            }

            return false;
        }
    }
}

//para fazer o teste para mostrar o valor que aparece na variável "anos", inserimos "Console.WriteLine(anos)" e colocamos o tipo de retorno aqui só para atender ao tipo de método. Depois, indicamos o método 'ValidarDataNasc' no Program e inserimos uma data.