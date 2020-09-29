using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Windows.Controls;
using System.Windows;

namespace WPFUserControl
{
    public partial class MayNghienTinh : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public bool IsStarted { get; private set; }

        public ITag MotorMayNghienChayThuan { get; set; }
        public ITag MotorMayNghienChayNghich { get; set; }
        public ITag MotorMayNghienLoi { get; set; }
        public ITag MotorVitTaiCapLieu { get; set; }
        public ITag MotorQuatHut { get; set; }
        //public ITag XiLanh { get; set; }

        public ITag BaoAlarmHeThong { get; set; }
        public ITag AlarmMotorMayNghien { get; set; }
        public ITag AlarmMotorVitTai { get; set; }
        public ITag AlarmMotorQuatHut { get; set; }

        //private bool _motorMayNghienChayThuan = false, _motorMayNghienChayNghich = false;

        public MayNghienTinh()
        {
            InitializeComponent();

            motorMayNghienChay.Visibility = Visibility.Collapsed;
            motorMayNghienLoi.Visibility = Visibility.Collapsed;
            motorQuatHutChay.Visibility = Visibility.Collapsed;
            motorQuatHutLoi.Visibility = Visibility.Collapsed;
            motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
            motorVitTaiCapLieuLoi.Visibility = Visibility.Collapsed;
            vitTaiCapLieu.Visibility = Visibility.Collapsed;
            quatHut.Visibility = Visibility.Collapsed;
            motorMayNghienChayThuan.Visibility = Visibility.Collapsed;
            motorMayNghienChayNghich.Visibility = Visibility.Collapsed;
            ruotMayNghien.Visibility = Visibility.Collapsed;
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
                MotorMayNghienChayNghich = GetTag("PL_MN_Nghich");
                if (MotorMayNghienChayNghich != null)
                {
                    MotorMayNghienChayNghich_ValueChanged(MotorMayNghienChayNghich, new TagValueChangedEventArgs("", MotorMayNghienChayNghich.Value));
                    MotorMayNghienChayNghich.ValueChanged += MotorMayNghienChayNghich_ValueChanged;
                }

                MotorMayNghienChayThuan = GetTag("PL_MN_Thuan");
                if (MotorMayNghienChayThuan != null)
                {
                    MotorMayNghienChayThuan_ValueChanged(MotorMayNghienChayThuan, new TagValueChangedEventArgs("", MotorMayNghienChayThuan.Value));
                    MotorMayNghienChayThuan.ValueChanged += MotorMayNghienChayThuan_ValueChanged;
                }

                MotorVitTaiCapLieu = GetTag("PL_Vtai");
                if (MotorVitTaiCapLieu != null)
                {
                    MotorVitTaiCapLieu_ValueChanged(MotorVitTaiCapLieu, new TagValueChangedEventArgs("", MotorVitTaiCapLieu.Value));
                    MotorVitTaiCapLieu.ValueChanged += MotorVitTaiCapLieu_ValueChanged;
                }

                //XiLanh = GetTag("XiLanhMayNghien");
                //if (XiLanh != null)
                //{
                //    XiLanh_ValueChanged(XiLanh, new TagValueChangedEventArgs("", XiLanh.Value));
                //    XiLanh.ValueChanged += XiLanh_ValueChanged;
                //}

                MotorQuatHut = GetTag("PL_Qhut");
                if (MotorQuatHut != null)
                {
                    MotorQuatHut_ValueChanged(MotorQuatHut, new TagValueChangedEventArgs("", MotorQuatHut.Value));
                    MotorQuatHut.ValueChanged += MotorQuatHut_ValueChanged;
                }

                BaoAlarmHeThong = GetTag("ALARM_MN");
                if (BaoAlarmHeThong != null)
                {
                    BaoAlarmHeThong_ValueChanged(BaoAlarmHeThong, new TagValueChangedEventArgs("", BaoAlarmHeThong.Value));
                    BaoAlarmHeThong.ValueChanged += BaoAlarmHeThong_ValueChanged;
                }

                AlarmMotorMayNghien = GetTag("PL_OVL_MN");
                if (AlarmMotorMayNghien != null)
                {
                    AlarmMotorMayNghien_ValueChanged(AlarmMotorMayNghien, new TagValueChangedEventArgs("", AlarmMotorMayNghien.Value));
                    AlarmMotorMayNghien.ValueChanged += AlarmMotorMayNghien_ValueChanged;
                }

                AlarmMotorVitTai = GetTag("PL_OVL_Vtai");
                if (AlarmMotorVitTai != null)
                {
                    AlarmMotorVitTai_ValueChanged(AlarmMotorVitTai, new TagValueChangedEventArgs("", AlarmMotorVitTai.Value));
                    AlarmMotorVitTai.ValueChanged += AlarmMotorVitTai_ValueChanged;
                }

                AlarmMotorQuatHut = GetTag("PL_OVL_Qhut");
                if (AlarmMotorQuatHut != null)
                {
                    AlarmMotorQuatHut_ValueChanged(AlarmMotorQuatHut, new TagValueChangedEventArgs("", AlarmMotorQuatHut.Value));
                    AlarmMotorQuatHut.ValueChanged += AlarmMotorQuatHut_ValueChanged;
                }
            });
        }

        private void AlarmMotorMayNghien_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayNghienLoi.Visibility = Visibility.Visible;
                    motorMayNghienChay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayNghienLoi.Visibility = Visibility.Collapsed;

                    if (MotorMayNghienChayNghich.Value == "1" || MotorMayNghienChayThuan.Value == "1")
                    {
                        motorMayNghienChay.Visibility = Visibility.Visible;
                    }
                }
            }));
        }

        private void AlarmMotorVitTai_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorVitTaiCapLieuLoi.Visibility = Visibility.Visible;
                    motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorVitTaiCapLieuLoi.Visibility = Visibility.Collapsed;

                    if (MotorVitTaiCapLieu.Value == "1")
                    {
                        motorVitTaiCapLieuChay.Visibility = Visibility.Visible;
                    }
                }
            }));
        }

        private void AlarmMotorQuatHut_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorQuatHutLoi.Visibility = Visibility.Visible;
                    motorQuatHutChay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorQuatHutLoi.Visibility = Visibility.Collapsed;

                    if (MotorQuatHut.Value == "1")
                    {
                        motorQuatHutChay.Visibility = Visibility.Visible;
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
                }
                else
                {
                    Error = 0;
                }
            }));
        }

        private void MotorVitTaiCapLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorVitTaiCapLieuChay.Visibility = Visibility.Visible;
                    //motorVitTaiCapLieuLoi.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu.Visibility = Visibility.Visible;
                }
                else
                {
                    motorVitTaiCapLieuChay.Visibility = Visibility.Collapsed;
                    vitTaiCapLieu.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorQuatHut_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorQuatHutChay.Visibility = Visibility.Visible;
                    //motorQuatHutLoi.Visibility = Visibility.Collapsed;
                    quatHut.Visibility = Visibility.Visible;
                }
                else
                {
                    motorQuatHutChay.Visibility = Visibility.Collapsed;
                    quatHut.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMayNghienChayThuan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayNghienChayThuan.Visibility = Visibility.Visible;
                    motorMayNghienChayNghich.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayNghienChayThuan.Visibility = Visibility.Collapsed;
                }

                if (MotorMayNghienChayThuan.Value == "1" || MotorMayNghienChayNghich.Value == "1")
                {
                    motorMayNghienChay.Visibility = Visibility.Visible;
                    motorMayNghienLoi.Visibility = Visibility.Collapsed;
                    ruotMayNghien.Visibility = Visibility.Visible;
                }
                else
                {
                    motorMayNghienChay.Visibility = Visibility.Collapsed;
                    motorMayNghienLoi.Visibility = Visibility.Collapsed;
                    ruotMayNghien.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorMayNghienChayNghich_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorMayNghienChayNghich.Visibility = Visibility.Visible;
                    motorMayNghienChayThuan.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorMayNghienChayNghich.Visibility = Visibility.Collapsed;
                }

                if (MotorMayNghienChayThuan.Value == "1" || MotorMayNghienChayNghich.Value == "1")
                {
                    motorMayNghienChay.Visibility = Visibility.Visible;
                    motorMayNghienLoi.Visibility = Visibility.Collapsed;
                    ruotMayNghien.Visibility = Visibility.Visible;
                }
                else
                {
                    motorMayNghienChay.Visibility = Visibility.Collapsed;
                    motorMayNghienLoi.Visibility = Visibility.Collapsed;
                    ruotMayNghien.Visibility = Visibility.Collapsed;
                }
            }));
        }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        public event EventHandler MotorMayNghienClick;
        public event EventHandler MotorQuatHutClick;
        public event EventHandler MotorVitTaiClick;

        public int Error
        {
            get { return (int)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(int), typeof(MayNghienTinh), new PropertyMetadata(0));

        private void MotorMayNghienChay_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MotorMayNghienClick?.Invoke(this, e);
        }

        private void MotorVitTaiCapLieuChay_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MotorVitTaiClick?.Invoke(this, e);
        }

        private void MotorQuatHutChay_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MotorQuatHutClick?.Invoke(this, e);
        }
    }
}
