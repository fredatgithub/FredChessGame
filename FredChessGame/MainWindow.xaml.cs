using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace FredChessGame
{
  /// <summary>
  /// Logique d'interaction pour MainWindow.xaml
  /// </summary>
  public partial class MainWindow: Window
  {
    private const string WindowSettingsFile = "window_settings.json";

    public MainWindow()
    {
      InitializeComponent();
      LoadWindowSettings();
      this.Closing += MainWindow_Closing;
    }

    private void LoadWindowSettings()
    {
      try
      {
        if (File.Exists(WindowSettingsFile))
        {
          var json = File.ReadAllText(WindowSettingsFile);
          var settings = JsonSerializer.Deserialize<WindowSettings>(json);

          if (settings != null)
          {
            // Vérifier si la fenêtre est toujours visible sur un écran
            var screenWidth = SystemParameters.VirtualScreenWidth;
            var screenHeight = SystemParameters.VirtualScreenHeight;

            // Ajuster la position si nécessaire pour s'assurer que la fenêtre est visible
            var left = Math.Max(0, Math.Min(settings.Left, screenWidth - 100));
            var top = Math.Max(0, Math.Min(settings.Top, screenHeight - 100));

            this.Left = left;
            this.Top = top;
            this.Width = Math.Max(MinWidth, Math.Min(settings.Width, screenWidth - left));
            this.Height = Math.Max(MinHeight, Math.Min(settings.Height, screenHeight - top));
            this.WindowState = settings.WindowState;
          }
        }
      }
      catch (Exception ex)
      {
        // En cas d'erreur, on utilise les valeurs par défaut
        Console.WriteLine($"Erreur lors du chargement des paramètres de la fenêtre: {ex.Message}");
      }
    }

    private void SaveWindowSettings()
    {
      try
      {
        var settings = new WindowSettings
        {
          Left = this.RestoreBounds.Left,
          Top = this.RestoreBounds.Top,
          Width = this.RestoreBounds.Width,
          Height = this.RestoreBounds.Height,
          WindowState = this.WindowState == WindowState.Maximized ? WindowState.Maximized : WindowState.Normal
        };

        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(WindowSettingsFile, json);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erreur lors de la sauvegarde des paramètres de la fenêtre: {ex.Message}");
      }
    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      SaveWindowSettings();
    }
  }

  public class WindowSettings
  {
    public double Left { get; set; }
    public double Top { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public WindowState WindowState { get; set; }
  }
}
