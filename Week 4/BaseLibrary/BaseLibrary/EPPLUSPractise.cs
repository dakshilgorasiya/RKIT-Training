using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    internal class EPPLUSPractise
    {
        static void Main(string[] args)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Dakshil");

            string filePath = "example.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);

            using(ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Add some text to cell A1
                worksheet.Cells["A1"].Value = "Product";
                worksheet.Cells["B1"].Value = "Price";
                worksheet.Cells["C1"].Value = "Quantity";

                // Add some data
                worksheet.Cells["A2"].Value = "Laptop";
                worksheet.Cells["B2"].Value = 1200.50;
                worksheet.Cells["C2"].Value = 5;

                worksheet.Cells["A3"].Value = "Mouse";
                worksheet.Cells["B3"].Value = 25.00;
                worksheet.Cells["C3"].Value = 20;

                // Formating
                worksheet.Cells["A1:C1"].Style.Font.Bold = true;
                worksheet.Cells["A:C"].AutoFitColumns();

                // Save the package
                package.Save();
            }

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];

                int startRow = workSheet.Dimension.Start.Row;
                int endRow = workSheet.Dimension.End.Row;
                int startColumn = workSheet.Dimension.Start.Column;
                int endColumn = workSheet.Dimension.End.Column;

                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startColumn; col <= endColumn; col++)
                    {
                        Console.Write($"{workSheet.Cells[row, col].Value}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
