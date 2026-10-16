using LibraryManagement.Domain;

namespace LibraryManagement.Application

{

    public class BookService : IBookService

    {

        public List<BookInfo> GetAllBooks()

        {

            return new List<BookInfo>

            {

                new BookInfo { Id = 1, Title = "Science" },

                new BookInfo { Id = 2, Title = "Programming" }

            };

        }

        public BookInfo? GetBookById(int id)

        {

            return GetAllBooks()

                .FirstOrDefault(b => b.Id == id);

        }

    }

}