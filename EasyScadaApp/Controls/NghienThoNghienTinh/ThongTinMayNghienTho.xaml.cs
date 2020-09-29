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
                dongMotorMayNghien.PathToTag = prefix + "Current_Digital_MN";

                if (DeviceName.Contains("Tho"))
                {
                    dongMotorCapLieu.PathToTag = prefix + "Current_Digital_Btai";
                    tanSoCapLieu.PathToTag = prefix + "Resuft_Hz_Btai";
                    inputTanSoCapLieu.PathToTag = prefix + "In_Hz_BT";
                }
                else
                {
                    dongMotorCapLieu.PathToTag = prefix + "Current_Digital_Vtai";
                    tanSoCapLieu.PathToTag = prefix + "Resuft_Hz_Vtai";
                    inputTanSoCapLieu.PathToTag = prefix + "In_Hz_VT";
                }

                dongMotorQuatHut.PathToTag = prefix + "Current_Digital_Qhut";

                EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "SW_Auto_MN").ValueChanged += (s, o) =>
                {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        Auto = o.NewValue;
                        //if (o.NewValue == "1")
                        //{
                        //    lbManual.Background = Brushes.DarkGray;
                        //    lbAuto.Background = Brushes.Green;
                        //}
                        //else
                        //{
                        //    lbAuto.Background = Brushes.DarkGray;
                        //}
                    }));
                };

                EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag(prefix + "SW_Man_MN").ValueChanged += (s, o) => {
                    DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                    {
                        Manual = o.NewValue;
                    }));
                };
            }
        }
    }
}
