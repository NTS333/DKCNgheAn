using EasyScada.Wpf.Controls;
using System;
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

            _timer.Interval = 100;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            //DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            //{
            //    labThoiGian.Content = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            //}));
            Dispatcher.Invoke(() =>
            {
                labThoiGian.Content = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            });
            _timer.Enabled = true;
        }

        System.Timers.Timer _timer = new System.Timers.Timer();

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
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
        }

        private void BtnKhoNghien_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghien.Visibility = Visibility.Visible;
            MayEpVien.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
        }

        private void BtnMayEp_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghien.Visibility = Visibility.Hidden;
            MayEpVien.Visibility = Visibility.Visible;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
        }
        #endregion

        private void BtnKhoNghienTinhGiuBui_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghien.Visibility = Visibility.Hidden;
            MayEpVien.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Visible;
        }
    }
}
