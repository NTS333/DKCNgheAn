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
    /// Interaction logic for SanLong.xaml
    /// </summary>
    public partial class SanLong : UserControl
    {
        public SanLong()
        {
            InitializeComponent();
        }

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }

        bool isStarted = false;

        public string Auto
        {
            get { return (string)GetValue(AutoProperties); }
            set { SetValue(AutoProperties, value); }
        }
        public static readonly DependencyProperty AutoProperties =
            DependencyProperty.Register("Auto", typeof(string), typeof(SanLong), new PropertyMetadata("0"));

        public string Manual
        {
            get { return (string)GetValue(ManualProperty); }
            set { SetValue(ManualProperty, value); }
        }
        public static readonly DependencyProperty ManualProperty =
            DependencyProperty.Register("Manual", typeof(string), typeof(SanLong), new PropertyMetadata("0"));

        public void Start()
        {
            if (!isStarted)
            {
                isStarted = true;
                string prefix = $"{StationName}/{ChannelName}/{DeviceName}/";

                //cach gan tag doc truc tiep vao easyLabel tool
                //pt1.TagPath = prefix + "Current_Digital_PT1";
                //pt2.TagPath = prefix + "Current_Digital_PT2";
                //pt3.TagPath = prefix + "Current_Digital_PT3";
                //pt4.TagPath = prefix + "Current_Digital_PT4";
                //pt5.TagPath = prefix + "Current_Digital_PT5";
                //pt6.TagPath = prefix + "Current_Digital_PT6";
                //pt8.TagPath = prefix + "Current_Digital_PT8";

                //do phair gioi han so le phia sau nen phai code them
                #region Ref
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT1").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt1.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT2").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt2.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT3").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt3.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT4").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt4.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT5").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt5.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT6").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt6.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_PT8").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        pt8.Content = Math.Round(Convert.ToDouble(o.NewValue), 1).ToString();
                //    }));
                //};

                ////tag the hienn trang thai auto/manual
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Auto").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Auto = o.NewValue;
                //    }));
                //};

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Manual").ValueChanged += (s, o) =>
                //{
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
