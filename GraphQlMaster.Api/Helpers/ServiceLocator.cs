using GraphQlMaster.ServiceFoundation.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQlMaster.Api.Helpers
{
    public class ServiceLocator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IBrandRepository BrandRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IBrandRepository>();
        public IMaterialRepository MaterialRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IMaterialRepository>();
        public IPurchaseHistoryRepository PurchaseHistoryRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPurchaseHistoryRepository>();

        public ServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
