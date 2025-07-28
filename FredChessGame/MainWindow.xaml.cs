using FredChessGame.Model;
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
    private Piece[,] plateau = new Piece[8, 8];

    public MainWindow()
    {
      InitializeComponent();
      CreateChessBoard();
      InitialiserPieces();
      AfficherPieces();
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

    private void InitialiserPieces()
    {
      plateau[0, 4] = new Roi(PieceColor.Noir);
      plateau[7, 4] = new Roi(PieceColor.Blanc);

      plateau[0, 3] = new Reine(PieceColor.Noir);
      plateau[7, 3] = new Reine(PieceColor.Blanc);
    }

    private void AfficherPieces()
    {
      ChessBoard.Children.Clear();

      for (int row = 0; row < 8; row++)
      {
        for (int col = 0; col < 8; col++)
        {
          var caseCouleur = (row + col) % 2 == 0 ? Brushes.Beige : Brushes.Brown;

          var border = new Border
          {
            Background = caseCouleur,
            BorderBrush = Brushes.Black,
            BorderThickness = new Thickness(1)
          };

          var piece = plateau[row, col];
          if (piece != null)
          {
            var text = new TextBlock
            {
              Text = piece.Symbole,
              FontSize = 32,
              FontWeight = FontWeights.Bold,
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center
            };
            border.Child = text;
          }

          Grid.SetRow(border, row);
          Grid.SetColumn(border, col);
          ChessBoard.Children.Add(border);
        }
      }
    }
  }
}

