using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    public partial class HeThongGiuBui : UserControl
    {
        #region ----- PROPERTY USERCONTROL -----

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public IEasyDriverConnector Connector { get; set; }
        public ITag MotorQuatHut { get; set; }
        public ITag MotorVitTai { get; set; }
        public ITag MotorAirLock { get; set; }
        public ITag StatusHeThongGiuBui { get; set; }
        public ITag MotorVitTaiUpdate { get; set; }

        public ITag AlarmMotorAirLock { get; set; }
        public ITag AlarmMotorVitTai { get; set; }
        public ITag AlarmMotorQuatHut { get; set; }
        #endregion ----- PROPERTY USERCONTROL ----- 

        public bool IsStarted { get; private set; }

        public ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        public HeThongGiuBui()
        {
            InitializeComponent();

            motorQuatHutChay.Visibility = Visibility.Collapsed;
            motorQuatHutLoi.Visibility = Visibility.Collapsed;
            motorVitTaiChay.Visibility = Visibility.Collapsed;
            motorVitTaiLoi.Visibility = Visibility.Collapsed;
            motorRotovanChay.Visibility = Visibility.Collapsed;
            motorRotovanLoi.Visibility = Visibility.Collapsed;
            statusHeThongGiuBuiChay.Visibility = Visibility.Collapsed;
            statusHeThongGiuBuiDung.Visibility = Visibility.Collapsed;
            quatHutGif.Visibility = Visibility.Collapsed;
            vitTaiGif.Visibility = Visibility.Collapsed;

            vitTaiGiuBuiUpdateGif.Visibility = Visibility.Collapsed;
            motorVitTaiGiuBuiUpdateChay.Visibility = Visibility.Collapsed;
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

                MotorQuatHut = GetTag("PL_QHGB");
                if (MotorQuatHut != null)
                {
                    MotorQuatHut_ValueChanged(MotorQuatHut, new TagValueChangedEventArgs(MotorQuatHut, "", MotorQuatHut.Value));
                    MotorQuatHut.ValueChanged += MotorQuatHut_ValueChanged;
                }

                MotorVitTai = GetTag("PL_VTGB");
                if (MotorVitTai != null)
                {
                    MotorVitTai_ValueChanged(MotorVitTai, new TagValueChangedEventArgs(MotorVitTai, "", MotorVitTai.Value));
                    MotorVitTai.ValueChanged += MotorVitTai_ValueChanged;
                }

                MotorAirLock = GetTag("PL_AirGB");
                if (MotorAirLock != null)
                {
                    MotorRotovan_ValueChanged(MotorAirLock, new TagValueChangedEventArgs(MotorAirLock, "", MotorAirLock.Value));
                    MotorAirLock.ValueChanged += MotorRotovan_ValueChanged;
                }

                StatusHeThongGiuBui = GetTag("PL_GB");
                if (StatusHeThongGiuBui != null)
                {
                    StatusHeThongGiuBui_ValueChanged(StatusHeThongGiuBui, new TagValueChangedEventArgs(StatusHeThongGiuBui, "", StatusHeThongGiuBui.Value));
                    StatusHeThongGiuBui.ValueChanged += StatusHeThongGiuBui_ValueChanged;
                }

                MotorVitTaiUpdate = GetTag("ST_VTGB_UPdate");
                if (MotorVitTaiUpdate != null)
                {
                    MotorVitTaiUpdate_ValueChanged(MotorVitTaiUpdate, new TagValueChangedEventArgs(MotorVitTaiUpdate, "", MotorVitTaiUpdate.Value));
                    MotorVitTaiUpdate.ValueChanged += MotorVitTaiUpdate_ValueChanged;
                }

                AlarmMotorAirLock = GetTag("PL_OVL_AirGB");
                if (AlarmMotorAirLock != null)
                {
                    AlarmMotorRotovan_ValueChanged(AlarmMotorAirLock, new TagValueChangedEventArgs(AlarmMotorAirLock, "", AlarmMotorAirLock.Value));
                    AlarmMotorAirLock.ValueChanged += AlarmMotorRotovan_ValueChanged;
                }

                AlarmMotorVitTai = GetTag("PL_OVL_VTGB");
                if (AlarmMotorVitTai != null)
                {
                    AlarmMotorVitTai_ValueChanged(AlarmMotorVitTai, new TagValueChangedEventArgs(AlarmMotorVitTai, "", AlarmMotorVitTai.Value));
                    AlarmMotorVitTai.ValueChanged += AlarmMotorVitTai_ValueChanged;
                }

                AlarmMotorQuatHut = GetTag("PL_OVL_QHGB");
                if (AlarmMotorQuatHut != null)
                {
                    AlarmMotorQuatHut_ValueChanged(AlarmMotorQuatHut, new TagValueChangedEventArgs(AlarmMotorQuatHut, "", AlarmMotorQuatHut.Value));
                    AlarmMotorQuatHut.ValueChanged += AlarmMotorQuatHut_ValueChanged;
                }
            });
        }

        private void MotorVitTaiUpdate_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    vitTaiGiuBuiUpdateGif.Visibility = Visibility.Visible;
                    motorVitTaiGiuBuiUpdateChay.Visibility = Visibility.Visible;
                    motorVitTaiGiuBuiUpdateDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    vitTaiGiuBuiUpdateGif.Visibility = Visibility.Collapsed;
                    motorVitTaiGiuBuiUpdateChay.Visibility = Visibility.Collapsed;
                    motorVitTaiGiuBuiUpdateDung.Visibility = Visibility.Visible;
                }
            }));
        }

        private void StatusHeThongGiuBui_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    statusHeThongGiuBuiChay.Visibility = Visibility.Visible;
                    statusHeThongGiuBuiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    statusHeThongGiuBuiDung.Visibility = Visibility.Visible;
                    statusHeThongGiuBuiChay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorRotovan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorRotovanChay.Visibility = Visibility.Visible;
                    motorRotovanDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorRotovanDung.Visibility = Visibility.Visible;
                    motorRotovanChay.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void MotorVitTai_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorVitTaiChay.Visibility = Visibility.Visible;
                    motorVitTaiDung.Visibility = Visibility.Collapsed;
                    vitTaiGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorVitTaiDung.Visibility = Visibility.Visible;
                    motorVitTaiChay.Visibility = Visibility.Collapsed;
                    vitTaiGif.Visibility = Visibility.Collapsed;
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
                    motorQuatHutDung.Visibility = Visibility.Collapsed;
                    quatHutGif.Visibility = Visibility.Visible;
                }
                else
                {
                    motorQuatHutDung.Visibility = Visibility.Visible;
                    motorQuatHutChay.Visibility = Visibility.Collapsed;
                    quatHutGif.Visibility = Visibility.Collapsed;
                }
            }));
        }

        private void AlarmMotorRotovan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            {
                if (e.NewValue == "1")
                {
                    motorRotovanLoi.Visibility = Visibility.Visible;
                    motorRotovanChay.Visibility = Visibility.Collapsed;
                    motorRotovanDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorRotovanLoi.Visibility = Visibility.Collapsed;

                    if (MotorAirLock.Value == "1")
                    {
                        motorRotovanDung.Visibility = Visibility.Collapsed;
                        motorRotovanChay.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorRotovanDung.Visibility = Visibility.Visible;
                        motorRotovanChay.Visibility = Visibility.Collapsed;
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
                    motorVitTaiLoi.Visibility = Visibility.Visible;
                    motorVitTaiChay.Visibility = Visibility.Collapsed;
                    motorVitTaiDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorVitTaiLoi.Visibility = Visibility.Collapsed;

                    if (MotorVitTai.Value == "1")
                    {
                        motorVitTaiDung.Visibility = Visibility.Collapsed;
                        motorVitTaiChay.Visibility = Visibility.Visible;
                        vitTaiGif.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorVitTaiDung.Visibility = Visibility.Visible;
                        motorVitTaiChay.Visibility = Visibility.Collapsed;
                        vitTaiGif.Visibility = Visibility.Collapsed;
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
                    motorQuatHutDung.Visibility = Visibility.Collapsed;
                }
                else
                {
                    motorQuatHutLoi.Visibility = Visibility.Collapsed;

                    if (MotorQuatHut.Value == "1")
                    {
                        motorQuatHutDung.Visibility = Visibility.Collapsed;
                        motorQuatHutChay.Visibility = Visibility.Visible;
                        quatHutGif.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        motorQuatHutDung.Visibility = Visibility.Visible;
                        motorQuatHutChay.Visibility = Visibility.Collapsed;
                        quatHutGif.Visibility = Visibility.Collapsed;
                    }
                }
            }));
        }

        #region Events
        public event EventHandler MotorRotovanClick;
        public event EventHandler MotorVitTaiClick;
        public event EventHandler MotorVitTaiUpdateClick;
        public event EventHandler MotorQuatHutClick;
        public event EventHandler GiuBuiClick;
        private void MotorQuatHut_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorQuatHutClick?.Invoke(this, e);
        }

        private void MotorVitTai_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorVitTaiClick?.Invoke(this, e);
        }

        private void MotorVitTaiUpdate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorVitTaiUpdateClick?.Invoke(this, e);
        }

        private void MotorRotovan_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MotorRotovanClick?.Invoke(this, e);
        }

        private void GiuBui_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            GiuBuiClick?.Invoke(this, e);
        }
        #endregion
    }
}
