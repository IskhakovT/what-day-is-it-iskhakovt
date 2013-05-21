/*************************************************
 *                                               *
 *     What day is it?                           *
 *                                               *
 *     Author: Timur Iskhakov                    *
 *     E-mail: iskhakovt@gmail.com               *
 *                                               *
 *************************************************/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace What_day_is_it
{
    public partial class CoreWindow : Form
    {
        public enum StartParameter { Normal, InTray, FirstStart };
        public enum SettingsParametr { First, FromTray };

        public CoreWindow()
        {
            InitializeComponent();
            this.Visible = false;

            notifyIcon.ContextMenuStrip = contextMenuStrip;
            updateContexText();
        }

        public void Start(StartParameter Start = StartParameter.Normal)
        {
            switch (Start)
            {
                case StartParameter.Normal:
                    Windows.showMainWindow();
                    break;
                case StartParameter.InTray:
                    Windows.LogInTray();
                    break;
                case StartParameter.FirstStart:
                    Windows.showSettings(SettingsParametr.First);
                    break;
            }
        }  

        #region Balloon

        public class ToShow
        {
            private String _Label;
            private String _Message;

            public ToShow(String Label, String Message)
            {
                _Label = Label;
                _Message = Message;
            }

            public String Label
            {
                get { return _Label; }
            }

            public String Message
            {
                get { return _Message; }
            }
        }

        private List<ToShow> showBalloonList = new List<ToShow>();

        public void addBalloon(String Label, String Text)
        {
            showBalloonList.Add(new ToShow(Label, Text));
        }

        private void updateContexText()
        {
            contextMenuStrip.Items[contextNotificationItem].Text = Vocabulary.contextNotifications(Data.ShowNotifications);
            contextMenuStrip.Items[contextStartUpItem].Text = Vocabulary.contextStartUp(Data.StartUpEnabled);
        }

        public void showBalloon()
        {
            if (showBalloonList.Count > 0)
            {
                notifyIcon.ShowBalloonTip(timeShowBalloon, showBalloonList[0].Label, showBalloonList[0].Message, ToolTipIcon.Info);
                showBalloonList.RemoveAt(0);
            }
        }

        public void deleteBalloonInfo()
        {
            showBalloonList.Clear();
        }

        private Int32 contextNotificationItem = 3;
        private Int32 contextStartUpItem = 4;

        private Int32 timeShowBalloon = 750;

        private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            showBalloon();
        }

        #endregion

        #region MenuStrip

        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.invertNotifications();

            updateContexText();
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.invertStartUp();

            updateContexText();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Windows.showMainWindow();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Windows.showMainWindow();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Log.ApplicationClosed();

            deleteBalloonInfo();

            Windows.showSettings(SettingsParametr.FromTray);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ApplicationExit();

            Close();
        }

        #endregion

        private void CoreWindow_VisibleChanged(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
