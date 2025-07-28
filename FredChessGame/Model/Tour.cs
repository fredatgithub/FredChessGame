namespace FredChessGame.Model
{
  public class Tour: Piece
  {
    public Tour(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♖" : "♜";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2)
        => x1 == x2 || y1 == y2;
  }
}
