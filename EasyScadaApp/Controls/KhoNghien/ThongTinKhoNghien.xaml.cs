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
    /// Interaction logic for ThongTinKhoNghien.xaml
    /// </summary>
    public partial class ThongTinKhoNghien : UserControl
    {
        public ThongTinKhoNghien()
        {
            InitializeComponent();
        }

        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string Header { get; set; }

        bool isStarted = false;

        public string Auto
        {
            get { return (string)GetValue(AutoProperties); }
            set { SetValue(AutoProperties, value); }
        }
        public static readonly DependencyProperty AutoProperties =
            DependencyProperty.Register("Auto", typeof(string), typeof(ThongTinKhoNghien), new PropertyMetadata("0"));

        public string Manual
        {
            get { return (string)GetValue(ManualProperty); }
            set { SetValue(ManualProperty, value); }
        }
        public static readonly DependencyProperty ManualProperty =
            DependencyProperty.Register("Manual", typeof(string), typeof(ThongTinKhoNghien), new PropertyMetadata("0"));

        public string CheDo3
        {
            get { return (string)GetValue(CheDo3Property); }
            set { SetValue(CheDo3Property, value); }
        }
        public static readonly DependencyProperty CheDo3Property =
            DependencyProperty.Register("CheDo3", typeof(string), typeof(ThongTinKhoNghien), new PropertyMetadata("0"));

        public void Start()
        {
            if (!isStarted)
            {
                lbHeader.Content = Header;
                isStarted = true;
                string prefix = $"{StationName}/{ChannelName}/{DeviceName}/";

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "ST_Auto").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Auto = o.NewValue;
                //    }));
                //};

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "ST_Manual").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Manual = o.NewValue;
                //    }));
                //};

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "ST_CheDo3").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        CheDo3 = o.NewValue;
                //    }));
                //};
            }
        }
    }
}
