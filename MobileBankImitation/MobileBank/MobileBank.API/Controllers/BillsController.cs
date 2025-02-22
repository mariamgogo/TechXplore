using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBank.API.Infrastructure.Validators;
using MobileBank.Application.Bills;
using MobileBank.Application.Customers.CustomerExceptions;
using MobileBank.Application.Customers;
using Swashbuckle.AspNetCore.Annotations;

namespace MobileBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }


        /// <summary>
        /// Retrieves all bills
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all bills (including providers and customers)", Description = "Retrieves list of all bills")]
        [SwaggerResponse(200, "Returns list of bills", typeof(List<BillResponseGetAllModel>))]
        public async Task<List<BillResponseGetAllModel>> GetAll(CancellationToken token)

        {
            return await _billService.GetAllAsync(token);
        }

        /// <summary>
        /// Retrieves bill by ID
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get bill by Id", Description = "Retrieves full details(including provider and customer) of a bill using its Id.")]
        [SwaggerResponse(200, "Returns the bill details", typeof(BillResponseGetAllModel))]
        [SwaggerResponse(404, "Bill not found")]
        public async Task<BillResponseGetAllModel> GetFull(CancellationToken token, int id)
        {
            return await _billService.GetFullAsync(token, id);
        }


        /// <summary>
        /// Creates a new bill.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Create new bill", Description = "Add new bill to database")]
        [SwaggerResponse(201, "Bill created")]
        [SwaggerResponse(400, "Invalid bill data")]
        public async Task Create(CancellationToken token, BillRequestModel bill)
        {
            
            await _billService.CreateAsync(token, bill);
        }

        /// <summary>
        /// Updates an existing bill.
        /// </summary>
        [HttpPut]
        [SwaggerOperation(Summary = "Update an existing bill", Description = "Updates details of existing bill.")]
        [SwaggerResponse(200, "Bill  updated")]
        [SwaggerResponse(400, "Invalid bill data")]
        public async Task Update(CancellationToken token, BillRequestModel bill)
        {
          
            await _billService.UpdateAsync(token, bill);
        }


        /// <summary>
        /// Deletes a bill by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete bill", Description = "Removes bill using its ID.")]
        [SwaggerResponse(204, "Bill deleted")]
        [SwaggerResponse(404, "Bill not found")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _billService.DeletAsync(token, id);
        }

    }
}
