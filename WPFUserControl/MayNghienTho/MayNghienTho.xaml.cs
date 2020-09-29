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
using EasyScada.Core;
using EasyScada.Wpf.Controls;

namespace WPFUserControl
{
    public partial class MayNghienTho : UserControl
    {
        #region ----- PROPERTY USERCONTROL -----

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public ITag MotorMayNghienChayThuan { get; set; }
        public ITag MotorMayNghienChayNghich { get; set; }
        public ITag MotorMayNghienLoi { get; set; }
        public ITag MotorBangTaiCapLieu { get; set; }
        public ITag MotorBangTaiTu { get; set; }
        public ITag MotorQuatHut { get; set; }
        public ITag BaoAlarmHeThong { get; set; }
        public ITag AlarmMotorMayNghien { get; set; }
        public ITag AlarmMotorBangTai { get; set; }
        public ITag AlarmMotorQuatHut { get; set; }

        #endregion ----- PROPERTY USERCONTROL -----        

        #region ----- FUNCTION -----        

        public MayNghienTho()
        {
            InitializeComponent();

            motorMayNghienChay.Visibility = Visibility.Collapsed;
            motorMayNghienLoi.Visibility = Visibility.Collapsed;
            motorMayNghienChayThuan.Visibility = Visibility.Collapsed;
            motorMayNghienChayNghich.Visibility = Visibility.Collapsed;
            ruotMayNghien.Visibility = Visibility.Collapsed;

            motorQuatHutChay.Visibility = Visibility.Collapsed;
            motorQuatHutLoi.Visibility = Visibility.Collapsed;

            motorBangTaiTuChay.Visibility = Visibility.Collapsed;
            motorBangTaiTuLoi.Visibility = Visibility.Collapsed;
            bangTaiTu.Visibility = Visibility.Collapsed;

            motorBTCapLieuChay.Visibility = Visibility.Collapsed;
            motorBTCapLieuLoi.Visibility = Visibility.Collapsed;
            bangTaiCapLieu.Visibility = Visibility.Collapsed;

            Loaded += OnLoaded;
        }

        public bool IsStarted { get; private set; }

        public int Error
        {
            get { return (int)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(int), typeof(MayNghienTho), new PropertyMetadata(0));

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

                MotorBangTaiCapLieu = GetTag("PL_Btai");
                if (MotorBangTaiCapLieu != null)
                {
                    MotorBangTaiCapLieu_ValueChanged(MotorBangTaiCapLieu, new TagValueChangedEventArgs("", MotorBangTaiCapLieu.Value));
                    MotorBangTaiCapLieu.ValueChanged += MotorBangTaiCapLieu_ValueChanged;
                }

                MotorBangTaiTu = GetTag("PL_BTai_Tu");
                if (MotorBangTaiTu != null)
                {
                    MotorBangTaiTu_ValueChanged(MotorBangTaiTu, new TagValueChangedEventArgs("", MotorBangTaiTu.Value));
                    MotorBangTaiTu.ValueChanged += MotorBangTaiTu_ValueChanged;
                }

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

                AlarmMotorBangTai = GetTag("PL_OVL_Btai");
                if (AlarmMotorBangTai != null)
                {
                    AlarmMotorBangTai_ValueChanged(AlarmMotorBangTai, new TagValueChangedEventArgs("", AlarmMotorBangTai.Value));
                    AlarmMotorBangTai.ValueChanged += AlarmMotorBangTai_ValueChanged;
                }

                AlarmMotorQuatHut = GetTag("PL_OVL_Qhut");
                if (AlarmMotorQuatHut != null)
                {
                    AlarmMotorQuatHut_ValueChanged(AlarmMotorQuatHut, new TagValueChangedEventArgs("", AlarmMotorQuatHut.Value));
                    AlarmMotorQuatHut.ValueChanged += AlarmMotorQuatHut_ValueChanged;
                }
            });
        }

        #region alarm
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

        private void AlarmMotorBangTai_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorBTCapLieuLoi.Visibility = Visibility.Visible;
                    motorBTCapLieuChay.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorBTCapLieuLoi.Visibility = Visibility.Collapsed;

                    if (MotorBangTaiCapLieu.Value == "1")
                    {
                        motorBTCapLieuChay.Visibility = Visibility.Visible;
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
        #endregion

        private void OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void MotorQuatHut_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorQuatHutChay.Visibility = Visibility.Visible;
                    quatHut.Visibility = Visibility.Visible;
                }
                else
                {
                    motorQuatHutChay.Visibility = Visibility.Collapsed;
                    quatHut.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorBangTaiTu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorBangTaiTuChay.Visibility = Visibility.Visible;
                    bangTaiTu.Visibility = Visibility.Visible;
                }
                else
                {
                    motorBangTaiTuChay.Visibility = Visibility.Collapsed;
                    bangTaiTu.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorBangTaiCapLieu_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorBTCapLieuChay.Visibility = Visibility.Visible;
                    bangTaiCapLieu.Visibility = Visibility.Visible;
                }
                else
                {
                    motorBTCapLieuChay.Visibility = Visibility.Collapsed;
                    bangTaiCapLieu.Visibility = Visibility.Collapsed;
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
                    ruotMayNghien.Visibility = Visibility.Visible;
                }
                else
                {
                    motorMayNghienChay.Visibility = Visibility.Collapsed;
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
                    ruotMayNghien.Visibility = Visibility.Visible;
                }
                else
                {
                    motorMayNghienChay.Visibility = Visibility.Collapsed;
                    ruotMayNghien.Visibility = Visibility.Collapsed;
                }
            }));
        }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        #endregion ----- FUNCTION -----

        public event EventHandler BangTaiCapLieuClick;
        public event EventHandler BangTaiTuClick;
        public event EventHandler MotorMayNghienClick;
        public event EventHandler MotorQuatHutClick;

        private void BangTaiCapLieu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BangTaiCapLieuClick?.Invoke(this, e);
        }

        private void BangTaiTu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            BangTaiTuClick?.Invoke(this, e);
        }

        private void MotorMayNghienChay_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorMayNghienClick?.Invoke(this, e);
        }

        private void MotorQuatHutChay_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorQuatHutClick?.Invoke(this, e);
        }
    }
}
