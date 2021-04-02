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
    /// Interaction logic for ucKhoNghienTinh_GiuBui.xaml
    /// </summary>
    public partial class ucKhoNghienTinh_GiuBui : UserControl
    {
        public ucKhoNghienTinh_GiuBui()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;

            //Dat vi trí cho Control
            //Thickness oldMargin = ThongTinKhoNghienTinh.Margin;
            //ThongTinKhoNghienTinh.Margin = new Thickness(0, oldMargin.Top, 0, 0);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            #region Giũ bụi trung tâm
            giuBui.StationName = "RemoteStation1";
            giuBui.ChannelName = "PLC_GiuBuiEpVien";
            giuBui.DeviceName = "GiuBuiEpVien";

            giuBui.MotorRotovanClick += GiuBui_MotorRotovanClick;
            giuBui.MotorVitTaiClick += GiuBui_MotorVitTaiClick;
            //giuBui.MotorVitTaiUpdateClick += GiuBui_MotorVitTaiUpdateClick;
            giuBui.MotorQuatHutClick += GiuBui_MotorQuatHutClick;
            giuBui.GiuBuiClick += GiuBui_GiuBuiClick;

            giuBui.Start();
            #endregion

            #region kho nghien tinh
            thongTinKhoNghienTinh.StationName = "RemoteStation1";
            thongTinKhoNghienTinh.ChannelName = "PLC_KhoNghienTinh";
            thongTinKhoNghienTinh.DeviceName = "KhoNghienTinh";
            thongTinKhoNghienTinh.Header = "Trạng Thái Hoạt Động";
            thongTinKhoNghienTinh.Start();

            khoNghienTinh.StationName = "RemoteStation1";
            khoNghienTinh.ChannelName = "PLC_KhoNghienTinh";
            khoNghienTinh.DeviceName = "KhoNghienTinh";

            khoNghienTinh.MotorBomDauClick += KhoNghienTinh_MotorBomDauClick;
            //khoNghienTinh.MotorVTRLClick += KhoNghienTinh_MotorVTRLClick;
            khoNghienTinh.MotorVTCLClick += KhoNghienTinh_MotorVTCLClick;
            khoNghienTinh.Xilanh1Click += KhoNghienTinh_Xilanh1Click;
            khoNghienTinh.Xilanh2Click += KhoNghienTinh_Xilanh2Click;
            khoNghienTinh.MotorAirLockLClick += KhoNghienTinh_MotorAirLockLClick;

            khoNghienTinh.Start();
            #endregion

            #region Máy ép viên
            thongTinMayEp1.Header1 = "MÁY ÉP 1";
            thongTinMayEp1.Header2 = "CẤP LIỆU MÁY ÉP 1";
            thongTinMayEp1.StationName = "RemoteStation1";
            thongTinMayEp1.ChannelName = "PLC_EpVien";
            thongTinMayEp1.DeviceName = "EpVien1";

            thongTinMayEp2.Header1 = "MÁY ÉP 2";
            thongTinMayEp2.Header2 = "CẤP LIỆU MÁY ÉP 2";
            thongTinMayEp2.StationName = "RemoteStation1";
            thongTinMayEp2.ChannelName = "PLC_EpVien";
            thongTinMayEp2.DeviceName = "EpVien2";

            thongTinMayEp1.Start();
            thongTinMayEp2.Start();
            #endregion

            #region Phụ trợ máy ép viên
            thongTinPhuTroEpVien.StationName = "RemoteStation1";
            thongTinPhuTroEpVien.ChannelName = "PLC_PTEV";
            thongTinPhuTroEpVien.DeviceName = "PTEV";

            thongTinPhuTroEpVien.Start();

            phuTroEpVien.StationName = "RemoteStation1";
            phuTroEpVien.ChannelName = "PLC_PTEV";
            phuTroEpVien.DeviceName = "PTEV";

            phuTroEpVien.MotorPT4Click += PhuTroEpVien_MotorPT4Click;
            phuTroEpVien.MotorPT5Click += PhuTroEpVien_MotorPT5Click;
            phuTroEpVien.MotorPT6Click += PhuTroEpVien_MotorPT6Click;
            phuTroEpVien.MotorPT8Click += PhuTroEpVien_MotorPT8Click;

            phuTroEpVien.Start();

            thongTinCanPTEV.StationName = "RemoteStation1";
            thongTinCanPTEV.ChannelName = "PLC_PTEV";
            thongTinCanPTEV.DeviceName = "PTEV";

            thongTinCanPTEV.Start();
            #endregion


            #region Hệ làm mát
         

            #endregion
            #region Graphic
            mayEpVien.StationName = "RemoteStation1";
            mayEpVien.ChannelName = "PLC_EpVien";
            mayEpVien.DeviceNameMayEp1 = "EpVien1";
            mayEpVien.DeviceNameMayEp2 = "EpVien2";
            mayEpVien.DeviceNamePhuTroEpVien = "PTEV";

            mayEpVien.MotorMayEpVien1Click += MayEpVien_MotorMayEpVien1Click;
            mayEpVien.MotorB1Click += MayEpVien_MotorB1Click;
            mayEpVien.MotorA11Click += MayEpVien_MotorA11Click;
            mayEpVien.MotorA12Click += MayEpVien_MotorA12Click;
            mayEpVien.MotorMixer1Click += MayEpVien_MotorMixer1Click;

            mayEpVien.MotorMayEpVien2Click += MayEpVien_MotorMayEpVien2Click;
            mayEpVien.MotorB2Click += MayEpVien_MotorB2Click;
            mayEpVien.MotorA21Click += MayEpVien_MotorA21Click;
            mayEpVien.MotorA22Click += MayEpVien_MotorA22Click;
            mayEpVien.MotorMixer2Click += MayEpVien_MotorMixer2Click;

            mayEpVien.MotorPT1Click += MayEpVien_MotorPT1Click;
            mayEpVien.MotorPT2Click += MayEpVien_MotorPT2Click;
            mayEpVien.MotorPT3Click += MayEpVien_MotorPT3Click;

            mayEpVien.Start();
            #endregion

            thongTinMayNghienTinh.StationName = "RemoteStation1";
            thongTinMayNghienTinh.ChannelName = "PLC_MayNghienTinh";
            thongTinMayNghienTinh.DeviceName = "MayNghienTinh1";

            mayNghienTinh.StationName = "RemoteStation1";
            mayNghienTinh.ChannelName = "PLC_MayNghienTinh";
            mayNghienTinh.DeviceName = "MayNghienTinh1";
            mayNghienTinh.MotorVitTaiClick += OnVitTaiClick;
            mayNghienTinh.MotorMayNghienClick += OnMotorMayNghienClick;
            mayNghienTinh.MotorQuatHutClick += OnMotorQuatHutClick;

            thongTinMayNghienTinh.Start();
            mayNghienTinh.Start();
        }


        #region Method of event kho nghien tinh
        private void KhoNghienTinh_MotorAirLockLClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLC_EpVien";
                string deviceName = "EpVien1";

                string autoTagName = null;
                string manualTagName = null;
                string cheDo3TagName = null;


                string motorName = "AirLock";
                string onMotorTagName = "SW_AirLock_Ntinh";
                string offMotorTagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_AirLock_NTinh";
                string statusAutoTagName = null ;
                string statusManualTagName = null;
                string statusCheDo3TagName = null;

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);
                //clickPoint.Offset(1920,0);
                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                     cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTinh_Xilanh2Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLC_KhoNghienTinh";
                string deviceName = "KhoNghienTinh";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "XiLanh";
                string onMotorTagName = "BT_XiLanh2Tien";
                string offMotorTagName = "BT_XiLanh2Lui";
                string statusOffMotorTagName = "ST_XiLanh2Lui";
                string statusOnMotorTagName = "ST_XiLanh2Tien";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                     cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTinh_Xilanh1Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoNghienTinh";
                string deviceName = "KhoNghienTinh";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "XiLanh";
                string onMotorTagName = "BT_XiLanh1Tien";
                string offMotorTagName = "BT_XiLanh1Lui";
                string statusOffMotorTagName = "ST_XiLanh1Lui";
                string statusOnMotorTagName = "ST_XiLanh1Tien";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                    cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                    statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTinh_MotorVTCLClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoNghienTinh";
                string deviceName = "KhoNghienTinh";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "VTCL";
                string onMotorTagName = "BT_BatVTCLThuan1";
                string offMotorTagName = "BT_BatVTCLNghich1";
                string statusOffMotorTagName = "ST_VitTai1Nghich";
                string statusOnMotorTagName = "ST_VitTai1Thuan";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                    cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                    statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTinh_MotorVTRLClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoNghienTinh";
                string deviceName = "KhoNghienTinh";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "VTRL";
                string onMotorTagName = "BT_BatVTRL";
                string offMotorTagName = null;//Don't use
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "ST_VTRL";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                    cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                    statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTinh_MotorBomDauClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoNghienTinh";
                string deviceName = "KhoNghienTinh";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "BomDau";
                string onMotorTagName = "BT_BatBomDau1";
                string offMotorTagName = null;

                string statusOffMotorTagName = null;//don't use
                string statusOnMotorTagName = "ST_Pump1";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "Bảng điều khiển - Kho Nghien Tinh";

                Point clickPoint = args.GetPosition(this.khoNghienTinh);

                Point p = this.khoNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                    cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                    statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }
        #endregion

        private void GiuBui_GiuBuiClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "GiuBuiEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";
                string title = "Bảng điều khiển - Giũ Bụi Ép Viên";

                string motorName = "GiuBui";
                string onMotorTagName = "BT_Start_GB";
                string offMotorTagName = "BT_Stop_GB";
                string offMotorMNTagName = null;

                string statusAlarmtagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_GB";
                string statusAutoTagName = null;
                string statusManualTagName = null;

                Point clickPoint = args.GetPosition(this.giuBui);

                Point p = this.giuBui.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                    onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void GiuBui_MotorQuatHutClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "GiuBuiEpVien";

                string resetAlarmTagName = null;
                string autoTagName = null;
                string manualTagName = null;

                string title = "Bảng điều khiển - Giũ Bụi Ép Viên";

                string motorName = "MotorQHGB";
                string onMotorTagName = "BT_Start_QHGB";
                string offMotorTagName = "BT_Stop_QHGB";
                string offMotorMNTagName = null;

                string statusAlarmtagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_QHGB";
                string statusAutoTagName = null;
                string statusManualTagName = null;

                Point clickPoint = args.GetPosition(this.giuBui);

                Point p = this.giuBui.PointToScreen(clickPoint);
                p.Offset(-250, 0);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void GiuBui_MotorVitTaiUpdateClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "GiuBuiEpVien";

                string resetAlarmTagName = null;
                string autoTagName = null;
                string manualTagName = null;

                string title = "Bảng điều khiển - Giũ Bụi Ép Viên";

                string motorName = "MotorVTGB";
                string onMotorTagName = "BT_Start_VTGB";
                string offMotorTagName = "BT_Stop_VTGB";
                string offMotorMNTagName = null;

                string statusAlarmtagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "ST_VTGB_UPdate";
                string statusAutoTagName = null;
                string statusManualTagName = null;

                Point clickPoint = args.GetPosition(this.giuBui);

                Point p = this.giuBui.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void GiuBui_MotorVitTaiClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "GiuBuiEpVien";

                string resetAlarmTagName = null;
                string autoTagName = null;
                string manualTagName = null;

                string title = "Bảng điều khiển - Giũ Bụi Ép Viên";

                string motorName = "MotorVTGB";
                string onMotorTagName = "BT_Start_VTGB";
                string offMotorTagName = "BT_Stop_VTGB";
                string offMotorMNTagName = null;

                string statusAlarmtagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_VTGB";
                string statusAutoTagName = null;
                string statusManualTagName = null;

                Point clickPoint = args.GetPosition(this.giuBui);

                Point p = this.giuBui.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void GiuBui_MotorRotovanClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "GiuBuiEpVien";

                string resetAlarmTagName = null;
                string autoTagName = null;
                string manualTagName = null;

                string title = "Bảng điều khiển - Giũ Bụi Ép Viên";

                string motorName = "MotorRotovan";
                string onMotorTagName = "BT_Start_AirGB";
                string offMotorTagName = "BT_Stop_AirGB";
                string offMotorMNTagName = null;

                string statusAlarmtagName = null;
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_AirGB";
                string statusAutoTagName = null;
                string statusManualTagName = null;

                Point clickPoint = args.GetPosition(this.giuBui);

                Point p = this.giuBui.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                    onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void PhuTroEpVien_MotorPT8Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT8";
                string onMotorTagName = "BT_Start_PT8";
                string offMotorTagName = "BT_Stop_PT8";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT8";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.phuTroEpVien);

                Point p = this.phuTroEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void PhuTroEpVien_MotorPT6Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT6";
                string onMotorTagName = "BT_Start_PT6";
                string offMotorTagName = "BT_Stop_PT6";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT6";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.phuTroEpVien);

                Point p = this.phuTroEpVien.PointToScreen(clickPoint);
                p.Offset(0, -150);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void PhuTroEpVien_MotorPT5Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT5";
                string onMotorTagName = "BT_Start_PT5";
                string offMotorTagName = "BT_Stop_PT5";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT5";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.phuTroEpVien);

                Point p = this.phuTroEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void PhuTroEpVien_MotorPT4Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT4";
                string onMotorTagName = "BT_Start_PT4";
                string offMotorTagName = "BT_Stop_PT4";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT4";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.phuTroEpVien);

                Point p = this.phuTroEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorPT3Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT3";
                string onMotorTagName = "BT_Start_PT3";
                string offMotorTagName = "BT_Stop_PT3";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT3";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);
                //clickPoint.Y = clickPoint.Y - 200;
                p.Offset(0, -150);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorPT2Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT2";
                string onMotorTagName = "BT_Start_PT2";
                string offMotorTagName = "BT_Stop_PT2";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT2";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                    onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorPT1Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "PhuTroEpVien";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Phụ Trợ Ép Viên";

                string motorName = "MotorPT1";
                string onMotorTagName = "BT_Start_PT1";
                string offMotorTagName = "BT_Stop_PT1";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_PT11";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorMixer2Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien2";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 2";

                string motorName = "MotorMixer2";
                string onMotorTagName = "BT_Start_MX";
                string offMotorTagName = "BT_Stop_MX";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_MX";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorA22Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien2";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 2";

                string motorName = "MotorA22";
                string onMotorTagName = "BT_Start_A2";
                string offMotorTagName = "BT_Stop_A2";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_A2";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorA21Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien2";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";

                string title = "Bảng điều khiển - Máy Ép Viên 2";

                string motorName = "MotorA21";
                string onMotorTagName = "BT_Start_A1";
                string offMotorTagName = "BT_Stop_A1";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_A1";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorB2Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien2";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 2";

                string motorName = "MotorB2";
                string onMotorTagName = "BT_Start_B";
                string offMotorTagName = "BT_Stop_B";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_B";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorMayEpVien2Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien2";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 2";

                string motorName = "MayEpVien";
                string onMotorTagName = "BT_Start_M";
                string offMotorTagName = "BT_Stop_M";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_M";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorMixer1Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien1";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 1";

                string motorName = "MotorMixer1";
                string onMotorTagName = "BT_Start_MX";
                string offMotorTagName = "BT_Stop_MX";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_MX";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorA12Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien1";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 1";

                string motorName = "MotorA12";
                string onMotorTagName = "BT_Start_A12";
                string offMotorTagName = "BT_Stop_A12";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_A2";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorA11Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien1";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 1";

                string motorName = "MotorA11";
                string onMotorTagName = "BT_Start_A1";
                string offMotorTagName = "BT_Stop_A1";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_A1";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorB1Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien1";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 1";

                string motorName = "MotorB1";
                string onMotorTagName = "BT_Start_B";
                string offMotorTagName = "BT_Stop_B";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_B";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void MayEpVien_MotorMayEpVien1Click(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayEpVien1";

                string resetAlarmTagName = "BT_RST_EV";
                string autoTagName = "SW_Auto_EV";
                string manualTagName = "SW_Man_EV";


                string title = "Bảng điều khiển - Máy Ép Viên 1";

                string motorName = "MayEpVien";
                string onMotorTagName = "BT_Start_M";
                string offMotorTagName = "BT_Stop_M";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "PL_OVL_M";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_M";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayEpVien);

                Point p = this.mayEpVien.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void OnVitTaiClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayNghienTinh1";
                string resetAlarmTagName = "BT_RST_MN";
                string autoTagName = "SW_Auto_MN";
                string manualTagName = "SW_Man_MN";


                string title = "Bảng điều khiển - Nghiền tinh";

                string motorName = "BTCapLieu";
                string onMotorTagName = "BT_Start_Btai";
                string offMotorTagName = "BT_Stop_Btai";
                string offMotorMNTagName = null;

                string statusAlarmtagName = "Alarm_HT";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_Btai";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayNghienTinh);

                Point p = this.mayNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void OnMotorMayNghienClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayNghienTinh1";
                string resetAlarmTagName = "BT_RST_MN";
                string autoTagName = "SW_Auto_MN";
                string manualTagName = "SW_Man_MN";


                string title = "Bảng điều khiển - Nghiền tinh";

                string motorName = "MayNghien";
                string onMotorTagName = "BT_Start_FW_MN";
                string offMotorTagName = "BT_Start_RV_MN";
                string offMotorMNTagName = "BT_Stop_MN";

                string statusAlarmtagName = "Alarm_HT";
                string statusOffMotorTagName = "PL_RV_MN";
                string statusOnMotorTagName = "PL_FW_MN";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayNghienTinh);

                Point p = this.mayNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void OnMotorQuatHutClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCNghien_EpVien";
                string deviceName = "MayNghienTinh1";

                string autoTagName = "SW_Auto_MN";
                string manualTagName = "SW_Man_MN";


                string title = "Bảng điều khiển - Nghiền tinh";

                string motorName = "QuatHut";
                string onMotorTagName = "BT_Start_Qhut";
                string offMotorTagName = "BT_Stop_Qhut";
                string offMotorMNTagName = null;
                string resetAlarmTagName = "BT_RST_MN";

                string statusAlarmtagName = "Alarm_HT";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_Qhut";
                string statusAutoTagName = "PL_Auto"; ;
                string statusManualTagName = "PL_Manual";

                Point clickPoint = args.GetPosition(this.mayNghienTinh);

                Point p = this.mayNghienTinh.PointToScreen(clickPoint);

                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }
    }
}
