using EasyScada.Core;
using EasyScada.Wpf.Controls;
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

namespace WPFUserControl
{
    public partial class KhoNghienTinh : UserControl
    {
        #region ----- PROPERTY USERCONTROL -----

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public ITag BaoDayCylone { get; set; }
        public ITag BomDau { get; set; }
        //vit tai
        public ITag VitTaiRaLieu { get; set; }
        public ITag BaoDayVitTaiRaLieu { get; set; }
        public ITag BaoDayVitTaiCapLieu { get; set; }
        public ITag AirLock { get; set; }
        public ITag MortorVitTaiCapLieuChayNghich { get; set; }
        public ITag MortorVitTaiCapLieuChayThuan { get; set; }
        //xilanh
        public ITag TrangThaiXiLanh1ChayLui { get; set; }
        public ITag TrangThaiXiLanh1ChayToi { get; set; }
        public ITag TrangThaiXiLanh2ChayLui { get; set; }
        public ITag TrangThaiXiLanh2ChayToi { get; set; }
        #endregion ----- PROPERTY USERCONTROL -----    

        public bool IsStarted { get; private set; }

        private bool _vitTai1ChayThuan = false, _vitTai1ChayNghich = false;
        private bool _xiLanh1ChayToi = false, _xiLanh1ChayLui = false, _xiLanh2ChayToi = false, _xiLanh2ChayLui = false;

