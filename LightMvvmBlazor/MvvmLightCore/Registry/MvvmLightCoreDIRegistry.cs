using Microsoft.Extensions.DependencyInjection;
using MvvmLightCore.Binder;

namespace MvvmLightCore.Registry
{
    public static class MvvmLightCoreDIRegistry
    {
        public static void AddMvvm(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddTransient<IBindingManager, BindingManager>();
            serviceProvider.AddTransient<IMvvmBinder, MvvmBinder>();
        }
    }
}
