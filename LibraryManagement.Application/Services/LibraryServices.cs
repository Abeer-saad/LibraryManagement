using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.Services.Base;
using LibraryManagement.Domain.Models;
using LibraryManagement.Infrastructure.Repositories.Base;

namespace LibraryManagement.Application.Services;

public class BookService(IUnitOfWork uow) : IBookService
{
    static BookDto Map(Book x) => new() { Id=x.Id,Uuid=x.Uuid,Title=x.Title,Author=x.Author,Price=x.Price,CategoryId=x.CategoryId,CategoryName=x.Category?.Name ?? "" };
    public async Task<IEnumerable<BookDto>> GetAllAsync() => (await uow.Books.GetAllAsync()).Select(Map);
    public async Task<BookDto?> GetDetailsAsync(string uuid) { var x=await uow.Books.GetByUuidAsync(uuid); return x is null?null:Map(x); }
    public async Task<BookUpdateDto?> GetForUpdateAsync(string uuid) { var x=await uow.Books.GetByUuidAsync(uuid); return x is null?null:new(){Uuid=x.Uuid,Title=x.Title,Author=x.Author,Price=x.Price,CategoryId=x.CategoryId}; }
    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync() => (await uow.Categories.GetAllAsync()).Select(x=>new CategoryDto{Id=x.Id,Uuid=x.Uuid,Name=x.Name});
    public Task AddAsync(BookCreateDto d)=>uow.Books.AddAsync(new(){Title=d.Title,Author=d.Author,Price=d.Price,CategoryId=d.CategoryId});
    public async Task UpdateAsync(BookUpdateDto d){var x=await uow.Books.GetByUuidAsync(d.Uuid)??throw new KeyNotFoundException("Book not found"); x.Title=d.Title;x.Author=d.Author;x.Price=d.Price;x.CategoryId=d.CategoryId;await uow.Books.UpdateAsync(x);}
    public async Task DeleteAsync(string uuid){var x=await uow.Books.GetByUuidAsync(uuid)??throw new KeyNotFoundException("Book not found");if(await uow.Books.HasBorrowingsAsync(x.Id))throw new InvalidOperationException("Cannot delete this book because it has linked borrowings.");await uow.Books.DeleteAsync(uuid);}
}
public class CategoryService(IUnitOfWork uow) : ICategoryService
{
    static CategoryDto Map(Category x)=>new(){Id=x.Id,Uuid=x.Uuid,Name=x.Name};
    public async Task<IEnumerable<CategoryDto>> GetAllAsync()=>(await uow.Categories.GetAllAsync()).Select(Map);
    public async Task<CategoryDto?> GetDetailsAsync(string uuid){var x=await uow.Categories.GetByUuidAsync(uuid);return x is null?null:Map(x);}
    public async Task<CategoryUpdateDto?> GetForUpdateAsync(string uuid){var x=await uow.Categories.GetByUuidAsync(uuid);return x is null?null:new(){Uuid=x.Uuid,Name=x.Name};}
    public Task AddAsync(CategoryCreateDto d)=>uow.Categories.AddAsync(new(){Name=d.Name});
    public async Task UpdateAsync(CategoryUpdateDto d){var x=await uow.Categories.GetByUuidAsync(d.Uuid)??throw new KeyNotFoundException("Category not found");x.Name=d.Name;await uow.Categories.UpdateAsync(x);}
    public async Task DeleteAsync(string uuid){var x=await uow.Categories.GetByUuidAsync(uuid)??throw new KeyNotFoundException("Category not found");if(await uow.Categories.HasBooksAsync(x.Id))throw new InvalidOperationException("Cannot delete this category because it has linked books.");await uow.Categories.DeleteAsync(uuid);}
}
public class CustomerService(IUnitOfWork uow) : ICustomerService
{
    static CustomerDto Map(Customer x)=>new(){Id=x.Id,Uuid=x.Uuid,Name=x.Name,Email=x.Email,Phone=x.Phone};
    public async Task<IEnumerable<CustomerDto>> GetAllAsync()=>(await uow.Customers.GetAllAsync()).Select(Map);
    public async Task<CustomerDto?> GetDetailsAsync(string uuid){var x=await uow.Customers.GetByUuidAsync(uuid);return x is null?null:Map(x);}
    public async Task<CustomerUpdateDto?> GetForUpdateAsync(string uuid){var x=await uow.Customers.GetByUuidAsync(uuid);return x is null?null:new(){Uuid=x.Uuid,Name=x.Name,Email=x.Email,Phone=x.Phone};}
    public Task AddAsync(CustomerCreateDto d)=>uow.Customers.AddAsync(new(){Name=d.Name,Email=d.Email,Phone=d.Phone});
    public async Task UpdateAsync(CustomerUpdateDto d){var x=await uow.Customers.GetByUuidAsync(d.Uuid)??throw new KeyNotFoundException("Customer not found");x.Name=d.Name;x.Email=d.Email;x.Phone=d.Phone;await uow.Customers.UpdateAsync(x);}
    public async Task DeleteAsync(string uuid){var x=await uow.Customers.GetByUuidAsync(uuid)??throw new KeyNotFoundException("Customer not found");if(await uow.Customers.HasBorrowingsAsync(x.Id))throw new InvalidOperationException("Cannot delete this customer because they have linked borrowings.");await uow.Customers.DeleteAsync(uuid);}
}
public class BorrowingService(IUnitOfWork uow) : IBorrowingService
{
    static BorrowingDto Map(Borrowing x)=>new(){Id=x.Id,Uuid=x.Uuid,CustomerId=x.CustomerId,CustomerName=x.Customer?.Name??"",BookId=x.BookId,BookTitle=x.Book?.Title??"",BorrowDate=x.BorrowDate,ReturnDate=x.ReturnDate};
    public async Task<IEnumerable<BorrowingDto>> GetAllAsync()=>(await uow.Borrowings.GetAllAsync()).Select(Map);
    public async Task<BorrowingDto?> GetDetailsAsync(string uuid){var x=await uow.Borrowings.GetByUuidAsync(uuid);return x is null?null:Map(x);}
    public async Task<BorrowingUpdateDto?> GetForUpdateAsync(string uuid){var x=await uow.Borrowings.GetByUuidAsync(uuid);return x is null?null:new(){Uuid=x.Uuid,CustomerId=x.CustomerId,BookId=x.BookId,BorrowDate=x.BorrowDate,ReturnDate=x.ReturnDate};}
    public async Task<IEnumerable<BookDto>> GetBooksAsync()=>(await uow.Books.GetAllAsync()).Select(x=>new BookDto{Id=x.Id,Uuid=x.Uuid,Title=x.Title,Author=x.Author,Price=x.Price,CategoryId=x.CategoryId,CategoryName=x.Category?.Name??""});
    public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()=>(await uow.Customers.GetAllAsync()).Select(x=>new CustomerDto{Id=x.Id,Uuid=x.Uuid,Name=x.Name,Email=x.Email,Phone=x.Phone});
    static void Validate(DateTime borrow,DateTime ret){if(ret<borrow)throw new InvalidOperationException("Return date cannot be before borrow date.");}
    public Task AddAsync(BorrowingCreateDto d){Validate(d.BorrowDate,d.ReturnDate);return uow.Borrowings.AddAsync(new(){CustomerId=d.CustomerId,BookId=d.BookId,BorrowDate=d.BorrowDate,ReturnDate=d.ReturnDate});}
    public async Task UpdateAsync(BorrowingUpdateDto d){Validate(d.BorrowDate,d.ReturnDate);var x=await uow.Borrowings.GetByUuidAsync(d.Uuid)??throw new KeyNotFoundException("Borrowing not found");x.CustomerId=d.CustomerId;x.BookId=d.BookId;x.BorrowDate=d.BorrowDate;x.ReturnDate=d.ReturnDate;await uow.Borrowings.UpdateAsync(x);}
    public async Task DeleteAsync(string uuid){_ = await uow.Borrowings.GetByUuidAsync(uuid)??throw new KeyNotFoundException("Borrowing not found");await uow.Borrowings.DeleteAsync(uuid);}
}
