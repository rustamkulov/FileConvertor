using FileConvertor.Dtos.Login;
using FileConvertor.Integrated.Services.Login;
using System.Windows;

namespace FileConvertor.Desktop.Windows;

/// <summary>
/// Interaction logic for LoginWindow.xaml
/// </summary>
public partial class LoginWindow : Window
{
    private readonly LoginService _service;

    public LoginWindow()
    {
        InitializeComponent();
        this._service = new LoginService();
    }


    private void showPassword_Click(object sender, RoutedEventArgs e)
    {
        if (textboxParolText.Visibility == Visibility.Collapsed)
        {
            showPassword.Style = (Style)FindResource("showPasswordCrosButton");
            textboxParolText.Text = textboxParol.Password;
            textboxParol.Visibility = Visibility.Collapsed;
            textboxParolText.Visibility = Visibility.Visible;
        }
        else
        {
            showPassword.Style = (Style)FindResource("showPasswordButton");
            textboxParol.Password = textboxParolText.Text;
            textboxParolText.Visibility = Visibility.Collapsed;
            textboxParol.Visibility = Visibility.Visible;
        }
    }

    private async void LoginBtn_Click(object sender, RoutedEventArgs e)
    {
        if (textboxParolText.Visibility == Visibility.Collapsed)
        {
            textboxParolText.Text = textboxParol.Password;
        }
        else
        {
            textboxParol.Password = textboxParolText.Text;
        }
        int count = 0;
        if (!textboxEmail.Text.EndsWith("@gmail.com"))
        {
            count++;
        }
        else
            MessageBox.Show("Emailingizni to'liq kiriting");
        if (textboxParol.Password.ToString().Length >= 8 && textboxParol.Password.ToString().Length <= 32)
        {
            count++;
        }
        else
            MessageBox.Show("Parol 8 ta belgidan kam bolmasligi kerak");
        if (count == 2)
        {
            LoginDto loginDto = new LoginDto()
            {
                Email = textboxEmail.Text,
                Password = textboxParol.Password
            };

            bool response = await _service.Login(loginDto);

            if (response)
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bunday user mavjud emas");
            }
        }

    }
}
