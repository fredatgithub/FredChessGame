using System;

namespace FredChessGame.Model
{
  internal class Cavalier: Piece
  {
    public Cavalier(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♘" : "♞";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      // Le cavalier peut sauter par-dessus les autres pièces, donc on ne vérifie pas les cases intermédiaires
      int dx = Math.Abs(x1 - x2);
      int dy = Math.Abs(y1 - y2);
      
      // Le cavalier se déplace en forme de "L", soit deux cases dans une direction et une case dans l'autre
      bool deplacementEnL = (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
      
      // Vérifier que la case de destination est vide ou contient une pièce adverse
      bool priseValide = pieceDestination == null || pieceDestination.Couleur != this.Couleur;
      
      return deplacementEnL && priseValide;
    }
  }
}
