using LibraryManagement.Domain.Models;

namespace LibraryManagement.Infrastructure.Repositories;

public interface IBookRepository { Task<IEnumerable<Book>> GetAllAsync(); Task<Book?> GetByUuidAsync(string uuid); Task AddAsync(Book value); Task UpdateAsync(Book value); Task DeleteAsync(string uuid); Task<bool> HasBorrowingsAsync(int id); }
public interface ICategoryRepository { Task<IEnumerable<Category>> GetAllAsync(); Task<Category?> GetByUuidAsync(string uuid); Task AddAsync(Category value); Task UpdateAsync(Category value); Task DeleteAsync(string uuid); Task<bool> HasBooksAsync(int id); }
public interface ICustomerRepository { Task<IEnumerable<Customer>> GetAllAsync(); Task<Customer?> GetByUuidAsync(string uuid); Task AddAsync(Customer value); Task UpdateAsync(Customer value); Task DeleteAsync(string uuid); Task<bool> HasBorrowingsAsync(int id); }
public interface IBorrowingRepository { Task<IEnumerable<Borrowing>> GetAllAsync(); Task<Borrowing?> GetByUuidAsync(string uuid); Task AddAsync(Borrowing value); Task UpdateAsync(Borrowing value); Task DeleteAsync(string uuid); }
