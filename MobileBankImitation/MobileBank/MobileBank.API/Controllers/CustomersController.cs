using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBank.API.Infrastructure.Localizations;
using MobileBank.API.Infrastructure.Validators;
using MobileBank.Application.Customers;
using MobileBank.Application.Customers.CustomerExceptions;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.WebSockets;

namespace MobileBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
       // private readonly CustomerValidator _validator;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
           // _validator = validator;
        }


        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>List of customers.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all customers", Description = "Returns customers list")]
        [SwaggerResponse(200, "Returns the list of customers", typeof(List<CustomerResponseModel>))]
        [SwaggerResponse(400, "Bad request")]
        public async Task<List<CustomerResponseModel>> GetAll(CancellationToken token)

        {
            return await _customerService.GetAllAsync(token);
        }

        /// <summary>
        /// Gets customer by Id
        /// </summary>
        /// <param name="id">customer Id</param>
        /// <returns>Csutomer details</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieve customer by ID", Description = "Provide an Id to get specific customer")]
        [SwaggerResponse(200, "Returns the customer details", typeof(CustomerResponseModel))]
        [SwaggerResponse(404, "User not found")]
        public async Task<CustomerResponseModel> Get(CancellationToken token, int id)
        {
            return await _customerService.GetAsync(token, id);
        }


        /// <summary>
        /// Creates new customer
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new customer", Description = "Adds new customer to database")]
        [SwaggerResponse(201, "Customer created")]
        [SwaggerResponse(400, "Invalid customer data")]
        public async Task Create(CancellationToken token, CustomerRequestPostModel customer)
        {
            var validator = new CustomerValidatorPost();
            var result = validator.Validate(customer);
            if (!result.IsValid)
                throw new InvalidCustomerException(ErrorMessages.InvalidCustomer);
            await _customerService.CreateAsync(token, customer);
        }


        /// <summary>
        /// Updates an existing customer
        /// </summary>
        [HttpPut]
        [SwaggerOperation(Summary = "Update existing customer", Description = "Updates customer details in database")]
        [SwaggerResponse(200, "Customer updated")]
        [SwaggerResponse(400, "Invalid customer data")]
        public async Task Update(CancellationToken token, CustomerRequestPutModel customer)
        {
            var validator = new CustomerValidatorPut();
            var result = validator.Validate(customer);
            if (!result.IsValid)
                throw new InvalidCustomerException(ErrorMessages.InvalidCustomer);
            await _customerService.UpdateAsync(token, customer);
        }


        /// <summary>
        /// Deletes customer by Id
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete customer", Description = "Removes customer from database by Id")]
        [SwaggerResponse(204, "Customer deleted")]
        [SwaggerResponse(404, "Customer not found")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _customerService.DeleteAsync(token, id);
        }
    }




}
