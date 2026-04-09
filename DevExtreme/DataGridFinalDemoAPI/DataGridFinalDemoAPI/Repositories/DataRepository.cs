using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace DataGridFinalDemoAPI.Repositories
{
    public class DataRepository
    {
        public List<Sale_Record> Sale_Records { get; set; }
        string filePath = "./MOCK_DATA.json";
        public DataRepository() 
        {
            string data = "";

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }

                data = File.ReadAllText(filePath);

                Sale_Records = JsonConvert.DeserializeObject<List<Sale_Record>>(data);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found : " + filePath);
            }
        }
    }

    public class Sale_Record
    {
        public int Id { get; set; }
        public string? Product_Name { get; set; }
        public string? Product_Category { get; set; }
        public string? Customer_Name { get; set; }
        public DateTime? Sale_Date { get; set; }
        public int? Sale_Price { get; set; }
        public int? Discount { get; set; }
        public int? Quantity { get; set; }
        public Shipping_Address? Shipping_Address { get; set; }
        public string? Payment_Method { get; set; }
        public int? Review { get; set; }
    }

    public class Shipping_Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
