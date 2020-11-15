namespace Loja.Data.Collections
{
    public class Produtos
    {
        public Produtos(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}