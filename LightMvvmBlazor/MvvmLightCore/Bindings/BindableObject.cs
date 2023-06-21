using System.ComponentModel;
using System.Reflection;

namespace MvvmLightCore.Binder
{
    public class BindableObject : IBindableObject
    {
        public BindableObject(WeakReference<INotifyPropertyChanged>? notifyObj)
        {
            _notifyObj = notifyObj ?? throw new NullReferenceException("notify obj is null");
        }

        private WeakReference<INotifyPropertyChanged> _notifyObj;
        public WeakReference<INotifyPropertyChanged> NotifyObj => _notifyObj;
        public HashSet<PropertyInfo?> Properties { get; set; } = new();

        public bool NotifyObjAlreadyExist(IBindableObject toCheckObject)
        {
            if (toCheckObject.NotifyObj.TryGetTarget(out INotifyPropertyChanged? keyObject)
             &&  NotifyObj.TryGetTarget(out INotifyPropertyChanged? currentObjectVM))
            {                
                return keyObject.Equals(currentObjectVM);
            }
            return false;
        }

        public bool NotifyObjPropAlreadyExist(IBindableObject toCheckObject)
        {
            return NotifyObjAlreadyExist(toCheckObject) && this.Properties.Contains(toCheckObject.Properties.First());
        }

        public int GetHashcode
        {
            get
            {
                if (this.NotifyObj != null)
                {
                    INotifyPropertyChanged? vm;
                    return this.NotifyObj.TryGetTarget(out vm).GetHashCode();
                }
                return -1;
            }
        }
    }
}
