
using EasyScada.Core;
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
using WPFUserControl;

namespace EasyScadaApp.Pages
{
    /// <summary>
    /// Interaction logic for ucNghienThoTinh.xaml
    /// </summary>
    public partial class ucNghienThoTinh : UserControl
    {
        public ucNghienThoTinh()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
        }

        private bool isLoaded;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                thongTinMayNghienTho1.StationName = "RemoteStation1";
                thongTinMayNghienTho1.ChannelName = "PLC_MayNghienTho";
                thongTinMayNghienTho1.DeviceName = "MayNghienTho1";

                nghienTho1.StationName = "RemoteStation1";
                nghienTho1.ChannelName = "PLC_MayNghienTho";
                nghienTho1.DeviceName = "MayNghienTho1";
                nghienTho1.MotorBangTaiCapLieuClick += OnBangTaiCapLieuClick;
                nghienTho1.MotorBangTaiTuClick += OnBangTaiTuClick;
                nghienTho1.MotorMayNghienClick += OnMotorMayNghienClick;
                nghienTho1.MotorQuatHutClick += OnMotorQuatHutClick;

                thongTinMayNghienTho2.StationName = "RemoteStation1";
                thongTinMayNghienTho2.ChannelName = "PLC_MayNghienTho";
                thongTinMayNghienTho2.DeviceName = "MayNghienTho2";

                nghienTho2.StationName = "RemoteStation1";
                nghienTho2.ChannelName = "PLC_MayNghienTho";
                nghienTho2.DeviceName = "MayNghienTho2";
                nghienTho2.MotorBangTaiCapLieuClick += OnBangTaiCapLieuClick;
                nghienTho2.MotorBangTaiTuClick += OnBangTaiTuClick;
                nghienTho2.MotorMayNghienClick += OnMotorMayNghienClick;
                nghienTho2.MotorQuatHutClick += OnMotorQuatHutClick;

                thongTinMayNghienTho3.StationName = "RemoteStation1";
                thongTinMayNghienTho3.ChannelName = "PLC_MayNghienTho";
                thongTinMayNghienTho3.DeviceName = "MayNghienTho3";

                nghienTho3.StationName = "RemoteStation1";
                nghienTho3.ChannelName = "PLC_MayNghienTho";
                nghienTho3.DeviceName = "MayNghienTho3";
                nghienTho3.MotorBangTaiCapLieuClick += OnBangTaiCapLieuClick;
                nghienTho3.MotorBangTaiTuClick += OnBangTaiTuClick;
                nghienTho3.MotorMayNghienClick += OnMotorMayNghienClick;
                nghienTho3.MotorQuatHutClick += OnMotorQuatHutClick;

                thongTinMayNghienTho4.StationName = "RemoteStation1";
                thongTinMayNghienTho4.ChannelName = "PLC_MayNghienTho";
                thongTinMayNghienTho4.DeviceName = "MayNghienTho4";

                nghienTho4.StationName = "RemoteStation1";
                nghienTho4.ChannelName = "PLC_MayNghienTho";
                nghienTho4.DeviceName = "MayNghienTho4";
                nghienTho4.MotorBangTaiCapLieuClick += OnBangTaiCapLieuClick;
                nghienTho4.MotorBangTaiTuClick += OnBangTaiTuClick;
                nghienTho4.MotorMayNghienClick += OnMotorMayNghienClick;
                nghienTho4.MotorQuatHutClick += OnMotorQuatHutClick;



                thongTinMayNghienTho1.Start();
                thongTinMayNghienTho2.Start();
                thongTinMayNghienTho3.Start();
                thongTinMayNghienTho4.Start();

                nghienTho1.Start();
                nghienTho2.Start();
                nghienTho3.Start();
                nghienTho4.Start();

                thongTinKhoNghienTho.StationName = "RemoteStation1";
                thongTinKhoNghienTho.ChannelName = "PLC_KhoNghienTho";
                thongTinKhoNghienTho.DeviceName = "KhoNghienTho";
                thongTinKhoNghienTho.Header = "Trạng Thái Hoạt Động";
                thongTinKhoNghienTho.Start();

