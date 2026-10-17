using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Application.DTOs;

public class BookDto { public int Id { get; set; } public string Uuid { get; set; } = string.Empty; public string Title { get; set; } = string.Empty; public string Author { get; set; } = string.Empty; public decimal Price { get; set; } public int CategoryId { get; set; } public string CategoryName { get; set; } = string.Empty; }
public class BookCreateDto { [Required] public string Title { get; set; } = string.Empty; [Required] public string Author { get; set; } = string.Empty; [Range(0, double.MaxValue)] public decimal Price { get; set; } [Range(1, int.MaxValue)] public int CategoryId { get; set; } }
public class BookUpdateDto : BookCreateDto { public string Uuid { get; set; } = string.Empty; }

public class CategoryDto { public int Id { get; set; } public string Uuid { get; set; } = string.Empty; public string Name { get; set; } = string.Empty; }
public class CategoryCreateDto { [Required] public string Name { get; set; } = string.Empty; }
public class CategoryUpdateDto : CategoryCreateDto { public string Uuid { get; set; } = string.Empty; }

public class CustomerDto { public int Id { get; set; } public string Uuid { get; set; } = string.Empty; public string Name { get; set; } = string.Empty; public string Email { get; set; } = string.Empty; public string Phone { get; set; } = string.Empty; }
public class CustomerCreateDto { [Required] public string Name { get; set; } = string.Empty; [Required, EmailAddress] public string Email { get; set; } = string.Empty; [Required] public string Phone { get; set; } = string.Empty; }
public class CustomerUpdateDto : CustomerCreateDto { public string Uuid { get; set; } = string.Empty; }

public class BorrowingDto { public int Id { get; set; } public string Uuid { get; set; } = string.Empty; public int CustomerId { get; set; } public string CustomerName { get; set; } = string.Empty; public int BookId { get; set; } public string BookTitle { get; set; } = string.Empty; public DateTime BorrowDate { get; set; } public DateTime ReturnDate { get; set; } }
public class BorrowingCreateDto { [Range(1, int.MaxValue)] public int CustomerId { get; set; } [Range(1, int.MaxValue)] public int BookId { get; set; } [DataType(DataType.Date)] public DateTime BorrowDate { get; set; } [DataType(DataType.Date)] public DateTime ReturnDate { get; set; } }
public class BorrowingUpdateDto : BorrowingCreateDto { public string Uuid { get; set; } = string.Empty; }
