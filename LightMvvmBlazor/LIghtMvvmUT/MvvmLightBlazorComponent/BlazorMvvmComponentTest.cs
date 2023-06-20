using Castle.Core.Logging;
using LIghtMvvmUT.TestData;
using Microsoft.Extensions.Logging;
using Moq;
using MvvmLightBlazorComponent;
using MvvmLightCore;
using MvvmLightCore.Binder;
using System.Reflection;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LightMvvmUT.MvvmLightBlazorComponent
{
    public class BlazorMvvmComponentTest
    {
        private readonly SampleComponentTest balzorComponentTest;
        private readonly SampleComponentViewModel sampleVM;
        private readonly Mock<IMvvmBinder> mvvmBinder = new Mock<IMvvmBinder>();

        public BlazorMvvmComponentTest()
        {
            this.balzorComponentTest = new SampleComponentTest(mvvmBinder.Object);
            this.sampleVM = new SampleComponentViewModel();
        }

        [Fact]
        void Bind_CounterValue_ReturnsSameCounterValue()
        {
            this.sampleVM.Counter = 1;
            int expectedResult = 1;
            this.mvvmBinder.Setup(x => x.Bind<SampleComponentViewModel, int>(this.sampleVM, x => x.Counter)).Returns(1);

            int actualResult = this.balzorComponentTest.Bind<SampleComponentViewModel, int>(this.sampleVM, x => x.Counter);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        void Bind_OnVmPropChange_InvokesOnPropChangeMethod()
        {
            var mvvmBinder = new MvvmBinder(new BindingManager());
            this.balzorComponentTest.MvvmBinder = mvvmBinder;
          
            this.balzorComponentTest.Bind<SampleComponentViewModel, int>(this.sampleVM, x => x.Counter);
            this.sampleVM.Counter = 1;
             
            Assert.True(this.balzorComponentTest.IsPropChangeEventInvoked); 
        }

    }
}
