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

                //#region Máy ép viên
                //thongTinMayEp1.Header1 = "MÁY ÉP 1";
                //thongTinMayEp1.Header2 = "CẤP LIỆU MÁY ÉP 1";
                //thongTinMayEp1.StationName = "RemoteStation1";
                //thongTinMayEp1.ChannelName = "PLCNghien_EpVien";
                //thongTinMayEp1.DeviceName = "MayEpVien1";

                //thongTinMayEp2.Header1 = "MÁY ÉP 2";
                //thongTinMayEp2.Header2 = "CẤP LIỆU MÁY ÉP 2";
                //thongTinMayEp2.StationName = "RemoteStation1";
                //thongTinMayEp2.ChannelName = "PLCNghien_EpVien";
                //thongTinMayEp2.DeviceName = "MayEpVien2";

                //thongTinMayEp1.Start();
                //thongTinMayEp2.Start();
                //#endregion

                //#region Phụ trợ máy ép viên
                //thongTinSanLong.StationName = "RemoteStation1";
                //thongTinSanLong.ChannelName = "PLCNghien_EpVien";
                //thongTinSanLong.DeviceName = "PhuTroEpVien";

                //thongTinSanLong.Start();

                //phuTroMayEpVien.StationName = "RemoteStation1";
                //phuTroMayEpVien.ChannelName = "PLCNghien_EpVien";
                //phuTroMayEpVien.DeviceName = "PhuTroEpVien";

                //phuTroMayEpVien.Start();
                //#endregion

                //#region Graphic
                //MayEp.StationName = "RemoteStation1";
                //MayEp.ChannelName = "PLCNghien_EpVien";
                //MayEp.DeviceNameMayEp1 = "MayEpVien1";
                //MayEp.DeviceNameMayEp2 = "MayEpVien2";

                //MayEp.Start();
                //#endregion
            }
        }

        private void UcDongCoChayDung_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
