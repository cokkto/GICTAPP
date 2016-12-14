using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GICTAPP
{
    /// <summary>
    ///     ValueConverter bool to Visibility when false == Visible
    /// </summary>
    internal class ConvertBoolToVisibilityInvert : IValueConverter
    {  
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            return value is bool ? (bool) value ? Visibility.Collapsed : Visibility.Visible : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            return value is Visibility && (Visibility) value != Visibility.Visible;
        }
    }
}