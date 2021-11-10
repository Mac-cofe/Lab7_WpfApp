using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace Lab5_WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)        // гарнитура
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)        // кегль
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            double size = Convert.ToDouble(fontSize);
            if (textBox != null)
                textBox.FontSize = size;
        }

        private void Button_Click(object sender, RoutedEventArgs e)                //жирное начертание
        {
            if (textBox != null)
            {
                if (textBox.FontWeight == FontWeights.Normal)
                {
                    textBox.FontWeight = FontWeights.UltraBold;
                }
                else
                { textBox.FontWeight = FontWeights.Normal; }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)        // курсивное начертание
        {

            if (textBox != null)
            {
                if (textBox.FontStyle == FontStyles.Normal)
                {
                    textBox.FontStyle = FontStyles.Italic;
                }
                else
                { textBox.FontStyle = FontStyles.Normal; }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)                      // подчеркнутое начертание 
        {
            if (textBox != null)
            {
                if (textBox.TextDecorations == TextDecorations.Underline)
                {
                    {
                        //if (!textBox.TextDecorations.IsFrozen)                // неподчеркнутое
                        //    textBox.TextDecorations.Clear();
                    }
                }
                else
                { textBox.TextDecorations = TextDecorations.Underline; }

            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)          // черный цвет текста
        {
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)            // красный цвет текста
        {
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int x = random.Next(0, 255);
            int y = random.Next(0, 255);
            int z = random.Next(0, 255);
            if (textBox != null)
            {
                textBox.Foreground = new SolidColorBrush(Color.FromRgb((byte)x, (byte)y, (byte)z));
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

       
    }
}
