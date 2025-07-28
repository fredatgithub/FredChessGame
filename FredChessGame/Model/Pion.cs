using System;
using FredChessGame.Model;

namespace FredChessGame
{
  public class Pion: Piece
  {
    private bool _aBouge = false;

    public Pion(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♙" : "♟";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      int direction = Couleur == PieceColor.Blanc ? -1 : 1;
      int deltaX = x2 - x1;
      int deltaY = Math.Abs(y2 - y1);

      // Déplacement en avant d'une case (sans prise)
      if (deltaX == direction && deltaY == 0 && pieceDestination == null)
      {
        if (!_aBouge) _aBouge = true;
        return true;
      }

      // Premier déplacement de deux cases (sans prise)
      if (!_aBouge && deltaX == 2 * direction && deltaY == 0 && pieceDestination == null)
      {
        _aBouge = true;
        return true;
      }

      // Prise en diagonale d'une case
      if (deltaX == direction && deltaY == 1 && pieceDestination != null && pieceDestination.Couleur != this.Couleur)
      {
        if (!_aBouge) _aBouge = true;
        return true;
      }

      return false;
    }
  }
}
