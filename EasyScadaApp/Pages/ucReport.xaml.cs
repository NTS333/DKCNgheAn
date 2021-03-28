using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for ucReport.xaml
    /// </summary>
    public partial class ucReport : UserControl, INotifyPropertyChanged
    {

        public ucReport()
        {
            InitializeComponent();

            machineName = 2;
        }

        private Colors selectIndevData = Colors.alarm;
        private int machineName;

        public enum Colors
        {
            runTime = 0,
            data = 1,
            alarm = 2,
        }
        public Colors SelectIndevData
        {
            get { return selectIndevData; }
            set
            {
                if (selectIndevData != value)
                {
                    selectIndevData = value;
                    OnPropertyChanged("SelectIndevData");
                }
            }
        }

        public int MachineName
        {
            get => machineName;
            set
            {
                if (machineName != value)
                {
                    machineName = value;
                    OnPropertyChanged("MachineName");
                }
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // A path to export a report.
                string reportPath = "";

                DataTable _data = new DataTable();
                if (!string.IsNullOrEmpty(datePickerFormDate.Text) && !string.IsNullOrEmpty(datePickerToDate.Text))
                {
                    if (comboboxChon.Text == "Data")
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        saveFileDialog1.Title = "Save an Excel File";
                        saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd")}_Data";
                        saveFileDialog1.ShowDialog();

                        reportPath = saveFileDialog1.FileName;

                        _data = DbData.Instance.GetDateTime(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"));// DbData.Instance.GetAll();
                                                                                               //hien thi gridVie
                    }
                    else if (comboboxChon.Text == "Alarm")
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        saveFileDialog1.Title = "Save an Excel File";
                        saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd")}_Alarm";
                        saveFileDialog1.ShowDialog();

                        reportPath = saveFileDialog1.FileName;

                        _data = DbAlarm.Instance.GetDateTime(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"));// DbData.Instance.GetAll();
                    }
                    else if (comboboxChon.Text == "Khối lượng cân 1")
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        saveFileDialog1.Title = "Save an Excel File";
                        saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd")}_KhoiLuongCan1";
                        saveFileDialog1.ShowDialog();

                        reportPath = saveFileDialog1.FileName;

                        _data = DbData.Instance.GetScaleValueDDataTable(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), "1");// DbData.Instance.GetAll();
                                                                                                    //hien thi gridVie
                    }
                    else if (comboboxChon.Text == "Khối lượng cân 2")
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        saveFileDialog1.Title = "Save an Excel File";
                        saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd")}_KhoiLuongCan2";
                        saveFileDialog1.ShowDialog();

                        reportPath = saveFileDialog1.FileName;

                        _data = DbData.Instance.GetScaleValueDDataTable(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), "2");// DbData.Instance.GetAll();
                                                                                                    //hien thi gridVie
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel|*.xlsx";
                        saveFileDialog1.Title = "Save an Excel File";
                        saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyyMMdd")}_RunTime_{comboboxTenMay.Text}";
                        saveFileDialog1.ShowDialog();

                        reportPath = saveFileDialog1.FileName;

                        _data = DbData.Instance.GetRunTime(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                       , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), comboboxTenMay.Text);// DbData.Instance.GetAll();
                    }

                    ReadWriteExcel exportExcel = new ReadWriteExcel();

                    exportExcel.CreateExcelFile(_data, reportPath);
                }
                else
                {
                    MessageBox.Show("Chưa chọn khoảng thời gian xuất. Mời chọn lại !", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnTruyVan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<DataModel> _data = new List<DataModel>();
                List<AlarmModel> _alarm = new List<AlarmModel>();
                List<ThoiGianChayMayModel> runTimeMachine = new List<ThoiGianChayMayModel>();

                var s = comboboxChon.SelectedValue;
                int d = comboboxChon.SelectedIndex;

                if (!string.IsNullOrEmpty(datePickerFormDate.Text) && !string.IsNullOrEmpty(datePickerToDate.Text))
                {
                    if (comboboxChon.Text == "Data")
                    {
                        _data = DbData.Instance.GetDateTimeList(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"));// DbData.Instance.GetAll();
                                                                                               //hien thi gridView
                        dataGrid1.ItemsSource = _data;
                    }
                    else if (comboboxChon.Text == "Alarm")
                    {
                        _alarm = DbAlarm.Instance.GetDateTimeList(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"));// DbData.Instance.GetAll();

                        //hien thi gridView
                        dataGrid1.ItemsSource = _alarm;
                    }
                    else if (comboboxChon.Text == "Thời gian máy chạy")//TimeRun
                    {
                        runTimeMachine = DbData.Instance.GetDateRunTimeList(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), comboboxTenMay.Text);// DbData.Instance.GetAll();

                        //hien thi gridView
                        dataGrid1.ItemsSource = runTimeMachine;
                        dataGrid1.Columns[0].Visibility = Visibility.Hidden;
                    }
                    else if (comboboxChon.Text == "Khối lượng cân 1")
                    {
                        dataGrid1.ItemsSource = DbData.Instance.GetScaleValue(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), "1");// DbData.Instance.GetAll();
                    }
                    else if (comboboxChon.Text == "Khối lượng cân 2")
                    {
                        dataGrid1.ItemsSource = DbData.Instance.GetScaleValue(Convert.ToDateTime(datePickerFormDate.Text).ToString("yyyy-MM-dd 00:00:00")
                  , Convert.ToDateTime(datePickerToDate.Text).ToString("yyyy-MM-dd 23:59:59"), "2");// DbData.Instance.GetAll();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn khoảng thời gian xuất. Mời chọn lại !", "CẢNH BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void comboboxChon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox _item = sender as ComboBox;

            //if (_item!=null)
            //{
            //    labItemName.IsEnabled = true;
            //    comboboxTenMay.IsEnabled = true;

            //    //if (_item.get)
            //    //{

            //    //}

            //    var a = _item.Text;
            //}

        }
    }
}
