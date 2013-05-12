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
using System.Windows.Forms;
using System.Threading.Tasks;

namespace What_day_is_it
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            timer.Start();

            dateTimePicker.Value = Default.Today;

            UpdateContexText();

            if (!Default.FirstStart)
            {
                newDay();

                if (showBalloonList.Count > 0)
                {
                    showFirstBalloon();
                }
            }
        }

        private void UpdateContexText()
        {
            contextMenuStrip.Items[contextNotificationItem].Text = Vocabulary.contextNotifications(Default.ShowNotifications);
            contextMenuStrip.Items[contextStartUpItem].Text = Vocabulary.contextStartUp(Default.StartUpEnabled);
        }

        private class ToShow
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

        private enum Push { One, Two, Three, Done };

        private void getCloseInfo()
        {
            DateTime find = Default.Today;
            Push push = Push.One;

            while (push != Push.Done && (find - Default.Today).Days < 15)
            {
                find = find.AddDays(1);

                String add = DateInfo.getCloseInformation(find);

                if (add != String.Empty)
                {
                    if (Default.ShowNotifications)
                    {
                        showBalloonList.Add(new ToShow(Vocabulary.Soon() + find.ToLongDateString(), add));
                    }

                    add = find.ToLongDateString() + Environment.NewLine + add;
                    AddLabel(push, add);

                    if (push == Push.One)
                    {
                        push = Push.Two;
                    }
                    else if (push == Push.Two)
                    {
                        push = Push.Three;
                    }
                    else if (push == Push.Three)
                    {
                        push = Push.Done;
                    }
                }
            }

            if (push == Push.One)
            {
                label1.Text = Vocabulary.noAtAll();
                label2.Text = String.Empty;
                label3.Text = String.Empty;
            }
            else if (push == Push.Two)
            {
                label2.Text = Vocabulary.noMore();
                label3.Text = String.Empty;
            }
            else if (push == Push.Three)
            {
                label3.Text = Vocabulary.noMore();
            }
        }

        private void AddLabel(Push push, String info)
        {
            switch (push)
            {
                case Push.One:
                    label1.Text = info;
                    break;
                case Push.Two:
                    label2.Text = info;
                    break;
                case Push.Three:
                    label3.Text = info;
                    break;
            }
        }

        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            changeAnyDay();
        }

        private void changeAnyDay()
        {
            if (dateTimePicker.Value == Default.Today)
            {
                anyDayInfo.Text = String.Empty;
            }
            else
            {
                anyDayInfo.Text = DateInfo.getInformation(dateTimePicker.Value);
            }
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveClosingForm)
            {
                Visible = false;
                e.Cancel = true;
            }
        }

        public void show()
        {
            if (!settingsOpened)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Log.ApplicationOpened();
            show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Log.ApplicationOpened();
            show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Log.SettingsOpened();
            Log.ApplicationClosed();

            Visible = false;

            FirstStart newSettings = new FirstStart();
            newSettings.Visible = true;

            settingsOpened = true;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ApplicationClosed();

            saveClosingForm = false;
            Close();
        }

        private static Boolean saveClosingForm = true;

        public void newDay()
        {
            Default.Today = DateTime.Today;
            Default.checkDate();

            todayLabel.Text = Vocabulary.Today() + Default.Today.ToLongDateString();
            todayInfo.Text = DateInfo.getInformation(Default.Today);

            if (Default.ShowNotifications && todayInfo.Text != String.Empty)
            {
                showBalloonList.Add(new ToShow(Default.Today.ToLongDateString(), todayInfo.Text));
            }

            getCloseInfo();
            changeAnyDay();

            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Today != Default.Today)
            {
                newDay();
            }
        }

        public Boolean settingsOpened = false;

        private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            if (showBalloonList.Count > 0)
            {
                showFirstBalloon();
            }
        }

        private void showFirstBalloon()
        {
            if (showBalloonList.Count == 0)
            {
                throw new Exception("There is no balloon to show");
            }

            notifyIcon.ShowBalloonTip(timeShowBalloon, showBalloonList[0].Label, showBalloonList[0].Message, ToolTipIcon.Info);
            showBalloonList.RemoveAt(0);
        }

        private Int32 contextNotificationItem = 3;
        private Int32 contextStartUpItem = 4;

        private Int32 timeShowBalloon = 750;

        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Default.ShowNotifications = !Default.ShowNotifications;
            Default.SaveSettings();

            UpdateContexText();
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Default.StartUpEnabled = !Default.StartUpEnabled;
            Default.SaveSettings();

            UpdateContexText();
        }
    }
}
