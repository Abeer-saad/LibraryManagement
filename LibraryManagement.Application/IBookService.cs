using LibraryManagement.Domain;

namespace LibraryManagement.Application

{

    public interface IBookService

    {

        List<BookInfo> GetAllBooks();

        BookInfo? GetBookById(int id);

    }

}