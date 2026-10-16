using LibraryManagement.DTOs;

namespace LibraryManagement.Repositories

{

    public interface IBookRepository

    {

        List<BookDTO> GetAll();

        BookDTO? GetById(int id);

        void Add(BookDTO book);

        void Update(BookDTO book);

        void Delete(int id);

    }

}