using System.Threading;
using System.Windows;

namespace EasyScadaApp
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

        #region Nút nhấn footer
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMayNghien_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Visible;
            KhoNghien.Visibility = Visibility.Hidden;
            MayEpVien.Visibility = Visibility.Hidden;
        }

        private void BtnKhoNghien_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghien.Visibility = Visibility.Visible;
            MayEpVien.Visibility = Visibility.Hidden;
        }

        private void BtnMayEp_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghien.Visibility = Visibility.Hidden;
            MayEpVien.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
