using LibraryManagement.Application.DTOs;

namespace LibraryManagement.Application.Services.Base;

public interface IBookService { Task<IEnumerable<BookDto>> GetAllAsync(); Task<BookDto?> GetDetailsAsync(string uuid); Task<BookUpdateDto?> GetForUpdateAsync(string uuid); Task<IEnumerable<CategoryDto>> GetCategoriesAsync(); Task AddAsync(BookCreateDto dto); Task UpdateAsync(BookUpdateDto dto); Task DeleteAsync(string uuid); }
public interface ICategoryService { Task<IEnumerable<CategoryDto>> GetAllAsync(); Task<CategoryDto?> GetDetailsAsync(string uuid); Task<CategoryUpdateDto?> GetForUpdateAsync(string uuid); Task AddAsync(CategoryCreateDto dto); Task UpdateAsync(CategoryUpdateDto dto); Task DeleteAsync(string uuid); }
public interface ICustomerService { Task<IEnumerable<CustomerDto>> GetAllAsync(); Task<CustomerDto?> GetDetailsAsync(string uuid); Task<CustomerUpdateDto?> GetForUpdateAsync(string uuid); Task AddAsync(CustomerCreateDto dto); Task UpdateAsync(CustomerUpdateDto dto); Task DeleteAsync(string uuid); }
public interface IBorrowingService { Task<IEnumerable<BorrowingDto>> GetAllAsync(); Task<BorrowingDto?> GetDetailsAsync(string uuid); Task<BorrowingUpdateDto?> GetForUpdateAsync(string uuid); Task<IEnumerable<BookDto>> GetBooksAsync(); Task<IEnumerable<CustomerDto>> GetCustomersAsync(); Task AddAsync(BorrowingCreateDto dto); Task UpdateAsync(BorrowingUpdateDto dto); Task DeleteAsync(string uuid); }
