using System;
using System.Windows.Input;
using System.ComponentModel;

public class ChessViewModel: INotifyPropertyChanged
{
  public Plateau Plateau { get; } = new Plateau();

  private (int row, int col)? pieceSelectionnee = null;

  public ICommand CaseCliqueeCommand { get; }

  public ChessViewModel()
  {
    CaseCliqueeCommand = new RelayCommand(param => OnCaseCliquee(param));
  }

  private void OnCaseCliquee(object param)
  {
    var position = param as Tuple<int, int>;
    if (position == null)
        return;

    int row = position.Item1;
    int col = position.Item2;

    var piece = Plateau.Cases[row, col];

    // 1. Si aucune pièce sélectionnée
    if (pieceSelectionnee == null)
    {
      // On peut sélectionner une pièce seulement si elle appartient au joueur actuel
      if (piece != null && piece.Couleur == Plateau.JoueurActuel)
      {
        pieceSelectionnee = (row, col);
        // Ici tu peux déclencher une notification pour surligner
      }
    }
    else
    {
      var (selRow, selCol) = pieceSelectionnee.Value;
      var pieceSelec = Plateau.Cases[selRow, selCol];

      // Vérifier si le déplacement est valide
      if (pieceSelec != null && pieceSelec.PeutSeDeplacer(selRow, selCol, row, col))
      {
        Plateau.Cases[row, col] = pieceSelec;
        Plateau.Cases[selRow, selCol] = null;
        Plateau.ChangerDeJoueur(); // Changer de joueur
      }

      pieceSelectionnee = null;

      // Notifier la mise à jour de l'UI
      OnPropertyChanged(nameof(Plateau));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;
  protected virtual void OnPropertyChanged(string propName)
      => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}
