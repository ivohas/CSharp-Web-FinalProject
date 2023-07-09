using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookFindingAndRatingSystem.Web.Infrastucture.Extensions
{
    public static class WebApplicationBuilderExtensions
    {

        public static void AddApllicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided");
            }

            Type[] serviceTypes  = serviceAssembly
                .GetTypes()
                .Where(t=> t.Name.EndsWith("Service")&& !t.IsInterface)
                .ToArray();

            foreach (var st in serviceTypes)
            {
                Type? interfaceType = st
                    .GetInterface($"I{st.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface is provided for service {st.Name}");
                }
                services.AddScoped(interfaceType,st);
            }
        }
    }
}
