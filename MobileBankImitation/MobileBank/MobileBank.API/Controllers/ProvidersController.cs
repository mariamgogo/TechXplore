using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MobileBank.Application.Providers;
using System.Runtime.CompilerServices;

namespace MobileBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }


        [HttpGet]
        public async Task<List<ProviderResponseModel>> GetAll(CancellationToken token)
        {
            return await _providerService.GetAllAsync(token);
        }


        [HttpGet("{id}")]
        public async Task<ProviderResponseModel> Get(CancellationToken token, int id)
        {
            return await _providerService.GetAsync(token, id);
        }

        [HttpPost]
        public async Task Create(CancellationToken token, ProviderRequestModel provider)
        {
            await _providerService.CreateAsync(token, provider);
        }

        [HttpPut]
        public async Task Update(CancellationToken token, ProviderRequestModel provider)
        {
            await _providerService.UpdateAsync(token, provider);
        }

        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _providerService.DeletAsync(token, id);

        }
    }
}
