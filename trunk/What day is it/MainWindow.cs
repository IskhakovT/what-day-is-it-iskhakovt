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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Core.setToday();
            dateTimePicker.Value = Core.Today;
        }

        #region Data

        public void updateData()
        {
            Core.setToday();

            todayLabel.Text = Vocabulary.today() + Core.Today.ToLongDateString();
            todayInfo.Text = DateInfo.getInformation(Core.Today);

            if (Data.ShowNotifications && todayInfo.Text != String.Empty)
            {
                Program.ApplicationWindow.addBalloon(Core.Today.ToLongDateString(), todayInfo.Text);
            }

            getCloseInfo();
            changeAnyDay();

            Program.ApplicationWindow.showBalloon();
        }

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
                        Program.ApplicationWindow.addBalloon(Vocabulary.soon() + find.ToLongDateString(), add);
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

        #endregion

        #region Date - addition

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

        #endregion

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.ApplicationClosed();

            Visible = false;
            e.Cancel = true;
        }
    }
}