                khoNghienTho.StationName = "RemoteStation1";
                khoNghienTho.ChannelName = "PLC_KhoNghienTho";
                khoNghienTho.DeviceName = "KhoNghienTho";

                khoNghienTho.MotorBomDau1Click += KhoNghienTho_MotorBomDau1Click;
                khoNghienTho.MotorBomDau2Click += KhoNghienTho_MotorBomDau2Click;
                khoNghienTho.MotorVTRLClick += KhoNghienTho_MotorVTRLClick;
                khoNghienTho.MotorVTCL1Click += KhoNghienTho_MotorVTCL1Click;
                khoNghienTho.MotorVTCL2Click += KhoNghienTho_MotorVTCL2Click;
                khoNghienTho.Xilanh1Click += KhoNghienTho_Xilanh1Click;
                khoNghienTho.Xilanh2Click += KhoNghienTho_Xilanh2Click;
                khoNghienTho.Xilanh3Click += KhoNghienTho_Xilanh3Click;
                khoNghienTho.Xilanh4Click += KhoNghienTho_Xilanh4Click;

                khoNghienTho.Start();

                thongTinKhoSauSay.StationName = "RemoteStation1";
                thongTinKhoSauSay.ChannelName = "PLC_KhoSauSay";
                thongTinKhoSauSay.DeviceName = "KhoSauSay";
                thongTinKhoSauSay.Header = "Trạng Thái Hoạt Động";
                thongTinKhoSauSay.Start();

                khoSauSay.StationName = "RemoteStation1";
                khoSauSay.ChannelName = "PLC_KhoSauSay";
                khoSauSay.DeviceName = "KhoSauSay";

                khoSauSay.MotorBomDau1Click += KhoSauSay_MotorBomDau1Click;
                khoSauSay.MotorBomDau2Click += KhoSauSay_MotorBomDau2Click;
                khoSauSay.MotorVTRLClick += KhoSauSay_MotorVTRLClick;
                khoSauSay.MotorVTCL1Click += KhoSauSay_MotorVTCL1Click;
                khoSauSay.MotorVTCL2Click += KhoSauSay_MotorVTCL2Click;
                khoSauSay.Xilanh1Click += KhoSauSay_Xilanh1Click;
                khoSauSay.Xilanh2Click += KhoSauSay_Xilanh2Click;
                khoSauSay.Xilanh3Click += KhoSauSay_Xilanh3Click;
                khoSauSay.Xilanh4Click += KhoSauSay_Xilanh4Click;

