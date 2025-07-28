using System;
using FredChessGame.Model;

namespace FredChessGame
{
  public class Plateau
  {
    public Piece[,] Cases { get; } = new Piece[8, 8];

    public Plateau()
    {
      Console.WriteLine("Création d'un nouveau plateau...");
      InitialiserPieces();
      Console.WriteLine("Plateau initialisé avec succès.");
    }

    private void InitialiserPieces()
    {
      Console.WriteLine("Initialisation des pièces...");
      // Noirs
      Cases[0, 0] = new Tour(PieceColor.Noir);
      Cases[0, 1] = new Cavalier(PieceColor.Noir);
      Cases[0, 2] = new Fou(PieceColor.Noir);
      Cases[0, 3] = new Reine(PieceColor.Noir);
      Cases[0, 4] = new Roi(PieceColor.Noir);
      Cases[0, 5] = new Fou(PieceColor.Noir);
      Cases[0, 6] = new Cavalier(PieceColor.Noir);
      Cases[0, 7] = new Tour(PieceColor.Noir);

      for (int col = 0; col < 8; col++)
      {
        Cases[1, col] = new Pion(PieceColor.Noir);
      }

      // Blancs
      Cases[7, 0] = new Tour(PieceColor.Blanc);
      Cases[7, 1] = new Cavalier(PieceColor.Blanc);
      Cases[7, 2] = new Fou(PieceColor.Blanc);
      Cases[7, 3] = new Reine(PieceColor.Blanc);
      Cases[7, 4] = new Roi(PieceColor.Blanc);
      Cases[7, 5] = new Fou(PieceColor.Blanc);
      Cases[7, 6] = new Cavalier(PieceColor.Blanc);
      Cases[7, 7] = new Tour(PieceColor.Blanc);

      for (int col = 0; col < 8; col++)
      {
        Cases[6, col] = new Pion(PieceColor.Blanc);
      }

      // Afficher le contenu du plateau pour débogage
      for (int row = 0; row < 8; row++)
      {
        for (int col = 0; col < 8; col++)
        {
          var piece = Cases[row, col];
          Console.WriteLine($"[{row},{col}]: {(piece != null ? $"{piece.GetType().Name} {piece.Couleur}" : "Vide")}");
        }
      }
    }
  }
}
