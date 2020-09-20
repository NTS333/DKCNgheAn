using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ucMayEpVien.xaml
    /// </summary>
    public partial class ucMayEpVien : UserControl
    {
        private bool isLoaded;

        public ucMayEpVien()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;

                #region Máy ép viên
                thongTinMayEp1.Header1 = "MÁY ÉP 1";
                thongTinMayEp1.Header2 = "CẤP LIỆU MÁY ÉP 1";
                thongTinMayEp1.StationName = "RemoteStation1";
                thongTinMayEp1.ChannelName = "PLCMayEpVien";
                thongTinMayEp1.DeviceName = "MayEpVien1";

                thongTinMayEp2.Header1 = "MÁY ÉP 2";
                thongTinMayEp2.Header2 = "CẤP LIỆU MÁY ÉP 2";
                thongTinMayEp2.StationName = "RemoteStation1";
                thongTinMayEp2.ChannelName = "PLCMayEpVien";
                thongTinMayEp2.DeviceName = "MayEpVien2";

                thongTinMayEp3.Header1 = "MÁY ÉP 3";
                thongTinMayEp3.Header2 = "CẤP LIỆU MÁY ÉP 3";
                thongTinMayEp3.StationName = "RemoteStation1";
                thongTinMayEp3.ChannelName = "PLCMayEpVien";
                thongTinMayEp3.DeviceName = "MayEpVien3";

                thongTinMayEp4.Header1 = "MÁY ÉP 4";
                thongTinMayEp4.Header2 = "CẤP LIỆU MÁY ÉP 4";
                thongTinMayEp4.StationName = "RemoteStation1";
                thongTinMayEp4.ChannelName = "PLCMayEpVien";
                thongTinMayEp4.DeviceName = "MayEpVien4";

                thongTinMayEp1.Start();
                thongTinMayEp2.Start();
                thongTinMayEp3.Start();
                thongTinMayEp4.Start();
                #endregion

                #region Phụ trợ máy ép viên
                thongTinSanLong.StationName = "RemoteStation1";
                thongTinSanLong.ChannelName = "PLCMayEpVien";
                thongTinSanLong.DeviceName = "PhuTroEpVien";

                thongTinSanLong.Start();
                #endregion

                #region Graphic
                MayEp.StationName = "RemoteStation1";
                MayEp.ChannelName = "PLCMayEpVien";
                MayEp.DeviceNameMayEp1 = "MayEpVien1";
                MayEp.DeviceNameMayEp2 = "MayEpVien2";
                MayEp.DeviceNameMayEp3 = "MayEpVien3";
                MayEp.DeviceNameMayEp4 = "MayEpVien4";

                MayEp.Start();
                #endregion
            }
        }

        private void UcDongCoChayDung_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
