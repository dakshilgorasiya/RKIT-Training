using Domain;
using Ingestion.Pipeline.DTO;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Extension
{
    /// <summary>
    /// Extension methods for processing collections of Book objects.
    /// </summary>
    public static class BookExtension
    {
        /// <summary>
        /// Used to count top N book by a specific key selector function.
        /// </summary>
        /// <param name="books">List of all books</param>
        /// <param name="keySelector">Function to calculate penalty by BookCondition enum</param>
        /// <param name="n">Top n will be returned</param>
        /// <returns>A List of BookSummary representing top n unique book with highest penalty</returns>
        public static List<BookSummary> TopBy(this IEnumerable<Book> books, Func<Book, int> keySelector, int n)
        {
            List<BookSummary> booksSummary = books
                .GroupBy(b => new { b.Id, b.Title, b.Author })  // Group by unique book properties
                .Select(b =>
                {
                    int totalPenalty = b.Sum(b => (int)keySelector(b)); // Calculate total penalty

                    totalPenalty = Math.Clamp(totalPenalty, 1, 100); // Clamp penalty between 1 and 100

                    return new BookSummary
                    {
                        Id = b.Key.Id,
                        Title = b.Key.Title,
                        Author = b.Key.Author,
                        TotalPenalty = totalPenalty
                    };
                })
                .OrderByDescending(b => b.TotalPenalty) // Sort by total penalty in descending order
                .Take(n) // Take the top n books
                .ToList();

            return booksSummary;
        }

        /// <summary>
        /// To count the number of books in each condition.
        /// </summary>
        /// <param name="books">List of all books</param>
        /// <returns>Dictionary of BookCondition, int representing total number of book by condition</returns>
        public static Dictionary<BookCondition, int> ToConditionCounts(this IEnumerable<Book> books)
        {
            Dictionary<BookCondition, int> conditionCounts = books
                .GroupBy(b => b.BookCondition)
                .ToDictionary(group => group.Key, group => group.Count());

            return conditionCounts;
        }

        /// <summary>
        /// A method to get penalty by BookCondition enum.
        /// </summary>
        /// <param name="book">Book object to find penalty</param>
        /// <returns>Penalty of book</returns>
        public static int GetPenalty(Book book)
        {
            int penalty;
            switch (book.BookCondition)
            {
                case BookCondition.New:
                    penalty = -1;
                    break;

                case BookCondition.Good:
                    penalty = 0;
                    break;

                case BookCondition.Worn:
                    penalty = 3;
                    break;

                case BookCondition.Damaged:
                    penalty = 10;
                    break;

                default:
                    penalty = 0;
                    break;

            }
            return penalty;
        }
    }
}
