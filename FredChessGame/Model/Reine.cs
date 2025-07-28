using System;

namespace FredChessGame.Model
{
  public class Reine: Piece
  {
    public Reine(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♕" : "♛";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      // Vérifier que le déplacement est en ligne droite ou en diagonale
      bool deplacementValide = (x1 == x2) || (y1 == y2) || (Math.Abs(x1 - x2) == Math.Abs(y1 - y2));
      
      // Vérifier que la case de destination est vide ou contient une pièce adverse
      bool priseValide = pieceDestination == null || pieceDestination.Couleur != this.Couleur;
      
      return deplacementValide && priseValide;
    }
  }
}
