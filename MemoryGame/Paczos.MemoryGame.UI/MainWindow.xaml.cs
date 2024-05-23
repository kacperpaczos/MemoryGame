using System.Windows;
using System.Windows.Navigation;
using Paczos.MemoryGame.UI.Views;

namespace Paczos.MemoryGame.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainMenu());
        }
    }
}