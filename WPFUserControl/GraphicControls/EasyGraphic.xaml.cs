using EasyScada.Core;
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
using WPFUserControl.GraphicControls;

namespace WPFUserControl
{
    /// <summary>
    /// Interaction logic for EasyGraphic.xaml
    /// </summary>
    public partial class EasyGraphic : UserControl, ISupportTag, ISupportInitialize
    {
        EasyGraphicViewModel EasyGraphicDataContext = new EasyGraphicViewModel();
        public EasyGraphic()
        {
            InitializeComponent();
            DataContext = EasyGraphicDataContext;
        }

        public static readonly DependencyProperty PathToTagProperty = DependencyProperty.Register("PathToTag", typeof(string), typeof(EasyGraphic), new PropertyMetadata((PropertyChangedCallback)null));

        static EasyGraphic() => FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(EasyGraphic), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(EasyGraphic)));

        [TypeConverter(typeof(TagPathConverter))]
        public string TagPath
        {
            get => (string)this.GetValue(EasyGraphic.PathToTagProperty);
            set
            {
                if (!(value != this.TagPath))
                    return;
                this.SetValue(EasyGraphic.PathToTagProperty, (object)value);
                this.OnPathToTagPropertyChanged();
            }
        }

        [Browsable(false)]
        public ITag LinkedTag { get;  set; }

        [Browsable(false)]
        public IEasyDriverConnector Connector => EasyDriverConnectorProvider.GetEasyDriverConnector();

        public override void EndInit()
        {
            base.EndInit();
            this.OnPathToTagPropertyChanged();
        }

        private void OnPathToTagPropertyChanged()
        {
            if (DesignerProperties.GetIsInDesignMode((DependencyObject)this))
                return;
            if (this.LinkedTag != null)
            {
                this.LinkedTag.ValueChanged -= new EventHandler<TagValueChangedEventArgs>(this.OnValueChanged);
                this.LinkedTag.QualityChanged -= new EventHandler<TagQualityChangedEventArgs>(this.OnQualityChanged);
                this.LinkedTag = (ITag)null;
            }
            if (this.Connector.IsStarted)
                this.OnConnectorStarted((object)this.Connector, (EventArgs)null);
            else
                this.Connector.Started += new EventHandler(this.OnConnectorStarted);
        }

        private void OnConnectorStarted(object sender, EventArgs e) => this.Dispatcher.Invoke((Action)(() =>
        {
            if (e != null)
                this.Connector.Started -= new EventHandler(this.OnConnectorStarted);
            if (this.LinkedTag == null)
                this.LinkedTag = this.Connector.GetTag(this.TagPath);
            if (this.LinkedTag == null)
                return;
            this.OnValueChanged((object)this.LinkedTag, new TagValueChangedEventArgs(this.LinkedTag, "", this.LinkedTag.Value));
            this.LinkedTag.ValueChanged += new EventHandler<TagValueChangedEventArgs>(this.OnValueChanged);
            this.LinkedTag.QualityChanged += new EventHandler<TagQualityChangedEventArgs>(this.OnQualityChanged);
        }));

        private void OnQualityChanged(object sender, TagQualityChangedEventArgs e)
        {
        }

        //private void OnValueChanged(object sender, TagValueChangedEventArgs e) => Dispatcher.Invoke(new Action(()=> this.Content = (object)e.NewValue));
        private void OnValueChanged(object sender, TagValueChangedEventArgs e) => Dispatcher.Invoke(new Action(() =>
        
        (DataContext as EasyGraphicViewModel).Status = int.Parse(e.NewValue)));
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            (DataContext as EasyGraphicViewModel).Status = cbb.SelectedIndex + 1;
        }
    }
}
