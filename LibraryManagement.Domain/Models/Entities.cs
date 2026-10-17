using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Domain.Models;

[Index(nameof(Uuid), IsUnique = true)]
public class Book
{
    public int Id { get; set; }
    public string Uuid { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Borrowing> Borrowings { get; set; } = [];
}

[Index(nameof(Uuid), IsUnique = true)]
public class Category
{
    public int Id { get; set; }
    public string Uuid { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public ICollection<Book> Books { get; set; } = [];
}

[Index(nameof(Uuid), IsUnique = true)]
public class Customer
{
    public int Id { get; set; }
    public string Uuid { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<Borrowing> Borrowings { get; set; } = [];
}

[Index(nameof(Uuid), IsUnique = true)]
public class Borrowing
{
    public int Id { get; set; }
    public string Uuid { get; set; } = Guid.NewGuid().ToString();
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
