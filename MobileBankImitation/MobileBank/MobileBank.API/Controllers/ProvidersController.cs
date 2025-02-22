using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MobileBank.Application.Providers;
using Swashbuckle.AspNetCore.Annotations;
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


        /// <summary>
        /// Retrieves all providers.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all providers", Description = "Retrieves list of all providers")]
        [SwaggerResponse(200, "Returns the list of providers", typeof(List<ProviderResponseModel>))]
        public async Task<List<ProviderResponseModel>> GetAll(CancellationToken token)
        {
            return await _providerService.GetAllAsync(token);
        }

        /// <summary>
        /// Retrieves a provider by Id
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get provider by Id", Description = "Retrieves provider using its Id")]
        [SwaggerResponse(200, "Returns provider details", typeof(ProviderResponseModel))]
        [SwaggerResponse(404, "Provider not found")]
        public async Task<ProviderResponseModel> Get(CancellationToken token, int id)
        {
            return await _providerService.GetAsync(token, id);
        }

        /// <summary>
        /// Creates a new provider.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new provider", Description = "Adds provider")]
        [SwaggerResponse(201, "Provider  created")]
        [SwaggerResponse(400, "Invalid provider data")]
        public async Task Create(CancellationToken token, ProviderRequestPostModel provider)
        {
            await _providerService.CreateAsync(token, provider);
        }

        /// <summary>
        /// Updates an existing provider.
        /// </summary>
        [HttpPut]
        [SwaggerOperation(Summary = "Update provider", Description = "Updates provider")]
        [SwaggerResponse(200, "Provider updated")]
        [SwaggerResponse(400, "Invalid provider data")]
        public async Task Update(CancellationToken token,ProviderRequestPutModel provider)
        {
            await _providerService.UpdateAsync(token, provider);
        }

        /// <summary>
        /// Deletes a provider by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a provider", Description = "Removes provider using its ID.")]
        [SwaggerResponse(204, "Provider deleted")]
        [SwaggerResponse(404, "Provider not found")]
        public async Task Delete(CancellationToken token, int id)
        {
            await _providerService.DeletAsync(token, id);
        }
    }
}
