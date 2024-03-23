using Moq;
using MvvmLightBlazorComponent.Test.TestData;
using MvvmLightCore;
using MvvmLightCore.Binder;
using System.Diagnostics.CodeAnalysis;

namespace MvvmLightBlazorComponent.Test
{
    [ExcludeFromCodeCoverage]
    public class BlazorMvvmComponentTest
    {
        private readonly SampleComponentTest balzorComponentTest;
        private readonly SampleComponentViewModel sampleVM;
        private readonly Mock<IMvvmBinder> mvvmBinder = new Mock<IMvvmBinder>();

        public BlazorMvvmComponentTest()
        {
            balzorComponentTest = new SampleComponentTest(mvvmBinder.Object);
            sampleVM = new SampleComponentViewModel();
        }

        [Fact]
        void Bind_CounterValue_ReturnsSameCounterValue()
        {
            sampleVM.Counter = 1;
            int expectedResult = 1;
            mvvmBinder.Setup(x => x.Bind<SampleComponentViewModel, int>(sampleVM, x => x.Counter)).Returns(1);

            int actualResult = balzorComponentTest.Bind<SampleComponentViewModel, int>(sampleVM, x => x.Counter);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        void Bind_OnVmPropChange_InvokesOnPropChangeMethod()
        {
            var mvvmBinder = new MvvmBinder(new BindingManager());
            balzorComponentTest.MvvmBinder = mvvmBinder;

            balzorComponentTest.Bind<SampleComponentViewModel, int>(sampleVM, x => x.Counter);
            sampleVM.Counter = 1;

            Assert.True(balzorComponentTest.IsPropChangeEventInvoked);
        }

    }
}
