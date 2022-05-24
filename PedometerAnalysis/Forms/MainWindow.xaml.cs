using System.Windows;
using PedometerAnalysis.API;
namespace PedometerAnalysis.Forms;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = new ApplicationViewModel();
    }

}
