namespace Lab4_MVC_App.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // Уход, Макияж, Парфюм
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Emoji { get; set; } = "✨"; // Эмодзи для карточки
    }
}