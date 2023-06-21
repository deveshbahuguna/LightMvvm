using System.ComponentModel;
using System.Reflection;

namespace MvvmLightCore.Binder
{
    public interface IBindableObject
    {
        int GetHashcode { get; }
        HashSet<PropertyInfo?> Properties { get; set; }
        WeakReference<INotifyPropertyChanged> NotifyObj { get;}
        bool NotifyObjAlreadyExist(IBindableObject toCheckObject);
        bool NotifyObjPropAlreadyExist(IBindableObject toCheckObject);  

    }
}