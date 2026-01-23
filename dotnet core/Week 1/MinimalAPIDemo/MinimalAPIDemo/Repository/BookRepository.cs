using MinimalAPIDemo.Models;

namespace MinimalAPIDemo.Repository
{
    public class BookRepository: IBookRepository
    {
        public List<Book> Books { get; set; }

        public BookRepository()
        {
            Books = new List<Book>();
        }

        public Book AddBook(Book book)
        {
            Books.Add(book);
            return book;
        }

        public void DeleteBook(Guid id)
        {
            Books.RemoveAll(b => b.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public Book? GetBook(Guid id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public Book? UpdateBook(Book book)
        {
            Book? existing = Books.FirstOrDefault(book => book.Id == book.Id);
            if(existing != null)
            {
                existing.Id = book.Id;
                existing.Title = book.Title;
                existing.Content = book.Content;
                existing.Author = book.Author;

                return existing;
            }
            else
            {
                return null;
            }
        }
    }
}