                khoSauSay.Start();
            }
        }

        #region Method of event kho nghien tho
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="index">Số thứ tự Xilanh</param>
        /// <param name="machineType">Loại kho</param>
        private void XilanhClick(object sender,EventArgs e,int index,string inventoryType)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = inventoryType=="A"?"PLC_KhoNghienTho": "PLC_KhoSauSay";
                string deviceName = "";
                string autoTagName = $"SW_Auto_{inventoryType}";
                string manualTagName = $"SW_Man_{inventoryType}";
                string cheDo3TagName = $"SW_CD3_{inventoryType}";
                string motorName = "XiLanh";
                string onMotorTagName = $"BT_FW{index}_{inventoryType}";
                string offMotorTagName = $"BT_RV{index}_{inventoryType}";
                string statusOffMotorTagName = $"ST_RV{index}_Vale_{inventoryType}";
                string statusOnMotorTagName = $"ST_FW{index}_Vale_{inventoryType}";
                string statusAutoTagName = $"PL_Auto_{inventoryType}"; ;
                string statusManualTagName = $"PL_Man_{inventoryType}";
                string statusCheDo3TagName = $"PL_CD3_{inventoryType}";
                string title = "";
                if (sender.Equals(khoNghienTho))
                {
                    deviceName = "KhoNghienTho";
                    title = "Bảng điều khiển - Kho Nghiền Thô";
                }
                else if (sender.Equals(khoSauSay))
                {
                    deviceName = "KhoSauSay";
                    title = "Bảng điều khiển - Kho Sau Sấy";
                }

                Point clickPoint = args.GetPosition(this.khoNghienTho);

                Point p = this.khoNghienTho.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                       cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                       statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }
        private void KhoNghienTho_Xilanh4Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoNghienTho";
            //    string deviceName = "";
            //    string autoTagName = "SW_Auto_A";
            //    string manualTagName = "SW_Man_A";
            //    string cheDo3TagName = "SW_CD3_A";
            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_FW4_A";
            //    string offMotorTagName = "BT_RV4_A";
            //    string statusOffMotorTagName = "ST_RV4_Vale_A";
            //    string statusOnMotorTagName = "ST_FW4_Vale_A";
            //    string statusAutoTagName = "PL_Auto_A"; ;
            //    string statusManualTagName = "PL_Man_A";
            //    string statusCheDo3TagName = "PL_CD3_A";
            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //           cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //           statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 4,"A");
        }

        private void KhoNghienTho_Xilanh3Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoNghienTho";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto_A";
            //    string manualTagName = "SW_Man_A";
            //    string cheDo3TagName = "SW_CD3_A";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_FW3_A";
            //    string offMotorTagName = "BT_RV3_A";
            //    string statusOffMotorTagName = "ST_RV3_Vale_A";
            //    string statusOnMotorTagName = "ST_FW3_Vale_A";
            //    string statusAutoTagName = "PL_Auto_A"; ;
            //    string statusManualTagName = "PL_Man_A";
            //    string statusCheDo3TagName = "PL_CD3_A";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //        cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //        statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 3,"A");
        }

        private void KhoNghienTho_Xilanh2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoNghienTho";
            //    string deviceName = "";




            //    string autoTagName = "SW_Auto_A";
            //    string manualTagName = "SW_Man_A";
            //    string cheDo3TagName = "SW_CD3_A";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_FW2_A";
            //    string offMotorTagName = "BT_RV2_A";
            //    string statusOffMotorTagName = "ST_RV2_Vale_A";
            //    string statusOnMotorTagName = "ST_FW2_Vale_A";
            //    string statusAutoTagName = "PL_Auto_A"; ;
            //    string statusManualTagName = "PL_Man_A";
            //    string statusCheDo3TagName = "PL_CD3_A";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //           cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //           statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 3,"A");
        }

        private void KhoNghienTho_Xilanh1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoNghienTho";
            //    string deviceName = "";




            //    string autoTagName = "SW_Auto_A";
            //    string manualTagName = "SW_Man_A";
            //    string cheDo3TagName = "SW_CD3_A";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_FW1_A";
            //    string offMotorTagName = "BT_RV1_A";
            //    string statusOffMotorTagName = "ST_RV1_Vale_A";
            //    string statusOnMotorTagName = "ST_FW1_Vale_A";
            //    string statusAutoTagName = "PL_Auto_A"; ;
            //    string statusManualTagName = "PL_Man_A";
            //    string statusCheDo3TagName = "PL_CD3_A";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //           cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //           statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e,1,"A");
        }

        private void BangTaiCapLieuClick(object sender, EventArgs e, int index, string inventoryType)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = inventoryType == "A" ? "PLC_KhoNghienTho" : "PLC_KhoSauSay";
                string deviceName = "";

                string autoTagName = $"SW_Auto_{inventoryType}";
                string manualTagName = $"SW_Man_{inventoryType}";
                string cheDo3TagName = $"SW_CD3_{inventoryType}";


                string motorName = "VTCL";
                string onMotorTagName = $"BT_FW_FD{inventoryType}{index}";
                string offMotorTagName = $"BT_RV_FD{inventoryType}{index}";
                string statusOffMotorTagName = $"PL_RV_FD_{inventoryType}{index}";
                string statusOnMotorTagName = $"PL_FW_FD_{inventoryType}{index}";
                string statusAutoTagName = $"PL_Auto_{inventoryType}"; ;
                string statusManualTagName = $"PL_Man_{inventoryType}";
                string statusCheDo3TagName = $"PL_CD3_{inventoryType}";

                string title = "";
                if (sender.Equals(khoNghienTho))
                {
                    deviceName = "KhoNghienTho";
                    title = "Bảng điều khiển - Kho Nghiền Thô";
                }
                else if (sender.Equals(khoSauSay))
                {
                    deviceName = "KhoSauSay";
                    title = "Bảng điều khiển - Kho Sau Sấy";
                }

                Point clickPoint = args.GetPosition(this.khoNghienTho);

                Point p = this.khoNghienTho.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                     cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTho_MotorVTCL2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoNghienTho";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "VTCL";
            //    string onMotorTagName = "BT_BatVTCLThuan2";
            //    string offMotorTagName = "BT_BatVTCLNghich2";
            //    string statusOffMotorTagName = "ST_VitTai2Nghich";
            //    string statusOnMotorTagName = "ST_VitTai2Thuan";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //          cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //          statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BangTaiCapLieuClick(sender, e, 2,"A");

        }

        private void KhoNghienTho_MotorVTCL1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoNghienTho";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "VTCL";
            //    string onMotorTagName = "BT_BatVTCLThuan1";
            //    string offMotorTagName = "BT_BatVTCLNghich1";
            //    string statusOffMotorTagName = "ST_VitTai1Nghich";
            //    string statusOnMotorTagName = "ST_VitTai1Thuan";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //         cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //         statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BangTaiCapLieuClick(sender, e, 1,"A");
        }

        private void KhoNghienTho_MotorVTRLClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoNghienTho";
                string deviceName = "";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "VTRL";
                string onMotorTagName = "BT_BatVTRL";
                string offMotorTagName = null;//Don't use
                string statusOffMotorTagName = null;//Don't use
                string statusOnMotorTagName = "ST_VTRL";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "";
                if (sender.Equals(khoNghienTho))
                {
                    deviceName = "KhoNghienTho";
                    title = "Bảng điều khiển - Kho Nghiền Thô";
                }
                else if (sender.Equals(khoSauSay))
                {
                    deviceName = "KhoSauSay";
                    title = "Bảng điều khiển - Kho Sau Sấy";
                }

                Point clickPoint = args.GetPosition(this.khoNghienTho);

                Point p = this.khoNghienTho.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                      cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoNghienTho_MotorBomDau2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoNghienTho";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "BomDau";
            //    string onMotorTagName = "BT_BatBomDau2";
            //    string offMotorTagName = null;//don't use
            //    string statusOffMotorTagName = null;//Don't use
            //    string statusOnMotorTagName = "ST_Pump2";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //        cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //        statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BomDauClick(sender, e, 2,"A");

        }

        private void KhoNghienTho_MotorBomDau1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoNghienTho";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto_A";
            //    string manualTagName = "SW_Man_A";
            //    string cheDo3TagName = "SW_CD3_A";


            //    string motorName = "BomDau";
            //    string onMotorTagName = "BT_Pump_A1";
            //    string offMotorTagName = null;//Don't use
            //    string statusOffMotorTagName = null;//Don't use
            //    string statusOnMotorTagName = "PL_Pump_A1";
            //    string statusAutoTagName = "PL_Auto_A"; ;
            //    string statusManualTagName = "PL_Man_A";
            //    string statusCheDo3TagName = "PL_CD3_A";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoNghienTho);

            //    Point p = this.khoNghienTho.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //            cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //            statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BomDauClick(sender, e, 1,"A");
        }

        private void BomDauClick(object sender, EventArgs e, int index, string inventoryType)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = inventoryType == "A" ? "PLC_KhoNghienTho" : "PLC_KhoSauSay";
                string deviceName = "";

                string autoTagName = $"SW_Auto_{inventoryType}";
                string manualTagName =$"SW_Man_{inventoryType}";
                string cheDo3TagName = $"SW_CD3_{inventoryType}";


                string motorName = "BomDau";
                string onMotorTagName = $"BT_PUMP_{inventoryType}{index}";
                string offMotorTagName = null;//don't use
                string statusOffMotorTagName = null;//Don't use
                string statusOnMotorTagName = $"PL_Pump_{inventoryType}{index}";
                string statusAutoTagName = $"PL_Auto_{inventoryType}"; ;
                string statusManualTagName = $"PL_Man_{inventoryType}";
                string statusCheDo3TagName = $"PL_CD3_{inventoryType}";

                string title = "";
                if (sender.Equals(khoNghienTho))
                {
                    deviceName = "KhoNghienTho";
                    title = "Bảng điều khiển - Kho Nghiền Thô";
                }
                else if (sender.Equals(khoSauSay))
                {
                    deviceName = "KhoSauSay";
                    title = "Bảng điều khiển - Kho Sau Sấy";
                }

                Point clickPoint = args.GetPosition(this.khoNghienTho);

                Point p = this.khoNghienTho.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                    cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                    statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        #endregion

        #region Method of event kho sau say
        private void KhoSauSay_Xilanh4Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLC_KhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_XiLanh4Tien";
            //    string offMotorTagName = "BT_XiLanh4Lui";
            //    string statusOffMotorTagName = "ST_XiLanh4Lui";
            //    string statusOnMotorTagName = "ST_XiLanh4Tien";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //         cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //         statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 4, "B");
        }

        private void KhoSauSay_Xilanh3Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_XiLanh3Tien";
            //    string offMotorTagName = "BT_XiLanh3Lui";
            //    string statusOffMotorTagName = "ST_XiLanh3Lui";
            //    string statusOnMotorTagName = "ST_XiLanh3Tien";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //        cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //        statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 3, "B");

        }

        private void KhoSauSay_Xilanh2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_XiLanh2Tien";
            //    string offMotorTagName = "BT_XiLanh2Lui";
            //    string statusOffMotorTagName = "ST_XiLanh2Lui";
            //    string statusOnMotorTagName = "ST_XiLanh2Tien";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //           cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //           statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 2, "B");

        }

        private void KhoSauSay_Xilanh1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "XiLanh";
            //    string onMotorTagName = "BT_XiLanh1Tien";
            //    string offMotorTagName = "BT_XiLanh1Lui";
            //    string statusOffMotorTagName = "ST_XiLanh1Lui";
            //    string statusOnMotorTagName = "ST_XiLanh1Tien";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //         cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //         statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            XilanhClick(sender, e, 1, "B");

        }

        private void KhoSauSay_MotorVTCL2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "VTCL";
            //    string onMotorTagName = "BT_BatVTCLThuan2";
            //    string offMotorTagName = "BT_BatVTCLNghich2";
            //    string statusOffMotorTagName = "ST_VitTai2Nghich";
            //    string statusOnMotorTagName = "ST_VitTai2Thuan";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //          cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //          statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BangTaiCapLieuClick(sender, e, 2, "B");
        }

        private void KhoSauSay_MotorVTCL1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "VTCL";
            //    string onMotorTagName = "BT_BatVTCLThuan1";
            //    string offMotorTagName = "BT_BatVTCLNghich1";
            //    string statusOffMotorTagName = "ST_VitTai1Nghich";
            //    string statusOnMotorTagName = "ST_VitTai1Thuan";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //         cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //         statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BangTaiCapLieuClick(sender, e, 1, "B");

        }

        private void KhoSauSay_MotorVTRLClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLCKhoSauSay";
                string deviceName = "";

                string autoTagName = "SW_Auto";
                string manualTagName = "SW_Man";
                string cheDo3TagName = "BT_CheDo3";


                string motorName = "VTRL";
                string onMotorTagName = "BT_BatVTRL";
                string offMotorTagName = null;//Don't use
                string statusOffMotorTagName = null;//Don't use
                string statusOnMotorTagName = "ST_VTRL";
                string statusAutoTagName = "ST_Auto"; ;
                string statusManualTagName = "ST_Manual";
                string statusCheDo3TagName = "ST_CheDo3";

                string title = "";
                if (sender.Equals(khoNghienTho))
                {
                    deviceName = "KhoNghienTho";
                    title = "Bảng điều khiển - Kho Nghiền Thô";
                }
                else if (sender.Equals(khoSauSay))
                {
                    deviceName = "KhoSauSay";
                    title = "Bảng điều khiển - Kho Sau Sấy";
                }

                Point clickPoint = args.GetPosition(this.khoSauSay);

                Point p = this.khoSauSay.PointToScreen(clickPoint);

                BangDieuKhienKho bangDK = new BangDieuKhienKho();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
                      cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName, statusCheDo3TagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void KhoSauSay_MotorBomDau2Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "BomDau";
            //    string onMotorTagName = "BT_BatBomDau2";
            //    string offMotorTagName = null;//don't use
            //    string statusOffMotorTagName = null;//Don't use
            //    string statusOnMotorTagName = "ST_Pump2";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //        cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //        statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BomDauClick(sender, e, 2, "B");
        }

        private void KhoSauSay_MotorBomDau1Click(object sender, EventArgs e)
        {
            //if (e is MouseButtonEventArgs args)
            //{
            //    string stationName = "RemoteStation1";
            //    string channelName = "PLCKhoSauSay";
            //    string deviceName = "";

            //    string autoTagName = "SW_Auto";
            //    string manualTagName = "SW_Man";
            //    string cheDo3TagName = "BT_CheDo3";


            //    string motorName = "BomDau";
            //    string onMotorTagName = "BT_BatBomDau1";
            //    string offMotorTagName = null;//Don't use

            //    string statusOffMotorTagName = null;//Don't use
            //    string statusOnMotorTagName = "ST_Pump1";
            //    string statusAutoTagName = "ST_Auto"; ;
            //    string statusManualTagName = "ST_Manual";
            //    string statusCheDo3TagName = "ST_CheDo3";

            //    string title = "";
            //    if (sender.Equals(khoNghienTho))
            //    {
            //        deviceName = "KhoNghienTho";
            //        title = "Bảng điều khiển - Kho Nghiền Thô";
            //    }
            //    else if (sender.Equals(khoSauSay))
            //    {
            //        deviceName = "KhoSauSay";
            //        title = "Bảng điều khiển - Kho Sau Sấy";
            //    }

            //    Point clickPoint = args.GetPosition(this.khoSauSay);

            //    Point p = this.khoSauSay.PointToScreen(clickPoint);

            //    BangDieuKhienKho bangDK = new BangDieuKhienKho();
            //    bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName,
            //            cheDo3TagName, motorName, onMotorTagName, offMotorTagName, statusOffMotorTagName, statusOnMotorTagName,
            //            statusAutoTagName, statusManualTagName, statusCheDo3TagName);
            //    DialogService.Instance.Show(bangDK, p, title);
            //}
            BomDauClick(sender, e, 1, "B");

        }
        #endregion

        #region Mothod of event May nghien tho
        private void OnMotorQuatHutClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLC_MayNghienTho";
                string deviceName = "";

                string autoTagName = "SW_Auto_NTho";
                string manualTagName = "SW_Man_NTho";

                string motorName = "QuatHut";
                string onMotorTagName = "BT_Start_Qhut";
                string offMotorTagName = "BT_Stop_Qhut";
                string offMotorMNTagName = null;
                string resetAlarmTagName = "BT_RST_NTho";

                string statusAlarmtagName = "ALARM_System_NTho";
                string statusOffMotorTagName = null;//Don't use
                string statusOnMotorTagName = "PL_QH";
                string statusAutoTagName = "PL_Auto_MN"; ;
                string statusManualTagName = "PL_Man_MN";

                string title = "";

                Point clickPoint = new Point(0, 0);
                Point p = new Point(0, 0);

                if (sender.Equals(nghienTho1))
                {
                    deviceName = "MayNghienTho1";
                    title = "Bảng điều khiển - Nghiền Thô 1";

                     clickPoint = args.GetPosition(this.labMayNghienTho1);

                     p = this.labMayNghienTho1.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho2))
                {
                    deviceName = "MayNghienTho2";
                    title = "Bảng điều khiển - Nghiền Thô 2";

                    clickPoint = args.GetPosition(this.labMayNghienTho2);

                    p = this.labMayNghienTho2.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho3))
                {
                    deviceName = "MayNghienTho3";
                    title = "Bảng điều khiển - Nghiền Thô 3";

                    clickPoint = args.GetPosition(this.labMayNghienTho3);

                    p = this.labMayNghienTho3.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho4))
                {
                    deviceName = "MayNghienTho4";
                    title = "Bảng điều khiển - Nghiền Thô 4";

                    clickPoint = args.GetPosition(this.labMayNghienTho4);

                    p = this.labMayNghienTho4.PointToScreen(clickPoint);
                }

                //Point clickPoint = args.GetPosition(Application.Current.MainWindow);
                p.Offset(0, -100);
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
                string channelName = "PLC_MayNghienTho";
                string deviceName = "";
                
                string autoTagName = "SW_Auto_NTho";
                string manualTagName = "SW_Man_NTho";

                string motorName = "MayNghien";
                string onMotorTagName = "BT_Start_FW_NTho";
                string offMotorTagName = "BT_Start_RV_NTho";
                string offMotorMNTagName = "BT_Stop_NTho";
                string resetAlarmTagName = "BT_RST_NTho";

                string statusAlarmtagName = "ALARM_System_NTho";
                string statusOffMotorTagName = "PL_RV_NTho";
                string statusOnMotorTagName = "PL_FW_NTho";
                string statusAutoTagName = "PL_Auto_MN"; ;
                string statusManualTagName = "PL_Man_MN";


                string title = "";
                Point clickPoint = new Point(0, 0);
                Point p = new Point(0, 0);

                if (sender.Equals(nghienTho1))
                {
                    channelName = "PLC_MayNghienTho";
                    deviceName = "MayNghienTho1";
                    title = "Bảng điều khiển - Nghiền Thô 1";

                    clickPoint = args.GetPosition(this.labMayNghienTho1);

                    p = this.labMayNghienTho1.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho2))
                {
                    deviceName = "MayNghienTho2";
                    title = "Bảng điều khiển - Nghiền Thô 2";

                    clickPoint = args.GetPosition(this.labMayNghienTho2);

                    p = this.labMayNghienTho2.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho3))
                {
                    deviceName = "MayNghienTho3";
                    title = "Bảng điều khiển - Nghiền Thô 3";

                    clickPoint = args.GetPosition(this.labMayNghienTho3);

                    p = this.labMayNghienTho3.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho4))
                {
                    deviceName = "MayNghienTho4";
                    title = "Bảng điều khiển - Nghiền Thô 4";

                    clickPoint = args.GetPosition(this.labMayNghienTho4);

                    p = this.labMayNghienTho4.PointToScreen(clickPoint);
                }
                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                    onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }

        private void OnBangTaiTuClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLC_MayNghienTho";
                string deviceName = "";
                
                string autoTagName = "SW_Auto_NTho";
                string manualTagName = "SW_Man_NTho";

                string motorName = "BTTu";
                string onMotorTagName = null;
                string offMotorTagName = null;
                string offMotorMNTagName = null;
                string resetAlarmTagName = "BT_RST_NTho";

                string statusAlarmtagName = "ALARM_System_NTho";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = null;
                string statusAutoTagName = "PL_Auto_MN"; ;
                string statusManualTagName = "PL_Man_MN";

                string title = "";
                Point clickPoint = new Point(0, 0);
                Point p = new Point(0, 0);

                if (sender.Equals(nghienTho1))
                {
                    deviceName = "MayNghienTho1";
                    title = "Bảng điều khiển - Nghiền Thô 1";

                    clickPoint = args.GetPosition(this.labMayNghienTho1);

                    p = this.labMayNghienTho1.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho2))
                {
                    deviceName = "MayNghienTho2";
                    title = "Bảng điều khiển - Nghiền Thô 2";

                    clickPoint = args.GetPosition(this.labMayNghienTho2);

                    p = this.labMayNghienTho2.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho3))
                {
                    deviceName = "MayNghienTho3";
                    title = "Bảng điều khiển - Nghiền Thô 3";

                    clickPoint = args.GetPosition(this.labMayNghienTho3);

                    p = this.labMayNghienTho3.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho4))
                {
                    deviceName = "MayNghienTho4";
                    title = "Bảng điều khiển - Nghiền Thô 4";

                    clickPoint = args.GetPosition(this.labMayNghienTho4);

                    p = this.labMayNghienTho4.PointToScreen(clickPoint);
                }
                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                   onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                     statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }

        }

        private void OnBangTaiCapLieuClick(object sender, EventArgs e)
        {
            if (e is MouseButtonEventArgs args)
            {
                string stationName = "RemoteStation1";
                string channelName = "PLC_MayNghienTho";
                string deviceName = "";
                string autoTagName = "SW_Auto_NTho";
                string manualTagName = "SW_Man_NTho";

                string motorName = "BTCapLieu";
                string onMotorTagName = "BT_Start_BTai";
                string offMotorTagName = "BT_Stop_BTai";
                string offMotorMNTagName = null;
                string resetAlarmTagName = "BT_RST_NTho";

                string statusAlarmtagName = "ALARM_System_NTho";
                string statusOffMotorTagName = null;
                string statusOnMotorTagName = "PL_BT";
                string statusAutoTagName = "PL_Auto_MN"; ;
                string statusManualTagName = "PL_Man_MN";

                string title = "";
                Point clickPoint = new Point(0, 0);
                Point p = new Point(0, 0);

                if (sender.Equals(nghienTho1))
                {
                    deviceName = "MayNghienTho1";
                    title = "Bảng điều khiển - Nghiền Thô 1";

                    clickPoint = args.GetPosition(this.labMayNghienTho1);

                    p = this.labMayNghienTho1.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho2))
                {
                    deviceName = "MayNghienTho2";
                    title = "Bảng điều khiển - Nghiền Thô 2";

                    clickPoint = args.GetPosition(this.labMayNghienTho2);

                    p = this.labMayNghienTho2.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho3))
                {
                    deviceName = "MayNghienTho3";
                    title = "Bảng điều khiển - Nghiền Thô 3";

                    clickPoint = args.GetPosition(this.labMayNghienTho3);

                    p = this.labMayNghienTho3.PointToScreen(clickPoint);
                }
                else if (sender.Equals(nghienTho4))
                {
                    deviceName = "MayNghienTho4";
                    title = "Bảng điều khiển - Nghiền Thô 4";

                    clickPoint = args.GetPosition(this.labMayNghienTho4);

                    p = this.labMayNghienTho4.PointToScreen(clickPoint);
                }

                (loDot1.lodotDatacontext as LoDotViewModel).Status = (loDot1.lodotDatacontext as LoDotViewModel).Status + 1;
                //Status = Status + 1;
                if ((loDot1.lodotDatacontext as LoDotViewModel).Status == 4)
                {
                    (loDot1.lodotDatacontext as LoDotViewModel).Status = 1;
                }
                BangDieuKhienMayNghien bangDK = new BangDieuKhienMayNghien();
                bangDK.Start(stationName, channelName, deviceName, autoTagName, manualTagName, statusAlarmtagName, resetAlarmTagName, motorName,
                    onMotorTagName, offMotorTagName, offMotorMNTagName, statusOffMotorTagName, statusOnMotorTagName,
                      statusAutoTagName, statusManualTagName);
                DialogService.Instance.Show(bangDK, p, title);
            }
        }
        #endregion
    }
}
