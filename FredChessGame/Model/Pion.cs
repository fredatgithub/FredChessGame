using FredChessGame.Model;

namespace FredChessGame
{
  public class Pion: Piece
  {
    public Pion(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♙" : "♟";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2)
    {
      int direction = Couleur == PieceColor.Blanc ? -1 : 1;
      return (x1 + direction == x2) && (y1 == y2);
    }
  }
}
