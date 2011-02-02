using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace LeftButtonContextSliders
{
    class Conv_RGB_SolidBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is byte)
            {
                byte red = (byte)(values[0]);
                byte green = (byte)(values[1]);
                byte blue = (byte)(values[2]);

                return new SolidColorBrush(Color.FromRgb(red, green, blue));
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }

    class Conv_S_GradientBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is double)
            {
                double h = (double)(values[0]);
                double s = (double)(values[1]);
                double v = (double)(values[2]);
                System.Drawing.Color col0 = ColorConv.ColorFromHSV(h, 0.0, v);
                System.Drawing.Color col1 = ColorConv.ColorFromHSV(h, 1.0, v);

                LinearGradientBrush myBrush = new LinearGradientBrush();
                myBrush.StartPoint = new Point(0, 0);
                myBrush.EndPoint = new Point(1, 0);
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(col0.R, col0.G, col0.B), 0.0));
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(col1.R, col1.G, col1.B), 1.0));
                return myBrush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }

    class Conv_V_GradientBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is double)
            {
                double h = (double)(values[0]);
                double s = (double)(values[1]);
                double v = (double)(values[2]);
                System.Drawing.Color col0 = ColorConv.ColorFromHSV(h, s, 0.0);
                System.Drawing.Color col1 = ColorConv.ColorFromHSV(h, s, 1.0);

                LinearGradientBrush myBrush = new LinearGradientBrush();
                myBrush.StartPoint = new Point(0, 0);
                myBrush.EndPoint = new Point(1, 0);
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(col0.R, col0.G, col0.B), 0.0));
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(col1.R, col1.G, col1.B), 1.0));
                return myBrush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }

    class Conv_R_GradientBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is byte)
            {
                byte red = (byte)(values[0]);
                byte green = (byte)(values[1]);
                byte blue = (byte)(values[2]);

                LinearGradientBrush myBrush = new LinearGradientBrush();
                myBrush.StartPoint = new Point(0, 0);
                myBrush.EndPoint = new Point(1, 0);
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(0, green, blue), 0.0));
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(255, green, blue), 1.0)); 
                return myBrush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }

    class Conv_G_GradientBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is byte)
            {
                byte red = (byte)(values[0]);
                byte green = (byte)(values[1]);
                byte blue = (byte)(values[2]);

                LinearGradientBrush myBrush = new LinearGradientBrush();
                myBrush.StartPoint = new Point(0, 0);
                myBrush.EndPoint = new Point(1, 0);
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(red, 0, blue), 0.0));
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(red, 255, blue), 1.0));
                return myBrush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }

    class Conv_B_GradientBrush : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Note that we have to downcast each of the values (an object) to its actual
            // type (double) before converting it to a float.
            if (values[0] is byte)
            {
                byte red = (byte)(values[0]);
                byte green = (byte)(values[1]);
                byte blue = (byte)(values[2]);

                LinearGradientBrush myBrush = new LinearGradientBrush();
                myBrush.StartPoint = new Point(0, 0);
                myBrush.EndPoint = new Point(1, 0);
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(red, green, 0), 0.0));
                myBrush.GradientStops.Add(new GradientStop(Color.FromRgb(red, green, 255), 1.0));
                return myBrush;
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack should never be called");
        }
    }
}
