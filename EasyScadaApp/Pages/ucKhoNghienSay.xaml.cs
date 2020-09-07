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

namespace EasyScadaApp.Pages
{
    /// <summary>
    /// Interaction logic for ucKhoNghienSay.xaml
    /// </summary>
    public partial class ucKhoNghienSay : UserControl
    {
        private bool isLoaded;

        public ucKhoNghienSay()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;

                #region KHO NGHIỀN THÔ
                thongTinKhoNghienTho.Header = "KHO NGHIỀN THÔ";
                thongTinKhoNghienTho.StationName = "RemoteStation1";
                thongTinKhoNghienTho.ChannelName = "PLCKhoNghienTho";
                thongTinKhoNghienTho.DeviceName = "KhoNghienTho";

                thongTinKhoNghienTho.Start();
                #endregion

                #region KHO NGHIỀN THÔ
                thongTinKhoSauSay.Header = "KHO SAU SẤY";
                thongTinKhoSauSay.StationName = "RemoteStation1";
                thongTinKhoSauSay.ChannelName = "PLCKhoSauSay";
                thongTinKhoSauSay.DeviceName = "KhoSauSay";

                thongTinKhoSauSay.Start();
                #endregion

                #region Giũ bụi trung tâm
                giuBuiTrungTam.StationName = "RemoteStation1";
                giuBuiTrungTam.ChannelName = "PLCMayEpVien";
                giuBuiTrungTam.DeviceName = "GiuBuiEpVien";

                giuBuiTrungTam.Start();
                #endregion
            }
        }
    }
}
