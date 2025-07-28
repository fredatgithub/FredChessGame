using System.ComponentModel;
using FredChessGame.Model;

namespace FredChessGame.ViewModel
{
  public class CaseViewModel: INotifyPropertyChanged
  {
    public int Ligne { get; }
    
    public int Colonne { get; }
    
    private Piece _piece;
    public (int Ligne, int Colonne) Position => (Ligne, Colonne);

    public Piece Piece
    {
      get => _piece;
      set
      {
        _piece = value;
        OnPropertyChanged(nameof(Piece));
        OnPropertyChanged(nameof(Symbole));
      }
    }

    public string Symbole => Piece?.Symbole ?? "";

    public CaseViewModel(int ligne, int colonne, Piece piece)
    {
      Ligne = ligne;
      Colonne = colonne;
      Piece = piece;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string prop)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
  }
}
