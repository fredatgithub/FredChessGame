using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using FredChessGame.Model;
using System.Linq;
using System;

namespace FredChessGame.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<CaseViewModel> Cases { get; }
        private CaseViewModel _selectedCase;
        private Plateau _plateau;

        public ICommand CaseClickCommand { get; }

        public MainViewModel()
        {
            _plateau = new Plateau();
            Cases = new ObservableCollection<CaseViewModel>();
            InitializeBoard();
            CaseClickCommand = new RelayCommand<CaseViewModel>(OnCaseClicked);
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Cases.Add(new CaseViewModel(row, col, _plateau.Cases[row, col]) 
                    { 
                        IsSelected = false,
                        IsHighlighted = false
                    });
                }
            }
        }

        private void OnCaseClicked(CaseViewModel clickedCase)
        {
            // Si aucune case n'est sélectionnée et qu'on clique sur une pièce
            if (_selectedCase == null && clickedCase.Piece != null)
            {
                // Désélectionner toutes les cases
                ClearSelections();
                
                // Sélectionner la case cliquée
                _selectedCase = clickedCase;
                _selectedCase.IsSelected = true;
                
                // Mettre en surbrillance les mouvements possibles
                HighlightPossibleMoves(clickedCase);
            }
            // Si une case est déjà sélectionnée et qu'on clique sur une autre case
            else if (_selectedCase != null)
            {
                // Si on clique sur une pièce de la même couleur, on change la sélection
                if (clickedCase.Piece != null && 
                    clickedCase.Piece.Couleur == _selectedCase.Piece?.Couleur)
                {
                    ClearSelections();
                    _selectedCase = clickedCase;
                    _selectedCase.IsSelected = true;
                    HighlightPossibleMoves(clickedCase);
                }
                // Sinon, on tente de déplacer la pièce
                else
                {
                    if (TryMovePiece(_selectedCase, clickedCase))
                    {
                        // Déplacement réussi
                        ClearSelections();
                    }
                    else
                    {
                        // Déplacement invalide, on ne fait rien ou on affiche un message
                        MessageBox.Show("Mouvement invalide !", "Erreur", 
                                      MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private bool TryMovePiece(CaseViewModel fromCase, CaseViewModel toCase)
        {
            Console.WriteLine($"Tentative de déplacement de ({fromCase.Ligne},{fromCase.Colonne}) vers ({toCase.Ligne},{toCase.Colonne})");
            Console.WriteLine($"Pièce source: {fromCase.Piece?.GetType().Name} {fromCase.Piece?.Couleur}");
            Console.WriteLine($"Pièce destination: {toCase.Piece?.GetType().Name} {toCase.Piece?.Couleur}");
            
            // Vérifier si le déplacement est valide selon les règles du jeu
            bool peutSeDeplacer = fromCase.Piece.PeutSeDeplacer(
                fromCase.Ligne, 
                fromCase.Colonne, 
                toCase.Ligne, 
                toCase.Colonne,
                toCase.Piece); // Passer la pièce de destination
                
            Console.WriteLine($"Peut se déplacer: {peutSeDeplacer}");
            
            if (peutSeDeplacer)
            {
                // Vérifier s'il y a une pièce sur la case d'arrivée
                if (toCase.Piece != null)
                {
                    // Vérifier que ce n'est pas une pièce de la même couleur
                    if (toCase.Piece.Couleur == fromCase.Piece.Couleur)
                    {
                        Console.WriteLine("Erreur: Pièce de même couleur sur la case de destination");
                        return false;
                    }
                    
                    // Manger la pièce adverse
                    toCase.Piece = null;
                }

                // Déplacer la pièce
                toCase.Piece = fromCase.Piece;
                fromCase.Piece = null;
                
                Console.WriteLine("Déplacement réussi");
                return true;
            }
            
            Console.WriteLine("Le déplacement n'est pas valide selon les règles du jeu");
            return false;
        }

        private void HighlightPossibleMoves(CaseViewModel selectedCase)
        {
            foreach (var caseVm in Cases)
            {
                caseVm.IsHighlighted = selectedCase.Piece.PeutSeDeplacer(
                    selectedCase.Ligne, selectedCase.Colonne,
                    caseVm.Ligne, caseVm.Colonne,
                    caseVm.Piece); // Passer la pièce de destination
            }
        }

        private void ClearSelections()
        {
            if (_selectedCase != null)
                _selectedCase.IsSelected = false;
                
            foreach (var caseVm in Cases)
            {
                caseVm.IsSelected = false;
                caseVm.IsHighlighted = false;
            }
            
            _selectedCase = null;
        }
    }
}
