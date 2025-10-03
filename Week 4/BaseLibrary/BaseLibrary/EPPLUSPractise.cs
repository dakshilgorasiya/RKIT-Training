using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace BaseLibrary
{
    internal class EPPLUSPractise
    {
        static void Main(string[] args)
        {
            ExcelPackage.License = new Licence()
            {
                LicenseContext = LicenseContext.NonCommercial
            };

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
                worksheet.Cells["B2:B3"].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells["A:C"].AutoFitColumns();

                // Save the package
                package.Save();
            }
        }
    }
}
