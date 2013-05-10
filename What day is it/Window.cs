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

            if (!Default.FirstStart)
            {
                newDay();
            }
        }

        private enum Push { One, Two, Three, Done };

        private void getCloseInfo()
        {
            DateTime find = Default.Today;
            Push push = Push.One;

            while (push != Push.Done && (find - Default.Today).Days < 15)
            {
                find = find.AddDays(1);

                String add = getCloseDayInfo(find);

                if (add != String.Empty)
                {
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

        private String getCloseDayInfo(DateTime Date)
        {
            String result = String.Empty;

            if (Default.ImportantDateExists)
            {
                if (Date.Day == Default.ImportantDate.Day)
                {
                    Int32 yearDiff = Date.Year - Default.ImportantDate.Year;

                    if (Date.Month == Default.ImportantDate.Month)
                    {
                        result += Vocabulary.exactYears(yearDiff);
                    }
                    else
                    {
                        Int32 monthDiff = (Date.Month - Default.ImportantDate.Month) + yearDiff * 12;
                        result += Vocabulary.exactMonth(monthDiff);
                    }
                }

                DateInfo.Warning info = DateInfo.analizeNum(DateInfo.Diff(Default.ImportantDate, Date));

                if (info != DateInfo.Warning.None)
                {
                    result += Vocabulary.countDateTime(DateInfo.Diff(Default.ImportantDate, Date));
                    result += Vocabulary.Analize(info);
                }
            }

            if (Default.AnoterBirthdayExists && DateInfo.Diff(Date, Default.AnoterBirthday) >= 0)
            {
                DateTime toBirthday = Default.AnoterBirthday;

                while (toBirthday.Year != Date.Year)
                {
                    toBirthday = toBirthday.AddYears(1);
                }

                Int32 diff = DateInfo.Diff(Date, toBirthday);

                if (diff == 0)
                {
                    result += Vocabulary.Birthday();
                }
            }

            Holidays.HolidayEvent Holyday = Holidays.analizeHolyday(Date);

            if (Holyday.Holyday != Holidays.HolidayType.None && Holyday.Today)
            {
                result += Vocabulary.HolydayText(Holyday);
            }

            if (Default.YourBirthdayExists && DateInfo.Diff(Date, Default.YourBirthday) >= 0)
            {
                DateTime toBirthday = Default.YourBirthday;

                while (toBirthday.Year != Date.Year)
                {
                    toBirthday = toBirthday.AddYears(1);
                }

                Int32 diff = DateInfo.Diff(Date, toBirthday);

                if (diff == 0)
                {
                    result += Vocabulary.yourBirthday();
                }
            }

            return result;
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

            getCloseInfo();
            changeAnyDay();

            notifyIcon.ShowBalloonTip(1000, Default.Today.ToLongDateString(), todayInfo.Text, ToolTipIcon.Info);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Today != Default.Today)
            {
                newDay();
            }
        }

        public Boolean settingsOpened = false;
    }
}
