namespace FredChessGame.Model
{
  public class Tour: Piece
  {
    public Tour(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♖" : "♜";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      // Vérifier que le déplacement est en ligne droite (même ligne ou même colonne)
      bool deplacementLigneDroite = (x1 == x2) || (y1 == y2);
      
      // Vérifier que la case de destination est vide ou contient une pièce adverse
      bool priseValide = pieceDestination == null || pieceDestination.Couleur != this.Couleur;
      
      return deplacementLigneDroite && priseValide;
    }
  }
}
