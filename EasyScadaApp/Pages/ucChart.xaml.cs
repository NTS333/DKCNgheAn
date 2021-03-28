using EasyScada.Core;
using EasyScada.Wpf.Controls;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ucChart.xaml
    /// </summary>
    public partial class ucChart : UserControl, INotifyPropertyChanged
    {
        private double dongMNTho1 = 0, dongMNTho2 = 0, dongMNTinh = 0, dongMayEV1 = 0, dongMayEV2 = 0;
        private double dongQHNTho1 = 0, dongQHNTho2 = 0, dongQHNTinh = 0, dongMixerEV1 = 0, dongMixerEV2 = 0;
        //bat tat series
        private bool enableDongMNTho1 = false, enableDongMNTho2 = false, enableDongMNTinh = false, enableDongMayEV1 = false, enableDongMayEV2 = false;
        private bool enableDongQHNTho1 = false, enableDongQHNTho2 = false, enableDongQHNTinh = false, enableDongMixerEV1 = false, enableDongMixerEV2 = false;


        //cau hinh chart
        private double _axisMax;
        private double _axisMin;
        private double _trend;

        LineSeries seriesDongMNTho1, seriesDongMNTho2, seriesDongMNTinh, seriesDongMEV1, seriesDongMEV2;
        LineSeries seriesDongQHNTho1, seriesDongQHNTho2, seriesDongQHNTinh, seriesDongMixerEV1, seriesDongMixerEV2;

        public ChartValues<MeasureModel> ChartValuesDongMNTho2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMNTho1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMNTinh { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMEV1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMEV2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongQHNTho1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongQHNTho2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongQHNTinh { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMixerEV1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesDongMixerEV2 { get; set; }

        public Func<double, string> DateTimeFormatter { get; set; }
        public Func<double, string> ValueFormat { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsReading { get; set; }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(0).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(60).Ticks; // and 8 seconds behind
        }

        private void SetAxisLimits(DateTime min, DateTime max)
        {
            AxisMax = max.Ticks; // lets force the axis to be 1 second ahead
            AxisMin = min.Ticks; // and 8 seconds behind
        }

        private void InjectStopOnClick(object sender, RoutedEventArgs e)
        {
            IsReading = !IsReading;
            if (IsReading)
            {
                Task.Factory.StartNew(Read);
                btnChart.Background = new SolidColorBrush(Color.FromRgb(41, 191, 18));
            }
            else
            {
                btnChart.Background = new SolidColorBrush(Color.FromRgb(255, 153, 20));
            }
        }

        #region biến dùng để bidding bật tắt series 
        public bool EnableDongMNTho1
        {
            get { return enableDongMNTho1; }
            set
            {
                enableDongMNTho1 = value;
                OnPropertyChanged("EnableDongMNTho1");

                if (enableDongMNTho1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTho1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTho1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableDongQHNTho1
        {
            get { return enableDongQHNTho1; }
            set
            {
                enableDongQHNTho1 = value;
                OnPropertyChanged("EnableDongQHNTho1");

                if (enableDongQHNTho1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTho1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTho1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableDongMNTho2
        {
            get { return enableDongMNTho2; }
            set
            {
                enableDongMNTho2 = value;
                OnPropertyChanged("EnableDongMNTho2");

                if (enableDongMNTho2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTho2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTho2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableDongQHNTho2
        {
            get { return enableDongQHNTho2; }
            set
            {
                enableDongQHNTho2 = value;
                OnPropertyChanged("EnableDongQHNTho2");

                if (enableDongQHNTho2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTho2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTho2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableDongMNTinh
        {
            get { return enableDongMNTinh; }
            set
            {
                enableDongMNTinh = value;
                OnPropertyChanged("EnableDongMNTinh");

                if (enableDongMNTinh)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTinh.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMNTinh.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableDongQHNTinh
        {
            get { return enableDongQHNTinh; }
            set
            {
                enableDongQHNTinh = value;
                OnPropertyChanged("EnableDongQHNTinh");

                if (enableDongQHNTinh)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTinh.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongQHNTinh.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableDongMEV1
        {
            get { return enableDongMayEV1; }
            set
            {
                enableDongMayEV1 = value;
                OnPropertyChanged("EnableDongMEV1");

                if (enableDongMayEV1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMEV1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMEV1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableDongMixerEV1
        {
            get { return enableDongMixerEV1; }
            set
            {
                enableDongMixerEV1 = value;
                OnPropertyChanged("EnableDongMixerEV1");

                if (enableDongMixerEV1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMixerEV1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMixerEV1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableDongMEV2
        {
            get { return enableDongMayEV2; }
            set
            {
                enableDongMayEV2 = value;
                OnPropertyChanged("EnableDongMEV2");

                if (enableDongMayEV2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMEV2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMEV2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableDongMixerEV2
        {
            get { return enableDongMixerEV2; }
            set
            {
                enableDongMixerEV2 = value;
                OnPropertyChanged("EnableDongMixerEV2");

                if (enableDongMixerEV2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMixerEV2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesDongMixerEV2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }


        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ucChart()
        {
            InitializeComponent();

            var mapper = Mappers.Xy<MeasureModel>()
                    .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                    .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("dd/MM/yyyy HH:mm:ss");
            ValueFormat = value => Math.Round(value, 1).ToString();

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(5).Ticks;//cài đặt số điểm hiển thị trên label trục x

            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.FromSeconds(50).Ticks;//cài đặt bao nhiêu point thì rendom 1 lần

            SetAxisLimits(DateTime.Now);//sét min và max cảu trục x

            #region khởi tạo Series
            //convert max hex mau. để truyền trực tiếp vào Stroke
            //BrushConverter converter = new BrushConverter();
            //var brush = (Brush)converter.ConvertFrom("#FF0000");

            seriesDongMNTho1 = new LineSeries();
            seriesDongMNTho1.LineSmoothness = 0;
            seriesDongMNTho1.StrokeThickness = 4;
            seriesDongMNTho1.Stroke = new SolidColorBrush(Color.FromRgb(41, 191, 18));
            seriesDongMNTho1.Fill = Brushes.Transparent;
            seriesDongMNTho1.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMNTho1 = new ChartValues<MeasureModel>();
            seriesDongMNTho1.Values = ChartValuesDongMNTho1;
            seriesDongMNTho1.Title = "Dòng máy NThô 1";
            seriesDongMNTho1.FontSize = 10;
            seriesDongMNTho1.DataLabels = true;
            seriesDongMNTho1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMNTho1);

            seriesDongQHNTho1 = new LineSeries();
            seriesDongQHNTho1.LineSmoothness = 0;
            seriesDongQHNTho1.StrokeThickness = 4;
            seriesDongQHNTho1.Stroke = new SolidColorBrush(Color.FromRgb(239, 121, 138));
            seriesDongQHNTho1.Fill = Brushes.Transparent;
            seriesDongQHNTho1.PointGeometry = DefaultGeometries.None;
            ChartValuesDongQHNTho1 = new ChartValues<MeasureModel>();
            seriesDongQHNTho1.Values = ChartValuesDongQHNTho1;
            seriesDongQHNTho1.Title = "Dòng QH NThô1";
            seriesDongQHNTho1.FontSize = 10;
            seriesDongQHNTho1.DataLabels = true;
            seriesDongQHNTho1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongQHNTho1);

            seriesDongMNTho2 = new LineSeries();
            seriesDongMNTho2.LineSmoothness = 0;
            seriesDongMNTho2.StrokeThickness = 4;
            seriesDongMNTho2.Stroke = new SolidColorBrush(Color.FromRgb(74, 223, 252));
            seriesDongMNTho2.Fill = Brushes.Transparent;
            seriesDongMNTho2.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMNTho2 = new ChartValues<MeasureModel>();
            seriesDongMNTho2.Values = ChartValuesDongMNTho2;
            seriesDongMNTho2.Title = "Dòng máy NThô 2";
            seriesDongMNTho2.FontSize = 10;
            seriesDongMNTho2.DataLabels = true;
            seriesDongMNTho2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMNTho2);

            seriesDongQHNTho2 = new LineSeries();
            seriesDongQHNTho2.LineSmoothness = 0;
            seriesDongQHNTho2.StrokeThickness = 4;
            seriesDongQHNTho2.Stroke = new SolidColorBrush(Color.FromRgb(0, 80, 157));
            seriesDongQHNTho2.Fill = Brushes.Transparent;
            seriesDongQHNTho2.PointGeometry = DefaultGeometries.None;
            ChartValuesDongQHNTho2 = new ChartValues<MeasureModel>();
            seriesDongQHNTho2.Values = ChartValuesDongQHNTho2;
            seriesDongQHNTho2.Title = "Dòng QH NThô2";
            seriesDongQHNTho2.FontSize = 10;
            seriesDongQHNTho2.DataLabels = true;
            seriesDongQHNTho2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongQHNTho2);

            seriesDongMNTinh = new LineSeries();
            seriesDongMNTinh.LineSmoothness = 0;
            seriesDongMNTinh.StrokeThickness = 4;
            seriesDongMNTinh.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            seriesDongMNTinh.Fill = Brushes.Transparent;
            seriesDongMNTinh.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMNTinh = new ChartValues<MeasureModel>();
            seriesDongMNTinh.Values = ChartValuesDongMNTinh;
            seriesDongMNTinh.Title = "Dòng máy NTinh";
            seriesDongMNTinh.FontSize = 10;
            seriesDongMNTinh.DataLabels = true;
            seriesDongMNTinh.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMNTinh);

            seriesDongQHNTinh = new LineSeries();
            seriesDongQHNTinh.LineSmoothness = 0;
            seriesDongQHNTinh.StrokeThickness = 4;
            seriesDongQHNTinh.Stroke = new SolidColorBrush(Color.FromRgb(229, 195, 209));
            seriesDongQHNTinh.Fill = Brushes.Transparent;
            seriesDongQHNTinh.PointGeometry = DefaultGeometries.None;
            ChartValuesDongQHNTinh = new ChartValues<MeasureModel>();
            seriesDongQHNTinh.Values = ChartValuesDongQHNTinh;
            seriesDongQHNTinh.Title = "Dòng QH NTinh";
            seriesDongQHNTinh.FontSize = 10;
            seriesDongQHNTinh.DataLabels = true;
            seriesDongQHNTinh.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongQHNTinh);

            seriesDongMEV1 = new LineSeries();
            seriesDongMEV1.LineSmoothness = 0;
            seriesDongMEV1.StrokeThickness = 4;
            seriesDongMEV1.Stroke= new SolidColorBrush(Color.FromRgb(167, 19, 246));
            seriesDongMEV1.Fill = Brushes.Transparent;
            seriesDongMEV1.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMEV1 = new ChartValues<MeasureModel>();
            seriesDongMEV1.Values = ChartValuesDongMEV1;
            seriesDongMEV1.Title = "Dòng máy EV1";
            seriesDongMEV1.FontSize = 10;
            seriesDongMEV1.DataLabels = true;
            seriesDongMEV1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMEV1);

            seriesDongMixerEV1 = new LineSeries();
            seriesDongMixerEV1.LineSmoothness = 0;
            seriesDongMixerEV1.StrokeThickness = 4;
            seriesDongMixerEV1.Stroke = new SolidColorBrush(Color.FromRgb(237, 255, 171));
            seriesDongMixerEV1.Fill = Brushes.Transparent;
            seriesDongMixerEV1.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMixerEV1 = new ChartValues<MeasureModel>();
            seriesDongMixerEV1.Values = ChartValuesDongMixerEV1;
            seriesDongMixerEV1.Title = "Dòng mixer EV1";
            seriesDongMixerEV1.FontSize = 10;
            seriesDongMixerEV1.DataLabels = true;
            seriesDongMixerEV1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMixerEV1);

            seriesDongMEV2 = new LineSeries();
            seriesDongMEV2.LineSmoothness = 0;
            seriesDongMEV2.StrokeThickness = 4;
            seriesDongMEV2.Stroke = new SolidColorBrush(Color.FromRgb(255, 153, 20));
            seriesDongMEV2.Fill = Brushes.Transparent;
            seriesDongMEV2.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMEV2 = new ChartValues<MeasureModel>();
            seriesDongMEV2.Values = ChartValuesDongMEV2;
            seriesDongMEV2.Title = "Dòng máy EV2";
            seriesDongMEV2.FontSize = 10;
            seriesDongMEV2.DataLabels = true;
            seriesDongMEV2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMEV2);

            seriesDongMixerEV2 = new LineSeries();
            seriesDongMixerEV2.LineSmoothness = 0;
            seriesDongMixerEV2.StrokeThickness = 4;
            seriesDongMixerEV2.Stroke = new SolidColorBrush(Color.FromRgb(255, 213, 0));
            seriesDongMixerEV2.Fill = Brushes.Transparent;
            seriesDongMixerEV2.PointGeometry = DefaultGeometries.None;
            ChartValuesDongMixerEV2 = new ChartValues<MeasureModel>();
            seriesDongMixerEV2.Values = ChartValuesDongMixerEV2;
            seriesDongMixerEV2.Title = "Dòng mixer EV2";
            seriesDongMixerEV2.FontSize = 10;
            seriesDongMixerEV2.DataLabels = true;
            seriesDongMixerEV2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesDongMixerEV2);
            #endregion


            //cho enable
            EnableDongMNTho1 = true;
            EnableDongMNTho2 = true;
            EnableDongMNTinh = true;
            EnableDongMEV1 = true;
            EnableDongMEV2 = true;

            enableDongQHNTho1 = true;
            enableDongQHNTho2 = true;
            enableDongQHNTinh = true;
            enableDongMixerEV1 = true;
            enableDongMixerEV2 = true;

            DataContext = this;

            #region đăng ký sự kiện tagValueChanged của các tag dòng motor để nó ghi nhận thời gian máy chạy máy dừng, dựa vào dòng của động cơ
            var Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_NTho").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMNTho1 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_QH").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongQHNTho1 = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho2/Current_Digital_NTho").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMNTho2 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_QH").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongQHNTho2 = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTinh/MayNghienTinh1/Current_Digital_NTinh").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMNTinh = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTinh/MayNghienTinh1/Current_Digital_QH").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongQHNTinh = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien1/Current_Digital_M1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMayEV1 = Convert.ToDouble(o.NewValue);
                }));
            }; 
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien1/Current_Digital_MX").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMixerEV1 = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien2/Current_Digital_M1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMayEV2 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien2/Current_Digital_MX").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    dongMixerEV2 = Convert.ToDouble(o.NewValue);
                }));
            };

            #endregion
            
            IsReading = true;
            btnChart.Background = new SolidColorBrush(Color.FromRgb(41, 191, 18));
            Task.Factory.StartNew(Read);//chay chart
        }


        private void Read()
        {
            while (IsReading)
            {
                Thread.Sleep(1000);
                var now = DateTime.Now;

                ChartValuesDongMNTho1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMNTho1
                });

                ChartValuesDongMNTho2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMNTho2
                });

                ChartValuesDongMNTinh.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMNTinh
                });

                ChartValuesDongMEV1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMayEV1
                });

                ChartValuesDongMEV2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMayEV2
                });

                ChartValuesDongQHNTho1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongQHNTho1
                });

                ChartValuesDongQHNTho2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongQHNTho2
                });

                ChartValuesDongQHNTinh.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongQHNTinh
                });

                ChartValuesDongMixerEV1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMixerEV1
                });

                ChartValuesDongMixerEV2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = dongMixerEV2
                });

                SetAxisLimits(now);

                //lets only use the last 150 values
                if (ChartValuesDongMNTho1.Count > 200)
                    ChartValuesDongMNTho1.RemoveAt(0);

                if (ChartValuesDongMNTho2.Count > 200)
                    ChartValuesDongMNTho2.RemoveAt(0);

                if (ChartValuesDongMNTinh.Count > 200)
                    ChartValuesDongMNTinh.RemoveAt(0);

                if (ChartValuesDongMEV1.Count > 200)
                    ChartValuesDongMEV1.RemoveAt(0);

                if (ChartValuesDongMEV2.Count > 200)
                    ChartValuesDongMEV2.RemoveAt(0);

                if (ChartValuesDongQHNTho1.Count > 200)
                    ChartValuesDongQHNTho1.RemoveAt(0);

                if (ChartValuesDongQHNTho2.Count > 200)
                    ChartValuesDongQHNTho2.RemoveAt(0);

                if (ChartValuesDongQHNTinh.Count > 200)
                    ChartValuesDongQHNTinh.RemoveAt(0);

                if (ChartValuesDongMixerEV1.Count > 200)
                    ChartValuesDongMixerEV1.RemoveAt(0);

                if (ChartValuesDongMixerEV2.Count > 200)
                    ChartValuesDongMixerEV2.RemoveAt(0);
            }
        }
    }
}
