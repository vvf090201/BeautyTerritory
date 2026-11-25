using Lab4_MVC_App.Models;

namespace Lab4_MVC_App.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Сыворотка для сияния", Brand = "Aura", Category = "Уход", Price = 3500, Description = "Гиалуроновая кислота и витамин С.", Emoji = "🧴" },
            new Product { Id = 2, Name = "Помада Velvet", Brand = "Lux", Category = "Макияж", Price = 1800, Description = "Матовый финиш, оттенок пыльная роза.", Emoji = "💄" },
            new Product { Id = 3, Name = "Парфюм Sweet Peony", Brand = "Bloom", Category = "Парфюм", Price = 5200, Description = "Аромат пиона и белого мускуса.", Emoji = "🌸" }
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Brand = product.Brand;
                existing.Category = product.Category;
                existing.Price = product.Price;
                existing.Description = product.Description;
                existing.Emoji = product.Emoji;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null) _products.Remove(product);
        }
    }
}