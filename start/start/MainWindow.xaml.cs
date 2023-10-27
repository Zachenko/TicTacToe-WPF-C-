using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Dane z Formułarza do zapisu";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "pliki tekstów (*.txt) | *txt";


            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                string dane = zapiszDane();
                System.IO.File.WriteAllText(filePath, dane);
            }
        }

        private string zapiszDane()
        {
            string? selectedCombo = ((ComboBoxItem)ComboBox.SelectedItem).Content.ToString();
            string? selectedRadio;

            if (afryka.IsChecked == true) selectedRadio = afryka.Content.ToString();
            else if (azja.IsChecked == true) selectedRadio = azja.Content.ToString();
            else if (australia.IsChecked == true) selectedRadio = australia.Content.ToString();
            else selectedRadio = "Min nie wybrano";

            DateTime? selectedDate = dataNarodzienia.SelectedDate;
            alert.Text = selectedDate.ToString();
            string dataNarodzieniaString = selectedDate.HasValue ? selectedDate.Value.ToString() : "brak daty";

            string textSuwaka = suwak.Value.ToString();

            return $"— combobox: {selectedCombo} \n— radio: {selectedRadio}\ndata narodzenia: {dataNarodzieniaString}\nSuwak: {textSuwaka}";
        }
    }
}
