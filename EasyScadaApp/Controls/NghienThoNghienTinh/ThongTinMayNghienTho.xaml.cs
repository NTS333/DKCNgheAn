using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ThongTinMayNghienTho.xaml
    /// </summary>
    public partial class ThongTinMayNghienTho : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }

        public ThongTinMayNghienTho()
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
            DependencyProperty.Register("Auto", typeof(string), typeof(ThongTinMayNghienTho), new PropertyMetadata("0"));

        public string Manual
        {
            get { return (string)GetValue(ManualProperty); }
            set { SetValue(ManualProperty, value); }
        }
        public static readonly DependencyProperty ManualProperty =
            DependencyProperty.Register("Manual", typeof(string), typeof(ThongTinMayNghienTho), new PropertyMetadata("0"));

        public void Start()
        {
            if (!isStarted)
            {
                isStarted = true;

                string prefix = $"{StationName}/{ChannelName}/{DeviceName}/";
                dongMotorMayNghien.TagPath = prefix + "Current_Digital_NTho";

                //if (DeviceName.Contains("Tho"))
                {
                    //dongMotorCapLieu.TagPath = prefix + "Current_Digital_Btai";
                    tanSoCapLieu.TagPath = prefix + "Hz_BT";
                    inputTanSoCapLieu.TagPath = prefix + "Input_Hz_BT";
                }
                //else
                //{
                //    dongMotorCapLieu.TagPath = prefix + "Current_Digital_Vtai";
                //    tanSoCapLieu.TagPath = prefix + "Resuft_Hz_Vtai";
                //    inputTanSoCapLieu.TagPath = prefix + "In_Hz_VT";
                //}

                dongMotorQuatHut.TagPath = prefix + "Current_Digital_QH";
                //if (DeviceName.Contains("Tho"))
                //{
                //    EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "Current_Digital_NTho").ValueChanged += (s, o) =>
                //    {
                //        //DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //        //{
                //        //    Debug.WriteLine(o.NewValue);
                //        //}));
                //        this.Dispatcher.Invoke(new Action(() =>
                //        {
                            
                //            //(DataContext as TagViewModel).TagValue = o.NewValue;
                //        }));
                //        Debug.WriteLine(o.NewValue);
                //    };
                //}
              
                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Auto").ValueChanged += (s, o) =>
                //{
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Auto = o.NewValue;
                //        //if (o.NewValue == "1")
                //        //{
                //        //    lbManual.Background = Brushes.DarkGray;
                //        //    lbAuto.Background = Brushes.Green;
                //        //}
                //        //else
                //        //{
                //        //    lbAuto.Background = Brushes.DarkGray;
                //        //}
                //    }));
                //};

                //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "PL_Manual").ValueChanged += (s, o) => {
                //    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                //    {
                //        Manual = o.NewValue;
                //    }));
                //};
            }
        }
    }
}
