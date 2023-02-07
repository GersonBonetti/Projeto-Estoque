namespace Sln.Estoque.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CategoryId { get; set; }
        public DateTime HoraAtualizada { get; set; }
        public virtual Category? Category { get; set; }
    }
}
