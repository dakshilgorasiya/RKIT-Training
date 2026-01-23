using Microsoft.AspNetCore.Mvc;
using MinimalAPIDemo.DTOs;
using MinimalAPIDemo.Models;
using MinimalAPIDemo.Repository;

namespace MinimalAPIDemo.Endpoints
{
    public class BookEndpoints
    {
        public static Book CreateBook([FromBody]CreateBookDTO bookDTO, [FromServices]IBookRepository bookRepository)
        {
            Book book = new Book
            {
                Id = Guid.NewGuid(),
                Title = bookDTO.Title,
                Content = bookDTO.Content,
                Author = bookDTO.Author,
            };

            bookRepository.AddBook(book);

            return book;
        }

        public static List<Book> GetAllBooks([FromServices]IBookRepository bookRepository)
        {
            return bookRepository.GetAllBooks();
        }

        public static Book UpdateBook([FromRoute]Guid id, [FromBody]UpdateBookDTO bookDTO, [FromServices]IBookRepository bookRepository)
        {
            Book book = new Book
            {
                Id = id,
                Title = bookDTO.Title,
                Content = bookDTO.Content,
                Author = bookDTO.Author,
            };

            bookRepository.AddBook(book);

            return book;
        }

        public static void DeleteBook([FromRoute]Guid id, [FromServices]IBookRepository bookRepository)
        {
            bookRepository.DeleteBook(id);
        }

        public static Book? GetBookById([FromRoute] Guid id, IBookRepository bookRepository)
        {
            return bookRepository.GetBook(id);
        }
    }
}
