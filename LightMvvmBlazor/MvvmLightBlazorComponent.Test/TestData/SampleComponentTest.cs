using MvvmLightBlazorComponent;
using MvvmLightCore;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MvvmLightBlazorComponent.Test.TestData
{
    [ExcludeFromCodeCoverage]
    public class SampleComponentTest : BlazorMvvmComponent
    {
        public bool IsPropChangeEventInvoked { get; set; } = false;
        public TValue? Bind<TInput, TValue>(INotifyPropertyChanged viewmodel, Expression<Func<TInput, TValue?>> bindingExpression) where TInput : INotifyPropertyChanged
        {
            return base.Bind(viewmodel, bindingExpression);
        }

        public override void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            IsPropChangeEventInvoked = true;
        }

        public SampleComponentTest(IMvvmBinder mvvmBinder)
        {
            MvvmBinder = mvvmBinder;
        }
    }
}
