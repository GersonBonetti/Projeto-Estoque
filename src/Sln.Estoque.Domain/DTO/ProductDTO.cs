using Sln.Estoque.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sln.Estoque.Domain.DTO
{
    public class ProductDTO
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Código")]
        public string codigoProduto { get; set; }

        [MaxLength(30, ErrorMessage = "O nome do produto precisa ter menos de 30 caracteres")]
        [DisplayName("Nome")]
        public string nome { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
		[DisplayName("Qtd")]
        public int quantidade { get; set; }

		[Range(0.01, int.MaxValue, ErrorMessage = "O preço precisa ser maior que zero.")]
		[DisplayName("Preço")]
        public decimal preco { get; set; }

        [DisplayName("Categoria")]
        public int categoryId { get; set; }

		[DisplayName("Última Atualização")]
		public DateTime horaAtualizada { get; set; }

		public virtual CategoryDTO? category { get; set; }

        public Product mapToEntity()
        {
            return new Product
            {
                Id = id,
                CodigoProduto = codigoProduto,
                Nome = nome,
                Quantidade = quantidade,
                Preco = preco,
                CategoryId = categoryId,
				HoraAtualizada = horaAtualizada
			};
        }

        public ProductDTO mapToDTO(Product product)
        {
            return new ProductDTO()
            {
                id = product.Id,
                codigoProduto = product.CodigoProduto,
                nome = product.Nome,
                quantidade = product.Quantidade,
                preco = product.Preco,
                categoryId = product.CategoryId,
				horaAtualizada = product.HoraAtualizada,
				category = new CategoryDTO
				{
					id = product.CategoryId,
					name = product.Nome
				}
			};
        }
    }
}