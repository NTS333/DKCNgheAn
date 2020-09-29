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
        public ITag MotorRotovan { get; set; }
        public ITag StatusHeThongGiuBui { get; set; }

        public ITag AlarmMotorRotovan { get; set; }
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

                MotorQuatHut = GetTag("PL_Qhut");
                if (MotorQuatHut != null)
                {
                    MotorQuatHut_ValueChanged(MotorQuatHut, new TagValueChangedEventArgs("", MotorQuatHut.Value));
                    MotorQuatHut.ValueChanged += MotorQuatHut_ValueChanged;
                }

                MotorVitTai = GetTag("PL_Vtai");
                if (MotorVitTai != null)
                {
                    MotorVitTai_ValueChanged(MotorVitTai, new TagValueChangedEventArgs("", MotorVitTai.Value));
                    MotorVitTai.ValueChanged += MotorVitTai_ValueChanged;
                }

                MotorRotovan = GetTag("PL_Rotorvan");
                if (MotorRotovan != null)
                {
                    MotorRotovan_ValueChanged(MotorRotovan, new TagValueChangedEventArgs("", MotorRotovan.Value));
                    MotorRotovan.ValueChanged += MotorRotovan_ValueChanged;
                }

                StatusHeThongGiuBui = GetTag("PL_Gbui");
                if (StatusHeThongGiuBui != null)
                {
                    StatusHeThongGiuBui_ValueChanged(StatusHeThongGiuBui, new TagValueChangedEventArgs("", StatusHeThongGiuBui.Value));
                    StatusHeThongGiuBui.ValueChanged += StatusHeThongGiuBui_ValueChanged;
                }

                AlarmMotorRotovan = GetTag("PL_OVL_Rotorvan");
                if (AlarmMotorRotovan != null)
                {
                    AlarmMotorRotovan_ValueChanged(AlarmMotorRotovan, new TagValueChangedEventArgs("", AlarmMotorRotovan.Value));
                    AlarmMotorRotovan.ValueChanged += AlarmMotorRotovan_ValueChanged;
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
                }
                else
                {
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
                    vitTaiGif.Visibility = Visibility.Visible;
                }
                else
                {
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
                    quatHutGif.Visibility = Visibility.Visible;
                }
                else
                {
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
                }
                else
                {
                    motorRotovanLoi.Visibility = Visibility.Collapsed;

                    if (MotorRotovan.Value == "1")
                    {
                        motorRotovanChay.Visibility = Visibility.Visible;
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
                }
                else
                {
                    motorVitTaiLoi.Visibility = Visibility.Collapsed;

                    if (MotorVitTai.Value == "1")
                    {
                        motorVitTaiChay.Visibility = Visibility.Visible;
                        vitTaiGif.Visibility = Visibility.Visible;
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
                        quatHutGif.Visibility = Visibility.Visible;
                    }
                }
            }));
        }
        

    }
}
