using MinimalAPIDemo.Models;

namespace MinimalAPIDemo.Repository
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        Book? UpdateBook(Book book);
        List<Book> GetAllBooks();
        Book? GetBook(Guid id);
        void DeleteBook(Guid id);
    }
}
