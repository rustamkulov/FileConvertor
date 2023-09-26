using FileConvertor.Dtos.DocumentDto;
using FileConvertor.Integrated.Interfaces;
using FileConvertor.Integrated.Services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FileConvertor.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDocumentService _documentService;


    public string path = "";
    public int id;
    public MainWindow()
    {
        InitializeComponent();
        this._documentService = new DocumentService();
    }

    private OpenFileDialog GetFileDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        return openFileDialog;
    }

    private async void pdfBtn_Click(object sender, RoutedEventArgs e)
    {
        if (path != "" && path != null)
        {
            Button button = (Button)sender;
            if (button.Name == "pdfBtn")
            {
                id = 1;
            }
            else if (button.Name == "exelBtn")
            {
                id = 2;
            }
            else if (button.Name == "docBtn")
            {
                id = 3;
            }

            DocumentDto documentDto = new DocumentDto();
            documentDto.DocumentType = id.ToString();
            documentDto.Document = path;

            var response = await _documentService.CreateAsync(documentDto);
            if (response)
            {
                MessageBox.Show("Konvert qilindi!");
            }
            else
            {
                MessageBox.Show("Qandaydir xatolik mavjud!");
            }
        }
        else
        {
            MessageBox.Show("Mos fayl turini tanlang!");
        }
    }

    private void ChangeBtn_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = GetFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            string pathName = openFileDialog.FileName;
            string extension = System.IO.Path.GetExtension(pathName).ToLower();

            if (extension == ".pdf")
            {
                path = pathName;
            }
            else if (extension == ".docx" || extension == ".doc")
            {
                path = pathName;
            }
            else if (extension == ".xlsx" || extension == ".xls")
            {
                path = pathName;
            }
            else
            {
                MessageBox.Show("Mos fayl turini tanlang!");
            }
        }
    }
}
