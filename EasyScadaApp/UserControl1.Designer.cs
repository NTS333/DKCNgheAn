namespace EasyScadaApp
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            EasyScada.Core.LogColumn logColumn1 = new EasyScada.Core.LogColumn();
            EasyScada.Core.LogColumn logColumn2 = new EasyScada.Core.LogColumn();
            EasyScada.Core.LogColumn logColumn3 = new EasyScada.Core.LogColumn();
            EasyScada.Core.LogColumn logColumn4 = new EasyScada.Core.LogColumn();
            EasyScada.Core.LogColumn logColumn5 = new EasyScada.Core.LogColumn();
            EasyScada.Core.LogProfile logProfile1 = new EasyScada.Core.LogProfile();
            EasyScada.Core.LogProfile logProfile2 = new EasyScada.Core.LogProfile();
            this.easyDriverConnector1 = new EasyScada.Winforms.Controls.EasyDriverConnector(this.components);
            this.easyDataLogger1 = new EasyScada.Winforms.Controls.EasyDataLogger(this.components);
            this.easyAlarmLogger1 = new EasyScada.Winforms.Controls.EasyAlarmLogger(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.easyDriverConnector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyDataLogger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyAlarmLogger1)).BeginInit();
            this.SuspendLayout();
            // 
            // easyDriverConnector1
            // 
            this.easyDriverConnector1.CommunicationMode = EasyScada.Core.CommunicationMode.ReceiveFromServer;
            this.easyDriverConnector1.Port = ((ushort)(8800));
            this.easyDriverConnector1.RefreshRate = 1000;
            this.easyDriverConnector1.ServerAddress = "127.0.0.1";
            // 
            // easyDataLogger1
            // 
            this.easyDataLogger1.AllowLogWhenTagBad = true;
            logColumn1.ColumnName = "DongMayNghienTho1";
            logColumn1.DefaultValue = "0";
            logColumn1.Description = "DongMayNghienTho1";
            logColumn1.Enabled = true;
            logColumn1.Mode = EasyScada.Core.LogColumnMode.KeepValueWhenTagBad;
            logColumn1.TagPath = "RemoteStation1/PLCNghien_EpVien/MayNghienTho1/Current_Digital_MN";
            logColumn2.ColumnName = "DongMayNghienTho2";
            logColumn2.DefaultValue = "0";
            logColumn2.Description = "DongMayNghienTho2";
            logColumn2.Enabled = true;
            logColumn2.Mode = EasyScada.Core.LogColumnMode.KeepValueWhenTagBad;
            logColumn2.TagPath = "RemoteStation1/PLCNghien_EpVien/MayNghienTho2/Current_Digital_MN";
            logColumn3.ColumnName = "DongMayNghienTinh";
            logColumn3.DefaultValue = "0";
            logColumn3.Description = "DongMayNghienTinh";
            logColumn3.Enabled = true;
            logColumn3.Mode = EasyScada.Core.LogColumnMode.KeepValueWhenTagBad;
            logColumn3.TagPath = "RemoteStation1/PLCNghien_EpVien/MayNghienTinh1/Current_Digital_MN";
            logColumn4.ColumnName = "DongMayEpVien1";
            logColumn4.DefaultValue = "0";
            logColumn4.Description = "DongMayEpVien1";
            logColumn4.Enabled = true;
            logColumn4.Mode = EasyScada.Core.LogColumnMode.KeepValueWhenTagBad;
            logColumn4.TagPath = "RemoteStation1/PLCNghien_EpVien/MayEpVien1/Current_Digital_EV";
            logColumn5.ColumnName = "DongMayEpVien2";
            logColumn5.DefaultValue = "0";
            logColumn5.Description = "DongMayEpVien2";
            logColumn5.Enabled = true;
            logColumn5.Mode = EasyScada.Core.LogColumnMode.KeepValueWhenTagBad;
            logColumn5.TagPath = "RemoteStation1/PLCNghien_EpVien/MayEpVien2/Current_Digital_EV";
            this.easyDataLogger1.Columns.AddRange(new EasyScada.Core.LogColumn[] {
            logColumn1,
            logColumn2,
            logColumn3,
            logColumn4,
            logColumn5});
            logProfile1.DatabaseName = "easyScada";
            logProfile1.DatabaseType = EasyScada.Core.DbType.MySql;
            logProfile1.DataSourceName = null;
            logProfile1.Enabled = true;
            logProfile1.IpAddress = "127.0.0.1";
            logProfile1.Password = "100100";
            logProfile1.Port = ((ushort)(3306));
            logProfile1.TableName = "data1";
            logProfile1.Username = "root";
            this.easyDataLogger1.Databases.Add(logProfile1);
            this.easyDataLogger1.Enabled = true;
            this.easyDataLogger1.Interval = 60000;
            // 
            // easyAlarmLogger1
            // 
            logProfile2.DatabaseName = "easyScada";
            logProfile2.DatabaseType = EasyScada.Core.DbType.MySql;
            logProfile2.DataSourceName = null;
            logProfile2.Enabled = true;
            logProfile2.IpAddress = "127.0.0.1";
            logProfile2.Password = "100100";
            logProfile2.Port = ((ushort)(3306));
            logProfile2.TableName = "alarm1";
            logProfile2.Username = "root";
            this.easyAlarmLogger1.Databases.Add(logProfile2);
            this.easyAlarmLogger1.Enabled = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(688, 389);
            ((System.ComponentModel.ISupportInitialize)(this.easyDriverConnector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyDataLogger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyAlarmLogger1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EasyScada.Winforms.Controls.EasyDriverConnector easyDriverConnector1;
        private EasyScada.Winforms.Controls.EasyDataLogger easyDataLogger1;
        private EasyScada.Winforms.Controls.EasyAlarmLogger easyAlarmLogger1;
    }
}
