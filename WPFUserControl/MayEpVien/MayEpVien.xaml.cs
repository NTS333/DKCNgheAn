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
    public partial class MayEpVien : UserControl
    {
        #region ----- PROPERTY USERCONTROL -----

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceNameMayEp1 { get; set; }
        public string DeviceNameMayEp2 { get; set; }

        public string DeviceNamePhuTroEpVien { get; set; }//phu tro ep vien

        public IEasyDriverConnector Connector { get; set; }
        public ITag MotorMayEpVien1 { get; set; }
        public ITag MotorMayEpVien2 { get; set; }

        public ITag MotorFeederA11 { get; set; }
        public ITag MotorFeederA12 { get; set; }

        public ITag MotorFeederA21 { get; set; }
        public ITag MotorFeederA22 { get; set; }

        public ITag MotorFeederB1 { get; set; }
        public ITag MotorFeederB2 { get; set; }

        public ITag MotorMixer1 { get; set; }
        public ITag MotorMixer2 { get; set; }

        public ITag DayBinLieu { get; set; }
        public ITag CanBinLieu1 { get; set; }
        public ITag CanBinLieu2 { get; set; }

        public ITag MotorPT1 { get; set; }
        public ITag MotorPT2 { get; set; }
        public ITag MotorPT3 { get; set; }

        public ITag AlarmHeThongEV1 { get; set; }
        public ITag AlarmHeThongEV2 { get; set; }
        public ITag AlarmMotorMayEp1 { get; set; }
        public ITag AlarmMotorMayEp2 { get; set; }
        public ITag AlarmMotorMix1 { get; set; }
        public ITag AlarmMotorMix2 { get; set; }
        public ITag AlarmMotorFeederB1 { get; set; }
        public ITag AlarmMotorFeederA11 { get; set; }
        public ITag AlarmMotorFeederA12 { get; set; }
        public ITag AlarmMotorFeederB2 { get; set; }
        public ITag AlarmMotorFeederA21 { get; set; }
        public ITag AlarmMotorFeederA22 { get; set; }
        public ITag AlarmMotorPt1 { get; set; }
        public ITag AlarmMotorPt2 { get; set; }
        public ITag AlarmMotorPt3 { get; set; }
        #endregion ----- PROPERTY USERCONTROL -----    

        public MayEpVien()
        {
            InitializeComponent();

            motorMayEp1PhaiChay.Visibility = Visibility.Collapsed;
            motorMayEp1PhaiLoi.Visibility = Visibility.Collapsed;
            motorMayEp1TraiChay.Visibility = Visibility.Collapsed;
            motorMayEp1TraiLoi.Visibility = Visibility.Collapsed;

            motorMayEp2PhaiChay.Visibility = Visibility.Collapsed;
            motorMayEp2PhaiLoi.Visibility = Visibility.Collapsed;
            motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
            motorMayEp2TraiLoi.Visibility = Visibility.Collapsed;

            mortorMixer1Loi.Visibility = Visibility.Collapsed;
            mortorMixer1Chay.Visibility = Visibility.Collapsed;
            mortorMixer1Gif.Visibility = Visibility.Collapsed;
            vitTaiMix1Gif.Visibility = Visibility.Collapsed;

            mortorMixer2Loi.Visibility = Visibility.Collapsed;
            mortorMixer2Chay.Visibility = Visibility.Collapsed;
            mortorMixer2Gif.Visibility = Visibility.Collapsed;
            vitTaiMix2Gif.Visibility = Visibility.Collapsed;

            mortorFeederB1Chay.Visibility = Visibility.Collapsed;
            mortorFeederB1Loi.Visibility = Visibility.Collapsed;
            mortorFeederA11Loi.Visibility = Visibility.Collapsed;
            mortorFeederA12Loi.Visibility = Visibility.Collapsed;
            vitTaiFeederB1Gif.Visibility = Visibility.Collapsed;
            vitTaiFeederA11Gif.Visibility = Visibility.Collapsed;
            vitTaiFeederA12Gif.Visibility = Visibility.Collapsed;

            mortorFeederB2Chay.Visibility = Visibility.Collapsed;
            mortorFeederB2Loi.Visibility = Visibility.Collapsed;
            mortorFeederA21Loi.Visibility = Visibility.Collapsed;
            mortorFeederA22Loi.Visibility = Visibility.Collapsed;
            vitTaiFeederB2Gif.Visibility = Visibility.Collapsed;
            vitTaiFeederA21Gif.Visibility = Visibility.Collapsed;
            vitTaiFeederA22Gif.Visibility = Visibility.Collapsed;

            motorPT1Chay.Visibility = Visibility.Collapsed;
            motorPT1Loi.Visibility = Visibility.Collapsed;
            bangTaiPt1Gif.Visibility = Visibility.Collapsed;

            motorPT2Chay.Visibility = Visibility.Collapsed;
            motorPT2Loi.Visibility = Visibility.Collapsed;
            bangTaiPt2Gif.Visibility = Visibility.Collapsed;

            motorPT3Chay.Visibility = Visibility.Collapsed;
            motorPT3Loi.Visibility = Visibility.Collapsed;
            bangTaiPT3Gif.Visibility = Visibility.Collapsed;

            baoDayBinLieuEpVienOn.Visibility = Visibility.Collapsed;
            baoDayBinLieuEpVienOff.Visibility = Visibility.Collapsed;

            baoCanBinLieuEpVien1Off.Visibility = Visibility.Collapsed;
            baoCanBinLieuEpVien1On.Visibility = Visibility.Collapsed;

            baoCanBinLieuEpVien2Off.Visibility = Visibility.Collapsed;
            baoCanBinLieuEpVien2On.Visibility = Visibility.Collapsed;

            loiMayEpVien1.Visibility = Visibility.Collapsed;
            loiMayEpVien2.Visibility = Visibility.Collapsed;
        }

        public bool IsStarted { get; private set; }

        public int Error
        {
            get { return (int)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(int), typeof(MayEpVien), new PropertyMetadata(0));


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

        public ITag GetTag(string deviceNameMayEp, string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{deviceNameMayEp}/{tagName}");
        }

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                #region may ep vien 1
                AlarmHeThongEV1 = GetTag(DeviceNameMayEp1, "Alarm_HT");
                if (AlarmHeThongEV1 != null)
                {
                    AlarmHeThongEV1_ValueChanged(AlarmHeThongEV1, new TagValueChangedEventArgs(AlarmHeThongEV1, "", AlarmHeThongEV1.Value));
                    AlarmHeThongEV1.ValueChanged += AlarmHeThongEV1_ValueChanged;
                }

                MotorMayEpVien1 = GetTag(DeviceNameMayEp1, "PL_M");
                if (MotorMayEpVien1 != null)
                {
                    MotorMayEpVien1_ValueChanged(MotorMayEpVien1, new TagValueChangedEventArgs(MotorMayEpVien1, "", MotorMayEpVien1.Value));
                    MotorMayEpVien1.ValueChanged += MotorMayEpVien1_ValueChanged;
                }

                MotorMixer1 = GetTag(DeviceNameMayEp1, "PL_MX");
                if (MotorMixer1 != null)
                {
                    MotorMixer1_ValueChanged(MotorMixer1, new TagValueChangedEventArgs(MotorMixer1, "", MotorMixer1.Value));
                    MotorMixer1.ValueChanged += MotorMixer1_ValueChanged;
                }

                MotorFeederA12 = GetTag(DeviceNameMayEp1, "PL_A2");
                if (MotorFeederA12 != null)
                {
                    MotorFeederA12_ValueChanged(MotorFeederA12, new TagValueChangedEventArgs(MotorFeederA12, "", MotorFeederA12.Value));
                    MotorFeederA12.ValueChanged += MotorFeederA12_ValueChanged;
                }

                MotorFeederA11 = GetTag(DeviceNameMayEp1, "PL_A1");
                if (MotorFeederA11 != null)
                {
                    MotorFeederA11_ValueChanged(MotorFeederA11, new TagValueChangedEventArgs(MotorFeederA11, "", MotorFeederA11.Value));
                    MotorFeederA11.ValueChanged += MotorFeederA11_ValueChanged;
                }

                MotorFeederB1 = GetTag(DeviceNameMayEp1, "PL_B");
                if (MotorFeederB1 != null)
                {
                    MotorFeederB1_ValueChanged(MotorFeederB1, new TagValueChangedEventArgs(MotorFeederB1, "", MotorFeederB1.Value));
                    MotorFeederB1.ValueChanged += MotorFeederB1_ValueChanged;
                }

                CanBinLieu1 = GetTag(DeviceNameMayEp1, "Low_LV_EV");
                if (CanBinLieu1 != null)
                {
                    CanBinLieu1_ValueChanged(CanBinLieu1, new TagValueChangedEventArgs(CanBinLieu1, "", CanBinLieu1.Value));
                    CanBinLieu1.ValueChanged += CanBinLieu1_ValueChanged;
                }

                //alarm
                AlarmMotorMayEp1 = GetTag(DeviceNameMayEp1, "PL_OVL_M");
                if (AlarmMotorMayEp1 != null)
                {
                    AlarmMotorMayEp1_ValueChanged(AlarmMotorMayEp1, new TagValueChangedEventArgs(AlarmMotorMayEp1, "", AlarmMotorMayEp1.Value));
                    AlarmMotorMayEp1.ValueChanged += AlarmMotorMayEp1_ValueChanged;
                }

                AlarmMotorMix1 = GetTag(DeviceNameMayEp1, "PL_OVL_MX");
                if (AlarmMotorMix1 != null)
                {
                    AlarmMotorMix1_ValueChanged(AlarmMotorMix1, new TagValueChangedEventArgs(AlarmMotorMix1, "", AlarmMotorMix1.Value));
                    AlarmMotorMix1.ValueChanged += AlarmMotorMix1_ValueChanged;
                }

                AlarmMotorFeederB1 = GetTag(DeviceNameMayEp1, "PL_OVL_B");
                if (AlarmMotorFeederB1 != null)
                {
                    AlarmMotorFeederB1_ValueChanged(AlarmMotorFeederB1, new TagValueChangedEventArgs(AlarmMotorFeederB1, "", AlarmMotorFeederB1.Value));
                    AlarmMotorFeederB1.ValueChanged += AlarmMotorFeederB1_ValueChanged;
                }

                AlarmMotorFeederA11 = GetTag(DeviceNameMayEp1, "PL_OVL_A1");
                if (AlarmMotorFeederA11 != null)
                {
                    AlarmMotorFeederA11_ValueChanged(AlarmMotorFeederA11, new TagValueChangedEventArgs(AlarmMotorFeederA11, "", AlarmMotorFeederA11.Value));
                    AlarmMotorFeederA11.ValueChanged += AlarmMotorFeederA11_ValueChanged;
                }
                AlarmMotorFeederA12 = GetTag(DeviceNameMayEp1, "PL_OVL_A2");
                if (AlarmMotorFeederA12 != null)
                {
                    AlarmMotorFeederA12_ValueChanged(AlarmMotorFeederA12, new TagValueChangedEventArgs(AlarmMotorFeederA12, "", AlarmMotorFeederA12.Value));
                    AlarmMotorFeederA12.ValueChanged += AlarmMotorFeederA12_ValueChanged;
                }
                #endregion

                #region may ep vien 2
                AlarmHeThongEV2 = GetTag(DeviceNameMayEp2, "Alarm_HT");
                if (AlarmHeThongEV2 != null)
                {
                    AlarmHeThongEV2_ValueChanged(AlarmHeThongEV2, new TagValueChangedEventArgs(AlarmHeThongEV2, "", AlarmHeThongEV2.Value));
                    AlarmHeThongEV2.ValueChanged += AlarmHeThongEV2_ValueChanged;
                }

                MotorMayEpVien2 = GetTag(DeviceNameMayEp2, "PL_M");
                if (MotorMayEpVien2 != null)
                {
                    MotorMayEpVien2_ValueChanged(MotorMayEpVien2, new TagValueChangedEventArgs(MotorMayEpVien2, "", MotorMayEpVien2.Value));
                    MotorMayEpVien2.ValueChanged += MotorMayEpVien2_ValueChanged;
                }

                MotorMixer2 = GetTag(DeviceNameMayEp2, "PL_MX");
                if (MotorMixer2 != null)
                {
                    MotorMixer2_ValueChanged(MotorMixer2, new TagValueChangedEventArgs(MotorMixer2, "", MotorMixer2.Value));
                    MotorMixer2.ValueChanged += MotorMixer2_ValueChanged;
                }

                MotorFeederA22 = GetTag(DeviceNameMayEp2, "PL_A2");
                if (MotorFeederA22 != null)
                {
                    MotorFeederA22_ValueChanged(MotorFeederA22, new TagValueChangedEventArgs(MotorFeederA22, "", MotorFeederA22.Value));
                    MotorFeederA22.ValueChanged += MotorFeederA22_ValueChanged;
                }

                MotorFeederA21 = GetTag(DeviceNameMayEp2, "PL_A1");
                if (MotorFeederA21 != null)
                {
                    MotorFeederA21_ValueChanged(MotorFeederA21, new TagValueChangedEventArgs(MotorFeederA21, "", MotorFeederA21.Value));
                    MotorFeederA21.ValueChanged += MotorFeederA21_ValueChanged;
                }

                MotorFeederB2 = GetTag(DeviceNameMayEp2, "PL_B");
                if (MotorFeederB2 != null)
                {
                    MotorFeederB2_ValueChanged(MotorFeederB2, new TagValueChangedEventArgs(MotorFeederB2, "", MotorFeederB2.Value));
                    MotorFeederB2.ValueChanged += MotorFeederB2_ValueChanged;
                }

                CanBinLieu2 = GetTag(DeviceNameMayEp2, "Low_LV_EV");
                if (CanBinLieu2 != null)
                {
                    CanBinLieu2_ValueChanged(CanBinLieu2, new TagValueChangedEventArgs(CanBinLieu2, "", CanBinLieu2.Value));
                    CanBinLieu2.ValueChanged += CanBinLieu2_ValueChanged;
                }

                //alarm
                AlarmMotorMayEp2 = GetTag(DeviceNameMayEp2, "PL_OVL_M");
                if (AlarmMotorMayEp2 != null)
                {
                    AlarmMotorMayEp2_ValueChanged(AlarmMotorMayEp2, new TagValueChangedEventArgs(AlarmMotorMayEp2, "", AlarmMotorMayEp2.Value));
                    AlarmMotorMayEp2.ValueChanged += AlarmMotorMayEp2_ValueChanged;
                }

                AlarmMotorMix2 = GetTag(DeviceNameMayEp2, "PL_OVL_MX");
                if (AlarmMotorMix2 != null)
                {
                    AlarmMotorMix2_ValueChanged(AlarmMotorMix2, new TagValueChangedEventArgs(AlarmMotorMix2, "", AlarmMotorMix2.Value));
                    AlarmMotorMix2.ValueChanged += AlarmMotorMix2_ValueChanged;
                }

                AlarmMotorFeederB2 = GetTag(DeviceNameMayEp2, "PL_OVL_B");
                if (AlarmMotorFeederB2 != null)
                {
                    AlarmMotorFeederB2_ValueChanged(AlarmMotorFeederB2, new TagValueChangedEventArgs(AlarmMotorFeederB2, "", AlarmMotorFeederB2.Value));
                    AlarmMotorFeederB2.ValueChanged += AlarmMotorFeederB2_ValueChanged;
                }

                AlarmMotorFeederA21 = GetTag(DeviceNameMayEp2, "PL_OVL_A1");
                if (AlarmMotorFeederA21 != null)
                {
                    AlarmMotorFeederA21_ValueChanged(AlarmMotorFeederA21, new TagValueChangedEventArgs(AlarmMotorFeederA21, "", AlarmMotorFeederA21.Value));
                    AlarmMotorFeederA21.ValueChanged += AlarmMotorFeederA21_ValueChanged;
                }
                AlarmMotorFeederA22 = GetTag(DeviceNameMayEp2, "PL_OVL_A2");
                if (AlarmMotorFeederA22 != null)
                {
                    AlarmMotorFeederA22_ValueChanged(AlarmMotorFeederA22, new TagValueChangedEventArgs(AlarmMotorFeederA22, "", AlarmMotorFeederA22.Value));
                    AlarmMotorFeederA22.ValueChanged += AlarmMotorFeederA22_ValueChanged;
                }
                #endregion

                #region chung
                DayBinLieu = GetTag(DeviceNameMayEp1, "High_LV_EV");
                if (DayBinLieu != null)
                {
                    DayBinLieu_ValueChanged(DayBinLieu, new TagValueChangedEventArgs(DayBinLieu, "", DayBinLieu.Value));
                    DayBinLieu.ValueChanged += DayBinLieu_ValueChanged;
                }

                MotorPT1 = GetTag(DeviceNamePhuTroEpVien, "PL_PT1");
                if (MotorPT1 != null)
                {
                    MotorPT1_ValueChanged(MotorPT1, new TagValueChangedEventArgs(MotorPT1, "", MotorPT1.Value));
                    MotorPT1.ValueChanged += MotorPT1_ValueChanged;
                }

                MotorPT2 = GetTag(DeviceNamePhuTroEpVien, "PL_PT2");
                if (MotorPT2 != null)
                {
                    MotorPT2_ValueChanged(MotorPT2, new TagValueChangedEventArgs(MotorPT2, "", MotorPT2.Value));
                    MotorPT2.ValueChanged += MotorPT2_ValueChanged;
                }

                MotorPT3 = GetTag(DeviceNamePhuTroEpVien, "PL_PT3");
                if (MotorPT3 != null)
                {
                    MotorPT3_ValueChanged(MotorPT3, new TagValueChangedEventArgs(MotorPT3, "", MotorPT3.Value));
                    MotorPT3.ValueChanged += MotorPT3_ValueChanged;
                }

                AlarmMotorPt1 = GetTag(DeviceNamePhuTroEpVien, "PL_OVL_PT1");
                if (AlarmMotorPt1 != null)
                {
                    AlarmMotorPt1_ValueChanged(AlarmMotorPt1, new TagValueChangedEventArgs(AlarmMotorPt1, "", AlarmMotorPt1.Value));
                    AlarmMotorPt1.ValueChanged += AlarmMotorPt1_ValueChanged;
                }

                AlarmMotorPt2 = GetTag(DeviceNamePhuTroEpVien, "PL_OVL_PT2");
                if (AlarmMotorPt2 != null)
                {
                    AlarmMotorPt2_ValueChanged(AlarmMotorPt2, new TagValueChangedEventArgs(AlarmMotorPt2, "", AlarmMotorPt2.Value));
                    AlarmMotorPt2.ValueChanged += AlarmMotorPt2_ValueChanged;
                }

                AlarmMotorPt3 = GetTag(DeviceNamePhuTroEpVien, "PL_OVL_PT3");
                if (AlarmMotorPt3 != null)
                {
                    AlarmMotorPt3_ValueChanged(AlarmMotorPt3, new TagValueChangedEventArgs(AlarmMotorPt3, "", AlarmMotorPt3.Value));
                    AlarmMotorPt3.ValueChanged += AlarmMotorPt3_ValueChanged;
                }
                #endregion
            });
        }

        private void AlarmHeThongEV2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    Error = 1;
                    loiMayEpVien2.Visibility = Visibility.Visible;
                }
                else
                {
                    if (AlarmHeThongEV1.Value == "0")
                    {
                        Error = 0;
                    }

                    loiMayEpVien2.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void AlarmHeThongEV1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    Error = 1;
                    loiMayEpVien1.Visibility = Visibility.Visible;
                }
                else
                {
                    if (AlarmHeThongEV2.Value == "0")
                    {
                        Error = 0;
                    }

                    loiMayEpVien1.Visibility = Visibility.Collapsed;
                }
            }));
        }

        #region Funtions
        #region may ep 1
        private void MotorMayEpVien1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp1TraiChay.Visibility = Visibility.Visible;
                    motorMayEp1PhaiChay.Visibility = Visibility.Visible;
                    motorMayEp1TraiDung.Visibility = Visibility.Collapsed;
                    motorMayEp1PhaiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp1TraiDung.Visibility = Visibility.Visible;
                    motorMayEp1PhaiDung.Visibility = Visibility.Visible;
                    motorMayEp1TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp1PhaiChay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMixer1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer1Chay.Visibility = Visibility.Visible;
                    mortorMixer1Dung.Visibility = Visibility.Collapsed;
                    mortorMixer1Gif.Visibility = Visibility.Visible;
                    vitTaiMix1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer1Dung.Visibility = Visibility.Visible;
                    mortorMixer1Chay.Visibility = Visibility.Collapsed;
                    mortorMixer1Gif.Visibility = Visibility.Collapsed;
                    vitTaiMix1Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorFeederB1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB1Chay.Visibility = Visibility.Visible;
                    mortorFeederB1Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederB1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB1Dung.Visibility = Visibility.Visible;
                    mortorFeederB1Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederB1Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorFeederA12_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA12Chay.Visibility = Visibility.Visible;
                    mortorFeederA12Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederA12Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA12Dung.Visibility = Visibility.Visible;
                    mortorFeederA12Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederA12Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederA11_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA11Chay.Visibility = Visibility.Visible;
                    mortorFeederA11Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederA11Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA11Dung.Visibility = Visibility.Visible;
                    mortorFeederA11Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederA11Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void AlarmMotorFeederA12_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA12Loi.Visibility = Visibility.Visible;
                    mortorFeederA12Dung.Visibility = Visibility.Collapsed;
                    mortorFeederA12Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorFeederA12Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederA12.Value == "1")
                    {
                        mortorFeederA12Dung.Visibility = Visibility.Collapsed;
                        mortorFeederA12Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederA12Dung.Visibility = Visibility.Visible;
                        mortorFeederA12Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorFeederA11_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA11Loi.Visibility = Visibility.Visible;
                    mortorFeederA11Dung.Visibility = Visibility.Collapsed;
                    mortorFeederA11Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorFeederA11Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederA11.Value == "1")
                    {
                        mortorFeederA11Dung.Visibility = Visibility.Collapsed;
                        mortorFeederA11Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederA11Dung.Visibility = Visibility.Visible;
                        mortorFeederA11Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorFeederB1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB1Loi.Visibility = Visibility.Visible;
                    mortorFeederB1Dung.Visibility = Visibility.Collapsed;
                    mortorFeederB1Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorFeederB1Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederB1.Value == "1")
                    {
                        mortorFeederB1Dung.Visibility = Visibility.Collapsed;
                        mortorFeederB1Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederB1Dung.Visibility = Visibility.Visible;
                        mortorFeederB1Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorMix1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer1Loi.Visibility = Visibility.Visible;
                    mortorMixer1Dung.Visibility = Visibility.Collapsed;
                    mortorMixer1Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorMixer1Loi.Visibility = Visibility.Collapsed;

                    if (MotorMixer1.Value == "1")
                    {
                        mortorMixer1Dung.Visibility = Visibility.Collapsed;
                        mortorMixer1Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorMixer1Dung.Visibility = Visibility.Visible;
                        mortorMixer1Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorMayEp1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp1PhaiLoi.Visibility = Visibility.Visible;
                    motorMayEp1TraiLoi.Visibility = Visibility.Visible;
                    motorMayEp1TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp1PhaiChay.Visibility = Visibility.Collapsed;
                    motorMayEp1PhaiDung.Visibility = Visibility.Collapsed;
                    motorMayEp1TraiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp1PhaiLoi.Visibility = Visibility.Collapsed;
                    motorMayEp1TraiLoi.Visibility = Visibility.Collapsed;

                    if (MotorMayEpVien1.Value == "1")
                    {
                        motorMayEp1PhaiDung.Visibility = Visibility.Collapsed;
                        motorMayEp1TraiDung.Visibility = Visibility.Collapsed;
                        motorMayEp1TraiChay.Visibility = Visibility.Visible;
                        motorMayEp2TraiChay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorMayEp1PhaiDung.Visibility = Visibility.Visible;
                        motorMayEp1TraiDung.Visibility = Visibility.Visible;
                        motorMayEp1TraiChay.Visibility = Visibility.Collapsed;
                        motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void CanBinLieu1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoCanBinLieuEpVien1On.Visibility = Visibility.Visible;
                    baoCanBinLieuEpVien1Off.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoCanBinLieuEpVien1On.Visibility = Visibility.Collapsed;
                    baoCanBinLieuEpVien1Off.Visibility = Visibility.Visible;
                }
            }));
        }
        #endregion

        #region may ep 2
        private void MotorMayEpVien2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp2TraiChay.Visibility = Visibility.Visible;
                    motorMayEp2PhaiChay.Visibility = Visibility.Visible;
                    motorMayEp2PhaiDung.Visibility = Visibility.Collapsed;
                    motorMayEp2TraiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp2PhaiDung.Visibility = Visibility.Visible;
                    motorMayEp2TraiDung.Visibility = Visibility.Visible;
                    motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp2PhaiChay.Visibility = Visibility.Collapsed;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorFeederA22_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA22Chay.Visibility = Visibility.Visible;
                    mortorFeederA22Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederA22Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA22Dung.Visibility = Visibility.Visible;
                    mortorFeederA22Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederA22Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorFeederA21_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA21Chay.Visibility = Visibility.Visible;
                    mortorFeederA21Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederA21Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA21Dung.Visibility = Visibility.Visible;
                    mortorFeederA21Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederA21Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMixer2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer2Chay.Visibility = Visibility.Visible;
                    mortorMixer2Dung.Visibility = Visibility.Collapsed;
                    mortorMixer2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer2Dung.Visibility = Visibility.Visible;
                    mortorMixer2Chay.Visibility = Visibility.Collapsed;
                    mortorMixer2Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorFeederB2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB2Chay.Visibility = Visibility.Visible;
                    mortorFeederB2Dung.Visibility = Visibility.Collapsed;
                    vitTaiFeederB2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB2Dung.Visibility = Visibility.Visible;
                    mortorFeederB2Chay.Visibility = Visibility.Collapsed;
                    vitTaiFeederB2Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void AlarmMotorMayEp2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp2PhaiLoi.Visibility = Visibility.Visible;
                    motorMayEp2TraiLoi.Visibility = Visibility.Visible;
                    motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp2PhaiChay.Visibility = Visibility.Collapsed;
                    motorMayEp2PhaiDung.Visibility = Visibility.Collapsed;
                    motorMayEp2TraiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp2PhaiLoi.Visibility = Visibility.Collapsed;
                    motorMayEp2TraiLoi.Visibility = Visibility.Collapsed;

                    if (MotorMayEpVien2.Value == "1")
                    {
                        motorMayEp2PhaiDung.Visibility = Visibility.Collapsed;
                        motorMayEp2TraiDung.Visibility = Visibility.Collapsed;
                        motorMayEp2TraiChay.Visibility = Visibility.Visible;
                        motorMayEp2TraiChay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorMayEp2PhaiDung.Visibility = Visibility.Visible;
                        motorMayEp2TraiDung.Visibility = Visibility.Visible;
                        motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                        motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorFeederA21_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA21Loi.Visibility = Visibility.Visible;
                    mortorFeederA21Dung.Visibility = Visibility.Collapsed;
                    mortorFeederA21Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorFeederA21Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederA21.Value == "1")
                    {
                        mortorFeederA21Dung.Visibility = Visibility.Collapsed;
                        mortorFeederA21Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederA21Dung.Visibility = Visibility.Visible;
                        mortorFeederA21Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorFeederB2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB2Loi.Visibility = Visibility.Visible;
                    mortorFeederB2Dung.Visibility = Visibility.Collapsed;
                    mortorFeederB2Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorFeederB2Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederB2.Value == "1")
                    {
                        mortorFeederB2Dung.Visibility = Visibility.Collapsed;
                        mortorFeederB2Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederB2Dung.Visibility = Visibility.Visible;
                        mortorFeederB2Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorMix2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer2Loi.Visibility = Visibility.Visible;
                    mortorMixer2Dung.Visibility = Visibility.Collapsed;
                    mortorMixer2Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorMixer2Loi.Visibility = Visibility.Collapsed;

                    if (MotorMixer2.Value == "1")
                    {
                        mortorMixer2Dung.Visibility = Visibility.Collapsed;
                        mortorMixer2Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorMixer2Dung.Visibility = Visibility.Visible;
                        mortorMixer2Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorFeederA22_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA22Loi.Visibility = Visibility.Visible;
                    mortorFeederA22Dung.Visibility = Visibility.Collapsed;
                    mortorFeederA22Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mortorMixer2Loi.Visibility = Visibility.Collapsed;

                    if (MotorFeederA22.Value == "1")
                    {
                        mortorFeederA22Dung.Visibility = Visibility.Collapsed;
                        mortorMixer2Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        mortorFeederA22Dung.Visibility = Visibility.Visible;
                        mortorMixer2Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void CanBinLieu2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoCanBinLieuEpVien2On.Visibility = Visibility.Visible;
                    baoCanBinLieuEpVien2Off.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoCanBinLieuEpVien2On.Visibility = Visibility.Collapsed;
                    baoCanBinLieuEpVien2Off.Visibility = Visibility.Visible;
                }
            }));
        }
        #endregion


        private void AlarmMotorPt3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT3Loi.Visibility = Visibility.Visible;
                    motorPT3Dung.Visibility = Visibility.Collapsed;
                    motorPT3Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT3Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT3.Value == "1")
                    {
                        motorPT3Dung.Visibility = Visibility.Collapsed;
                        motorPT3Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT3Dung.Visibility = Visibility.Visible;
                        motorPT3Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorPt2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT2Loi.Visibility = Visibility.Visible;
                    motorPT2Dung.Visibility = Visibility.Collapsed;
                    motorPT2Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT2Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT2.Value == "1")
                    {
                        motorPT2Dung.Visibility = Visibility.Collapsed;
                        motorPT2Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT2Dung.Visibility = Visibility.Visible;
                        motorPT2Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorPt1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT1Loi.Visibility = Visibility.Visible;
                    motorPT1Dung.Visibility = Visibility.Collapsed;
                    motorPT1Chay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT1Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT1.Value == "1")
                    {
                        motorPT1Dung.Visibility = Visibility.Collapsed;
                        motorPT1Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT1Dung.Visibility = Visibility.Visible;
                        motorPT1Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void MotorPT3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT3Chay.Visibility = Visibility.Visible;
                    motorPT3Dung.Visibility = Visibility.Collapsed;
                    bangTaiPT3Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT3Dung.Visibility = Visibility.Visible;
                    motorPT3Chay.Visibility = Visibility.Collapsed;
                    bangTaiPT3Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT2Chay.Visibility = Visibility.Visible;
                    motorPT2Dung.Visibility = Visibility.Collapsed;
                    bangTaiPt2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT2Dung.Visibility = Visibility.Visible;
                    motorPT2Chay.Visibility = Visibility.Collapsed;
                    bangTaiPt2Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT1Chay.Visibility = Visibility.Visible;
                    motorPT1Dung.Visibility = Visibility.Collapsed;
                    bangTaiPt1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT1Dung.Visibility = Visibility.Visible;
                    motorPT1Chay.Visibility = Visibility.Collapsed;
                    bangTaiPt1Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void DayBinLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayBinLieuEpVienOn.Visibility = Visibility.Visible;
                    baoDayBinLieuEpVienOff.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayBinLieuEpVienOn.Visibility = Visibility.Collapsed;
                    baoDayBinLieuEpVienOff.Visibility = Visibility.Visible;
                }
            }));
        }
        #endregion


        #region Events nhấn chuột vào các động cơ
        public event EventHandler MotorMayEpVien1Click;
        public event EventHandler MotorMixer1Click;
        public event EventHandler MotorB1Click;
        public event EventHandler MotorA11Click;
        public event EventHandler MotorA12Click;

        public event EventHandler MotorMayEpVien2Click;
        public event EventHandler MotorMixer2Click;
        public event EventHandler MotorB2Click;
        public event EventHandler MotorA21Click;
        public event EventHandler MotorA22Click;

        public event EventHandler MotorPT1Click;
        public event EventHandler MotorPT2Click;
        public event EventHandler MotorPT3Click;

        private void MotorMayApVien1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorMayEpVien1Click?.Invoke(this, e);
        }

        private void MotorB1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorB1Click?.Invoke(this, e);
        }

        private void MotorMix1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorMixer1Click?.Invoke(this, e);
        }

        private void MotorA11_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorA11Click?.Invoke(this, e);
        }

        private void MotorA12_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorA12Click?.Invoke(this, e);
        }

        private void MotorMayEpVien2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorMayEpVien2Click?.Invoke(this, e);
        }

        private void MotorB2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorB2Click?.Invoke(this, e);
        }

        private void MotorA21_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorA21Click?.Invoke(this, e);
        }

        private void MotorA22_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorA22Click?.Invoke(this, e);
        }

        private void MotorMixer2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorMixer2Click?.Invoke(this, e);
        }

        private void MotorPT1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT1Click?.Invoke(this, e);
        }

        private void MotorPT2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT2Click?.Invoke(this, e);
        }

        private void MotorPT3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT3Click?.Invoke(this, e);
        }
        #endregion
    }
}
