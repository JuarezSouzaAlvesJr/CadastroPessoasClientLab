/*Arquivo para a criação dos atributos.
Tanto a classe "pessoaFisica" quanto "pessoaJuridica" tem os atributos nome, rendimento e endereço, então esses atributos são criados aqui, na classe mãe.
Essa é uma classe abstrata, pois serve apenas como base para a criação das classes "pessoaFisica" e "pessoaJurídica". Ela não pode ser instanciada, ou seja, não é possível criar objetos para essa classe. Não é possível criar um objeto do tipo pessoa aqui.*/

using CadastroPessoasClientLab.interfaces;

namespace CadastroPessoasClientLab.classes
{
    public abstract class Pessoa : IPessoa //herança da interface "Ipessoa" (ctrl + . para reconhecer o arquivo que está em outra pasta; depois ctrl + . de novo para implementar a interface)
    {
        //primeiro, o modificador de acesso (no caso, é público); depois o tipo do atributo (no caso, o nome é uma string); por fim, o nome do atributo (no caso, "nome"). 
        //O "get; set" é opcional, mas em alguns casos é importante colocar para determinar se o atributo poderá ser modificado ou não, por exemplo, o saldo pode ser consultado (get), mas não modificado (set), nesse caso colocaríamos "private set".
        //o ponto de interrogação serve para indicar que a propriedade "nome" pode ter valor nulo, ou seja, nós não precisamos necessariamente atribuir um valor para ela para fazer a execução. Esse pode ser um recurso necessário no tipo string.
        public string? nome { get; set; }

        public float rendimento { get; set; }

        //atalho para criar a propriedade: "prop" (creats a property)
    
        public Endereco? endereco { get; set; }


        //O método "pagarImposto" é abstrato, pois a lógica dele só será feita nas classes "filhas" (a lógica ficará contida na classe "pessoaFisica" e "pessoaJuridica). Logo, esse método não terá um corpo.
        public abstract float PagarImposto(float rendimento);

        public void VerificarPastaArquivo(string caminho){

            string pasta = caminho.Split("/")[0]; //Apenas o nome da pasta ('Database') será salva na string 'pasta'. A barra (/) é o separador e o 0 indica a posição dessa pasta no array 'Database/PessoaJuridica.csv'

            //Usamos o IF para verificar a existência da pasta.
            if (!Directory.Exists(pasta)) //O ponto de exclamação inverte, então estamos verificando se a pasta NÃO existe.
            {
                Directory.CreateDirectory(pasta); //A pasta será criada.
            }

            //Fazemos o mesmo para o arquivo. Mas usaremos o 'using' para o fechamento do arquivo após a criação.
            if (!File.Exists(caminho))
            {
                using (File.Create(caminho)){}
            }
        }
    }
}