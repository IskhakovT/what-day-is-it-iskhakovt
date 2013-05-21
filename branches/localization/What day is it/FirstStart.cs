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

using System.Collections.Specialized;

namespace What_day_is_it
{
    public partial class FirstStart : Form
    {
        public FirstStart(Boolean firstTime = false)
        {
            InitializeComponent();

            SettingNotSaved = firstTime;

            if (!SettingNotSaved)
            {
                if (Data.Sex)
                {
                    boyRadioButton.Checked = true;
                }
                else
                {
                    girlRadioButton.Checked = true;
                }

                if (Data.ImportantDateExists)
                {
                    dateCheckBox.Checked = true;
                    dateTime.Enabled = true;
                    dateTime.Value = Data.ImportantDate;
                }

                if (Data.AnoterBirthdayExists)
                {
                    herCheckBox.Checked = true;
                    herTime.Enabled = true;
                    herTime.Value = Data.AnoterBirthday;
                }

                if (Data.YourBirthdayExists)
                {
                    myCheckBox.Checked = true;
                    myTime.Enabled = true;
                    myTime.Value = Data.YourBirthday;
                }
            }
            else
            {
                boyRadioButton.Checked = false;
                girlRadioButton.Checked = false;

                dateTime.Value = Core.Today;
                herTime.Value = Core.Today;
                myTime.Value = Core.Today;

                dateTime.MaxDate = Core.Today;
                herTime.MaxDate = Core.Today;
                myTime.MaxDate = Core.Today;
            }
        }

        private Boolean SettingNotSaved;

        private void dateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dateTime.Enabled = dateCheckBox.Checked;
        }

        private void herCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            herTime.Enabled = herCheckBox.Checked;
        }

        private void myCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            myTime.Enabled = myCheckBox.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (dateCheckBox.Checked)
            {
                if (herCheckBox.Checked)
                {
                    if ((dateTime.Value - herTime.Value).Days < 0)
                    {
                        MessageBox.Show(Vocabulary.partnerEarly(), Vocabulary.errorString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((dateTime.Value - herTime.Value).Days == 0)
                    {
                        MessageBox.Show(Vocabulary.partnerExactBirthday(), Vocabulary.errorString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (myCheckBox.Checked)
                {
                    if ((dateTime.Value - myTime.Value).Days < 0)
                    {
                        MessageBox.Show(Vocabulary.youEarly(), Vocabulary.errorString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((dateTime.Value - myTime.Value).Days == 0)
                    {
                        MessageBox.Show(Vocabulary.yourBirthday(), Vocabulary.errorString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            StringCollection toWrite = new StringCollection();

            if (boyRadioButton.Checked)
            {
                toWrite.Add(Data.BoyString);
            }

            if (girlRadioButton.Checked)
            {
                toWrite.Add(Data.GirtString);
            }

            if (!(boyRadioButton.Checked ^ girlRadioButton.Checked))
            {
                throw new Exception("RadioButton works incorrect");
            }

            if (dateCheckBox.Checked)
            {
                toWrite.Add(Data.TrueString);

                DateTime Date = dateTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Data.FalseString);
            }

            if (herCheckBox.Checked)
            {
                toWrite.Add(Data.TrueString);

                DateTime Date = herTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Data.FalseString);
            }

            if (myCheckBox.Checked)
            {
                toWrite.Add(Data.TrueString);

                DateTime Date = myTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Data.FalseString);
            }

            Log.SaveButton();

            Data.saveData(toWrite);

            SettingNotSaved = false;

            Close();
        }

        private void boyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            herCheckBox.Text = Vocabulary.rememberGirl();

            dateCheckBox.Enabled = true;
            herCheckBox.Enabled = true;
            myCheckBox.Enabled = true;

            saveButton.Enabled = true;
        }

        private void girlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            herCheckBox.Text = Vocabulary.rememberBoy();

            dateCheckBox.Enabled = true;
            herCheckBox.Enabled = true;
            myCheckBox.Enabled = true;

            saveButton.Enabled = true;
        }

        private void FirstStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingNotSaved)
            {
                Application.Exit();
            }
            else
            {
                Windows.settingsClosed();
            }
        }
    }
}
