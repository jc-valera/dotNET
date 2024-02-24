using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.DAL;
using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
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

        public async Task<PostNode> RequestTypeGET()
        {
            var postNode = new PostNode();

            var url = "https://jsonplaceholder.typicode.com/posts/1";

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                response = await client.GetAsync(url).ConfigureAwait(false);

                postNode = JsonConvert.DeserializeObject<PostNode>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return postNode;
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

        public async Task<PostNode> RequestTypePOST()
        {
            var postNodeResult = new PostNode();

            var url = "https://jsonplaceholder.typicode.com/posts";

            var postNode = new PostNode
            {
                title = "Title Test Jcvalera",
                body = "Body Test Jcvalera",
                userId = 50
            };

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                var content = new StringContent(JsonConvert.SerializeObject(postNode), Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, content).ConfigureAwait(false);

                postNodeResult = JsonConvert.DeserializeObject<PostNode>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return postNodeResult;
        }

        public async Task<PostNode> RequestTypePUT()
        {
            var postNodeResult = new PostNode();

            var url = "https://jsonplaceholder.typicode.com/posts/1";

            var postNode = new PostNode
            {
                title = "Update Title Test Jcvalera",
                body = "Update Body Test Jcvalera",
                userId = 50
            };

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                var content = new StringContent(JsonConvert.SerializeObject(postNode), Encoding.UTF8, "application/json");

                response = await client.PutAsync(url, content).ConfigureAwait(false);

                postNodeResult = JsonConvert.DeserializeObject<PostNode>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return postNodeResult;
        }

        public async Task<PostNode> RequestTypePATCH()
        {
            var postNodeResult = new PostNode();

            var url = "https://jsonplaceholder.typicode.com/posts/1";

            var postNode = new PostNode
            {
                title = "Title Jcvalera"
            };

            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                var content = new StringContent(JsonConvert.SerializeObject(postNode), Encoding.UTF8, "application/json");

                response = client.DeleteAsync(url).Result;

                postNodeResult = JsonConvert.DeserializeObject<PostNode>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            }

            return postNodeResult;
        }
    }
}
