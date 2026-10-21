using LibraryManagement.Domain.Models;

namespace LibraryManagement.Servisec.Base
{

    public interface IBookService

    {

        List<BookInfo> GetAllBooks();

        BookInfo? GetBookById(int id);

    }

}