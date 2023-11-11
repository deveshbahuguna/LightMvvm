using LIghtMvvmUT.TestData;
using MvvmLightCore.Binder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIghtMvvmUT.MvvmLightCore.Bindings
{
    [ExcludeFromCodeCoverage]
    public class BindableObjectTest
    {
        private SampleComponentViewModel _viewModel;

        public BindableObjectTest()
        {
            _viewModel = new SampleComponentViewModel();
        }

        [Fact]
        void NotifyObjAlreadyExist_SameNotifyObj_ReturnsTrue()
        {
            BindableObject bindableObject = new BindableObject(new WeakReference<INotifyPropertyChanged>(_viewModel));
            BindableObject addBindableObj = new BindableObject(new WeakReference<INotifyPropertyChanged>(_viewModel));
         
            var actualResult = bindableObject.NotifyObjAlreadyExist(addBindableObj);

            Assert.True(actualResult);

        }

        [Fact]
        void NotifyObjExist_DifferentNotifyObj_ReturnsFalse()
        {
            BindableObject bindableObject = new BindableObject(new WeakReference<INotifyPropertyChanged>(_viewModel));
            BindableObject addBindableObj = new BindableObject(new WeakReference<INotifyPropertyChanged>(new SampleComponentViewModel()));

            var actualResult = bindableObject.NotifyObjAlreadyExist(addBindableObj);

            Assert.False(actualResult);

        }

        [Fact]
        void NotifyObjExist_NotifyObjIsNull_ReturnsFalse()
        {
            BindableObject bindableObject = new BindableObject(new WeakReference<INotifyPropertyChanged>(_viewModel));
            BindableObject addBindableObj = new BindableObject(new WeakReference<INotifyPropertyChanged>(null));

            var actualResult = bindableObject.NotifyObjAlreadyExist(addBindableObj);

            Assert.False(actualResult);

        }


    }
}
