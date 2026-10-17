using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Infrastructure.Repositories.Base;

public interface IUnitOfWork { IBookRepository Books { get; } ICategoryRepository Categories { get; } ICustomerRepository Customers { get; } IBorrowingRepository Borrowings { get; } }
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext db) { Books = new BookRepository(db); Categories = new CategoryRepository(db); Customers = new CustomerRepository(db); Borrowings = new BorrowingRepository(db); }
    public IBookRepository Books { get; }
    public ICategoryRepository Categories { get; }
    public ICustomerRepository Customers { get; }
    public IBorrowingRepository Borrowings { get; }
}
