using Doera.Application.Interfaces.Services;
using Doera.Application.Services;

namespace Doera.Web.Extensions {
    public static class WebExtensions {
        public static IServiceCollection AddElmahIoMonitor(this IServiceCollection services) {
            services.AddElmahIo(options => {
                options.ApiKey = "";
                options.LogId = new Guid("");
            });
            return services;
        }
    }
}
