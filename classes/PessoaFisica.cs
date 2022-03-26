/*Os atributos da classe "pessoaFisica" são CPF e data de nascimento.
É preciso fazer a herança da interface "IPessoaFisica" e da classe mãe (a classe "Pessoa"). A classe base deve vir antes da interface. Só usamos um símbolo de herança (o dois-pontos) e separamos com vírgula os arquivos de onde foi feita a herança.

Tudo isso deve ser feito também na "pessoaJuridica"
*/

using CadastroPessoasClientLab.interfaces;

namespace CadastroPessoasClientLab.classes
{
    public class PessoaFisica : Pessoa , IPessoaFisica
    {
        public string? CPF { get; set; }

        public DateTime dataNasc { get; set; }


        //override = sobrescrito
        public override float PagarImposto(float rendimento)
        {
            throw new NotImplementedException();
        }

        public bool ValidarDataNasc(DateTime dataNasc)
        {
            throw new NotImplementedException();
        }
    }
}