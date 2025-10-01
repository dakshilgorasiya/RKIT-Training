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
    public static class BookExtension
    {
        public static List<BookSummary> TopBy(this IEnumerable<Book> books, Func<Book, int> keySelector, int n)
        {
            List<BookSummary> booksSummary = books
                .GroupBy(b => new { b.Id, b.Title, b.Author })
                .Select(b =>
                {
                    int totalPenalty = b.Sum(b => (int)keySelector(b));

                    totalPenalty = Math.Clamp(totalPenalty, 1, 100);

                    return new BookSummary
                    {
                        Id = b.Key.Id,
                        Title = b.Key.Title,
                        Author = b.Key.Author,
                        TotalPenalty = totalPenalty
                    };
                })
                .OrderByDescending(b => b.TotalPenalty)
                .Take(n)
                .ToList();

            return booksSummary;
        }

        public static Dictionary<BookCondition, int> ToConditionCounts(this IEnumerable<Book> books)
        {
            Dictionary<BookCondition, int> conditionCounts = books
                .GroupBy(b => b.BookCondition)
                .ToDictionary(group => group.Key, group => group.Count());

            return conditionCounts;
        }

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
