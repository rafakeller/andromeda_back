using andromeda_back.Models;
using System.Xml.Linq;

namespace andromeda_back.Services
{
    public class ProdutosService
    {
        static List<Produto> Produtos { get; }
        static int nextId = 3;
        static ProdutoService()
        {
            Produtos = new List<Produto>
        {
            new Produto { Id = 1, Name = "Classic Italian", IsTimed = false },
            new Produto { Id = 2, Name = "Veggie", IsTimed = true }
        };
        }

        public static List<Produto> GetAll() => Produtos;

        public static Produto? Get(int id) => Produtos.FirstOrDefault(p => p.Id == id);

        public static void Add(Produto produto)
        {
            produto.Id = nextId++;
            Produtos.Add(produto);
        }

        public static void Delete(int id)
        {
            var produto = Get(id);
            if (produto is null)
                return;

            Produtos.Remove(produto);
        }

        public static void Update(Produto produto)
        {
            var index = Produtos.FindIndex(p => p.Id == produto.Id);
            if (index == -1)
                return;

            Produtos[index] = produto;
        }
    }
}
