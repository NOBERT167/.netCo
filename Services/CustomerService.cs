using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class CustomerService(HttpClient httpClient, IConfiguration configuration,Credentials credentials) : ICustomer
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = configuration;
        public async Task<dynamic> PostData(SeminarData seminar)
        {
            try
            {
                var client = credentials.ObjNav();
                await client.InsertSeminarDataAsync(seminar.DocNo, seminar.Name, seminar.SearchName, seminar.SeminarDuration);
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }


    public class Customer
    {
        public string No { get; set; }
        public string Name { get; set; }
        public string Post_Code { get; set; }
        public string Shipping_Advice { get; set; }
        public string Contact { get; set; }
        public string Reserve { get; set; }
    }
    public class SeminarData {
        public string DocNo { get; set; }
        public string Name { get; set; }
        public int SeminarDuration { get; set; }
        public string SearchName { get; set; }

    }
}