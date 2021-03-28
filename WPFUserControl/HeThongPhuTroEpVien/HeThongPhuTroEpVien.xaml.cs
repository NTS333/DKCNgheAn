using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class HeThongPhuTroEpVien : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public bool IsStarted { get; private set; }

        public ITag AlarmHeThong { get; set; }

        public ITag MotorPT4 { get; set; }
        public ITag MotorPT5 { get; set; }
        public ITag MotorPT6 { get; set; }
        public ITag MotorPT8 { get; set; }
        public ITag PT9 { get; set; }
        public ITag DayPinThanhPham { get; set; }

        public ITag AlarmMotorPT4 { get; set; }
        public ITag AlarmMotorPT5 { get; set; }
        public ITag AlarmMotorPT6 { get; set; }
        public ITag AlarmMotorPT8 { get; set; }
        

        public HeThongPhuTroEpVien()
        {
            InitializeComponent();

            bangTaiPT4Gif.Visibility = Visibility.Collapsed;
            motorPT4Chay.Visibility = Visibility.Collapsed;
            motorPT4Loi.Visibility = Visibility.Collapsed;
            motorPT5Chay.Visibility = Visibility.Collapsed;
            motorPT5Loi.Visibility = Visibility.Collapsed;
            motorPT6Chay.Visibility = Visibility.Collapsed;
            motorPT6Loi.Visibility = Visibility.Collapsed;
            vitTaiPT6uGif.Visibility = Visibility.Collapsed;
            bangTaiPT8Gif.Visibility = Visibility.Collapsed;
            motorPT8Chay.Visibility = Visibility.Collapsed;
            motorPT8Loi.Visibility = Visibility.Collapsed;

            pt91Off.Visibility = Visibility.Collapsed;
            pt91On.Visibility = Visibility.Collapsed;
            pt92Off.Visibility = Visibility.Collapsed;
            pt92On.Visibility = Visibility.Collapsed;
            pt93Off.Visibility = Visibility.Collapsed;
            pt93On.Visibility = Visibility.Collapsed;
            pt94Off.Visibility = Visibility.Collapsed;
            pt94On.Visibility = Visibility.Collapsed;

            baoDayBinThanhPhamOff.Visibility = Visibility.Collapsed;
            baoDayBinThanhPhamOn.Visibility = Visibility.Collapsed;

            quatLamMat1Chay.Visibility = Visibility.Collapsed;
            quatLamMat1Loi.Visibility = Visibility.Collapsed;

            quatLamMat2Chay.Visibility = Visibility.Collapsed;
            quatLamMat2Loi.Visibility = Visibility.Collapsed;

            quatLamMat3Chay.Visibility = Visibility.Collapsed;
            quatLamMat3Loi.Visibility = Visibility.Collapsed;

            quatLamMat4Chay.Visibility = Visibility.Collapsed;
            quatLamMat4Loi.Visibility = Visibility.Collapsed;
            
            loiHeThong.Visibility = Visibility.Collapsed;
        }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        public int Error
        {
            get { return (int)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(int), typeof(HeThongPhuTroEpVien), new PropertyMetadata(0));


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
            Dispatcher.Invoke((Action)(() =>
            {
                AlarmHeThong = GetTag("Alarm_HT");
                if (AlarmHeThong != null)
                {
                    BaoAlarmHeThong_ValueChanged(AlarmHeThong, new TagValueChangedEventArgs(AlarmHeThong,"", AlarmHeThong.Value));
                    AlarmHeThong.ValueChanged += BaoAlarmHeThong_ValueChanged;
                }

                MotorPT4 = GetTag("PL_PT4");
                if (MotorPT4 != null)
                {
                    MotorPT4_ValueChanged(MotorPT4, new TagValueChangedEventArgs(MotorPT4,"", MotorPT4.Value));
                    MotorPT4.ValueChanged += MotorPT4_ValueChanged;
                }

                MotorPT5 = GetTag("PL_PT5");
                if (MotorPT5 != null)
                {
                    MotorPT5_ValueChanged(MotorPT5, new TagValueChangedEventArgs(MotorPT5,"", MotorPT5.Value));
                    MotorPT5.ValueChanged += MotorPT5_ValueChanged;
                }

                MotorPT6 = GetTag("PL_PT6");
                if (MotorPT6 != null)
                {
                    MotorPT6_ValueChanged(MotorPT6, new TagValueChangedEventArgs(MotorPT6,"", MotorPT6.Value));
                    MotorPT6.ValueChanged += MotorPT6_ValueChanged;
                }

                MotorPT8 = GetTag("PL_PT8");
                if (MotorPT8 != null)
                {
                    MotorPT8_ValueChanged(MotorPT8, new TagValueChangedEventArgs(MotorPT8,"", MotorPT8.Value));
                    MotorPT8.ValueChanged += MotorPT8_ValueChanged;
                }

                AlarmMotorPT4 = GetTag("PL_OVL_PT4");
                if (AlarmMotorPT4 != null)
                {
                    AlarmMotorPT4_ValueChanged(AlarmMotorPT4, new TagValueChangedEventArgs(AlarmMotorPT4,"", AlarmMotorPT4.Value));
                    AlarmMotorPT4.ValueChanged += AlarmMotorPT4_ValueChanged;
                }

                AlarmMotorPT5 = GetTag("PL_OVL_PT5");
                if (AlarmMotorPT5 != null)
                {
                    this.AlarmMotorPT5_ValueChanged(AlarmMotorPT5, new TagValueChangedEventArgs(AlarmMotorPT5, "", AlarmMotorPT5.Value));
                    AlarmMotorPT5.ValueChanged += this.AlarmMotorPT5_ValueChanged;
                }

                AlarmMotorPT6 = GetTag("PL_OVL_PT6");
                if (AlarmMotorPT6 != null)
                {
                    AlarmMotorPT6_ValueChanged(AlarmMotorPT6, new TagValueChangedEventArgs(AlarmMotorPT6,"", AlarmMotorPT6.Value));
                    AlarmMotorPT6.ValueChanged += AlarmMotorPT6_ValueChanged;
                }

                AlarmMotorPT8 = GetTag("PL_OVL_PT8");
                if (AlarmMotorPT8 != null)
                {
                    AlarmMotorPT8_ValueChanged(AlarmMotorPT8, new TagValueChangedEventArgs(AlarmMotorPT8, "", AlarmMotorPT8.Value));
                    AlarmMotorPT8.ValueChanged += AlarmMotorPT8_ValueChanged;
                }

                PT9 = GetTag("PL_PT9");
                if (PT9 != null)
                {
                    PT9_ValueChanged(PT9, new TagValueChangedEventArgs(PT9, "", PT9.Value));
                    PT9.ValueChanged += PT9_ValueChanged;
                }

                DayPinThanhPham = GetTag("PL_OVL_PT7");
                if (DayPinThanhPham != null)
                {
                    DayPinThanhPham_ValueChanged(DayPinThanhPham, new TagValueChangedEventArgs(DayPinThanhPham, "", DayPinThanhPham.Value));
                    DayPinThanhPham.ValueChanged += DayPinThanhPham_ValueChanged;
                }
            }));
        }

        #region funtions
        private void PT9_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    pt91On.Visibility = Visibility.Visible;
                    pt92On.Visibility = Visibility.Visible;
                    pt93On.Visibility = Visibility.Visible;
                    pt94On.Visibility = Visibility.Visible;
                    pt91Off.Visibility = Visibility.Collapsed;
                    pt92Off.Visibility = Visibility.Collapsed;
                    pt93Off.Visibility = Visibility.Collapsed;
                    pt94Off.Visibility = Visibility.Collapsed;
                }
                else
                {
                    pt91On.Visibility = Visibility.Collapsed;
                    pt92On.Visibility = Visibility.Collapsed;
                    pt93On.Visibility = Visibility.Collapsed;
                    pt94On.Visibility = Visibility.Collapsed;
                    pt91Off.Visibility = Visibility.Visible;
                    pt92Off.Visibility = Visibility.Visible;
                    pt93Off.Visibility = Visibility.Visible;
                    pt94Off.Visibility = Visibility.Visible;
                }
            }));
        }

        private void DayPinThanhPham_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    baoDayBinThanhPhamOn.Visibility = Visibility.Visible;
                    baoDayBinThanhPhamOff.Visibility = Visibility.Collapsed;
                }
                else
                {
                    baoDayBinThanhPhamOff.Visibility = Visibility.Visible;
                    baoDayBinThanhPhamOn.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void AlarmMotorPT8_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT8Loi.Visibility = Visibility.Visible;
                    motorPT8Chay.Visibility = Visibility.Collapsed;
                    motorPT8Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT8Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT8.Value == "1")
                    {
                        motorPT8Dung.Visibility = Visibility.Collapsed;
                        motorPT8Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT8Dung.Visibility = Visibility.Visible;
                        motorPT8Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorPT5_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT5Loi.Visibility = Visibility.Visible;
                    motorPT5Chay.Visibility = Visibility.Collapsed;
                    motorPT5Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT5Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT5.Value == "1")
                    {
                        motorPT5Dung.Visibility = Visibility.Collapsed;
                        motorPT5Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT5Dung.Visibility = Visibility.Visible;
                        motorPT5Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorPT6_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT6Loi.Visibility = Visibility.Visible;
                    motorPT6Chay.Visibility = Visibility.Collapsed;
                    motorPT6Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT6Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT6.Value == "1")
                    {
                        motorPT6Dung.Visibility = Visibility.Collapsed;
                        motorPT6Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT6Dung.Visibility = Visibility.Visible;
                        motorPT6Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void AlarmMotorPT4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT4Loi.Visibility = Visibility.Visible;
                    motorPT4Chay.Visibility = Visibility.Collapsed;
                    motorPT4Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT4Loi.Visibility = Visibility.Collapsed;

                    if (MotorPT4.Value == "1")
                    {
                        motorPT4Dung.Visibility = Visibility.Collapsed;
                        motorPT4Chay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorPT4Dung.Visibility = Visibility.Visible;
                        motorPT4Chay.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        private void BaoAlarmHeThong_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    Error = 1;
                    loiHeThong.Visibility = Visibility.Visible;
                }
                else
                {
                    Error = 0;
                    loiHeThong.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT4Chay.Visibility = Visibility.Visible;
                    motorPT4Dung.Visibility = Visibility.Collapsed;
                    bangTaiPT4Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT4Dung.Visibility = Visibility.Visible;
                    motorPT4Chay.Visibility = Visibility.Collapsed;
                    bangTaiPT4Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT6_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT6Chay.Visibility = Visibility.Visible;
                    motorPT6Dung.Visibility = Visibility.Collapsed;
                    vitTaiPT6uGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT6Dung.Visibility = Visibility.Visible;
                    motorPT6Chay.Visibility = Visibility.Collapsed;
                    vitTaiPT6uGif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT5_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT5Chay.Visibility = Visibility.Visible;
                    motorPT5Dung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorPT5Dung.Visibility = Visibility.Visible;
                    motorPT5Chay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorPT8_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorPT8Chay.Visibility = Visibility.Visible;
                    motorPT8Dung.Visibility = Visibility.Collapsed;
                    bangTaiPT8Gif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorPT8Dung.Visibility = Visibility.Visible;
                    motorPT8Chay.Visibility = Visibility.Collapsed;
                    bangTaiPT8Gif.Visibility = Visibility.Collapsed;
                }
            }));
        }
        #endregion

        #region Events
        public event EventHandler MotorPT4Click;
        public event EventHandler MotorPT5Click;
        public event EventHandler MotorPT6Click;
        public event EventHandler MotorPT8Click;
        #endregion

        private void MotorPT4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT4Click?.Invoke(this, e);
        }

        private void MotorPT8_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT8Click?.Invoke(this, e);
        }

        private void MotorPT5_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT5Click?.Invoke(this, e);
        }

        private void MotorPT6_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorPT6Click?.Invoke(this, e);
        }
    }
}
