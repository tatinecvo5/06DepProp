using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06DepProp
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }

    public class WeatherControl : DependencyObject
    {
        private Precipitation precipitation;
        private string windDirection;
        private int windSpeed;

        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
        WeatherControl(string winddir, int windsp, Precipitation precipitation)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windsp;
            this.precipitation = precipitation;
        }
        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Journal |
                FrameworkPropertyMetadataOptions.AffectsArrange,
                null,
                new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));

        }
        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v > -50 && v < 55)
                return true;
            else
                return false;
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > -51 && v < 51)
                return v;
            else
                return 0;
        }
        private void SetValue(DependencyProperty tempProperty)
        {
            throw new NotImplementedException();
        }
    }
}