using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerService customerService, ICustomer customer) : ControllerBase
    {
        private readonly CustomerService _customerService = customerService;
        private readonly ICustomer _customer = customer;

        [HttpPost("posttobc")]
        public async Task<dynamic> PostDataToBc(SeminarData seminarData)
        {
            var responce = await _customer.PostData(seminarData);
            return Ok(responce);
        }
    }
}