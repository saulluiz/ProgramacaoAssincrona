public class AuxFunctions
{
    public static void RealizarOperacao(int op, string nome, string sobrenome)
{   //codigo de execucao pesada
    Console.WriteLine($"Iniciando Operacao {op}...");
    for (int i = 0; i < 1000000000; i++)
    {
        var p = new Pessoa(nome, sobrenome, new DateTime(), 35);



    }
    Console.WriteLine($"Finalizando Operacao {op}...");

}

internal class Pessoa
{
    private string nome;
    private string sobrenome;
    private DateTime dateTime;
    private int idade;

    public Pessoa(string nome, string sobrenome, DateTime dateTime, int idade)
    {
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.dateTime = dateTime;
        this.idade = idade;
    }
}
}