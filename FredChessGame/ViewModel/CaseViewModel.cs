using System.ComponentModel;
using System.Windows.Media;
using FredChessGame.Model;

namespace FredChessGame.ViewModel
{
    public class CaseViewModel : INotifyPropertyChanged
    {
        public int Ligne { get; }
        public int Colonne { get; }
        
        private Piece _piece;
        private bool _isSelected;
        private bool _isHighlighted;
        private static readonly SolidColorBrush LightSquare = new SolidColorBrush(Color.FromRgb(240, 217, 181));
        private static readonly SolidColorBrush DarkSquare = new SolidColorBrush(Color.FromRgb(181, 136, 99));
        private static readonly SolidColorBrush SelectedColor = new SolidColorBrush(Color.FromRgb(247, 247, 105));
        private static readonly SolidColorBrush HighlightColor = new SolidColorBrush(Color.FromRgb(247, 247, 128));//105 ou 128

        public (int Ligne, int Colonne) Position => (Ligne, Colonne);

        public Piece Piece
        {
            get => _piece;
            set
            {
                _piece = value;
                OnPropertyChanged(nameof(Piece));
                OnPropertyChanged(nameof(Symbole));
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        public string Symbole => Piece?.Symbole ?? "";

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }

        public bool IsHighlighted
        {
            get => _isHighlighted;
            set
            {
                if (_isHighlighted != value)
                {
                    _isHighlighted = value;
                    OnPropertyChanged(nameof(IsHighlighted));
                    OnPropertyChanged(nameof(BackgroundColor));
                }
            }
        }

        public Brush BackgroundColor
        {
            get
            {
                if (IsSelected)
                    return SelectedColor;
                if (IsHighlighted)
                    return HighlightColor;
                return (Ligne + Colonne) % 2 == 0 ? LightSquare : DarkSquare;
            }
        }

        public CaseViewModel(int ligne, int colonne, Piece piece)
        {
            Ligne = ligne;
            Colonne = colonne;
            Piece = piece;
            IsSelected = false;
            IsHighlighted = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
