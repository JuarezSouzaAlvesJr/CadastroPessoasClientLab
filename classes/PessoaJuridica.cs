using CadastroPessoasClientLab.interfaces;

using System.Text.RegularExpressions;

namespace CadastroPessoasClientLab.classes
{
    public class PessoaJuridica : Pessoa , IPessoaJuridica
    {
        public string? cnpj { get; set; }

        public string? razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv"; //o 'private' é para indicar que o atributo 'caminho' não poderá ser alterado de qualquer lugar
        
        

        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento*0.03f; //3% do rendimento;
            }
            else if (rendimento <= 6000)
            {
                return rendimento*0.05f; //5% do rendimento
            }
            else if (rendimento <= 10000)
            {
                return rendimento*0.07f; //7% do rendimento
            }
            else
            {
                return rendimento*0.09f; //acima de 10000, paga-se 9% do rendimento
            }
        }


        //formatos do CNPJ: XX.XXX.XXX/OOO1-XX (18 caracteres) ou XXXXXXXX0001XX (14 caracteres)
        public bool ValidarCnpj(string cnpj)
        {
            //Regex para verificar o formato de uma string. Damos "ctrl + ." para adicionar o using. Utilizamos o operador bitwise (|), equivalente a "ou", para fazer a comparação com os possíveis formatos do CNPJ.
            //Toda essa comparação retorna um booleano (true ou false). Por isso, foi colocado dentro do 'if'.
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11, 4) == "0001") //pegará os 4 caracteres após o 11º e verificará se é igual a 0001
                    {
                        return true;
                    }   

                } else if (cnpj.Length == 14)
                {
                    if (cnpj.Substring(8, 4) == "0001") //pegará os 4 caracteres após o 8º e verificará se é igual a 0001
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }

        //Método para inserção de dados no arquivo csv.
        public void Inserir(PessoaJuridica pj){

            //Primeiro, fazemos a verificação.
            VerificarPastaArquivo(caminho);

            //Agora, é preciso transformar o objeto em string, pois não é possível inserir objeto num arquivo de texto ou csv.

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};

            //Por fim, será salvo dentro do arquivo.
            File.AppendAllLines(caminho, pjString); //Os argumentos são 'caminho + conteúdo'.

        }

        //Método de leitura do arquivo csv. Para isso, pegamos o conteúdo salvo na string e o transformamos em objeto. O retorno desse método será uma lista com o conteúdo presente no objeto 'PessoaJuridica'.
        public List<PessoaJuridica> LerArquivo(){

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                //Um novo objeto para salvar os atributos.
                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                //Agora, só falta adicionar esse objeto na lista "listaPj".
                listaPj.Add(cadaPj);
            }

            return listaPj;
        }

    }
}