namespace CadastroPessoasClientLab.interfaces
{
    public interface IPessoaJuridica
    {
         //método para validar o CNPJ;
         //o tipo de retorno será booleano, pois irá indicar se o CNPJ é válido ou não.
        bool ValidarCnpj (string cnpj);
    }
}