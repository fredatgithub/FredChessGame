using System;

namespace FredChessGame.Model
{
  public class Fou: Piece
  {
    public Fou(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♗" : "♝";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2)
        => Math.Abs(x1 - x2) == Math.Abs(y1 - y2);
  }
}
