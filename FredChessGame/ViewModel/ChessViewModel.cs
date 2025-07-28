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
    if (param is not Tuple<int, int> position)
      return;

    int row = position.Item1;
    int col = position.Item2;

    var piece = Plateau.Cases[row, col];

    // 1. Si aucune pièce sélectionnée
    if (pieceSelectionnee == null)
    {
      if (piece != null)
      {
        pieceSelectionnee = (row, col);
        // Ici tu peux déclencher une notification pour surligner
      }
    }
    else
    {
      var (selRow, selCol) = pieceSelectionnee.Value;
      var pieceSelec = Plateau.Cases[selRow, selCol];

      // Vérifier si le déplacement est valide (simple pour l'exemple)
      if (pieceSelec != null && pieceSelec.PeutSeDeplacer(selRow, selCol, row, col))
      {
        Plateau.Cases[row, col] = pieceSelec;
        Plateau.Cases[selRow, selCol] = null;
      }

      pieceSelectionnee = null;

      // Ici notifier la mise à jour de l'UI
      OnPropertyChanged(nameof(Plateau));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;
  protected virtual void OnPropertyChanged(string propName)
      => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}
