using System.Collections.ObjectModel;

namespace FredChessGame.ViewModel
{
  public class MainViewModel
  {
    public ObservableCollection<CaseViewModel> Cases { get; }

    public MainViewModel()
    {
      var plateau = new Plateau(); // ton modèle logique du jeu
      Cases = new ObservableCollection<CaseViewModel>();

      for (int row = 0; row < 8; row++)
      {
        for (int col = 0; col < 8; col++)
        {
          Cases.Add(new CaseViewModel(row, col, plateau.Cases[row, col]));
        }
      }
    }
  }
}
