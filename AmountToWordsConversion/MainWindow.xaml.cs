using System;
using System.Windows;
using System.Windows.Input;

namespace AmountToWordsConversion
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

        private void Textbox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key == Key.OemComma || e.Key == Key.D0 ||
                e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 ||
                e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string amount = Textbox1.Text;

            ServiceReference1.Service1Client service1 = new ServiceReference1.Service1Client();
            string wordsConversion = service1.ConvertAmountData(amount);

            MessageBox.Show(wordsConversion);
        }
    }
}
