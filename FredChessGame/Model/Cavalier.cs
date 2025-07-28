using System;

namespace FredChessGame.Model
{
  internal class Cavalier: Piece
  {
    public Cavalier(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♘" : "♞";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2)
    {
      int dx = Math.Abs(x1 - x2);
      int dy = Math.Abs(y1 - y2);
      // Le cavalier se déplace en forme de "L", soit deux cases dans une direction et une case dans l'autre
      return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }
  }
}
