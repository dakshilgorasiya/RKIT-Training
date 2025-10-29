namespace LinqPractise
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; } // Foreign Key to Author
        public List<int> GenreIds { get; set; } // Foreign Keys to Genre
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> odds = nums.Where(n => n % 2 == 1).ToList();
            Console.WriteLine(String.Join(", ", odds));


            List<string> strings = new List<string> { "apple", "banana", "cherry", "date", "fig", "grape" };
            List<int> lens = strings.Select(s => s.Length).ToList();
            Console.WriteLine(String.Join(", ", lens));




            // Sample Data Collections
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "J.R.R. Tolkien" },
                new Author { Id = 2, Name = "George Orwell" },
                new Author { Id = 3, Name = "J.K. Rowling" }
            };

            var genres = new List<Genre>
            {
                new Genre { Id = 101, Name = "Fantasy" },
                new Genre { Id = 102, Name = "Dystopian" },
                new Genre { Id = 103, Name = "Political Satire" },
                new Genre { Id = 104, Name = "Adventure" },
                new Genre { Id = 105, Name = "Young Adult" }
            };

            var books = new List<Book>
            {
                new Book { Id = 1, Title = "The Hobbit", PublicationYear = 1937, AuthorId = 1, GenreIds = new List<int> { 101, 104, 105 } },
                new Book { Id = 2, Title = "The Lord of the Rings", PublicationYear = 1954, AuthorId = 1, GenreIds = new List<int> { 101, 104 } },
                new Book { Id = 3, Title = "1984", PublicationYear = 1949, AuthorId = 2, GenreIds = new List<int> { 102, 103 } },
                new Book { Id = 4, Title = "Animal Farm", PublicationYear = 1945, AuthorId = 2, GenreIds = new List<int> { 103 } },
                new Book { Id = 5, Title = "Harry Potter and the Sorcerer's Stone", PublicationYear = 1997, AuthorId = 3, GenreIds = new List<int> { 101, 105 } }
            };



            // Books after 1950

            // Query Syntax
            var booksAfter1950Query = from b in books
                                      join a in authors on b.AuthorId equals a.Id
                                      where b.PublicationYear > 1950
                                      orderby b.PublicationYear
                                      select new
                                      {
                                          BookTitle = b.Title,
                                          AuthorName = a.Name,
                                      };

            // Method Syntax
            var booksAfter1950Method = books.Where(b => b.PublicationYear > 1950)
                                            .Join(authors,
                                                b => b.AuthorId,
                                                a => a.Id,
                                                (b, a) => new
                                                {
                                                    BookTitle = b.Title,
                                                    AuthorName = a.Name,
                                                    Year = b.PublicationYear
                                                })
                                            .OrderBy(result => result.Year);




            // Find number of book each author has written
            var authorBookCountsQuery = from b in books
                                        join a in authors on b.AuthorId equals a.Id
                                        group b by a.Name into authorGroup
                                        orderby authorGroup.Count() descending
                                        select new
                                        {
                                            AuthorName = authorGroup.Key,
                                            BookCount = authorGroup.Count()
                                        };

            var authorBookCountMethod = books.GroupBy(b => b.AuthorId)
                                             .Select(g => new
                                             {
                                                 AuthorId = g.Key,
                                                 NumberOfBooks = g.Count()
                                             })
                                             .Join(authors,
                                                bookCount => bookCount.AuthorId,
                                                author => author.Id,
                                                (bookCount, author) => new
                                                {
                                                    AuthorName = author.Name,
                                                    BookCount = bookCount.NumberOfBooks
                                                })
                                             .OrderByDescending(result => result.BookCount);


            // Find all books in the "Fantasy" genre
            var fantasyBooksQuery = from b in books
                                    where (from gId in b.GenreIds
                                           join g in genres on gId equals g.Id
                                           where g.Name == "Fantasy"
                                           select g).Any()
                                    select b;


            var fantasyGenereId = genres.First(g => g.Name == "Fantasy").Id;
            var fantasyBooksMethod = books.Where(b => b.GenreIds.Contains(fantasyGenereId));




            // Create a report that shows each author's name along with a comma-separated string of their book titles.
            var authorBookListQuery = from a in authors
                                      let authorBooks = (from b in books
                                                         where b.AuthorId == a.Id
                                                         select b.Title)
                                      select new
                                      {
                                          AuthorName = a.Name,
                                          Books = string.Join(", ", authorBooks)
                                      };


            var authorBookListMethod = authors.Select(a => new
            {
                AuthorName = a.Name,
                Books = string.Join(", ",
                                                books.Where(b => b.AuthorId == a.Id)
                                                .Select(b => b.Title))
            });
        }
    }
}
