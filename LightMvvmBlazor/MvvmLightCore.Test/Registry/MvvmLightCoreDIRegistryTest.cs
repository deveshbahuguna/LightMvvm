using Microsoft.Extensions.DependencyInjection;
using Moq;
using MvvmLightCore;
using MvvmLightCore.Binder;
using MvvmLightCore.Registry;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightCore.Test.Registry
{
    [ExcludeFromCodeCoverage]
    public class MvvmLightCoreDIRegistryTest
    {
        [Fact]
        public void AddMvvm_ServiceCollectionObj_AddsTwoMoreItems()
        {
            //Arrange
            Mock<IServiceCollection> serviceCollectionMockObj = new();
            bool isBindingManagedAdded = false;
            bool isMvvmBinderAdded = false;
            serviceCollectionMockObj.Setup(x => x.Add(It.IsAny<ServiceDescriptor>())).Callback((ServiceDescriptor descriptor) =>
            {
                if (descriptor.ServiceType == typeof(IBindingManager) && descriptor.ImplementationType == typeof(BindingManager))
                {
                    isBindingManagedAdded = true;
                }
                if (descriptor.ServiceType == typeof(IMvvmBinder) && descriptor.ImplementationType == typeof(MvvmBinder))
                {
                    isMvvmBinderAdded = true;
                }
            });

            //Act
            serviceCollectionMockObj.Object.AddMvvm();
            
            //Assert
            Assert.True(isBindingManagedAdded);
            Assert.True(isMvvmBinderAdded);
        }
    }
}
