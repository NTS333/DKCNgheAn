using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public partial class KhoSauSay : UserControl
    {
        #region ----- PROPERTY USERCONTROL -----

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public ITag BomDau1 { get; set; }
        public ITag BomDau2 { get; set; }
        //vit tai
        public ITag VitTaiRaLieu { get; set; }
        public ITag BaoDayVitTaiRaLieu { get; set; }
        public ITag BaoDayVitTaiCapLieu1 { get; set; }
        public ITag BaoDayVitTaiCapLieu2 { get; set; }
        public ITag MortorVitTai1ChayNghich { get; set; }
        public ITag MortorVitTai1ChayThuan { get; set; }
        public ITag MortorVitTai2ChayNghich { get; set; }
        public ITag MortorVitTai2ChayThuan { get; set; }
        //xilanh
        public ITag TrangThaiXiLanh1ChayLui { get; set; }
        public ITag TrangThaiXiLanh1ChayToi { get; set; }
        public ITag TrangThaiXiLanh2ChayLui { get; set; }
        public ITag TrangThaiXiLanh2ChayToi { get; set; }
        public ITag TrangThaiXiLanh3ChayLui { get; set; }
        public ITag TrangThaiXiLanh3ChayToi { get; set; }
        public ITag TrangThaiXiLanh4ChayLui { get; set; }
        public ITag TrangThaiXiLanh4ChayToi { get; set; }
        #endregion ----- PROPERTY USERCONTROL -----    

        public bool IsStarted { get; private set; }

        private bool _vitTai1ChayThuan = false, _vitTai1ChayNghich = false, _vitTai2ChayThuan = false, _vitTai2ChayNghich = false;
        private bool _xiLanh1ChayToi = false, _xiLanh1ChayLui = false, _xiLanh2ChayToi = false, _xiLanh2ChayLui = false;
        private bool _xiLanh3ChayToi = false, _xiLanh3ChayLui = false, _xiLanh4ChayToi = false, _xiLanh4ChayLui = false;

        public KhoSauSay()
        {
            InitializeComponent();

            xiLanh1.Visibility = Visibility.Collapsed;
            xiLanh2.Visibility = Visibility.Collapsed;
            xiLanh3.Visibility = Visibility.Collapsed;
            xiLanh4.Visibility = Visibility.Collapsed;
            xiLanh1Gif.Visibility = Visibility.Collapsed;
            xiLanh2Gif.Visibility = Visibility.Collapsed;
            xiLanh3Gif.Visibility = Visibility.Collapsed;
            xiLanh4Gif.Visibility = Visibility.Collapsed;
            xiLanh1Tien.Visibility = Visibility.Collapsed;
            xiLanh2Tien.Visibility = Visibility.Collapsed;
            xiLanh3Tien.Visibility = Visibility.Collapsed;
            xiLanh4Tien.Visibility = Visibility.Collapsed;
            xiLanh1Lui.Visibility = Visibility.Collapsed;
            xiLanh2Lui.Visibility = Visibility.Collapsed;
            xiLanh3Lui.Visibility = Visibility.Collapsed;
            xiLanh4Lui.Visibility = Visibility.Collapsed;

            mortorVitTai1Chay.Visibility = Visibility.Collapsed;
            mortorVitTai2Chay.Visibility = Visibility.Collapsed;
            vitTaiCapLieu1.Visibility = Visibility.Collapsed;
            vitTaiCapLieu2.Visibility = Visibility.Collapsed;
            mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
            mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;
            mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
            mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;
            motorVitTaiRaLieuChay.Visibility = Visibility.Collapsed;
            vitTaiRaLieuGif.Visibility = Visibility.Collapsed;

            bomDau1Chay.Visibility = Visibility.Collapsed;
            bomDau2Chay.Visibility = Visibility.Collapsed;
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
                BomDau1 = GetTag("PL_Pump_B1");
                if (BomDau1 != null)
                {
                    BomDau1_ValueChanged(BomDau1, new TagValueChangedEventArgs(BomDau1, "", BomDau1.Value));
                    BomDau1.ValueChanged += BomDau1_ValueChanged;
                }

                BomDau2 = GetTag("PL_Pump_B2");
                if (BomDau2 != null)
                {
                    BomDau2_ValueChanged(BomDau2, new TagValueChangedEventArgs(BomDau2, "", BomDau2.Value));
                    BomDau2.ValueChanged += BomDau2_ValueChanged;
                }

                VitTaiRaLieu = GetTag("PL_Screw_B");
                if (VitTaiRaLieu != null)
                {
                    VitTaiRaLieu_ValueChanged(VitTaiRaLieu, new TagValueChangedEventArgs(VitTaiRaLieu, "", VitTaiRaLieu.Value));
                    VitTaiRaLieu.ValueChanged += VitTaiRaLieu_ValueChanged;
                }

                MortorVitTai1ChayNghich = GetTag("PL_RV_FD_B1");
                if (MortorVitTai1ChayNghich != null)
                {
                    MortorVitTai1ChayNghich_ValueChanged(MortorVitTai1ChayNghich, new TagValueChangedEventArgs(MortorVitTai1ChayNghich, "", MortorVitTai1ChayNghich.Value));
                    MortorVitTai1ChayNghich.ValueChanged += MortorVitTai1ChayNghich_ValueChanged;
                }

                MortorVitTai1ChayThuan = GetTag("PL_FW_FD_B1");
                if (MortorVitTai1ChayThuan != null)
                {
                    MortorVitTai1ChayThuan_ValueChanged(MortorVitTai1ChayThuan, new TagValueChangedEventArgs(MortorVitTai1ChayThuan, "", MortorVitTai1ChayThuan.Value));
                    MortorVitTai1ChayThuan.ValueChanged += MortorVitTai1ChayThuan_ValueChanged;
                }

                MortorVitTai2ChayNghich = GetTag("PL_RV_FD_B2");
                if (MortorVitTai2ChayNghich != null)
                {
                    MortorVitTai2ChayNghich_ValueChanged(MortorVitTai2ChayNghich, new TagValueChangedEventArgs(MortorVitTai2ChayNghich, "", MortorVitTai2ChayNghich.Value));
                    MortorVitTai2ChayNghich.ValueChanged += MortorVitTai2ChayNghich_ValueChanged;
                }

                MortorVitTai2ChayThuan = GetTag("PL_FW_FD_B2");
                if (MortorVitTai2ChayThuan != null)
                {
                    MortorVitTai2ChayThuan_ValueChanged(MortorVitTai2ChayThuan, new TagValueChangedEventArgs(MortorVitTai2ChayThuan, "", MortorVitTai2ChayThuan.Value));
                    MortorVitTai2ChayThuan.ValueChanged += MortorVitTai2ChayThuan_ValueChanged;
                }

                TrangThaiXiLanh1ChayLui = GetTag("ST_RV1_Vale_B");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh1ChayLui_ValueChanged(TrangThaiXiLanh1ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh1ChayLui, "", TrangThaiXiLanh1ChayLui.Value));
                    TrangThaiXiLanh1ChayLui.ValueChanged += TrangThaiXiLanh1ChayLui_ValueChanged;
                }

                TrangThaiXiLanh1ChayToi = GetTag("ST_FW1_Vale_B");
                if (TrangThaiXiLanh1ChayToi != null)
                {
                    TrangThaiXiLanh1ChayToi_ValueChanged(TrangThaiXiLanh1ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh1ChayToi, "", TrangThaiXiLanh1ChayToi.Value));
                    TrangThaiXiLanh1ChayToi.ValueChanged += TrangThaiXiLanh1ChayToi_ValueChanged;
                }

                TrangThaiXiLanh2ChayLui = GetTag("ST_RV2_Vale_B");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh2ChayLui_ValueChanged(TrangThaiXiLanh2ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh2ChayLui, "", TrangThaiXiLanh2ChayLui.Value));
                    TrangThaiXiLanh2ChayLui.ValueChanged += TrangThaiXiLanh2ChayLui_ValueChanged;
                }

                TrangThaiXiLanh2ChayToi = GetTag("ST_FW2_Vale_B");
                if (TrangThaiXiLanh2ChayToi != null)
                {
                    TrangThaiXiLanh2ChayToi_ValueChanged(TrangThaiXiLanh2ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh2ChayToi, "", TrangThaiXiLanh2ChayToi.Value));
                    TrangThaiXiLanh2ChayToi.ValueChanged += TrangThaiXiLanh2ChayToi_ValueChanged;
                }

                TrangThaiXiLanh3ChayLui = GetTag("ST_RV3_Vale_B");
                if (TrangThaiXiLanh3ChayLui != null)
                {
                    TrangThaiXiLanh3ChayLui_ValueChanged(TrangThaiXiLanh3ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh3ChayLui, "", TrangThaiXiLanh3ChayLui.Value));
                    TrangThaiXiLanh3ChayLui.ValueChanged += TrangThaiXiLanh3ChayLui_ValueChanged;
                }

                TrangThaiXiLanh3ChayToi = GetTag("ST_FW3_Vale_B");
                if (TrangThaiXiLanh3ChayToi != null)
                {
                    TrangThaiXiLanh3ChayToi_ValueChanged(TrangThaiXiLanh3ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh3ChayToi, "", TrangThaiXiLanh3ChayToi.Value));
                    TrangThaiXiLanh3ChayToi.ValueChanged += TrangThaiXiLanh3ChayToi_ValueChanged;
                }

                TrangThaiXiLanh4ChayLui = GetTag("ST_RV4_Vale_B");
                if (TrangThaiXiLanh4ChayLui != null)
                {
                    TrangThaiXiLanh4ChayLui_ValueChanged(TrangThaiXiLanh4ChayLui, new TagValueChangedEventArgs(TrangThaiXiLanh4ChayLui, "", TrangThaiXiLanh4ChayLui.Value));
                    TrangThaiXiLanh4ChayLui.ValueChanged += TrangThaiXiLanh4ChayLui_ValueChanged;
                }

                TrangThaiXiLanh4ChayToi = GetTag("ST_FW4_Vale_B");
                if (TrangThaiXiLanh4ChayToi != null)
                {
                    TrangThaiXiLanh4ChayToi_ValueChanged(TrangThaiXiLanh4ChayToi, new TagValueChangedEventArgs(TrangThaiXiLanh4ChayToi, "", TrangThaiXiLanh4ChayToi.Value));
                    TrangThaiXiLanh4ChayToi.ValueChanged += TrangThaiXiLanh4ChayToi_ValueChanged;
                }

                BaoDayVitTaiCapLieu1 = GetTag("HI_LV_B1");
                if (BaoDayVitTaiCapLieu1 != null)
                {
                    BaoDayVitTaiCapLieu1_ValueChanged(BaoDayVitTaiCapLieu1, new TagValueChangedEventArgs(BaoDayVitTaiCapLieu1, "", BaoDayVitTaiCapLieu1.Value));
                    BaoDayVitTaiCapLieu1.ValueChanged += BaoDayVitTaiCapLieu1_ValueChanged;
                }

                BaoDayVitTaiCapLieu2 = GetTag("HI_LV_B2");
                if (BaoDayVitTaiCapLieu2 != null)
                {
                    BaoDayVitTaiCapLieu2_ValueChanged(BaoDayVitTaiCapLieu2, new TagValueChangedEventArgs(BaoDayVitTaiCapLieu2, "", BaoDayVitTaiCapLieu2.Value));
                    BaoDayVitTaiCapLieu2.ValueChanged += BaoDayVitTaiCapLieu2_ValueChanged;
                }

                BaoDayVitTaiRaLieu = GetTag("HI_LV_Screw_B");
                if (BaoDayVitTaiRaLieu != null)
                {
                    BaoDayVitTaiRaLieu_ValueChanged(BaoDayVitTaiRaLieu, new TagValueChangedEventArgs(BaoDayVitTaiRaLieu, "", BaoDayVitTaiRaLieu.Value));
                    BaoDayVitTaiRaLieu.ValueChanged += BaoDayVitTaiRaLieu_ValueChanged;
                }
            });
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

        private void BaoDayVitTaiCapLieu2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayVitTaiCapLieu2On.Visibility = Visibility.Visible;
                    baoDayVitTaiCapLieu2Off.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayVitTaiCapLieu2On.Visibility = Visibility.Collapsed;
                    baoDayVitTaiCapLieu2Off.Visibility = Visibility.Visible;
                }
            }));
        }

        private void BaoDayVitTaiCapLieu1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayVitTaiCapLieu1On.Visibility = Visibility.Visible;
                    baoDayVitTaiCapLieu1Off.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayVitTaiCapLieu1On.Visibility = Visibility.Collapsed;
                    baoDayVitTaiCapLieu1Off.Visibility = Visibility.Visible;
                }
            }));
        }

        private void TrangThaiXiLanh4ChayToi_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh4ChayToi = true;

                    xiLanh4.Visibility = Visibility.Visible;
                    xiLanh4Tien.Visibility = Visibility.Visible;
                    xiLanh4Lui.Visibility = Visibility.Collapsed;
                    xiLanh4Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh4ChayToi = false;
                    xiLanh4Tien.Visibility = Visibility.Collapsed;

                    if (_xiLanh4ChayLui == false)
                    {
                        xiLanh4.Visibility = Visibility.Collapsed;
                        xiLanh4Lui.Visibility = Visibility.Collapsed;
                        xiLanh4Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh4ChayLui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh4ChayLui = true;

                    xiLanh4.Visibility = Visibility.Visible;
                    xiLanh4Tien.Visibility = Visibility.Collapsed;
                    xiLanh4Lui.Visibility = Visibility.Visible;
                    xiLanh4Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh4ChayLui = false;
                    xiLanh4Lui.Visibility = Visibility.Collapsed;

                    if (_xiLanh4ChayToi == false)
                    {
                        xiLanh4.Visibility = Visibility.Collapsed;
                        xiLanh4Tien.Visibility = Visibility.Collapsed;
                        xiLanh4Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh3ChayLui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh3ChayLui = true;

                    xiLanh3.Visibility = Visibility.Visible;
                    xiLanh3Tien.Visibility = Visibility.Collapsed;
                    xiLanh3Lui.Visibility = Visibility.Visible;
                    xiLanh3Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh3ChayLui = false;
                    xiLanh3Lui.Visibility = Visibility.Collapsed;

                    if (_xiLanh3ChayToi == false)
                    {
                        xiLanh3.Visibility = Visibility.Collapsed;
                        xiLanh3Tien.Visibility = Visibility.Collapsed;
                        xiLanh3Gif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void TrangThaiXiLanh3ChayToi_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _xiLanh3ChayToi = true;

                    xiLanh3.Visibility = Visibility.Visible;
                    xiLanh3Tien.Visibility = Visibility.Visible;
                    xiLanh3Lui.Visibility = Visibility.Collapsed;
                    xiLanh3Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    _xiLanh3ChayToi = false;
                    xiLanh3Tien.Visibility = Visibility.Collapsed;

                    if (_xiLanh3ChayLui == false)
                    {
                        xiLanh3.Visibility = Visibility.Collapsed;
                        xiLanh3Lui.Visibility = Visibility.Collapsed;
                        xiLanh3Gif.Visibility = Visibility.Collapsed;
                    }
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

        private void MortorVitTai2ChayThuan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _vitTai2ChayThuan = true;

                    mortorVitTai2Chay.Visibility = Visibility.Visible;
                    mortorVitTai2Dung.Visibility = Visibility.Collapsed;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Visible;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu2.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai2ChayThuan = false;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;

                    if (_vitTai2ChayNghich == false)
                    {
                        mortorVitTai2Dung.Visibility = Visibility.Visible;
                        mortorVitTai2Chay.Visibility = Visibility.Collapsed;
                        mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu2.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void MortorVitTai2ChayNghich_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    _vitTai2ChayNghich = true;

                    mortorVitTai2Chay.Visibility = Visibility.Visible;
                    mortorVitTai2Dung.Visibility = Visibility.Collapsed;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Visible;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu2.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai2ChayNghich = false;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;

                    if (_vitTai2ChayThuan == false)
                    {
                        mortorVitTai2Dung.Visibility = Visibility.Visible;
                        mortorVitTai2Chay.Visibility = Visibility.Collapsed;
                        mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu2.Visibility = Visibility.Collapsed;
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

                    mortorVitTai1Chay.Visibility = Visibility.Visible;
                    mortorVitTai1Dung.Visibility = Visibility.Collapsed;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Visible;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu1.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai1ChayNghich = false;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;

                    if (_vitTai1ChayThuan == false)
                    {
                        mortorVitTai1Dung.Visibility = Visibility.Visible;
                        mortorVitTai1Chay.Visibility = Visibility.Collapsed;
                        mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu1.Visibility = Visibility.Collapsed;
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

                    mortorVitTai1Chay.Visibility = Visibility.Visible;
                    mortorVitTai1Dung.Visibility = Visibility.Collapsed;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Visible;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu1.Visibility = Visibility.Visible;
                }
                else
                {
                    _vitTai1ChayThuan = false;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;

                    if (_vitTai1ChayNghich == false)
                    {
                        mortorVitTai1Dung.Visibility = Visibility.Visible;
                        mortorVitTai1Chay.Visibility = Visibility.Collapsed;
                        mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
                        vitTaiCapLieu1.Visibility = Visibility.Hidden;
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

        private void BomDau2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    bomDau2Chay.Visibility = Visibility.Visible;
                    bomDau2Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    bomDau2Dung.Visibility = Visibility.Visible;
                    bomDau2Chay.Visibility = Visibility.Collapsed;
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

        #region Events
        public event EventHandler MotorBomDau1Click;
        public event EventHandler MotorBomDau2Click;
        public event EventHandler MotorVTRLClick;
        public event EventHandler MotorVTCL1Click;
        public event EventHandler MotorVTCL2Click;
        public event EventHandler Xilanh1Click;
        public event EventHandler Xilanh2Click;
        public event EventHandler Xilanh3Click;
        public event EventHandler Xilanh4Click;

        private void MotorBomDau1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorBomDau1Click?.Invoke(this, e);
        }

        private void MotorBomDau2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorBomDau2Click?.Invoke(this, e);
        }

        private void XiLanh4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh4Click?.Invoke(this, e);
        }

        private void XiLanh3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh3Click?.Invoke(this, e);
        }

        private void XiLanh2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh2Click?.Invoke(this, e);
        }

        private void XiLanh1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Xilanh1Click?.Invoke(this, e);
        }

        private void MotorVitTaiRaLieu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorVTRLClick?.Invoke(this, e);
        }

        private void MotorVitTaiCapLieu1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorVTCL1Click?.Invoke(this, e);
        }

        private void MotorVitTaiCapLieu2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MotorVTCL2Click?.Invoke(this, e);
        }
        #endregion
    }
}
