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
//using WPFUserControl.LoDot;

namespace WPFUserControl
{
    /// <summary>
    /// Interaction logic for LoDot.xaml
    /// </summary>
    public partial class LoDot : UserControl
    {
      public  LoDotViewModel lodotDatacontext = new LoDotViewModel();
        public LoDot()
        {
            InitializeComponent();
            DataContext = lodotDatacontext;
        }
    }
}
