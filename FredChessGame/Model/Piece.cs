namespace FredChessGame.Model
{
  public enum PieceColor { Blanc, Noir }

  public abstract class Piece
  {
    public PieceColor Couleur { get; private set; }
    public abstract string Symbole { get; }

    public Piece(PieceColor couleur)
    {
      Couleur = couleur;
    }

    public abstract bool PeutSeDeplacer(int departX, int departY, int arriveeX, int arriveeY);
  }
}