        public KhoNghienTinh()
        {
            InitializeComponent();

            xiLanh1.Visibility = Visibility.Collapsed;
            xiLanh2.Visibility = Visibility.Collapsed;

            xiLanh1Gif.Visibility = Visibility.Collapsed;
            xiLanh2Gif.Visibility = Visibility.Collapsed;

            xiLanh1Tien.Visibility = Visibility.Collapsed;
            xiLanh2Tien.Visibility = Visibility.Collapsed;

            xiLanh1Lui.Visibility = Visibility.Collapsed;
            xiLanh2Lui.Visibility = Visibility.Collapsed;

            vitTaiCapLieu.Visibility = Visibility.Collapsed;
            motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
            motorAirClockChay.Visibility = Visibility.Collapsed;

            mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
            mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;

            motorVitTaiRaLieuChay.Visibility = Visibility.Collapsed;
            vitTaiRaLieuGif.Visibility = Visibility.Collapsed;

            cylone.Visibility = Visibility.Collapsed;
        }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                if (Connector.IsStarted)
                {
                    Connector_Started(Connector, EventArgs.Empty);
                }
                else
                {
                    Connector.Started += Connector_Started;
                }
            }
        }

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                BaoDayCylone = GetTag("High_Level_Cylone");
                if (BaoDayCylone != null)
                {
                    BaoDayCylone1_ValueChanged(BaoDayCylone, new TagValueChangedEventArgs(BaoDayCylone, "", BaoDayCylone.Value));
                    BaoDayCylone.ValueChanged += BaoDayCylone1_ValueChanged;
                }

                BomDau = GetTag("ST_Pump1");
                if (BomDau != null)
                {
                    BomDau1_ValueChanged(BomDau, new TagValueChangedEventArgs(BomDau, "", BomDau.Value));
                    BomDau.ValueChanged += BomDau1_ValueChanged;
                }

                VitTaiRaLieu = GetTag("ST_VTRL");
                if (VitTaiRaLieu != null)
                {
                    VitTaiRaLieu_ValueChanged(VitTaiRaLieu, new TagValueChangedEventArgs(VitTaiRaLieu, "", VitTaiRaLieu.Value));
                    VitTaiRaLieu.ValueChanged += VitTaiRaLieu_ValueChanged;
                }

                MortorVitTaiCapLieuChayNghich = GetTag("ST_VitTai1Nghich");
                if (MortorVitTaiCapLieuChayNghich != null)
                {
                    MortorVitTai1ChayNghich_ValueChanged(MortorVitTaiCapLieuChayNghich, new TagValueChangedEventArgs(MortorVitTaiCapLieuChayNghich, "", MortorVitTaiCapLieuChayNghich.Value));
                    MortorVitTaiCapLieuChayNghich.ValueChanged += MortorVitTai1ChayNghich_ValueChanged;
                }

                MortorVitTaiCapLieuChayThuan = GetTag("ST_VitTai1Thuan");
                if (MortorVitTaiCapLieuChayThuan != null)
                {
                    MortorVitTai1ChayThuan_ValueChanged(MortorVitTaiCapLieuChayThuan, new TagValueChangedEventArgs(MortorVitTaiCapLieuChayThuan, "", MortorVitTaiCapLieuChayThuan.Value));
                    MortorVitTaiCapLieuChayThuan.ValueChanged += MortorVitTai1ChayThuan_ValueChanged;
                }

                TrangThaiXiLanh1ChayLui = GetTag("ST_XiLanh1Lui");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh1ChayLui_ValueChanged(TrangThaiXiLanh1ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh1ChayLui, "", TrangThaiXiLanh1ChayLui.Value));
                    TrangThaiXiLanh1ChayLui.ValueChanged += TrangThaiXiLanh1ChayLui_ValueChanged;
                }

                TrangThaiXiLanh1ChayToi = GetTag("ST_XiLanh1Tien");
                if (TrangThaiXiLanh1ChayToi != null)
                {
                    TrangThaiXiLanh1ChayToi_ValueChanged(TrangThaiXiLanh1ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh1ChayToi, "", TrangThaiXiLanh1ChayToi.Value));
                    TrangThaiXiLanh1ChayToi.ValueChanged += TrangThaiXiLanh1ChayToi_ValueChanged;
                }

                TrangThaiXiLanh2ChayLui = GetTag("ST_XiLanh2Lui");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh2ChayLui_ValueChanged(TrangThaiXiLanh2ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh2ChayLui, "", TrangThaiXiLanh2ChayLui.Value));
                    TrangThaiXiLanh2ChayLui.ValueChanged += TrangThaiXiLanh2ChayLui_ValueChanged;
                }

                TrangThaiXiLanh2ChayToi = GetTag("ST_XiLanh2Tien");
                if (TrangThaiXiLanh2ChayToi != null)
                {
                    TrangThaiXiLanh2ChayToi_ValueChanged(TrangThaiXiLanh2ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh2ChayToi, "", TrangThaiXiLanh2ChayToi.Value));
                    TrangThaiXiLanh2ChayToi.ValueChanged += TrangThaiXiLanh2ChayToi_ValueChanged;
                }

                BaoDayVitTaiRaLieu = GetTag("High_Level_VTRL");
                if (BaoDayVitTaiRaLieu != null)
                {
                    BaoDayVitTaiRaLieu_ValueChanged(BaoDayVitTaiRaLieu, new TagValueChangedEventArgs(BaoDayVitTaiRaLieu, "", BaoDayVitTaiRaLieu.Value));
                    BaoDayVitTaiRaLieu.ValueChanged += BaoDayVitTaiRaLieu_ValueChanged;
                }

                BaoDayVitTaiCapLieu = GetTag("High_Level_VTCL");
                if (BaoDayVitTaiCapLieu != null)
                {
                    BaoDayVitTaiCapLieu_ValueChanged(BaoDayVitTaiCapLieu, new TagValueChangedEventArgs(BaoDayVitTaiCapLieu, "", BaoDayVitTaiCapLieu.Value));
                    BaoDayVitTaiCapLieu.ValueChanged += BaoDayVitTaiCapLieu_ValueChanged;
                }

                //AirLock = GetTag("PL_AirLock_NTinh");
                AirLock = Connector.GetTag($"{StationName}/PLCNghien_EpVien/MayEpVien1/PL_AirLock_NTinh");//do 2 tag nay nam o mays ep vien nen lam rieng
                if (AirLock != null)
                {
                    AirLock_ValueChanged(AirLock, new TagValueChangedEventArgs(AirLock, "", AirLock.Value));
                    AirLock.ValueChanged += AirLock_ValueChanged;
                }
            });
        }

        private void BaoDayVitTaiCapLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayVitTaiCapLieuOn.Visibility = Visibility.Visible;
                    baoDayVitTaiCapLieuOff.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayVitTaiCapLieuOn.Visibility = Visibility.Collapsed;
                    baoDayVitTaiCapLieuOff.Visibility = Visibility.Visible;
                }
            }));
        }

        private void AirLock_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorAirClockChay.Visibility = Visibility.Visible;
                    motorAirClockDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorAirClockDung.Visibility = Visibility.Visible;
                    motorAirClockChay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void BaoDayVitTaiRaLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayVitTaiRaLieuOn.Visibility = Visibility.Visible;
                    baoDayVitTaiRaLieuOff.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayVitTaiRaLieuOn.Visibility = Visibility.Collapsed;
                    baoDayVitTaiRaLieuOff.Visibility = Visibility.Visible;
                }
            }));
        }

        private void TrangThaiXiLanh2ChayLui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh2ChayLui = true;

                    xiLanh2.Visibility = Visibility.Visible;
                    xiLanh2Tien.Visibility = Visibility.Collapsed;
                    xiLanh2Lui.Visibility = Visibility.Visible;
                    xiLanh2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh2ChayLui = false;
                    xiLanh2Lui.Visibility = Visibility.Collapsed;

                    if (_xiLanh2ChayToi == false)
                    {
                        xiLanh2.Visibility = Visibility.Collapsed;
                        xiLanh2Tien.Visibility = Visibility.Collapsed;
                        xiLanh2Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh2ChayToi_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh2ChayToi = true;

                    xiLanh2.Visibility = Visibility.Visible;
                    xiLanh2Tien.Visibility = Visibility.Visible;
                    xiLanh2Lui.Visibility = Visibility.Collapsed;
                    xiLanh2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh2ChayToi = false;
                    xiLanh2Tien.Visibility = Visibility.Collapsed;

                    if (_xiLanh2ChayLui == false)
                    {
                        xiLanh2.Visibility = Visibility.Collapsed;
                        xiLanh2Lui.Visibility = Visibility.Collapsed;
                        xiLanh2Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh1ChayToi_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh1ChayToi = true;

                    xiLanh1.Visibility = Visibility.Visible;
                    xiLanh1Tien.Visibility = Visibility.Visible;
                    xiLanh1Lui.Visibility = Visibility.Collapsed;
                    xiLanh1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh1ChayToi = false;
                    xiLanh1Tien.Visibility = Visibility.Collapsed;

                    if (_xiLanh1ChayLui == false)
                    {
                        xiLanh1.Visibility = Visibility.Collapsed;
                        xiLanh1Lui.Visibility = Visibility.Collapsed;
                        xiLanh1Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh1ChayLui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh1ChayLui = true;

                    xiLanh1.Visibility = Visibility.Visible;
                    xiLanh1Tien.Visibility = Visibility.Collapsed;
                    xiLanh1Lui.Visibility = Visibility.Visible;
                    xiLanh1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh1ChayLui = false;
                    xiLanh1Lui.Visibility = Visibility.Collapsed;

                    if (_xiLanh1ChayToi == false)
                    {
                        xiLanh1.Visibility = Visibility.Collapsed;
                        xiLanh1Tien.Visibility = Visibility.Collapsed;
                        xiLanh1Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void MortorVitTai1ChayNghich_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _vitTai1ChayNghich = true;

                    motorVitTaiCapLieuChay.Visibility = Visibility.Visible;
                    motorVitTaiCapLieuDung.Visibility = Visibility.Collapsed;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Visible;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai1ChayNghich = false;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;

                    if (_vitTai1ChayThuan == false)
                    {
                        motorVitTaiCapLieuDung.Visibility = Visibility.Visible;
                        motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
                        mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void MortorVitTai1ChayThuan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _vitTai1ChayThuan = true;

                    motorVitTaiCapLieuChay.Visibility = Visibility.Visible;
                    motorVitTaiCapLieuDung.Visibility = Visibility.Collapsed;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Visible;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai1ChayThuan = false;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;

                    if (_vitTai1ChayNghich == false)
                    {
                        motorVitTaiCapLieuDung.Visibility = Visibility.Visible;
                        motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
                        mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu.Visibility = Visibility.Hidden;
                    }
                }
            }));
        }

        private void VitTaiRaLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorVitTaiRaLieuChay.Visibility = Visibility.Visible;
                    motorVitTaiRaLieuDung.Visibility = Visibility.Collapsed;
                    vitTaiRaLieuGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorVitTaiRaLieuDung.Visibility = Visibility.Visible;
                    motorVitTaiRaLieuChay.Visibility = Visibility.Collapsed;
                    vitTaiRaLieuGif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void BomDau1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    bomDau1Chay.Visibility = Visibility.Visible;
                    bomDau1Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    bomDau1Dung.Visibility = Visibility.Visible;
                    bomDau1Chay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void BaoDayCylone1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    cylone.Visibility = Visibility.Visible;
                }
                else
                {
                    cylone.Visibility = Visibility.Collapsed;
                }
            }));
        }

        #region Events
        public event EventHandler MotorBomDauClick;
        public event EventHandler MotorVTRLClick;
        public event EventHandler MotorVTCLClick;
        public event EventHandler MotorAirLockLClick;
        public event EventHandler Xilanh1Click;
        public event EventHandler Xilanh2Click;

        private void MotorBomDau_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorBomDauClick?.Invoke(this, e);
        }

        private void MotorXiLanh1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh1Click?.Invoke(this, e);
        }

        private void MotorXiLanh2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh2Click?.Invoke(this, e);
        }

        private void MotorVitTaiRaLieu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorVTRLClick?.Invoke(this, e);
        }

        private void MotorVitTaiCapLieu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorVTCLClick?.Invoke(this, e);
        }

        private void MotorAirLock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorAirLockLClick?.Invoke(this, e);
        }
        #endregion
    }
}

