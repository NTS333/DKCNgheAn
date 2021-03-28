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
    /// Interaction logic for ucChartTS.xaml
    /// </summary>
    public partial class ucChartTS : UserControl, INotifyPropertyChanged
    {
        private double tanSoNTho1 = 0, tanSoNTho2 = 0, tanSoNTinh = 0, tanSoA1EV1 = 0, tanSoA2EV1 = 0, tanSoA1EV2 = 0, tanSoA2EV2 = 0;
        //bat tat series
        private bool enableNTho1 = false, enableNTho2 = false, enableNTinh = false, enableA1EV1 = false, enableA2EV1 = false, enableA1EV2 = false, enableA2EV2 = false;


        //cau hinh chart
        private double _axisMax;
        private double _axisMin;

        LineSeries seriesNTho1, seriesNTho2, seriesNTinh, seriesA1EV1, seriesA2EV1, seriesA1EV2, seriesA2EV2;

        public ChartValues<MeasureModel> ChartValuesTSNTho2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSNTho1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSNTinh { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSA1EV1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSA2EV1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSA1EV2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesTSA2EV2 { get; set; }

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


        #region biến dùng để bidding bật tắt series 
        public bool EnableNTho1
        {
            get { return enableNTho1; }
            set
            {
                enableNTho1 = value;
                OnPropertyChanged("EnableNTho1");

                if (enableNTho1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTho1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTho1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }
        public bool EnableNTho2
        {
            get { return enableNTho2; }
            set
            {
                enableNTho2 = value;
                OnPropertyChanged("EnableNTho2");

                if (enableNTho2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTho2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTho2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableNTinh
        {
            get { return enableNTinh; }
            set
            {
                enableNTinh = value;
                OnPropertyChanged("EnableNTinh");

                if (enableNTinh)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTinh.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesNTinh.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableA1EV1
        {
            get { return enableA1EV1; }
            set
            {
                enableA1EV1 = value;
                OnPropertyChanged("EnableA1EV1");

                if (enableA1EV1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA1EV1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA1EV1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableA2EV1
        {
            get { return enableA2EV1; }
            set
            {
                enableA2EV1 = value;
                OnPropertyChanged("EnableA2EV1");

                if (enableA2EV1)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA2EV1.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA2EV1.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableA1EV2
        {
            get { return enableA1EV2; }
            set
            {
                enableA1EV2 = value;
                OnPropertyChanged("EnableA1EV2");

                if (enableA1EV2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA1EV2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA1EV2.Visibility = Visibility.Hidden;
                    }));
                }
            }
        }

        public bool EnableA2EV2
        {
            get { return enableA2EV2; }
            set
            {
                enableA2EV2 = value;
                OnPropertyChanged("EnableA2EV2");

                if (enableA2EV2)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA2EV2.Visibility = Visibility.Visible;
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        seriesA2EV2.Visibility = Visibility.Hidden;
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
        public ucChartTS()
        {
            InitializeComponent();

            DataContext = this;

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

            seriesNTho1 = new LineSeries();
            seriesNTho1.LineSmoothness = 0;
            seriesNTho1.StrokeThickness = 4;
            seriesNTho1.Stroke = Brushes.Red;
            seriesNTho1.Fill = Brushes.Transparent;
            seriesNTho1.PointGeometry = DefaultGeometries.None;
            ChartValuesTSNTho1 = new ChartValues<MeasureModel>();
            seriesNTho1.Values = ChartValuesTSNTho1;
            seriesNTho1.Title = "Tần số NTho1";
            seriesNTho1.FontSize = 10;
            seriesNTho1.DataLabels = true;
            seriesNTho1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesNTho1);

            seriesNTho2 = new LineSeries();
            seriesNTho2.LineSmoothness = 0;
            seriesNTho2.StrokeThickness = 4;
            seriesNTho2.Stroke = Brushes.Yellow;
            seriesNTho2.Fill = Brushes.Transparent;
            seriesNTho2.PointGeometry = DefaultGeometries.None;
            ChartValuesTSNTho2 = new ChartValues<MeasureModel>();
            seriesNTho2.Values = ChartValuesTSNTho2;
            seriesNTho2.Title = "Tần số NTho2";
            seriesNTho2.FontSize = 10;
            seriesNTho2.DataLabels = true;
            seriesNTho2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesNTho2);

            seriesNTinh = new LineSeries();
            seriesNTinh.LineSmoothness = 0;
            seriesNTinh.StrokeThickness = 4;
            seriesNTinh.Stroke = Brushes.Orange;
            seriesNTinh.Fill = Brushes.Transparent;
            seriesNTinh.PointGeometry = DefaultGeometries.None;
            ChartValuesTSNTinh = new ChartValues<MeasureModel>();
            seriesNTinh.Values = ChartValuesTSNTinh;
            seriesNTinh.Title = "Tần số NTinh";
            seriesNTinh.FontSize = 10;
            seriesNTinh.DataLabels = true;
            seriesNTinh.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesNTinh);

            seriesA1EV1 = new LineSeries();
            seriesA1EV1.LineSmoothness = 0;
            seriesA1EV1.StrokeThickness = 4;
            seriesA1EV1.Stroke = Brushes.Blue;
            seriesA1EV1.Fill = Brushes.Transparent;
            seriesA1EV1.PointGeometry = DefaultGeometries.None;
            ChartValuesTSA1EV1 = new ChartValues<MeasureModel>();
            seriesA1EV1.Values = ChartValuesTSA1EV1;
            seriesA1EV1.Title = "Tần số A1 EV1";
            seriesA1EV1.FontSize = 10;
            seriesA1EV1.DataLabels = true;
            seriesA1EV1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesA1EV1);

            seriesA2EV1 = new LineSeries();
            seriesA2EV1.LineSmoothness = 0;
            seriesA2EV1.StrokeThickness = 4;
            seriesA2EV1.Stroke = Brushes.Green;
            seriesA2EV1.Fill = Brushes.Transparent;
            seriesA2EV1.PointGeometry = DefaultGeometries.None;
            ChartValuesTSA2EV1 = new ChartValues<MeasureModel>();
            seriesA2EV1.Values = ChartValuesTSA2EV1;
            seriesA2EV1.Title = "Tần số A2 EV1";
            seriesA2EV1.FontSize = 10;
            seriesA2EV1.DataLabels = true;
            seriesA2EV1.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesA2EV1);

            seriesA1EV2 = new LineSeries();
            seriesA1EV2.LineSmoothness = 0;
            seriesA1EV2.StrokeThickness = 4;
            seriesA1EV2.Stroke = Brushes.Crimson;
            seriesA1EV2.Fill = Brushes.Transparent;
            seriesA1EV2.PointGeometry = DefaultGeometries.None;
            ChartValuesTSA1EV2 = new ChartValues<MeasureModel>();
            seriesA1EV2.Values = ChartValuesTSA1EV2;
            seriesA1EV2.Title = "Tần số A1 EV2";
            seriesA1EV2.FontSize = 10;
            seriesA1EV2.DataLabels = true;
            seriesA1EV2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesA1EV2);

            seriesA2EV2 = new LineSeries();
            seriesA2EV2.LineSmoothness = 0;
            seriesA2EV2.StrokeThickness = 4;
            seriesA2EV2.Stroke = Brushes.Purple;
            seriesA2EV2.Fill = Brushes.Transparent;
            seriesA2EV2.PointGeometry = DefaultGeometries.None;
            ChartValuesTSA2EV2 = new ChartValues<MeasureModel>();
            seriesA2EV2.Values = ChartValuesTSA2EV2;
            seriesA2EV2.Title = "Tần số A2 EV2";
            seriesA2EV2.FontSize = 10;
            seriesA2EV2.DataLabels = true;
            seriesA2EV2.Foreground = Brushes.White;
            realTimeChart.Series.Add(seriesA2EV2);
            #endregion


            //cho enable
            enableNTho1 = true;
            enableNTho2 = true;
            enableNTinh = true;
            enableA1EV1 = true;
            enableA2EV1 = true;
            enableA1EV2 = true;
            enableA2EV2 = true;

            #region đăng ký sự kiện tagValueChanged của các tag dòng motor để nó ghi nhận thời gian máy chạy máy dừng, dựa vào dòng của động cơ
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTho1/Resuft_Hz_BT1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoNTho1 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTho2/Resuft_Hz_BT1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoNTho2 = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTinh1/Resuft_Hz_BT1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoNTinh = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien1/TagInput_Hz_A1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoA1EV1 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien1/TagInput_Hz_A2").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoA2EV1 = Convert.ToDouble(o.NewValue);
                }));
            };

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien2/TagInput_Hz_A1").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoA1EV2 = Convert.ToDouble(o.NewValue);
                }));
            };
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien2/TagInput_Hz_A2").ValueChanged += (s, o) =>
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    tanSoA2EV2 = Convert.ToDouble(o.NewValue);
                }));
            };
            #endregion

            IsReading = true;
            btnChart.Background = new SolidColorBrush(Color.FromRgb(41, 191, 18));
            Task.Factory.StartNew(Read);//chay chart
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

        private void Read()
        {
            while (IsReading)
            {
                Thread.Sleep(1000);
                var now = DateTime.Now;

                ChartValuesTSNTho1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoNTho1
                });

                ChartValuesTSNTho2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoNTho2
                });

                ChartValuesTSNTinh.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoNTinh
                });

                ChartValuesTSA1EV1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoA1EV1
                });
                ChartValuesTSA2EV1.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoA2EV1
                });

                ChartValuesTSA1EV2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoA1EV2
                });
                ChartValuesTSA2EV2.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = tanSoA2EV2
                });
                SetAxisLimits(now);

                //lets only use the last 150 values
                if (ChartValuesTSNTho1.Count > 200)
                    ChartValuesTSNTho1.RemoveAt(0);

                if (ChartValuesTSNTho2.Count > 200)
                    ChartValuesTSNTho2.RemoveAt(0);

                if (ChartValuesTSNTinh.Count > 200)
                    ChartValuesTSNTinh.RemoveAt(0);

                if (ChartValuesTSA1EV1.Count > 200)
                    ChartValuesTSA1EV1.RemoveAt(0);
                
                if (ChartValuesTSA2EV1.Count > 200)
                    ChartValuesTSA2EV1.RemoveAt(0);

                if (ChartValuesTSA1EV2.Count > 200)
                    ChartValuesTSA1EV2.RemoveAt(0);

                if (ChartValuesTSA2EV2.Count > 200)
                    ChartValuesTSA2EV2.RemoveAt(0);
            }
        }
    }
}
