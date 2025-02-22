using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileBank.API.Infrastructure.Validators;
using MobileBank.Application.Bills;
using MobileBank.Application.Customers.CustomerExceptions;
using MobileBank.Application.Customers;

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


        [HttpGet]
        public async Task<List<BillResponseGetAllModel>> GetAll(CancellationToken token)

        {
            return await _billService.GetAllAsync(token);
        }

        [HttpGet("{id}")]
        public async Task<BillResponseGetAllModel> GetFull(CancellationToken token, int id)
        {
            return await _billService.GetFullAsync(token, id);
        }
        [HttpPost]
        public async Task Create(CancellationToken token, BillRequestModel bill)
        {
            
            await _billService.CreateAsync(token, bill);
        }
        [HttpPut]
        public async Task Update(CancellationToken token, BillRequestModel bill)
        {
          
            await _billService.UpdateAsync(token, bill);
        }


        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _billService.DeletAsync(token, id);
        }

    }
}
