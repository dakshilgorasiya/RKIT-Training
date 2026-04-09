using DataGridFinalDemoAPI.Repositories;
using System.Net;

namespace DataGridFinalDemoAPI.DTO
{
    public class PaginationResponse
    {
        public int TotalCount { get; set; }
        public List<Sale_Record> Data { get; set; }
    }
}
