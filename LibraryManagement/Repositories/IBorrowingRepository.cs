using LibraryManagement.DTOs;

namespace LibraryManagement.Repositories

{

    public interface IBorrowingRepository

    {

        List<BorrowingDTO> GetAll();

        BorrowingDTO? GetById(int id);

        void Add(BorrowingDTO borrowing);

        void Update(BorrowingDTO borrowing);

        void Delete(int id);

    }

}