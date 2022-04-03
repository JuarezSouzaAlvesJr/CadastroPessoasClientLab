namespace CadastroPessoasClientLab.interfaces
{
    public interface IPessoaFisica
    {
         //método para validar a data de nascimento;
         //o retorno deverá responder se a pessoa é maior de idade ou não, logo é um tipo de retorno booleano; o argumento será a data de nascimento.
         bool ValidarDataNasc (DateTime dataNasc);

         bool ValidarDataNasc(string dataNasc);
    }
}