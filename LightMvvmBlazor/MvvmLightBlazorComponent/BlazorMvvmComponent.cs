using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MvvmLightCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MvvmLightBlazorComponent
{
    public abstract class BlazorMvvmComponent : ComponentBase
    {
    
        [Inject]
        public IMvvmBinder MvvmBinder { get; set; }

        [Inject]
        public ILogger<BlazorMvvmComponent> Logger { get; set; }
       
        protected TValue? Bind<TInput, TValue>(INotifyPropertyChanged viewmodel, Expression<Func<TInput, TValue?>> bindingExpression) where TInput : INotifyPropertyChanged
        {
            this.MvvmBinder.ViewModelPropertyChanged -= PropertyChangedEventHandler;
            this.MvvmBinder.ViewModelPropertyChanged += PropertyChangedEventHandler;
            return this.MvvmBinder.Bind(viewmodel, bindingExpression);
        }

        public virtual void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            Logger.Log(LogLevel.Trace, $"Prop change event invoked for {e.PropertyName} for object {sender}");
            this.InvokeAsync(()=>this.StateHasChanged());
        }

    }
}
