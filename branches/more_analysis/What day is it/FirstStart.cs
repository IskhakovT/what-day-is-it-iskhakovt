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
using System.Collections.Specialized;

namespace What_day_is_it
{
    public partial class FirstStart : Form
    {
        public FirstStart()
        {
            InitializeComponent();

            if (!Default.FirstStart)
            {
                if (Default.Sex)
                {
                    boyRadioButton.Checked = true;
                }
                else
                {
                    girlRadioButton.Checked = true;
                }

                if (Default.ImportantDateExists)
                {
                    dateCheckBox.Checked = true;
                    dateTime.Enabled = true;
                    dateTime.Value = Default.ImportantDate;
                }

                if (Default.AnoterBirthdayExists)
                {
                    herCheckBox.Checked = true;
                    herTime.Enabled = true;
                    herTime.Value = Default.AnoterBirthday;
                }

                if (Default.YourBirthdayExists)
                {
                    myCheckBox.Checked = true;
                    myTime.Enabled = true;
                    myTime.Value = Default.YourBirthday;
                }
            }
            else
            {
                boyRadioButton.Checked = false;
                girlRadioButton.Checked = false;

                dateTime.Value = Default.Today;
                herTime.Value = Default.Today;
                myTime.Value = Default.Today;

                dateTime.MaxDate = Default.Today;
                herTime.MaxDate = Default.Today;
                myTime.MaxDate = Default.Today;
            }
        }

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
                toWrite.Add(Default.BoyString);
            }

            if (girlRadioButton.Checked)
            {
                toWrite.Add(Default.GirtString);
            }

            if (!(boyRadioButton.Checked ^ girlRadioButton.Checked))
            {
                throw new Exception("RadioButton works incorrect");
            }

            if (dateCheckBox.Checked)
            {
                toWrite.Add(Default.TrueString);

                DateTime Date = dateTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Default.FalseString);
            }

            if (herCheckBox.Checked)
            {
                toWrite.Add(Default.TrueString);

                DateTime Date = herTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Default.FalseString);
            }

            if (myCheckBox.Checked)
            {
                toWrite.Add(Default.TrueString);

                DateTime Date = myTime.Value;
                toWrite.Add(Date.Year.ToString());
                toWrite.Add(Date.Month.ToString());
                toWrite.Add(Date.Day.ToString());
            }
            else
            {
                toWrite.Add(Default.FalseString);
            }

            Log.SaveButton();
            Default.WriteSettings(toWrite);

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
            if (Default.FirstStart)
            {
                Application.Exit();
            }
            else
            {
                Program.ShowMainWindow();
            }
        }
    }
}
