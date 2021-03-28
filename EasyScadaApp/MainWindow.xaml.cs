using EasyScada.Core;
using EasyScada.Wpf.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;

using Newtonsoft.Json;
using System.Collections.Generic;

namespace EasyScadaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEasyDriverConnector Connector { get; set; }
        //dynamic TagFile1 = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(@"F:\Project\DKCNgheAn\TagFile.json"));
        double dongMayNghienTho1 = 0, dongMayNghienTho2 = 0, dongMayNghienTinh = 0, dongMayEpVien1 = 0, dongMayEpVien2 = 0;
        ThoiGianChayMayModel dataTimeRunNghienTho1 = new ThoiGianChayMayModel() { MachineName = "MayNghienTho1" };
        ThoiGianChayMayModel dataTimeRunNghienTho2 = new ThoiGianChayMayModel() { MachineName = "MayNghienTho2" };
        ThoiGianChayMayModel dataTimeRunNghienTinh = new ThoiGianChayMayModel() { MachineName = "MayNghienTinh" };
        ThoiGianChayMayModel dataTimeRunEpVien1 = new ThoiGianChayMayModel() { MachineName = "EpVien1" };
        ThoiGianChayMayModel dataTimeRunEpVien2 = new ThoiGianChayMayModel() { MachineName = "EpVien2" };

        ScaleValuesModel scaleValues = new ScaleValuesModel();
        bool chotCan1 = false, chotCan2 = false;

        string EmailString { get; set; }
        string SMSString { get; set; }
        //PLCPi GateWay = new PLCPi();

        DateTime timeDailyReport;
        TimeSpan timeAddOrSub;



        public MainWindow()
        {

            InitializeComponent();
            //dynamic TagList = GetTagPath<dynamic>(TagFile1);
            _timer.Interval = 100;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;

            //Loaded += MainWindow_Loaded;
            control = new UserControl1();

            SMSString = ReadText(@"/Files/sms.txt").Trim();
            EmailString = ReadText(@"/Files/email.txt").Trim();
            Debug.WriteLine($"sms {SMSString} | Email {EmailString}");

            Console.WriteLine("Khởi tạo USB3G");
            //GateWay.SMS.Port_USB3G = ReadText(@"/Files/comSMS.txt");
            //GateWay.SMS.Port_USB3G = "COM12";
            //GateWay.SMS.Khoitao();
            //Console.WriteLine($"Com SMS {GateWay.SMS.Port_USB3G}| Khoi Tao {GateWay.SMS.Khoitao()}");
            Console.WriteLine("Khởi tạo USB3G thành công");

            #region đăng ký sự kiện tagValueChanged của các tag dòng motor để nó ghi nhận thời gian máy chạy máy dừng, dựa vào dòng của động cơ

            Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();
            //Connector.Su
            //Connector.
            Connector.Started += MainWindow_Started;

            #endregion
        }

        private void MainWindow_Started(object sender, EventArgs e)
        {
            //MainWindow_ValueChangedNT1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_NTho"),
            //    new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_NTho"), "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTho1/Current_Digital_MN").Value));

            //MainWindow_ValueChangedNTT2(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho2/Current_Digital_NTho"),
            //    new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho2/Current_Digital_NTho"), "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTho2/Current_Digital_MN").Value));

            //MainWindow_ValueChangedNTinh(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTinh/MayNghienTinh1/Current_Digital_MN"),
            //    new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTinh/MayNghienTinh1/Current_Digital_MN"), "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayNghienTinh1/Current_Digital_MN").Value));

            //MainWindow_ValueChangedEV2(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien2/Current_Digital_EV"),
            //   new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien2/Current_Digital_EV"), "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien2/Current_Digital_EV").Value));

            //MainWindow_ValueChangedEV1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien1/Current_Digital_EV"),
            //  new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien1/Current_Digital_EV"), "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLCNghien_EpVien/MayEpVien1/Current_Digital_EV").Value));

            //MainWindow_ValueChangedLoadcell1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell1"),
            //              new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell1")
            //              , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell1").Value));

            //MainWindow_ValueChangedLoadcell2(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell2"),
            //              new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell2")
            //              , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell2").Value));

            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho1/Current_Digital_MN").ValueChanged += MainWindow_ValueChangedNT1;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTho/MayNghienTho2/Current_Digital_MN").ValueChanged += MainWindow_ValueChangedNTT2;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_MayNghienTinh/MayNghienTinh1/Current_Digital_MN").ValueChanged += MainWindow_ValueChangedNTinh;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien1/Current_Digital_EV").ValueChanged += MainWindow_ValueChangedEV1;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_EpVien/EpVien2/Current_Digital_EV").ValueChanged += MainWindow_ValueChangedEV2;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell1").ValueChanged += MainWindow_ValueChangedLoadcell1;
            //EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("RemoteStation1/PLC_PTEV/PTEV/Save_Loadcell2").ValueChanged += MainWindow_ValueChangedLoadcell2;
        }

        private void MainWindow_ValueChangedLoadcell2(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && e.NewValue != scaleValues.ScaleValue2)
                    {
                        //Log khoi luong can 
                        scaleValues.ScaleValue2 = e.NewValue;
                        DbData.Instance.InsertDataScale(scaleValues, 2);

                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedLoadcell1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && e.NewValue != scaleValues.ScaleValue1)
                    {
                        //Log khoi luong can 
                        scaleValues.ScaleValue1 = e.NewValue;
                        DbData.Instance.InsertDataScale(scaleValues, 1);

                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedEV1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && dongMayEpVien1 == 0)
                    {
                        //ghi DB thời gian bắt đầu chạy máy
                        dataTimeRunEpVien1.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DbData.Instance.InsertDataTimeRun(dataTimeRunEpVien1);
                        dataTimeRunEpVien1.Id = DbData.Instance.GetMaxIdTimeRun();
                        dongMayEpVien1 = 1;
                    }
                    else if (e.NewValue == "0" && dongMayEpVien1 == 1)
                    {
                        //kho dòng về 0, thì máy dừng
                        //update thời gian dùng vào DB

                        dataTimeRunEpVien1.StopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        dataTimeRunEpVien1.RunTimeTotal = Math.Round((Convert.ToDateTime(dataTimeRunEpVien1.StopTime) - Convert.ToDateTime(dataTimeRunEpVien1.StartTime)).TotalMinutes, 2);
                        DbData.Instance.UpdateTimeRun(dataTimeRunEpVien1);
                        dongMayEpVien1 = 0;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedEV2(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && dongMayEpVien2 == 0)
                    {
                        //ghi DB thời gian bắt đầu chạy máy
                        dataTimeRunEpVien2.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DbData.Instance.InsertDataTimeRun(dataTimeRunEpVien2);
                        dataTimeRunEpVien2.Id = DbData.Instance.GetMaxIdTimeRun();
                        dongMayEpVien2 = 1;
                    }
                    else if (e.NewValue == "0" && dongMayEpVien2 == 1)
                    {
                        //kho dòng về 0, thì máy dừng
                        //update thời gian dùng vào DB

                        dataTimeRunEpVien2.StopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        dataTimeRunEpVien2.RunTimeTotal = Math.Round((Convert.ToDateTime(dataTimeRunEpVien2.StopTime) - Convert.ToDateTime(dataTimeRunEpVien2.StartTime)).TotalMinutes, 2);
                        DbData.Instance.UpdateTimeRun(dataTimeRunEpVien2);
                        dongMayEpVien2 = 0;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedNTinh(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && dongMayNghienTinh == 0)
                    {
                        //ghi DB thời gian bắt đầu chạy máy
                        dataTimeRunNghienTinh.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DbData.Instance.InsertDataTimeRun(dataTimeRunNghienTinh);
                        dataTimeRunNghienTinh.Id = DbData.Instance.GetMaxIdTimeRun();
                        dongMayNghienTinh = 1;
                    }
                    else if (e.NewValue == "0" && dongMayNghienTinh == 1)
                    {
                        //kho dòng về 0, thì máy dừng
                        //update thời gian dùng vào DB

                        dataTimeRunNghienTinh.StopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        dataTimeRunNghienTinh.RunTimeTotal = Math.Round((Convert.ToDateTime(dataTimeRunNghienTinh.StopTime) - Convert.ToDateTime(dataTimeRunNghienTinh.StartTime)).TotalMinutes, 2);
                        DbData.Instance.UpdateTimeRun(dataTimeRunNghienTinh);
                        dongMayNghienTinh = 0;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedNTT2(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && dongMayNghienTho2 == 0)
                    {
                        //ghi DB thời gian bắt đầu chạy máy
                        dataTimeRunNghienTho2.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DbData.Instance.InsertDataTimeRun(dataTimeRunNghienTho2);
                        dataTimeRunNghienTho2.Id = DbData.Instance.GetMaxIdTimeRun();
                        dongMayNghienTho2 = 1;
                    }
                    else if (e.NewValue == "0" && dongMayNghienTho2 == 1)
                    {
                        //kho dòng về 0, thì máy dừng
                        //update thời gian dùng vào DB

                        dataTimeRunNghienTho2.StopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        dataTimeRunNghienTho2.RunTimeTotal = Math.Round((Convert.ToDateTime(dataTimeRunNghienTho2.StopTime) - Convert.ToDateTime(dataTimeRunNghienTho2.StartTime)).TotalMinutes, 2);
                        DbData.Instance.UpdateTimeRun(dataTimeRunNghienTho2);
                        dongMayNghienTho2 = 0;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MainWindow_ValueChangedNT1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue != "0" && dongMayNghienTho1 == 0)
                    {
                        //ghi DB thời gian bắt đầu chạy máy
                        dataTimeRunNghienTho1.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        DbData.Instance.InsertDataTimeRun(dataTimeRunNghienTho1);

                        dataTimeRunNghienTho1.Id = DbData.Instance.GetMaxIdTimeRun();//get lai ID của dòng mới log vào, để khi máy dừng update thời gian dừng
                        dongMayNghienTho1 = 1;
                    }
                    else if (e.NewValue == "0" && dongMayNghienTho1 == 1)
                    {
                        //kho dòng về 0, thì máy dừng
                        //update thời gian dùng vào DB

                        dataTimeRunNghienTho1.StopTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        dataTimeRunNghienTho1.RunTimeTotal = Math.Round((Convert.ToDateTime(dataTimeRunNghienTho1.StopTime) - Convert.ToDateTime(dataTimeRunNghienTho1.StartTime)).TotalMinutes, 2);
                        DbData.Instance.UpdateTimeRun(dataTimeRunNghienTho1);
                        dongMayNghienTho1 = 0;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private UserControl1 control;

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            //DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            //{
            //    labThoiGian.Content = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            //}));

            #region kiểm tra tới giờ gửi report hằng ngày thì vào lấy dữ liệu và gửi report
            if (DateTime.Now >= timeDailyReport)
            {

            }
            #endregion

            Dispatcher.BeginInvoke(new Action(
                () =>
                {
                    labThoiGian.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }));
            _timer.Enabled = true;
        }

        System.Timers.Timer _timer = new System.Timers.Timer();

        #region Nút nhấn footer
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnChartTS_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            //Chart.Visibility = Visibility.Hidden;
            //ChartTS.Visibility = Visibility.Visible;
        }

        private void btnReportTime_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMayNghien_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Visible;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            //Chart.Visibility = Visibility.Hidden;
            //ChartTS.Visibility = Visibility.Hidden;
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Visible;
            //Chart.Visibility = Visibility.Hidden;
            //ChartTS.Visibility = Visibility.Hidden;
        }
        #endregion

        private void BtnKhoNghienTinhGiuBui_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Visible;
            Report.Visibility = Visibility.Hidden;
            //Chart.Visibility = Visibility.Hidden;
            //ChartTS.Visibility = Visibility.Hidden;
        }

        private void BtnChart_Click(object sender, RoutedEventArgs e)
        {
            NghienTho.Visibility = Visibility.Hidden;
            KhoNghienTinhGiuBui.Visibility = Visibility.Hidden;
            Report.Visibility = Visibility.Hidden;
            //Chart.Visibility = Visibility.Visible;
            //ChartTS.Visibility = Visibility.Hidden;
        }

        #region Gui bao cao hang ngay
        //public void SendAlarmEmail(string alarm, string content)
        //{
        //    try
        //    {
        //        GateWay.Email.CredentialEmail = "giamsat.canhbao@gmail.com";
        //        GateWay.Email.CredentialPass = "1@3$5^7*";

        //        GateWay.Email.emailTo = EmailString;

        //        GateWay.Email.subjectEmail = "Báo Cáo Hằng Ngày";
        //        //string strAlarm = "Location : " + location.Name + Environment.NewLine
        //        //     + "Alarm: " + alarm + Environment.NewLine
        //        //     + "Value: " + location.Value + Environment.NewLine
        //        //     + "Low Level: " + (location.LowLevel.HasValue ? location.LowLevel.Value.ToString() : "") + Environment.NewLine
        //        //     + "High Level: " + (location.HighLevel.HasValue ? location.HighLevel.Value.ToString() : "");
        //        string strContent = $"{DateTime.Now}. {Environment.NewLine}{content}.";
        //        Debug.WriteLine($"EMAIL {strContent}");
        //        GateWay.Email.bodyEmail = strContent;
        //        GateWay.Email.TimeOut = 2000;
        //        GateWay.Email.SendEmail();
        //        Thread.Sleep(10);
        //        Console.WriteLine($"Gui Email");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi gửi Email : {ex.Message}");
        //    }
        //}

        //public void SendAlarmSMS(string alarm, string content)
        //{
        //    try
        //    {
        //        string noidung = $"{DateTime.Now}\n{content}";
        //        Console.WriteLine($"SMS {noidung}");
        //        //for (int j = 0; j < SMSString.Split(',').Length; j++)
        //        //{
        //        //    //GateWay.SMS.GuiSMS(SMSString.Split(',')[j], noidung);
        //        //    Debug.WriteLine($"Gui SMS {GateWay.SMS.GuiSMS(SMSString.Split(',')[j], noidung)}");
        //        //    Thread.Sleep(2000);
        //        //}

        //        Console.WriteLine($"SDT {SMSString}");
        //        Console.WriteLine($"Gui SMS {GateWay.SMS.GuiSMS(SMSString, noidung)}");
        //        Console.WriteLine($"-----------------------------------------------------");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi gửi tin SMS : {ex.Message}");
        //    }
        //}

        public string ReadText(string PathFile)
        {
            try
            {
                FileStream fs = new FileStream(PathFile, FileMode.Open, FileAccess.Read, FileShare.None);
                System.IO.StreamReader sr = new System.IO.StreamReader(fs);
                string text = sr.ReadToEnd().Trim();
                sr.Close();
                fs.Close();
                return text;
            }
            catch { return "NULL"; }
        }

        public void WriteText(string Text, string PathFile)
        {
            FileStream fs = new FileStream(PathFile, FileMode.Create, FileAccess.Write, FileShare.None);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            sw.WriteLine(Text);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        #endregion
        public dynamic GetTagPath<T>(dynamic TagFile)
        {
            dynamic Childs = TagFile.Childs;
            dynamic result = null;
            List<dynamic> listTag = new List<dynamic>(); 
            //while (GetTagPath<dynamic>(Childs) != null)
            //{
            //    Childs = TagFile.Childs;
            //}
            foreach (var item in Childs)
            {
                result = item.Childs;
                while (result.Count != 0)
                {
                    result = result.Childs;
                }
            }
            return result;
        }

    }
    
}
