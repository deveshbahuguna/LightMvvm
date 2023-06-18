﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMvvmUT.MvvmLightBlazorComponent.TestData
{
    internal class SampleComponentViewModel : INotifyPropertyChanged
    {
        private int _counter;

        public int Counter
        {
            get => _counter; set
            {
                if (value != _counter)
                {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
