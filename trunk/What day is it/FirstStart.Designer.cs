/*************************************************
 *                                               *
 *     What day is it?                           *
 *                                               *
 *     Author: Timur Iskhakov                    *
 *     E-mail: iskhakovt@gmail.com               *
 *                                               *
 *************************************************/



namespace What_day_is_it
{
    partial class FirstStart
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstStart));
            this.mainLabel = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.herTime = new System.Windows.Forms.DateTimePicker();
            this.myTime = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.dateCheckBox = new System.Windows.Forms.CheckBox();
            this.herCheckBox = new System.Windows.Forms.CheckBox();
            this.myCheckBox = new System.Windows.Forms.CheckBox();
            this.boyRadioButton = new System.Windows.Forms.RadioButton();
            this.girlRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainLabel.Location = new System.Drawing.Point(108, 15);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(466, 33);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "Вы можете настроить программу";
            // 
            // dateTime
            // 
            this.dateTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTime.Enabled = false;
            this.dateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTime.Location = new System.Drawing.Point(449, 136);
            this.dateTime.MaxDate = new System.DateTime(2199, 12, 31, 0, 0, 0, 0);
            this.dateTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(200, 26);
            this.dateTime.TabIndex = 5;
            // 
            // herTime
            // 
            this.herTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.herTime.Enabled = false;
            this.herTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.herTime.Location = new System.Drawing.Point(449, 192);
            this.herTime.MaxDate = new System.DateTime(2199, 12, 31, 0, 0, 0, 0);
            this.herTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.herTime.Name = "herTime";
            this.herTime.Size = new System.Drawing.Size(200, 26);
            this.herTime.TabIndex = 6;
            // 
            // myTime
            // 
            this.myTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myTime.Enabled = false;
            this.myTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myTime.Location = new System.Drawing.Point(449, 248);
            this.myTime.MaxDate = new System.DateTime(2199, 12, 31, 0, 0, 0, 0);
            this.myTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.myTime.Name = "myTime";
            this.myTime.Size = new System.Drawing.Size(200, 26);
            this.myTime.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(276, 308);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(129, 38);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dateCheckBox
            // 
            this.dateCheckBox.AutoSize = true;
            this.dateCheckBox.Enabled = false;
            this.dateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateCheckBox.Location = new System.Drawing.Point(31, 136);
            this.dateCheckBox.Name = "dateCheckBox";
            this.dateCheckBox.Size = new System.Drawing.Size(332, 24);
            this.dateCheckBox.TabIndex = 8;
            this.dateCheckBox.Text = "Я помню, когда мы начали встречаться";
            this.dateCheckBox.UseVisualStyleBackColor = true;
            this.dateCheckBox.CheckedChanged += new System.EventHandler(this.dateCheckBox_CheckedChanged);
            // 
            // herCheckBox
            // 
            this.herCheckBox.AutoSize = true;
            this.herCheckBox.Enabled = false;
            this.herCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.herCheckBox.Location = new System.Drawing.Point(31, 192);
            this.herCheckBox.Name = "herCheckBox";
            this.herCheckBox.Size = new System.Drawing.Size(406, 24);
            this.herCheckBox.TabIndex = 9;
            this.herCheckBox.Text = "Я помню, когда у моей половинки день рождения";
            this.herCheckBox.UseVisualStyleBackColor = true;
            this.herCheckBox.CheckedChanged += new System.EventHandler(this.herCheckBox_CheckedChanged);
            // 
            // myCheckBox
            // 
            this.myCheckBox.AutoSize = true;
            this.myCheckBox.Enabled = false;
            this.myCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myCheckBox.Location = new System.Drawing.Point(31, 248);
            this.myCheckBox.Name = "myCheckBox";
            this.myCheckBox.Size = new System.Drawing.Size(321, 24);
            this.myCheckBox.TabIndex = 10;
            this.myCheckBox.Text = "Я помню, когда у меня день рождения";
            this.myCheckBox.UseVisualStyleBackColor = true;
            this.myCheckBox.CheckedChanged += new System.EventHandler(this.myCheckBox_CheckedChanged);
            // 
            // boyRadioButton
            // 
            this.boyRadioButton.AutoSize = true;
            this.boyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boyRadioButton.Location = new System.Drawing.Point(130, 76);
            this.boyRadioButton.Name = "boyRadioButton";
            this.boyRadioButton.Size = new System.Drawing.Size(97, 24);
            this.boyRadioButton.TabIndex = 12;
            this.boyRadioButton.TabStop = true;
            this.boyRadioButton.Text = "Я парень";
            this.boyRadioButton.UseVisualStyleBackColor = true;
            this.boyRadioButton.CheckedChanged += new System.EventHandler(this.boyRadioButton_CheckedChanged);
            // 
            // girlRadioButton
            // 
            this.girlRadioButton.AutoSize = true;
            this.girlRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.girlRadioButton.Location = new System.Drawing.Point(449, 76);
            this.girlRadioButton.Name = "girlRadioButton";
            this.girlRadioButton.Size = new System.Drawing.Size(109, 24);
            this.girlRadioButton.TabIndex = 13;
            this.girlRadioButton.TabStop = true;
            this.girlRadioButton.Text = "Я девушка";
            this.girlRadioButton.UseVisualStyleBackColor = true;
            this.girlRadioButton.CheckedChanged += new System.EventHandler(this.girlRadioButton_CheckedChanged);
            // 
            // FirstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 357);
            this.Controls.Add(this.girlRadioButton);
            this.Controls.Add(this.boyRadioButton);
            this.Controls.Add(this.myCheckBox);
            this.Controls.Add(this.herCheckBox);
            this.Controls.Add(this.dateCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.myTime);
            this.Controls.Add(this.herTime);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.mainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FirstStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FirstStart_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.DateTimePicker herTime;
        private System.Windows.Forms.DateTimePicker myTime;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox dateCheckBox;
        private System.Windows.Forms.CheckBox herCheckBox;
        private System.Windows.Forms.CheckBox myCheckBox;
        private System.Windows.Forms.RadioButton boyRadioButton;
        private System.Windows.Forms.RadioButton girlRadioButton;
    }
}