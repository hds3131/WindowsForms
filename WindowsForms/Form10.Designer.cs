﻿namespace WindowsForms
{
    partial class Form10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.upcomingEventsLabel = new System.Windows.Forms.Label();
            this.upcomingEventsList = new System.Windows.Forms.ListBox();
            this.quickActionsLabel = new System.Windows.Forms.Label();
            this.bookEventButton = new System.Windows.Forms.Button();
            this.cancelBookingButton = new System.Windows.Forms.Button();
            this.eventCalendar = new System.Windows.Forms.MonthCalendar();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // upcomingEventsLabel
            // 
            this.upcomingEventsLabel.AutoSize = true;
            this.upcomingEventsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.upcomingEventsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.upcomingEventsLabel.Location = new System.Drawing.Point(231, 109);
            this.upcomingEventsLabel.Name = "upcomingEventsLabel";
            this.upcomingEventsLabel.Size = new System.Drawing.Size(176, 24);
            this.upcomingEventsLabel.TabIndex = 3;
            this.upcomingEventsLabel.Text = "Upcoming Events";
            // 
            // upcomingEventsList
            // 
            this.upcomingEventsList.BackColor = System.Drawing.Color.Tomato;
            this.upcomingEventsList.Font = new System.Drawing.Font("Arial", 10F);
            this.upcomingEventsList.FormattingEnabled = true;
            this.upcomingEventsList.ItemHeight = 19;
            this.upcomingEventsList.Items.AddRange(new object[] {
            "Event 1 - 12th Dec 2024",
            "Event 2 - 15th Dec 2024",
            "Event 3 - 20th Dec 2024"});
            this.upcomingEventsList.Location = new System.Drawing.Point(235, 143);
            this.upcomingEventsList.Name = "upcomingEventsList";
            this.upcomingEventsList.Size = new System.Drawing.Size(487, 99);
            this.upcomingEventsList.TabIndex = 4;
            this.upcomingEventsList.SelectedIndexChanged += new System.EventHandler(this.upcomingEventsList_SelectedIndexChanged_1);
            // 
            // quickActionsLabel
            // 
            this.quickActionsLabel.AutoSize = true;
            this.quickActionsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.quickActionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.quickActionsLabel.Location = new System.Drawing.Point(231, 500);
            this.quickActionsLabel.Name = "quickActionsLabel";
            this.quickActionsLabel.Size = new System.Drawing.Size(141, 24);
            this.quickActionsLabel.TabIndex = 5;
            this.quickActionsLabel.Text = "Quick Actions";
            this.quickActionsLabel.Click += new System.EventHandler(this.quickActionsLabel_Click);
            // 
            // bookEventButton
            // 
            this.bookEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.bookEventButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bookEventButton.ForeColor = System.Drawing.Color.White;
            this.bookEventButton.Location = new System.Drawing.Point(235, 537);
            this.bookEventButton.Name = "bookEventButton";
            this.bookEventButton.Size = new System.Drawing.Size(120, 40);
            this.bookEventButton.TabIndex = 6;
            this.bookEventButton.Text = "Book Event";
            this.bookEventButton.UseVisualStyleBackColor = false;
            this.bookEventButton.Click += new System.EventHandler(this.BookEvent);
            // 
            // cancelBookingButton
            // 
            this.cancelBookingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.cancelBookingButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cancelBookingButton.ForeColor = System.Drawing.Color.White;
            this.cancelBookingButton.Location = new System.Drawing.Point(376, 542);
            this.cancelBookingButton.Name = "cancelBookingButton";
            this.cancelBookingButton.Size = new System.Drawing.Size(150, 30);
            this.cancelBookingButton.TabIndex = 7;
            this.cancelBookingButton.Text = "Cancel Booking";
            this.cancelBookingButton.UseVisualStyleBackColor = false;
            this.cancelBookingButton.Click += new System.EventHandler(this.CancelBooking);
            // 
            // eventCalendar
            // 
            this.eventCalendar.BackColor = System.Drawing.Color.Tomato;
            this.eventCalendar.Location = new System.Drawing.Point(235, 283);
            this.eventCalendar.MaxSelectionCount = 1;
            this.eventCalendar.Name = "eventCalendar";
            this.eventCalendar.TabIndex = 8;
            this.eventCalendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.eventCalendar.TitleForeColor = System.Drawing.Color.White;
            this.eventCalendar.TrailingForeColor = System.Drawing.Color.Gray;
            this.eventCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.eventCalendar_DateChanged);
            this.eventCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.ShowEventsOnDate);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Tomato;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(11, 99);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(169, 186);
            this.dataGridView2.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(231, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Event Calendar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Tomato;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(11, 22);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(169, 71);
            this.dataGridView3.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Tomato;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(185, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(545, 71);
            this.dataGridView1.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Tomato;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(314, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 25);
            this.button4.TabIndex = 53;
            this.button4.Text = "Events";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Tomato;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(422, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 25);
            this.button3.TabIndex = 52;
            this.button3.Text = "Community and Chats";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Tomato;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(199, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 51;
            this.button2.Text = "Dashboard";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Tomato;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(596, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(117, 25);
            this.button5.TabIndex = 54;
            this.button5.Text = "FeedBack";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Gainsboro;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(56, 237);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(80, 28);
            this.linkLabel1.TabIndex = 55;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Logout";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tomato;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(21, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 23);
            this.textBox1.TabIndex = 56;
            this.textBox1.Text = "Together Culture";
            // 
            // dataGridView5
            // 
            this.dataGridView5.BackgroundColor = System.Drawing.Color.Tomato;
            this.dataGridView5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(12, 291);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 51;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.Size = new System.Drawing.Size(169, 297);
            this.dataGridView5.TabIndex = 57;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Tomato;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(56, 422);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(81, 23);
            this.textBox6.TabIndex = 58;
            this.textBox6.Text = "Ads here";
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(742, 600);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.eventCalendar);
            this.Controls.Add(this.cancelBookingButton);
            this.Controls.Add(this.bookEventButton);
            this.Controls.Add(this.quickActionsLabel);
            this.Controls.Add(this.upcomingEventsList);
            this.Controls.Add(this.upcomingEventsLabel);
            this.Name = "Form10";
            this.Text = "Together Culture - Community Events";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label upcomingEventsLabel;
        private System.Windows.Forms.ListBox upcomingEventsList;
        private System.Windows.Forms.Label quickActionsLabel;
        private System.Windows.Forms.Button bookEventButton;
        private System.Windows.Forms.Button cancelBookingButton;
        private System.Windows.Forms.MonthCalendar eventCalendar;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.TextBox textBox6;
    }
}
