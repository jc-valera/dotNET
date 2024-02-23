using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.DAL;
using Microsoft.Exchange.WebServices.Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class SalesBLL
    {
        public SalesDAL salesDAL;

        public SalesBLL()
        {
            salesDAL = new SalesDAL();
        }

        public async Task<byte[]> GetReportSalesCustomer()
        {
            var salesCustomers = await salesDAL.GetSalesCustomer();

            using (var package = new ExcelPackage(new MemoryStream()))
            {
                var workSheet = package.Workbook.Worksheets.Add("General_Report");

                workSheet.Cells["A1"].Value = "FirstName";
                workSheet.Cells["B1"].Value = "MiddleName";
                workSheet.Cells["C1"].Value = "LastName";
                workSheet.Cells["D1"].Value = "SalesLastYear";

                int recordIndex = 2;

                foreach (var sales in salesCustomers)
                {
                    workSheet.Cells[recordIndex, 1].Value = sales.FirstName;
                    workSheet.Cells[recordIndex, 2].Value = sales.MiddleName;
                    workSheet.Cells[recordIndex, 3].Value = sales.LastName;
                    workSheet.Cells[recordIndex, 4].Value = sales.SalesLastYear;
                    recordIndex++;
                }

                return package.GetAsByteArray();
            }
        }

        public async Task<List<SalesCustomer>> GetSalesCustomer()
        {
            var salesCustomer = await salesDAL.GetSalesCustomer();

            return salesCustomer;
        }

        public void SendEmailReport()
        {
            var mailTo = "my_email@gmail.com";
            var filename = @"D:\Users\jcvalera\Desktop\Report_Sales_Customer.xlsx";

            var exchangeService = new ExchangeService(ExchangeVersion.Exchange2010)
            {
                UseDefaultCredentials = false,
                Credentials = new WebCredentials("my_email@outlook.com", "my_password"),
                Url = new Uri("https://outlook.office365.com/ews/exchange.asmx")
            };

            var mail = new EmailMessage(exchangeService)
            {
                Subject = "Test Send Sales Report",
                Body = "Test Send Sales Report",
                From = "my_email@outlook.com"
            };

            mail.Attachments.AddFileAttachment(filename);

            mail.ToRecipients.Add(mailTo);

            mail.Send();

        }
    }
}
