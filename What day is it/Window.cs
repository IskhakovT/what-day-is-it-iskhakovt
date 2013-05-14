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

            Core.setToday();

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            timer.Start();

            dateTimePicker.Value = Core.Today;

            updateContexText();
            updateData();
        }

        public void updateData()
        {
            Core.setToday();

            todayLabel.Text = Vocabulary.today() + Core.Today.ToLongDateString();
            todayInfo.Text = DateInfo.getInformation(Core.Today);

            if (Data.ShowNotifications && todayInfo.Text != String.Empty)
            {
                showBalloonList.Add(new ToShow(Core.Today.ToLongDateString(), todayInfo.Text));
            }

            getCloseInfo();
            changeAnyDay();

            if (showBalloonList.Count > 0)
            {
                showFirstBalloon();
            }
        }

        private void updateContexText()
        {
            contextMenuStrip.Items[contextNotificationItem].Text = Vocabulary.contextNotifications(Data.ShowNotifications);
            contextMenuStrip.Items[contextStartUpItem].Text = Vocabulary.contextStartUp(Data.StartUpEnabled);
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
            DateTime find = Core.Today;
            Push push = Push.One;

            while (push != Push.Done && (find - Core.Today).Days < 15)
            {
                find = find.AddDays(1);

                String add = DateInfo.getCloseInformation(find);

                if (add != String.Empty)
                {
                    if (Data.ShowNotifications)
                    {
                        showBalloonList.Add(new ToShow(Vocabulary.soon() + find.ToLongDateString(), add));
                    }

                    add = find.ToLongDateString() + Environment.NewLine + add;
                    addLabel(push, add);

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

        private void addLabel(Push push, String info)
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
            if (dateTimePicker.Value == Core.Today)
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
                Log.ApplicationClosed();

                Visible = false;
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        public void showForm()
        {
            if (!settingsOpened)
            {
                Log.ApplicationOpened();

                Visible = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            showForm();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Log.SettingsOpened();
            Log.ApplicationClosed();

            Visible = false;

            showBalloonList.Clear();

            FirstStart newSettings = new FirstStart();
            newSettings.Visible = true;

            settingsOpened = true;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.ApplicationExit();

            saveClosingForm = false;
            Close();
        }

        private static Boolean saveClosingForm = true;

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Today != Core.Today)
            {
                updateData();
            }
        }

        private Boolean _SettingsOpened = false;

        public Boolean settingsOpened
        {
            get { return _SettingsOpened; }
            set { _SettingsOpened = value; }
        }

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
            Data.invertNotifications();

            updateContexText();
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.invertStartUp();

            updateContexText();
        }
    }
}
