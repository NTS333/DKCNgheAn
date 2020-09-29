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
        public ITag BaoDayCylone1 { get; set; }
        public ITag BaoDayCylone2 { get; set; }
        public ITag BomDau1 { get; set; }
        //vit tai
        public ITag VitTaiRaLieu { get; set; }
        public ITag MortorVitTai1ChayNghich { get; set; }
        public ITag MortorVitTai1ChayThuan { get; set; }
        public ITag MortorVitTai2ChayNghich { get; set; }
        public ITag MortorVitTai2ChayThuan { get; set; }
        //xilanh
        public ITag TrangThaiXiLanh1ChayLui { get; set; }
        public ITag TrangThaiXiLanh1ChayToi { get; set; }
        public ITag TrangThaiXiLanh2ChayLui { get; set; }
        public ITag TrangThaiXiLanh2ChayToi { get; set; }
        #endregion ----- PROPERTY USERCONTROL -----    

        public bool IsStarted { get; private set; }

        private bool vitTai1ChayThuan = false, vitTai1ChayNghich = false, vitTai2ChayThuan = false, vitTai2ChayNghich = false;
        private bool xiLanh1ChayToi = false, xiLanh1ChayLui = false, xiLanh2ChayToi = false, xiLanh2ChayLui = false;
        private bool xiLanh3ChayToi = false, xiLanh3ChayLui = false, xiLanh4ChayToi = false, xiLanh4ChayLui = false;

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
            

            mortorVitTai1.Visibility = Visibility.Collapsed;
            mortorVitTai2.Visibility = Visibility.Collapsed;
            vitTaiCapLieu1.Visibility = Visibility.Collapsed;
            vitTaiCapLieu2.Visibility = Visibility.Collapsed;
            mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
            mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;
            mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
            mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;
            motorVitTaiRaLieu.Visibility = Visibility.Collapsed;
            vitTaiRaLieuGif.Visibility = Visibility.Collapsed;

            Cylone1.Visibility = Visibility.Collapsed;
            Cylone2.Visibility = Visibility.Collapsed;
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
                BaoDayCylone1 = GetTag("High_Level_Cylone1");
                if (BaoDayCylone1 != null)
                {
                    BaoDayCylone1_ValueChanged(BaoDayCylone1, new TagValueChangedEventArgs("", BaoDayCylone1.Value));
                    BaoDayCylone1.ValueChanged += BaoDayCylone1_ValueChanged;
                }

                BaoDayCylone2 = GetTag("High_Level_Cylone2");
                if (BaoDayCylone2 != null)
                {
                    BaoDayCylone2_ValueChanged(BaoDayCylone2, new TagValueChangedEventArgs("", BaoDayCylone2.Value));
                    BaoDayCylone2.ValueChanged += BaoDayCylone2_ValueChanged;
                }

                BomDau1 = GetTag("ST_Pump1");
                if (BomDau1 != null)
                {
                    BomDau1_ValueChanged(BomDau1, new TagValueChangedEventArgs("", BomDau1.Value));
                    BomDau1.ValueChanged += BomDau1_ValueChanged;
                }

                VitTaiRaLieu = GetTag("ST_VTRL");
                if (VitTaiRaLieu != null)
                {
                    VitTaiRaLieu_ValueChanged(VitTaiRaLieu, new TagValueChangedEventArgs("", VitTaiRaLieu.Value));
                    VitTaiRaLieu.ValueChanged += VitTaiRaLieu_ValueChanged;
                }

                MortorVitTai1ChayNghich = GetTag("ST_VitTai1Nghich");
                if (MortorVitTai1ChayNghich != null)
                {
                    MortorVitTai1ChayNghich_ValueChanged(MortorVitTai1ChayNghich, new TagValueChangedEventArgs("", MortorVitTai1ChayNghich.Value));
                    MortorVitTai1ChayNghich.ValueChanged += MortorVitTai1ChayNghich_ValueChanged;
                }

                MortorVitTai1ChayThuan = GetTag("ST_VitTai1Thuan");
                if (MortorVitTai1ChayThuan != null)
                {
                    MortorVitTai1ChayThuan_ValueChanged(MortorVitTai1ChayThuan, new TagValueChangedEventArgs("", MortorVitTai1ChayThuan.Value));
                    MortorVitTai1ChayThuan.ValueChanged += MortorVitTai1ChayThuan_ValueChanged;
                }

                MortorVitTai2ChayNghich = GetTag("ST_VitTai2Nghich");
                if (MortorVitTai2ChayNghich != null)
                {
                    MortorVitTai2ChayNghich_ValueChanged(MortorVitTai2ChayNghich, new TagValueChangedEventArgs("", MortorVitTai2ChayNghich.Value));
                    MortorVitTai2ChayNghich.ValueChanged += MortorVitTai2ChayNghich_ValueChanged;
                }

                MortorVitTai2ChayThuan = GetTag("ST_VitTai2Thuan");
                if (MortorVitTai2ChayThuan != null)
                {
                    MortorVitTai2ChayThuan_ValueChanged(MortorVitTai2ChayThuan, new TagValueChangedEventArgs("", MortorVitTai2ChayThuan.Value));
                    MortorVitTai2ChayThuan.ValueChanged += MortorVitTai2ChayThuan_ValueChanged;
                }

                TrangThaiXiLanh1ChayLui = GetTag("ST_XiLanh1Lui");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh1ChayLui_ValueChanged(TrangThaiXiLanh1ChayLui, new TagValueChangedEventArgs("", TrangThaiXiLanh1ChayLui.Value));
                    TrangThaiXiLanh1ChayLui.ValueChanged += TrangThaiXiLanh1ChayLui_ValueChanged;
                }

                TrangThaiXiLanh1ChayToi = GetTag("ST_XiLanh1Tien");
                if (TrangThaiXiLanh1ChayToi != null)
                {
                    TrangThaiXiLanh1ChayToi_ValueChanged(TrangThaiXiLanh1ChayToi, new TagValueChangedEventArgs("", TrangThaiXiLanh1ChayToi.Value));
                    TrangThaiXiLanh1ChayToi.ValueChanged += TrangThaiXiLanh1ChayToi_ValueChanged;
                }

                TrangThaiXiLanh2ChayLui = GetTag("ST_XiLanh2Lui");
                if (TrangThaiXiLanh1ChayLui != null)
                {
                    TrangThaiXiLanh2ChayLui_ValueChanged(TrangThaiXiLanh2ChayLui, new TagValueChangedEventArgs("", TrangThaiXiLanh2ChayLui.Value));
                    TrangThaiXiLanh2ChayLui.ValueChanged += TrangThaiXiLanh2ChayLui_ValueChanged;
                }

                TrangThaiXiLanh2ChayToi = GetTag("ST_XiLanh2Tien");
                if (TrangThaiXiLanh2ChayToi != null)
                {
                    TrangThaiXiLanh2ChayToi_ValueChanged(TrangThaiXiLanh2ChayToi, new TagValueChangedEventArgs("", TrangThaiXiLanh2ChayToi.Value));
                    TrangThaiXiLanh2ChayToi.ValueChanged += TrangThaiXiLanh2ChayToi_ValueChanged;
                }               
            });
        }

        private void TrangThaiXiLanh2ChayLui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    xiLanh2ChayLui = true;

                    xiLanh2.Visibility = Visibility.Visible;
                    xiLanh2Tien.Visibility = Visibility.Collapsed;
                    xiLanh2Lui.Visibility = Visibility.Visible;
                    xiLanh2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    xiLanh2ChayLui = false;
                    xiLanh2Lui.Visibility = Visibility.Collapsed;

                    if (xiLanh2ChayToi == false)
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
                    xiLanh2ChayToi = true;

                    xiLanh2.Visibility = Visibility.Visible;
                    xiLanh2Tien.Visibility = Visibility.Visible;
                    xiLanh2Lui.Visibility = Visibility.Collapsed;
                    xiLanh2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    xiLanh2ChayToi = false;
                    xiLanh2Tien.Visibility = Visibility.Collapsed;

                    if (xiLanh2ChayLui == false)
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
                    xiLanh1ChayToi = true;

                    xiLanh1.Visibility = Visibility.Visible;
                    xiLanh1Tien.Visibility = Visibility.Visible;
                    xiLanh1Lui.Visibility = Visibility.Collapsed;
                    xiLanh1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    xiLanh1ChayToi = false;
                    xiLanh1Tien.Visibility = Visibility.Collapsed;

                    if (xiLanh1ChayLui == false)
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
                    xiLanh1ChayLui = true;

                    xiLanh1.Visibility = Visibility.Visible;
                    xiLanh1Tien.Visibility = Visibility.Collapsed;
                    xiLanh1Lui.Visibility = Visibility.Visible;
                    xiLanh1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    xiLanh1ChayLui = false;
                    xiLanh1Lui.Visibility = Visibility.Collapsed;

                    if (xiLanh1ChayToi == false)
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
                    vitTai2ChayThuan = true;

                    mortorVitTai2.Visibility = Visibility.Visible;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Visible;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu2.Visibility = Visibility.Visible;
                }
                else
                {
                    vitTai2ChayThuan = false;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;

                    if (vitTai2ChayNghich == false)
                    {
                        mortorVitTai2.Visibility = Visibility.Collapsed;
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
                    vitTai2ChayNghich = true;

                    mortorVitTai2.Visibility = Visibility.Visible;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Visible;
                    mortorVitTai2ChayThuan.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu2.Visibility = Visibility.Visible;
                }
                else
                {
                    vitTai2ChayNghich = false;
                    mortorVitTai2ChayNghich.Visibility = Visibility.Collapsed;

                    if (vitTai2ChayThuan == false)
                    {
                        mortorVitTai2.Visibility = Visibility.Collapsed;
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
                    vitTai1ChayNghich = true;

                    mortorVitTai1.Visibility = Visibility.Visible;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Visible;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu1.Visibility = Visibility.Visible;
                }
                else
                {
                    vitTai1ChayNghich = false;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;

                    if (vitTai1ChayThuan == false)
                    {
                        mortorVitTai1.Visibility = Visibility.Collapsed;
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
                    vitTai1ChayThuan = true;

                    mortorVitTai1.Visibility = Visibility.Visible;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Visible;
                    mortorVitTai1ChayNghich.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu1.Visibility = Visibility.Visible;
                }
                else
                {
                    vitTai1ChayThuan = false;
                    mortorVitTai1ChayThuan.Visibility = Visibility.Collapsed;

                    if (vitTai1ChayNghich == false)
                    {
                        mortorVitTai1.Visibility = Visibility.Collapsed;
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
                    motorVitTaiRaLieu.Visibility = Visibility.Visible;
                    vitTaiRaLieuGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorVitTaiRaLieu.Visibility = Visibility.Collapsed;
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
                    bomDau1.Visibility = Visibility.Visible;
                }
                else
                {
                    bomDau1.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void BaoDayCylone2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    Cylone2.Visibility = Visibility.Visible;
                }
                else
                {
                    Cylone2.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void BaoDayCylone1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    Cylone1.Visibility = Visibility.Visible;
                }
                else
                {
                    Cylone1.Visibility = Visibility.Collapsed;
                }
            }));
        }
    }
}

