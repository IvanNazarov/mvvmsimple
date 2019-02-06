using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Windows.ApplicationModel;

namespace mvvmsimple
{
    public class ViewModelBase : ObservableObject
    {
        private static bool? _isInDesignMode;

        public static bool IsInDesignModeStatic
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    _isInDesignMode = DesignMode.DesignModeEnabled;
                }
                return _isInDesignMode.Value;
            }
        }

        protected bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
                return false;
            field = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }


    }
}
