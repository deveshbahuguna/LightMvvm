using Moq;
using MvvmLightCore;
using MvvmLightCore.Binder;
using MvvmLightCore.Test.TestData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightCore.Test.Bindings
{
    [ExcludeFromCodeCoverage]
    public class MvvmBinderTest
    {
        private MvvmBinder _mvvmBinder;
        private SampleComponentViewModel _sampleVm;
        private readonly Mock<IBindingManager> _bindingManager;
        public MvvmBinderTest()
        {
            _bindingManager = new Mock<IBindingManager>();
            _mvvmBinder = new MvvmBinder(_bindingManager.Object);
            _sampleVm = new SampleComponentViewModel();
        }

        [Fact]
        public void Bind_BindNewProperty_AddPropToBindingManager()
        {
            _bindingManager.Setup(x => x.CheckIfBindingAlreadyExist(It.IsAny<IBindableObject>())).Returns(false);

            _mvvmBinder.Bind<SampleComponentViewModel, int>(_sampleVm, x => x.Counter);

            _bindingManager.Verify(x => x.CheckIfBindingAlreadyExist(It.IsAny<IBindableObject>()), Times.Once);

        }

        [Fact]
        public void Bind_BindNewProperty_ReturnsTheSamePropertyValue()
        {
            _sampleVm.Counter = 1;
            var expectedCount = 1;
            _bindingManager.Setup(x => x.CheckIfBindingAlreadyExist(It.IsAny<IBindableObject>())).Returns(false);

            var actualResult = _mvvmBinder.Bind<SampleComponentViewModel, int>(_sampleVm, x => x.Counter);

            Assert.Equal(expectedCount, actualResult);

        }

        [Fact]
        public void Bind_BindExistingProperty_DontAddBindingManager()
        {
            _bindingManager.Setup(x => x.CheckIfBindingAlreadyExist(It.IsAny<BindableObject>())).Returns(true);

            _mvvmBinder.Bind<SampleComponentViewModel, int>(_sampleVm, x => x.Counter);

            _bindingManager.Verify(x => x.AddBinding(It.IsAny<IBindableObject>()), Times.Never);
        }

        [Fact]
        public void Bind_BindExistingProperty_ReturnsSamePropValue()
        {
            _sampleVm.Counter = 1;
            var expectedCount = 1;
            _bindingManager.Setup(x => x.CheckIfBindingAlreadyExist(It.IsAny<BindableObject>())).Returns(true);

            var actualResult = _mvvmBinder.Bind<SampleComponentViewModel, int>(_sampleVm, x => x.Counter);

            _bindingManager.Verify(x => x.AddBinding(It.IsAny<IBindableObject>()), Times.Never);
            Assert.Equal(expectedCount, actualResult);
        }

        [Fact]
        public void Bind_BindingExpressionIncorrect_ThrowNotImplementedException()
        {
            //Arrange
            _bindingManager.Setup(x => x.CheckIfBindingAlreadyExist(It.IsAny<BindableObject>())).Returns(true);

            //Act
            var action = () => { _mvvmBinder.Bind<SampleComponentViewModel, int>(_sampleVm, (_sampleVm) => 0); };

            //Assert
            Assert.Throws<NotSupportedException>(action);
        }


    }
}