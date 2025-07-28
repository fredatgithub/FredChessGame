namespace FredChessGame.Model
{
  public class Plateau
  {
    public Piece[,] Cases { get; } = new Piece[8, 8];

    public Plateau()
    {
      InitialiserPieces();
    }

    private void InitialiserPieces()
    {
      Cases[0, 4] = new Roi(PieceColor.Noir);
      Cases[7, 4] = new Roi(PieceColor.Blanc);
      Cases[0, 3] = new Reine(PieceColor.Noir);
      Cases[7, 3] = new Reine(PieceColor.Blanc);
    }
  }
}
