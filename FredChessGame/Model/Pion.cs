using System;
using FredChessGame.Model;
using System.Diagnostics;

namespace FredChessGame
{
  public class Pion: Piece
  {
    // Suppression de la variable _aBouge car elle ne doit pas être stockée dans l'instance
    // car une nouvelle instance est créée à chaque fois pour la surbrillance
    
    public Pion(PieceColor couleur) : base(couleur) { }
    public override string Symbole => Couleur == PieceColor.Blanc ? "♙" : "♟";

    public override bool PeutSeDeplacer(int x1, int y1, int x2, int y2, Piece pieceDestination = null)
    {
      Debug.WriteLine($"Pion {Couleur} - Déplacement de ({x1},{y1}) vers ({x2},{y2}), pieceDestination: {pieceDestination?.GetType().Name ?? "null"}");
      
      // Vérifier si c'est un déplacement en ligne droite (sans prise)
      if (y1 == y2 && pieceDestination == null)
      {
        Debug.WriteLine("Déplacement en ligne droite détecté");
        
        // Pour les blancs (en haut de l'échiquier)
        if (Couleur == PieceColor.Blanc)
        {
          Debug.WriteLine("Pion blanc - Vérification déplacement vers le haut");
          
          // Déplacement d'une case vers le haut
          if (x2 == x1 - 1)
          {
            Debug.WriteLine("Déplacement d'une case vers le haut valide");
            return true;
          }
          // Premier déplacement de deux cases vers le haut
          if (x1 == 6 && x2 == x1 - 2) // Vérifie si c'est la position de départ
          {
            Debug.WriteLine("Déplacement de deux cases vers le haut valide (premier déplacement)");
            return true;
          }
        }
        // Pour les noirs (en bas de l'échiquier)
        else
        {
          Debug.WriteLine("Pion noir - Vérification déplacement vers le bas");
          
          // Déplacement d'une case vers le bas
          if (x2 == x1 + 1)
          {
            Debug.WriteLine("Déplacement d'une case vers le bas valide");
            return true;
          }
          // Premier déplacement de deux cases vers le bas
          if (x1 == 1 && x2 == x1 + 2) // Vérifie si c'est la position de départ
          {
            Debug.WriteLine("Déplacement de deux cases vers le bas valide (premier déplacement)");
            return true;
          }
        }
      }
      
      // Prise en diagonale d'une case
      if (Math.Abs(x2 - x1) == 1 && Math.Abs(y2 - y1) == 1)
      {
        Debug.WriteLine("Tentative de prise en diagonale détectée");
        // Vérifier que la case de destination contient bien une pièce adverse
        if (pieceDestination != null && pieceDestination.Couleur != this.Couleur)
        {
          Debug.WriteLine("Prise en diagonale valide");
          return true;
        }
      }

      Debug.WriteLine("Aucun déplacement valide détecté");
      return false;
    }
  }
}
