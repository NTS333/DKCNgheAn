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

namespace EasyScadaApp
{
    /// <summary>
    /// Interaction logic for ThongTinMayEpVien.xaml
    /// </summary>
    public partial class ThongTinMayEpVien : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }

        public ThongTinMayEpVien()
        {
            InitializeComponent();

        }

        bool isStarted = false;

        public string Auto
        {
            get { return (string)GetValue(AutoProperties); }
            set { SetValue(AutoProperties, value); }
        }
        public static readonly DependencyProperty AutoProperties =
            DependencyProperty.Register("Auto", typeof(string), typeof(ThongTinMayEpVien), new PropertyMetadata("0"));

        public string Manual
        {
            get { return (string)GetValue(ManualProperty); }
            set { SetValue(ManualProperty, value); }
        }
        public static readonly DependencyProperty ManualProperty =
            DependencyProperty.Register("Manual", typeof(string), typeof(ThongTinMayEpVien), new PropertyMetadata("0"));

        public void Start()
        {
            if (!isStarted)
            {
                lbMayEp.Content = Header1;
                lbCapLieu.Content = Header2;
                isStarted = true;
                string prefix = $"{StationName}/{ChannelName}/{DeviceName}/";

                dongM1.TagPath = prefix + "Current_Digital_M1";
                #region Ref
                ////dongMixer.TagPath = prefix + "Current_Digital_MX";
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_MX").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() => {
                //        dongMixer.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};

                ////dongFeededA1.TagPath = prefix + "Current_Digital_FDA1";
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_A").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() => {
                //        dongFeededA1.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //nhapTSFeededA1.TagPath = prefix + "Input_Hz_A";

                ////dongFeededA2.TagPath = prefix + "Current_Digital_FDA2";
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_B").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() => {
                //        dongFeededA2.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //nhapTSFeededA2.TagPath = prefix + "Input_Hz_B";

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Auto").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Auto = o.NewValue;
                //    }));
                //};

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Manual").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Manual = o.NewValue;
                //    }));
                //};
                #endregion

            }
        }
    }
}
