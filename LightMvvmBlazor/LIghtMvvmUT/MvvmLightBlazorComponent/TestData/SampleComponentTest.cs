﻿using MvvmLightBlazorComponent;
using MvvmLightCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LightMvvmUT.MvvmLightBlazorComponent.TestData
{
    public class SampleComponentTest : BlazorMvvmComponent
    {
        public bool IsPropChangeEventInvoked { get; set; } = false;
        public TValue? Bind<TInput, TValue>(INotifyPropertyChanged viewmodel, Expression<Func<TInput, TValue?>> bindingExpression) where TInput : INotifyPropertyChanged
        {
            return base.Bind<TInput, TValue>(viewmodel, bindingExpression);
        }

        public override void PropertyChangedEventHandler(object? sender, PropertyChangedEventArgs e)
        {
            this.IsPropChangeEventInvoked = true;
        }

        public SampleComponentTest(IMvvmBinder mvvmBinder)
        {
            this.MvvmBinder = mvvmBinder;
        }
    }
}