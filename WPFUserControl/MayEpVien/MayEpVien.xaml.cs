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
        public string DeviceNameMayEp3 { get; set; }
        public string DeviceNameMayEp4 { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public ITag MotorMayEpVien1 { get; set; }
        public ITag MotorMayEpVien2 { get; set; }
        public ITag MotorMayEpVien3 { get; set; }
        public ITag MotorMayEpVien4 { get; set; }
        public ITag MotorFeederA1 { get; set; }
        public ITag MotorFeederA2 { get; set; }
        public ITag MotorFeederA3 { get; set; }
        public ITag MotorFeederA4 { get; set; }
        public ITag MotorFeederB1 { get; set; }
        public ITag MotorFeederB2 { get; set; }
        public ITag MotorFeederB3 { get; set; }
        public ITag MotorFeederB4 { get; set; }
        public ITag MotorMixer1 { get; set; }
        public ITag MotorMixer2 { get; set; }
        public ITag MotorMixer3 { get; set; }
        public ITag MotorMixer4 { get; set; }

        #endregion ----- PROPERTY USERCONTROL -----    
        
        public MayEpVien()
        {
            InitializeComponent();
        }

        public bool IsStarted { get; private set; }

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
                MotorMayEpVien1 = GetTag(DeviceNameMayEp1, "PlM");
                if (MotorMayEpVien1 != null)
                {
                    MotorMayEpVien1_ValueChanged(MotorMayEpVien1, new TagValueChangedEventArgs("", MotorMayEpVien1.Value));
                    MotorMayEpVien1.ValueChanged += MotorMayEpVien1_ValueChanged;
                }

                MotorMayEpVien2 = GetTag(DeviceNameMayEp2, "PlM");
                if (MotorMayEpVien2 != null)
                {
                    MotorMayEpVien2_ValueChanged(MotorMayEpVien2, new TagValueChangedEventArgs("", MotorMayEpVien2.Value));
                    MotorMayEpVien2.ValueChanged += MotorMayEpVien2_ValueChanged;
                }

                MotorMayEpVien3 = GetTag(DeviceNameMayEp3, "PlM");
                if (MotorMayEpVien3 != null)
                {
                    MotorMayEpVien3_ValueChanged(MotorMayEpVien3, new TagValueChangedEventArgs("", MotorMayEpVien3.Value));
                    MotorMayEpVien3.ValueChanged += MotorMayEpVien3_ValueChanged;
                }

                MotorMayEpVien4 = GetTag(DeviceNameMayEp4, "PlM");
                if (MotorMayEpVien4 != null)
                {
                    MotorMayEpVien4_ValueChanged(MotorMayEpVien4, new TagValueChangedEventArgs("", MotorMayEpVien4.Value));
                    MotorMayEpVien4.ValueChanged += MotorMayEpVien4_ValueChanged;
                }

                MotorFeederA1 = GetTag(DeviceNameMayEp1, "PlM");
                if (MotorFeederA1 != null)
                {
                    MotorFeederA1_ValueChanged(MotorFeederA1, new TagValueChangedEventArgs("", MotorFeederA1.Value));
                    MotorFeederA1.ValueChanged += MotorFeederA1_ValueChanged;
                }

                MotorFeederB1 = GetTag(DeviceNameMayEp1, "PlM");
                if (MotorFeederB1 != null)
                {
                    MotorFeederB1_ValueChanged(MotorFeederB1, new TagValueChangedEventArgs("", MotorFeederB1.Value));
                    MotorFeederB1.ValueChanged += MotorFeederB1_ValueChanged;
                }

                MotorMixer1 = GetTag(DeviceNameMayEp1, "PlM");
                if (MotorMixer1 != null)
                {
                    MotorMixer1_ValueChanged(MotorMixer1, new TagValueChangedEventArgs("", MotorMixer1.Value));
                    MotorMixer1.ValueChanged += MotorMixer1_ValueChanged;
                }

                MotorFeederA2 = GetTag(DeviceNameMayEp2, "PlM");
                if (mortorFeederA2 != null)
                {
                    MotorFeederA2_ValueChanged(MotorFeederA2, new TagValueChangedEventArgs("", MotorFeederA2.Value));
                    MotorFeederA2.ValueChanged += MotorFeederA2_ValueChanged;
                }

                MotorFeederB2 = GetTag(DeviceNameMayEp2, "PlM");
                if (MotorFeederB2 != null)
                {
                    MotorFeederB2_ValueChanged(MotorFeederB2, new TagValueChangedEventArgs("", MotorFeederB2.Value));
                    MotorFeederB2.ValueChanged += MotorFeederB2_ValueChanged;
                }

                MotorMixer2 = GetTag(DeviceNameMayEp2, "PlM");
                if (MotorMixer2 != null)
                {
                    MotorMixer2_ValueChanged(MotorMixer2, new TagValueChangedEventArgs("", MotorMixer2.Value));
                    MotorMixer2.ValueChanged += MotorMixer2_ValueChanged;
                }

                MotorFeederA3 = GetTag(DeviceNameMayEp3, "PlM");
                if (mortorFeederA3 != null)
                {
                    MotorFeederA3_ValueChanged(MotorFeederA3, new TagValueChangedEventArgs("", MotorFeederA3.Value));
                    MotorFeederA3.ValueChanged += MotorFeederA3_ValueChanged;
                }

                MotorFeederB3 = GetTag(DeviceNameMayEp3, "PlM");
                if (MotorFeederB3 != null)
                {
                    MotorFeederB3_ValueChanged(MotorFeederB3, new TagValueChangedEventArgs("", MotorFeederB3.Value));
                    MotorFeederB3.ValueChanged += MotorFeederB3_ValueChanged;
                }

                MotorMixer3 = GetTag(DeviceNameMayEp3, "PlM");
                if (MotorMixer3 != null)
                {
                    MotorMixer3_ValueChanged(MotorMixer3, new TagValueChangedEventArgs("", MotorMixer3.Value));
                    MotorMixer3.ValueChanged += MotorMixer3_ValueChanged;
                }

                MotorFeederA4= GetTag(DeviceNameMayEp4, "PlM");
                if (mortorFeederA4 != null)
                {
                    MotorFeederA4_ValueChanged(MotorFeederA4, new TagValueChangedEventArgs("", MotorFeederA4.Value));
                    MotorFeederA4.ValueChanged += MotorFeederA4_ValueChanged;
                }

                MotorFeederB4 = GetTag(DeviceNameMayEp4, "PlM");
                if (MotorFeederB4 != null)
                {
                    MotorFeederB4_ValueChanged(MotorFeederB4, new TagValueChangedEventArgs("", MotorFeederB4.Value));
                    MotorFeederB4.ValueChanged += MotorFeederB4_ValueChanged;
                }

                MotorMixer4 = GetTag(DeviceNameMayEp4, "PlM");
                if (MotorMixer4 != null)
                {
                    MotorMixer4_ValueChanged(MotorMixer4, new TagValueChangedEventArgs("", MotorMixer4.Value));
                    MotorMixer4.ValueChanged += MotorMixer4_ValueChanged;
                }
            });
        }

        private void MotorMixer4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer4.Visibility = Visibility.Visible;
                    mortorMixer4Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer4.Visibility = Visibility.Collapsed;
                    mortorMixer4Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederB4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB4.Visibility = Visibility.Visible;
                    vitTaiFeederB4.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB4.Visibility = Visibility.Collapsed;
                    vitTaiFeederB4.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederA4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA4.Visibility = Visibility.Visible;
                    vitTaiFeederA4.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA4.Visibility = Visibility.Collapsed;
                    vitTaiFeederA4.Visibility = Visibility.Hidden;                    
                }
            }));
        }

        private void MotorMixer3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer3.Visibility = Visibility.Visible;
                    mortorMixer3Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer3.Visibility = Visibility.Collapsed;
                    mortorMixer3Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederB3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB3.Visibility = Visibility.Visible;
                    vitTaiFeederB3.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB3.Visibility = Visibility.Collapsed;
                    vitTaiFeederB3.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederA3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA3.Visibility = Visibility.Visible;
                    vitTaiFeederA3.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA3.Visibility = Visibility.Collapsed;
                    vitTaiFeederA3.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorMixer2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer2.Visibility = Visibility.Visible;
                    mortorMixer2Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer2.Visibility = Visibility.Collapsed;
                    mortorMixer2Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederB2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB2.Visibility = Visibility.Visible;
                    vitTaiFeederB2.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB2.Visibility = Visibility.Collapsed;
                    vitTaiFeederB2.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederA2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA2.Visibility = Visibility.Visible;
                    vitTaiFeederA2.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA2.Visibility = Visibility.Collapsed;
                    vitTaiFeederA2.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorMixer1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorMixer1.Visibility = Visibility.Visible;
                    mortorMixer1Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorMixer1.Visibility = Visibility.Collapsed;
                    mortorMixer1Gif.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederB1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederB1.Visibility = Visibility.Visible;
                    vitTaiFeederB1.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederB1.Visibility = Visibility.Collapsed;
                    vitTaiFeederB1.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorFeederA1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    mortorFeederA1.Visibility = Visibility.Visible;
                    vitTaiFeederA1.Visibility = Visibility.Visible;
                }
                else
                {
                    mortorFeederA1.Visibility = Visibility.Collapsed;
                    vitTaiFeederA1.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void MotorMayEpVien4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp4TraiChay.Visibility = Visibility.Visible;
                    motorMayEp4PhaiChay.Visibility = Visibility.Visible;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp4TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp4PhaiChay.Visibility = Visibility.Collapsed;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMayEpVien3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp3TraiChay.Visibility = Visibility.Visible;
                    motorMayEp3PhaiChay.Visibility = Visibility.Visible;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp3TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp3PhaiChay.Visibility = Visibility.Collapsed;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMayEpVien2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp2TraiChay.Visibility = Visibility.Visible;
                    motorMayEp2PhaiChay.Visibility = Visibility.Visible;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp2TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp2PhaiChay.Visibility = Visibility.Collapsed;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMayEpVien1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayEp1TraiChay.Visibility = Visibility.Visible;
                    motorMayEp1PhaiChay.Visibility = Visibility.Visible;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayEp1TraiChay.Visibility = Visibility.Collapsed;
                    motorMayEp1PhaiChay.Visibility = Visibility.Collapsed;
                    //motorMayEp1Loi.Visibility = Visibility.Collapsed;
                }
            }));
        }

        public ITag GetTag(string deviceNameMayEp, string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{deviceNameMayEp}/{tagName}");
        }
    }
}
