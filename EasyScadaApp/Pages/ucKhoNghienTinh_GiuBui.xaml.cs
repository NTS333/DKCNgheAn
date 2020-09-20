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

namespace EasyScadaApp.Pages
{
    /// <summary>
    /// Interaction logic for ucKhoNghienTinh_GiuBui.xaml
    /// </summary>
    public partial class ucKhoNghienTinh_GiuBui : UserControl
    {
        public ucKhoNghienTinh_GiuBui()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            #region Giũ bụi trung tâm
            ThongTinGiuBui.StationName = "RemoteStation1";
            ThongTinGiuBui.ChannelName = "PLCMayEpVien";
            ThongTinGiuBui.DeviceName = "GiuBuiEpVien";

            ThongTinGiuBui.Start();
            #endregion
        }
    }
}
