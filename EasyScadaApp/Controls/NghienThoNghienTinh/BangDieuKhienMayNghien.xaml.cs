using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace EasyScadaApp
{
    /// <summary>
    /// Interaction logic for BangDieuKhienMayNghien.xaml
    /// </summary>
    public partial class BangDieuKhienMayNghien : UserControl
    {
        public BangDieuKhienMayNghien()
        {
            InitializeComponent();
            this.Focus();
            this.PreviewKeyDown += BangDieuKhienMayNghien_KeyUp;
            if (this.Parent is DockPanel dock)
                (dock.Parent as Window).PreviewKeyDown += BangDieuKhienMayNghien_KeyUp;
            this.Unloaded += BangDieuKhienMayNghien_Unloaded;
            Loaded += BangDieuKhienMayNghien_Loaded;
        }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        private void BangDieuKhienMayNghien_Loaded(object sender, RoutedEventArgs e)
        {
            btnAuto.Focus();
        }

        private void BangDieuKhienMayNghien_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void BangDieuKhienMayNghien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (this.Parent is Window window)
                    window.Close();
                if (Parent is DockPanel dock)
                {
                    if (dock.Parent is Window w)
                        w.Close();
                }
            }
        }

        public string WriteManualValue { get; set; } = "1";
        public string WriteAutoValue { get; set; } = "1";

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string MotorName { get; set; }

        public string AutoTagName { get; set; }
        public string ManualTagName { get; set; }

        public string ResetAlarmTagName { get; set; }
        public string OnMotorTagName { get; set; }
        public string OffMotorTagName { get; set; }
        public string OffMotorMNTagName { get; set; }

        //get trang thai tuu plc ve để thể hiện lên nút nhấn
        public string StatusAlarmTagName { get; set; }
        public string StatusOffMotorTagName { get; set; }
        public string StatusOnMotorTagName { get; set; }
        public string StatusAutoTagName { get; set; }
        public string StatusManualTagName { get; set; }

        public ITag AutoTag { get; set; }
        public ITag ManualTag { get; set; }
        public ITag ResetAlarmTag { get; set; }
        public ITag OnMotorTag { get; set; }
        public ITag OffMotorTag { get; set; }
        public ITag OffMotorMNTag { get; set; }

        public ITag StatusAlarmTag { get; set; }
        public ITag StatusOffMotorTag { get; set; }
        public ITag StatusOnMotorTag { get; set; }
        public ITag StatusAutoTag { get; set; }
        public ITag StatusManualTag { get; set; }


        public IEasyDriverConnector Connector { get; private set; }

        bool isStarted = false;
        public void Start(
            string stationName, string channelName, string deviceName,
            string autoTagName, string manualTagName,
            string statusAlarmTagName, string resetAlarmTagName, string motorName, string onMotorTagName, string offMotorTagName, string offMotorMNTagName,
            string statusOffMotorTagName, string statusOnMotorTagName, string statusAutoTagName, string statusManualTagName)
        {
            if (!isStarted)
            {
                StationName = stationName;
                ChannelName = channelName;
                DeviceName = deviceName;
                MotorName = motorName;

                AutoTagName = autoTagName;
                ManualTagName = manualTagName;

                ResetAlarmTagName = resetAlarmTagName;
                OffMotorMNTagName = offMotorMNTagName;

                OnMotorTagName = onMotorTagName;
                OffMotorTagName = offMotorTagName;

                StatusAlarmTagName = statusAlarmTagName;
                StatusOffMotorTagName = statusOffMotorTagName;
                StatusOnMotorTagName = statusOnMotorTagName;
                StatusAutoTagName = statusAutoTagName;
                StatusManualTagName = statusManualTagName;

                isStarted = true;
                Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                if (MotorName == "MayNghien")
                {
                    btnOnMotor.Content = "CHẠY THUẬN";
                    btnOffMotor.Content = "CHẠY NGHỊCH";
                }
                else if (DeviceName == "MayEpVien1" || DeviceName == "MayEpVien2" || DeviceName == "PhuTroEpVien")
                {
                    btnAlarm.Visibility = Visibility.Collapsed;
                    btnOffMN.Visibility = Visibility.Collapsed;
                }
                else if (MotorName == "BTTu")
                {
                    btnOnMotor.Visibility = Visibility.Collapsed;
                    btnOffMotor.Visibility = Visibility.Collapsed;
                    //btnAlarm.Visibility = Visibility.Collapsed;
                    btnOffMN.Visibility = Visibility.Collapsed;
                }
                else if (deviceName == "GiuBuiEpVien")
                {
                    btnAuto.Visibility = Visibility.Collapsed;
                    btnManual.Visibility = Visibility.Collapsed;
                    btnAlarm.Visibility = Visibility.Collapsed;
                    btnOffMN.Visibility = Visibility.Collapsed;
                }
                else
                {
                    btnOffMN.Visibility = Visibility.Collapsed;
                }

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
            //nut nhan
            if (!string.IsNullOrEmpty(AutoTagName))
            {
                AutoTag = GetTag(AutoTagName);

                if (AutoTag != null)
                {
                    btnAuto.Click += BtnAuto_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnAuto.IsEnabled = false;
                    }));
                }
            }

            if (!string.IsNullOrEmpty(ManualTagName))
            {
                ManualTag = GetTag(ManualTagName);

                if (ManualTag != null)
                {
                    btnManual.Click += BtnManual_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnManual.IsEnabled = false;
                    }));
                }
            }

            if (!string.IsNullOrEmpty(OnMotorTagName))
            {
                OnMotorTag = GetTag(OnMotorTagName);

                if (OnMotorTag != null)
                {
                    btnOnMotor.Click += BtnOnMotor_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnOnMotor.IsEnabled = false;
                    }));
                }
            }

            if (!string.IsNullOrEmpty(OffMotorTagName))
            {
                OffMotorTag = GetTag(OffMotorTagName);

                if (OffMotorTag != null)
                {
                    btnOffMotor.Click += BtnOffMotor_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnOffMotor.IsEnabled = false;
                    }));
                }
            }

            if (!string.IsNullOrEmpty(OffMotorMNTagName))
            {
                OffMotorMNTag = GetTag(OffMotorMNTagName);

                if (OffMotorMNTag != null)
                {
                    btnOffMN.Click += BtnOffMN_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnOffMN.IsEnabled = false;
                    }));
                }
            }

            if (!string.IsNullOrEmpty(ResetAlarmTagName))
            {
                ResetAlarmTag = GetTag(ResetAlarmTagName);

                if (ResetAlarmTag != null)
                {
                    btnAlarm.Click += BtnAlarm_Click;
                }
                else
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        btnAlarm.IsEnabled = false;
                    }));
                }
            }

            //trang thai
            if (!string.IsNullOrEmpty(StatusOffMotorTagName))
            {
                StatusOffMotorTag = GetTag(StatusOffMotorTagName);

                if (StatusOffMotorTag != null)
                {
                    StatusOffMotorTag_ValueChanged(StatusOffMotorTag, new TagValueChangedEventArgs(StatusOffMotorTag, "", StatusOffMotorTag.Value));
                    StatusOffMotorTag.ValueChanged += StatusOffMotorTag_ValueChanged;
                }
            }

            if (!string.IsNullOrEmpty(StatusOnMotorTagName))
            {
                StatusOnMotorTag = GetTag(StatusOnMotorTagName);

                if (StatusOnMotorTag != null)
                {
                    StatusOnMotorTag_ValueChanged(StatusOnMotorTag, new TagValueChangedEventArgs(StatusOnMotorTag, "", StatusOnMotorTag.Value));
                    StatusOnMotorTag.ValueChanged += StatusOnMotorTag_ValueChanged;
                }
            }

            if (!string.IsNullOrEmpty(StatusAutoTagName))
            {
                StatusAutoTag = GetTag(StatusAutoTagName);

                if (StatusAutoTag != null)
                {
                    StatusAutoTag_ValueChanged(StatusAutoTag, new TagValueChangedEventArgs(StatusAutoTag, "", StatusAutoTag.Value));
                    StatusAutoTag.ValueChanged += StatusAutoTag_ValueChanged;
                }
            }

            if (!string.IsNullOrEmpty(StatusManualTagName))
            {
                StatusManualTag = GetTag(StatusManualTagName);

                if (StatusManualTag != null)
                {
                    StatusManualTag_ValueChanged(StatusManualTag, new TagValueChangedEventArgs(StatusManualTag, "", StatusManualTag.Value));
                    StatusManualTag.ValueChanged += StatusManualTag_ValueChanged;
                }
            }

            if (!string.IsNullOrEmpty(StatusAlarmTagName))
            {
                StatusAlarmTag = GetTag(StatusAlarmTagName);

                if (StatusAlarmTag != null)
                {
                    AlarmTag_ValueChanged(StatusAlarmTag, new TagValueChangedEventArgs(StatusAlarmTag, "", StatusAlarmTag.Value));
                    StatusAlarmTag.ValueChanged += AlarmTag_ValueChanged;
                }
            }
        }

        #region method tagValueChanged
        private void StatusOffMotorTag_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    btnOffMotor.Background = Brushes.Green;
                }
                else
                {
                    btnOffMotor.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }

        private void StatusOnMotorTag_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    btnOnMotor.Background = Brushes.Green;
                }
                else
                {
                    btnOnMotor.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }

        private void StatusManualTag_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    btnManual.Background = Brushes.Green;
                }
                else
                {
                    btnManual.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }

        private void StatusAutoTag_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    btnAuto.Background = Brushes.Green;
                }
                else
                {
                    btnAuto.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }

        private void AlarmTag_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    btnAlarm.Background = Brushes.Red;
                }
                else
                {
                    btnAlarm.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }
        #endregion

        #region Method events click
        private void BtnOffMotor_Click(object sender, RoutedEventArgs e)
        {
            if (DeviceName != "GiuBuiEpVien")
            {
                if (StatusAutoTag.Value == "1" || StatusManualTag.Value == "1")
                {
                    OffMotorTag.Write("1");
                    Thread.Sleep(2000);
                    OffMotorTag.Write("0");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn chế độ.", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                OffMotorTag.Write("1");
                Thread.Sleep(2000);
                OffMotorTag.Write("0");
            }
        }

        private void BtnOnMotor_Click(object sender, RoutedEventArgs e)
        {
            if (DeviceName != "GiuBuiEpVien")
            {
                if (StatusAutoTag.Value == "1" || StatusManualTag.Value == "1")
                {
                    OnMotorTag.Write("1");
                    Thread.Sleep(2000);
                    OnMotorTag.Write("0");
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn chế độ.", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                OnMotorTag.Write("1");
                Thread.Sleep(2000);
                OnMotorTag.Write("0");
            }
        }

        private void BtnOffMN_Click(object sender, RoutedEventArgs e)
        {
            if (StatusAutoTag.Value == "1" || StatusManualTag.Value == "1")
            {
                OffMotorMNTag.Write("1");
                Thread.Sleep(2000);
                OffMotorMNTag.Write("0");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn chế độ.", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnAlarm_Click(object sender, RoutedEventArgs e)
        {
            if (StatusAutoTag.Value == "1" || StatusManualTag.Value == "1")
            {
                ResetAlarmTag.Write("1");
                Thread.Sleep(2000);
                ResetAlarmTag.Write("0");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn chế độ.", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnManual_Click(object sender, RoutedEventArgs e)
        {
            if (ManualTag.Value == "0")
            {
                ManualTag.Write("1");
                AutoTag.Write("0");
            }
            else
            {
                ManualTag.Write("0");
            }
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            if (AutoTag.Value == "0")
            {
                AutoTag.Write("1");
                ManualTag.Write("0");
            }
            else
            {
                AutoTag.Write("0");
            }
        }
        #endregion
    }
}
