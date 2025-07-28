using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FredChessGame
{
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    public MainWindow()
    {
      InitializeComponent();
      CreateChessBoard();
    }
    private void CreateChessBoard()
    {
      for (int i = 0; i < 8; i++)
      {
        ChessBoard.RowDefinitions.Add(new RowDefinition());
        ChessBoard.ColumnDefinitions.Add(new ColumnDefinition());
      }

      for (int row = 0; row < 8; row++)
      {
        for (int col = 0; col < 8; col++)
        {
          var square = new Border
          {
            Background = (row + col) % 2 == 0 ? Brushes.Beige : Brushes.Brown,
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(1)
          };

          Grid.SetRow(square, row);
          Grid.SetColumn(square, col);
          ChessBoard.Children.Add(square);
        }
      }
    }

  }
}

