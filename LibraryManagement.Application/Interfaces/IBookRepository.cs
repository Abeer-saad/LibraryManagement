using LibraryManagement.Application.DTOs;

using System.Collections.Generic;

namespace LibraryManagement.Application.Interfaces

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