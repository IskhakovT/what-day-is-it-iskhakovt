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
    partial class Window
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.label = new System.Windows.Forms.Label();
            this.todayGroupBox = new System.Windows.Forms.GroupBox();
            this.todayInfo = new System.Windows.Forms.Label();
            this.todayLabel = new System.Windows.Forms.Label();
            this.anyDayGroupBox = new System.Windows.Forms.GroupBox();
            this.anyDayInfo = new System.Windows.Forms.Label();
            this.anyDayLabel = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.todayGroupBox.SuspendLayout();
            this.anyDayGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(247, 15);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(356, 39);
            this.label.TabIndex = 0;
            this.label.Text = "Какой сегодня день?";
            // 
            // todayGroupBox
            // 
            this.todayGroupBox.Controls.Add(this.todayInfo);
            this.todayGroupBox.Controls.Add(this.todayLabel);
            this.todayGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.todayGroupBox.Location = new System.Drawing.Point(12, 70);
            this.todayGroupBox.Name = "todayGroupBox";
            this.todayGroupBox.Size = new System.Drawing.Size(400, 260);
            this.todayGroupBox.TabIndex = 2;
            this.todayGroupBox.TabStop = false;
            this.todayGroupBox.Text = "Сегодня";
            // 
            // todayInfo
            // 
            this.todayInfo.AutoSize = true;
            this.todayInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.todayInfo.Location = new System.Drawing.Point(10, 60);
            this.todayInfo.Name = "todayInfo";
            this.todayInfo.Size = new System.Drawing.Size(43, 17);
            this.todayInfo.TabIndex = 1;
            this.todayInfo.Text = "today";
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.todayLabel.Location = new System.Drawing.Point(7, 26);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(180, 18);
            this.todayLabel.TabIndex = 0;
            this.todayLabel.Text = "Между прочим, сегодня ";
            // 
            // anyDayGroupBox
            // 
            this.anyDayGroupBox.Controls.Add(this.anyDayInfo);
            this.anyDayGroupBox.Controls.Add(this.anyDayLabel);
            this.anyDayGroupBox.Controls.Add(this.dateTimePicker);
            this.anyDayGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.anyDayGroupBox.Location = new System.Drawing.Point(420, 70);
            this.anyDayGroupBox.Name = "anyDayGroupBox";
            this.anyDayGroupBox.Size = new System.Drawing.Size(400, 260);
            this.anyDayGroupBox.TabIndex = 3;
            this.anyDayGroupBox.TabStop = false;
            this.anyDayGroupBox.Text = "Машина времени";
            // 
            // anyDayInfo
            // 
            this.anyDayInfo.AutoSize = true;
            this.anyDayInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.anyDayInfo.Location = new System.Drawing.Point(7, 60);
            this.anyDayInfo.Name = "anyDayInfo";
            this.anyDayInfo.Size = new System.Drawing.Size(31, 17);
            this.anyDayInfo.TabIndex = 6;
            this.anyDayInfo.Text = "any";
            // 
            // anyDayLabel
            // 
            this.anyDayLabel.AutoSize = true;
            this.anyDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.anyDayLabel.Location = new System.Drawing.Point(7, 30);
            this.anyDayLabel.Name = "anyDayLabel";
            this.anyDayLabel.Size = new System.Drawing.Size(67, 18);
            this.anyDayLabel.TabIndex = 5;
            this.anyDayLabel.Text = "Сегодня";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(87, 26);
            this.dateTimePicker.MaxDate = new System.DateTime(2199, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.CloseUp += new System.EventHandler(this.dateTimePicker_CloseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 190);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ближайшие события";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(537, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(272, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Какой сегодня день";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClosed += new System.EventHandler(this.notifyIcon_BalloonTipClosed);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.notificationToolStripMenuItem,
            this.startupToolStripMenuItem,
            this.toolStripSeparator1,
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 148);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem2.Text = "Открыть программу";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "Настройки";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть программу";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.notificationToolStripMenuItem.Text = "notification";
            this.notificationToolStripMenuItem.Click += new System.EventHandler(this.notificationToolStripMenuItem_Click);
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startupToolStripMenuItem.Text = "startup";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.startupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.anyDayGroupBox);
            this.Controls.Add(this.todayGroupBox);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Какой сегодня день?";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.todayGroupBox.ResumeLayout(false);
            this.todayGroupBox.PerformLayout();
            this.anyDayGroupBox.ResumeLayout(false);
            this.anyDayGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox todayGroupBox;
        private System.Windows.Forms.Label todayLabel;
        private System.Windows.Forms.GroupBox anyDayGroupBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label anyDayLabel;
        private System.Windows.Forms.Label todayInfo;
        private System.Windows.Forms.Label anyDayInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}