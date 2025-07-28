// Converters/CaseColorConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FredChessGame.Converters
{
  public class CaseColorConverter: IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (parameter is string pos && pos.Contains("_"))
      {
        var parts = pos.Split('_');
        int row = int.Parse(parts[0]);
        int col = int.Parse(parts[1]);
        return (row + col) % 2 == 0 ? Brushes.Beige : Brushes.Brown;
      }

      return Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
  }
}
