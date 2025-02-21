using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBank.API.Infrastructure.Validators;
using MobileBank.Application.Customers;
using MobileBank.Application.Customers.CustomerExceptions;
using System.Net.WebSockets;

namespace MobileBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<List<CustomerResponseModel>> GetAll(CancellationToken token)

        {
            return await _customerService.GetAllAsync(token);
        }

        [HttpGet("{id}")]
        public async Task<CustomerResponseModel> Get(CancellationToken token, int id)
        {
            return await _customerService.GetAsync(token, id);
        }
        [HttpPost]
        public async Task Create(CancellationToken token, CustomerRequestModel customer)
        {
            var validator = new CustomerValidator();
            var result = validator.Validate(customer);
            if (!result.IsValid)
                throw new InvalidCustomerException(customer.Id.ToString());
            await _customerService.CreateAsync(token, customer);
        }
        [HttpPut]
        public async Task Update(CancellationToken token, CustomerRequestModel customer)
        {
            var validator = new CustomerValidator();
            var result = validator.Validate(customer);
            if (!result.IsValid)
                throw new InvalidCustomerException(customer.Id.ToString());
            await _customerService.UpdateAsync(token, customer);
        }


        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _customerService.DeleteAsync(token, id);
        }
    }




}
