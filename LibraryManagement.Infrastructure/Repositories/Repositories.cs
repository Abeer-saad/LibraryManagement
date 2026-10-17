using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories;

public class BookRepository(ApplicationDbContext db) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync() => await db.Books.Include(x => x.Category).ToListAsync();
    public Task<Book?> GetByUuidAsync(string uuid) => db.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.Uuid == uuid);
    public async Task AddAsync(Book value) { db.Books.Add(value); await db.SaveChangesAsync(); }
    public async Task UpdateAsync(Book value) { db.Books.Update(value); await db.SaveChangesAsync(); }
    public async Task DeleteAsync(string uuid) { var x = await db.Books.FirstOrDefaultAsync(x => x.Uuid == uuid); if (x is not null) { db.Books.Remove(x); await db.SaveChangesAsync(); } }
    public Task<bool> HasBorrowingsAsync(int id) => db.Borrowings.AnyAsync(x => x.BookId == id);
}
public class CategoryRepository(ApplicationDbContext db) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync() => await db.Categories.ToListAsync();
    public Task<Category?> GetByUuidAsync(string uuid) => db.Categories.FirstOrDefaultAsync(x => x.Uuid == uuid);
    public async Task AddAsync(Category value) { db.Categories.Add(value); await db.SaveChangesAsync(); }
    public async Task UpdateAsync(Category value) { db.Categories.Update(value); await db.SaveChangesAsync(); }
    public async Task DeleteAsync(string uuid) { var x = await db.Categories.FirstOrDefaultAsync(x => x.Uuid == uuid); if (x is not null) { db.Categories.Remove(x); await db.SaveChangesAsync(); } }
    public Task<bool> HasBooksAsync(int id) => db.Books.AnyAsync(x => x.CategoryId == id);
}
public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>> GetAllAsync() => await db.Customers.ToListAsync();
    public Task<Customer?> GetByUuidAsync(string uuid) => db.Customers.FirstOrDefaultAsync(x => x.Uuid == uuid);
    public async Task AddAsync(Customer value) { db.Customers.Add(value); await db.SaveChangesAsync(); }
    public async Task UpdateAsync(Customer value) { db.Customers.Update(value); await db.SaveChangesAsync(); }
    public async Task DeleteAsync(string uuid) { var x = await db.Customers.FirstOrDefaultAsync(x => x.Uuid == uuid); if (x is not null) { db.Customers.Remove(x); await db.SaveChangesAsync(); } }
    public Task<bool> HasBorrowingsAsync(int id) => db.Borrowings.AnyAsync(x => x.CustomerId == id);
}
public class BorrowingRepository(ApplicationDbContext db) : IBorrowingRepository
{
    public async Task<IEnumerable<Borrowing>> GetAllAsync() => await db.Borrowings.Include(x => x.Customer).Include(x => x.Book).ToListAsync();
    public Task<Borrowing?> GetByUuidAsync(string uuid) => db.Borrowings.Include(x => x.Customer).Include(x => x.Book).FirstOrDefaultAsync(x => x.Uuid == uuid);
    public async Task AddAsync(Borrowing value) { db.Borrowings.Add(value); await db.SaveChangesAsync(); }
    public async Task UpdateAsync(Borrowing value) { db.Borrowings.Update(value); await db.SaveChangesAsync(); }
    public async Task DeleteAsync(string uuid) { var x = await db.Borrowings.FirstOrDefaultAsync(x => x.Uuid == uuid); if (x is not null) { db.Borrowings.Remove(x); await db.SaveChangesAsync(); } }
}
