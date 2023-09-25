using System.Windows;
using System.Windows.Controls;

namespace FileConvertor.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public int id;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void pdfBtn_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender; 
        if(button.Content == "PDF")
        {
            id = 1;
        }
        else if(button.Content == "EXEL")
        {
            id = 2;
        }
        else if (button.Content == "Document")
        {
            id = 3;
        }

        
    }
}
