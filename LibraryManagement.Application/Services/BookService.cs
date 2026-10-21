using LibraryManagement.Application.Interfaces;

using LibraryManagement.Domain.Models;
using LibraryManagement.Servisec.Base;

namespace LibraryManagement.Application.Services

{

    public class BookService : IBookService

    {

        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)

        {

            _repository = repository;

        }

        public List<BookInfo> GetAllBooks()

        {

            return _repository.GetAll()

                .Select(book => new BookInfo

                {

                    Id = book.Id,

                    Title = book.Title

                })

                .ToList();

        }

        public BookInfo? GetBookById(int id)

        {

            return GetAllBooks()

                .FirstOrDefault(b => b.Id == id);

        }

    }

}