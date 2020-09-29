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

        public ITag BaoAlarmHeThong { get; set; }

        public ITag MotorBTCapLieu { get; set; }
        public ITag MotorSanLong { get; set; }
        public ITag MotorVitTai { get; set; }
        public ITag MotorBTLenVien { get; set; }
        public ITag MotorQuatLamMatVien { get; set; }

        public ITag AlarmMotorBTCapLieu { get; set; }
        public ITag AlarmMotorSanLong { get; set; }
        public ITag AlarmMotorVitTai { get; set; }
        public ITag AlarmMotorBTLenVien { get; set; }
        public ITag AlarmMotorQuatLamMatVien { get; set; }

        public HeThongPhuTroEpVien()
        {
            InitializeComponent();

            motorBangTaiCapLieuChay.Visibility = Visibility.Collapsed;
            motorBangTaiCapLieuLoi.Visibility = Visibility.Collapsed;
            bangTaiCapLieuGif.Visibility = Visibility.Collapsed;
            motorSanLongChay.Visibility = Visibility.Collapsed;
            motorSanLongLoi.Visibility = Visibility.Collapsed;
            motorVitTaiLayLieuChay.Visibility = Visibility.Collapsed;
            motorVitTaiLayLieuLoi.Visibility = Visibility.Collapsed;
            vitTaiLayLieuGif.Visibility = Visibility.Collapsed;
            bangTaiLenVienNenGif.Visibility = Visibility.Collapsed;
            motorBangTaiLenVienNenChay.Visibility = Visibility.Collapsed;
            motorBangTaiLenVienNenLoi.Visibility = Visibility.Collapsed;
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
            Dispatcher.Invoke(() =>
            {
                BaoAlarmHeThong = GetTag("ALARM_PT");
                if (BaoAlarmHeThong != null)
                {
                    BaoAlarmHeThong_ValueChanged(BaoAlarmHeThong, new TagValueChangedEventArgs("", BaoAlarmHeThong.Value));
                    BaoAlarmHeThong.ValueChanged += BaoAlarmHeThong_ValueChanged;
                }

                MotorBTCapLieu = GetTag("PL_PT1");
                if (MotorBTCapLieu != null)
                {
                   MotorBTCapLieu_ValueChanged(MotorBTCapLieu, new TagValueChangedEventArgs("", MotorBTCapLieu.Value));
                    MotorBTCapLieu.ValueChanged += MotorBTCapLieu_ValueChanged;
                }

                MotorSanLong = GetTag("PL_PT5");
                if (MotorSanLong != null)
                {
                    MotorSanLong_ValueChanged(MotorSanLong, new TagValueChangedEventArgs("", MotorSanLong.Value));
                    MotorSanLong.ValueChanged += MotorSanLong_ValueChanged;
                }

                MotorVitTai = GetTag("PL_PT6");
                if (MotorSanLong != null)
                {
                    MotorVitTai_ValueChanged(MotorVitTai, new TagValueChangedEventArgs("", MotorVitTai.Value));
                    MotorVitTai.ValueChanged += MotorVitTai_ValueChanged;
                }

                MotorBTLenVien = GetTag("PL_PT7");
                if (MotorSanLong != null)
                {
                    MotorBTLenVien_ValueChanged(MotorBTLenVien, new TagValueChangedEventArgs("", MotorBTLenVien.Value));
                    MotorBTLenVien.ValueChanged += MotorBTLenVien_ValueChanged;
                }

                MotorQuatLamMatVien = GetTag("PL_PT_FAN");
                if (MotorQuatLamMatVien != null)
                {
                    MotorQuatLamMatVien_ValueChanged(MotorQuatLamMatVien, new TagValueChangedEventArgs("", MotorQuatLamMatVien.Value));
                    MotorQuatLamMatVien.ValueChanged += MotorQuatLamMatVien_ValueChanged;
                }
            });
        }

        private void MotorQuatLamMatVien_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    quatLamMat1Chay.Visibility = Visibility.Visible;
                    quatLamMat2Chay.Visibility = Visibility.Visible;
                    quatLamMat3Chay.Visibility = Visibility.Visible;
                    quatLamMat4Chay.Visibility = Visibility.Visible;

                    quatLamMat1Loi.Visibility = Visibility.Collapsed;
                    quatLamMat2Loi.Visibility = Visibility.Collapsed;
                    quatLamMat3Loi.Visibility = Visibility.Collapsed;
                    quatLamMat4Loi.Visibility = Visibility.Collapsed;
                }
                else
                {
                    quatLamMat1Loi.Visibility = Visibility.Visible;
                    quatLamMat2Loi.Visibility = Visibility.Visible;
                    quatLamMat3Loi.Visibility = Visibility.Visible;
                    quatLamMat4Loi.Visibility = Visibility.Visible;

                    quatLamMat1Chay.Visibility = Visibility.Collapsed;
                    quatLamMat2Chay.Visibility = Visibility.Collapsed;
                    quatLamMat3Chay.Visibility = Visibility.Collapsed;
                    quatLamMat4Chay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorBTLenVien_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorBangTaiLenVienNenChay.Visibility = Visibility.Visible;
                    bangTaiLenVienNenGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorBangTaiLenVienNenChay.Visibility = Visibility.Collapsed;
                    bangTaiLenVienNenGif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorVitTai_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorVitTaiLayLieuChay.Visibility = Visibility.Visible;
                    vitTaiLayLieuGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorVitTaiLayLieuChay.Visibility = Visibility.Collapsed;
                    vitTaiLayLieuGif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorSanLong_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorSanLongChay.Visibility = Visibility.Visible;
                }
                else
                {
                    motorSanLongChay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorBTCapLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorBangTaiCapLieuChay.Visibility = Visibility.Visible;
                    bangTaiCapLieuGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorBangTaiCapLieuChay.Visibility = Visibility.Collapsed;
                    bangTaiCapLieuGif.Visibility = Visibility.Collapsed;
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
                }
                else
                {
                    Error = 0;
                }
            }));
        }
    }
}
