using Microsoft.AspNetCore.Mvc.RazorPages;
using wood.Models;

namespace wood.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public List<BookViewModel> NewBooks { get; set; } = new();
    public List<BookViewModel> BestSellers { get; set; } = new();
    public List<BookViewModel> DiscountedBooks { get; set; } = new();

    public void OnGet()
    {
        NewBooks = new List<BookViewModel>
        {
            new() { Id = 1, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Price = 899, OldPrice = 1200, Discount = 25, ImageUrl = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=300&h=400&fit=crop", IsNew = true },
            new() { Id = 2, Title = "1984", Author = "Джордж Оруэлл", Price = 750, OldPrice = 950, Discount = 21, ImageUrl = "https://images.unsplash.com/photo-1512820790803-83ca734da794?w=300&h=400&fit=crop", IsNew = true },
            new() { Id = 3, Title = "Преступление и наказание", Author = "Федор Достоевский", Price = 1100, OldPrice = null, Discount = 0, ImageUrl = "https://images.unsplash.com/photo-1543002588-bfa74002ed7e?w=300&h=400&fit=crop", IsNew = true },
            new() { Id = 4, Title = "Война и мир", Author = "Лев Толстой", Price = 1500, OldPrice = 1800, Discount = 17, ImageUrl = "https://images.unsplash.com/photo-1524995997946-a1c2e315a42f?w=300&h=400&fit=crop", IsNew = true },
            new() { Id = 5, Title = "Анна Каренина", Author = "Лев Толстой", Price = 950, OldPrice = null, Discount = 0, ImageUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765?w=300&h=400&fit=crop", IsNew = true },
            new() { Id = 6, Title = "Идиот", Author = "Федор Достоевский", Price = 890, OldPrice = 1100, Discount = 19, ImageUrl = "https://images.unsplash.com/photo-1481627834876-b7833e8f5570?w=300&h=400&fit=crop", IsNew = true }
        };
        
        BestSellers = new List<BookViewModel>
        {
            new() { Id = 7, Title = "Гарри Поттер и философский камень", Author = "Дж.К. Роулинг", Price = 1200, OldPrice = null, Discount = 0, ImageUrl = "https://images.unsplash.com/photo-1621351183012-e2f9972dd9bf?w=300&h=400&fit=crop", IsBestseller = true },
            new() { Id = 8, Title = "Маленький принц", Author = "Антуан де Сент-Экзюпери", Price = 650, OldPrice = 800, Discount = 19, ImageUrl = "https://images.unsplash.com/photo-1589998059171-988d887df646?w=300&h=400&fit=crop", IsBestseller = true },
            new() { Id = 9, Title = "Алхимик", Author = "Пауло Коэльо", Price = 780, OldPrice = null, Discount = 0, ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?w=300&h=400&fit=crop", IsBestseller = true },
            new() { Id = 10, Title = "Три товарища", Author = "Эрих Мария Ремарк", Price = 850, OldPrice = 1000, Discount = 15, ImageUrl = "https://images.unsplash.com/photo-1519682337058-a94d519337bc?w=300&h=400&fit=crop", IsBestseller = true }
        };

        // Скидки
        DiscountedBooks = new List<BookViewModel>
        {
            new() { Id = 15, Title = "Атлант расправил плечи", Author = "Айн Рэнд", Price = 1100, OldPrice = 1600, Discount = 31, ImageUrl = "https://images.unsplash.com/photo-1524995997946-a1c2e315a42f?w=300&h=400&fit=crop" },
            new() { Id = 16, Title = "Процесс", Author = "Франц Кафка", Price = 650, OldPrice = 900, Discount = 28, ImageUrl = "https://images.unsplash.com/photo-1532012197267-da84d127e765?w=300&h=400&fit=crop" },
            new() { Id = 17, Title = "Шантарам", Author = "Грегори Дэвид Робертс", Price = 980, OldPrice = 1400, Discount = 30, ImageUrl = "https://images.unsplash.com/photo-1481627834876-b7833e8f5570?w=300&h=400&fit=crop" },
            new() { Id = 18, Title = "Сто лет одиночества", Author = "Габриэль Гарсиа Маркес", Price = 850, OldPrice = 1200, Discount = 29, ImageUrl = "https://images.unsplash.com/photo-1621351183012-e2f9972dd9bf?w=300&h=400&fit=crop" }
        };
    }
}

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Price { get; set; }
    public int? OldPrice { get; set; }
    public int Discount { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsNew { get; set; }
    public bool IsBestseller { get; set; }
    public bool IsFavorite { get; set; }
}
