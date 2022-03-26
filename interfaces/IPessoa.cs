//esse arquivo é para conter apenas os métodos que as classes terão, as ações
//a função da interface é obrigar a classe a implementar o método contido na interfacce

namespace CadastroPessoasClientLab.interfaces
{
    public interface IPessoa
    {
         //primeiro item do método: tipo de retorno; segundo item: nome do método; terceiro item: os argumentos, que vão dentro dos parênteses
         //método para pagar impostos
         //no caso, o retorno será o quanto pagará de imposto, então o tipo de retorno é "float", número decimal; o argumento será o rendimento da pessoa, um número decimal também.
        float PagarImposto (float rendimento);

    }
}