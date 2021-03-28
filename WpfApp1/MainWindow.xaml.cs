using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
        }

        private bool isLoaded;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;
                khoNghienSay.StationName = "RemoteStation1";
                khoNghienSay.ChannelName = "PLCNghien";
                khoNghienSay.DeviceName = "MayEp1";
                
                khoNghienSay.MotorBomDau1Click += OnBomDau1;
                khoNghienSay.MotorBomDau2Click += OnBomDau2;
                khoNghienSay.MotorVTRLClick += OnVTRL;
                khoNghienSay.MotorVTCL1Click += OnVTCL1;
                khoNghienSay.MotorVTCL2Click += OnVTCL2;
                khoNghienSay.Xilanh1Click += OnXiLanh1;
                khoNghienSay.Xilanh2Click += OnXiLanh2;
                khoNghienSay.Xilanh3Click += OnXiLanh3;
                khoNghienSay.Xilanh4Click += OnXiLanh4;
                

                khoNghienSay.Start();
            }
        }

        private void OnXiLanhssss(object sender, EventArgs e)
        {
            MessageBox.Show("Air");
        }

        private void OnXiLanh3(object sender, EventArgs e)
        {
            MessageBox.Show("Xl3");
        }

        private void OnXiLanh2(object sender, EventArgs e)
        {
            MessageBox.Show("Xl2");
        }

        private void OnXiLanh4(object sender, EventArgs e)
        {
            MessageBox.Show("Xl4");
        }

        private void OnXiLanh1(object sender, EventArgs e)
        {
            MessageBox.Show("Xl1");
        }

        private void OnVTRL(object sender, EventArgs e)
        {
            MessageBox.Show("VTRL");
        }

        private void OnVTCL1(object sender, EventArgs e)
        {
            MessageBox.Show("VTCL1");
        }

        private void OnVTCL2(object sender, EventArgs e)
        {
            MessageBox.Show("VTCL2");
        }

        private void OnBomDau2(object sender, EventArgs e)
        {
            MessageBox.Show("BD2");
        }

        private void OnBomDau1(object sender, EventArgs e)
        {
            MessageBox.Show("BD1");
        }
    }
}
