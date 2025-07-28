using System;

namespace FredChessGame.Model
{
  public class Roi: Piece
  {
    public Roi(PieceColor couleur) : base(couleur) { }

    public override string Symbole => Couleur == PieceColor.Blanc ? "♔" : "♚";

    /// <summary>
    /// Can the king move to the specified position?
    /// </summary>
    /// <param name="dx">Start X position.</param>
    /// <param name="dy">Start Y position.</param>
    /// <param name="x">Target X position.</param>
    /// <param name="y">Target Y position.</param>
    /// <returns>A boolean indicating if the king can move to the target position.</returns>
    /// <remarks>Le Roi ne peut pas se déplacer dans une case attaquée par une autre pièce.</remarks>
    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2)
        => Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1;
  }
}
