using System;

namespace FredChessGame.Model
{
  public class Roi: Piece
  {
    public Roi(PieceColor couleur) : base(couleur) { }

    public override string Symbole => Couleur == PieceColor.Blanc ? "♔" : "♚";

    /// <summary>
    /// Vérifie si le roi peut se déplacer à la position spécifiée
    /// </summary>
    /// <param name="x1">Position X de départ</param>
    /// <param name="y1">Position Y de départ</param>
    /// <param name="x2">Position X d'arrivée</param>
    /// <param name="y2">Position Y d'arrivée</param>
    /// <param name="pieceDestination">Pièce présente sur la case d'arrivée (peut être null)</param>
    /// <returns>Vrai si le déplacement est valide, faux sinon</returns>
    /// <remarks>Le Roi ne peut pas se déplacer dans une case attaquée par une pièce adverse.</remarks>
    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      // Vérifier que le déplacement est d'une case dans n'importe quelle direction
      bool deplacementDuneCase = Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1;
      
      // Vérifier que la case de destination est vide ou contient une pièce adverse
      bool priseValide = pieceDestination == null || pieceDestination.Couleur != this.Couleur;
      
      return deplacementDuneCase && priseValide;
      
      // Note: La vérification des cases attaquées par l'adversaire
      // devrait être faite dans la logique du jeu, pas ici
    }
  }
}
