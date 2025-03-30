using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Tesseract;

namespace OCRApp
{
    public partial class MainWindow : Window
    {
        private string imagePath = "";
        private readonly string tessDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\tessdata");
        private Dictionary<string, (string text, bool isChecked)> checkboxValues = new Dictionary<string, (string, bool)>();
        private string selectedSeparator = "\n";
        private string selectedFileType = "txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Obrazy (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                imgDisplay.Source = new BitmapImage(new Uri(imagePath));
            }
        }

        private void StartOCR_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Wybierz najpierw obraz!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                LoadOCRResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd OCR: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadOCRResults()
        {
            checkboxPanel.Children.Clear();
            txtEdit.Clear();
            txtEdit.IsReadOnly = true;
            checkboxValues.Clear();

            using (var engine = new TesseractEngine(tessDataPath, "pol+eng", EngineMode.LstmOnly))
            using (var img = Pix.LoadFromFile(imagePath))
            using (var page = engine.Process(img))
            {
                string extractedText = page.GetText();
                string[] lines = extractedText.Split('\n');

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string trimmedLine = line.Trim();
                        checkboxValues[trimmedLine] = (trimmedLine, false);
                    }
                }
            }
            RefreshOCRList();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (txtEdit.Tag is string key)
            {
                checkboxValues[key] = (txtEdit.Text, checkboxValues[key].isChecked);
            }

            RefreshOCRList();
            MessageBox.Show("Zmiany zapisane i lista odświeżona!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string key)
            {
                txtEdit.IsReadOnly = false;
                txtEdit.Text = checkboxValues[key].text;
                txtEdit.Tag = key;
                checkboxValues[key] = (checkboxValues[key].text, true);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.Tag is string key)
            {
                checkboxValues[key] = (checkboxValues[key].text, false);
                txtEdit.IsReadOnly = true;
                txtEdit.Clear();
                txtEdit.Tag = null;
            }
        }

        private void RefreshOCRList()
        {
            checkboxPanel.Children.Clear();

            foreach (var kvp in checkboxValues)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = kvp.Value.text,
                    Tag = kvp.Key,
                    IsChecked = kvp.Value.isChecked
                };
                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;

                checkboxPanel.Children.Add(checkBox);
            }
        }

        private void SaveResults_Click(object sender, RoutedEventArgs e)
        {
            List<string> selectedLines = checkboxValues.Where(kvp => kvp.Value.isChecked)
                                                        .Select(kvp => kvp.Value.text)
                                                        .ToList();

            if (selectedLines.Count == 0)
            {
                MessageBox.Show("Brak zaznaczonych wyników do zapisania!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = selectedFileType == "csv" ? "Plik CSV (*.csv)|*.csv" : "Plik tekstowy (*.txt)|*.txt",
                FileName = selectedFileType == "csv" ? "OCR_Wyniki.csv" : "OCR_Wyniki.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string content = string.Join(selectedSeparator, selectedLines);
                File.WriteAllText(saveFileDialog.FileName, content);
                MessageBox.Show("Wyniki zapisane!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SeparatorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (separatorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Nowa linia":
                        selectedSeparator = "\n";
                        break;
                    case "Spacja":
                        selectedSeparator = " ";
                        break;
                    case ";":
                        selectedSeparator = ";";
                        break;
                    case ",":
                        selectedSeparator = ",";
                        break;
                }
            }
        }

        private void FileTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fileTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                selectedFileType = selectedItem.Content.ToString();
            }
        }
    }
}
