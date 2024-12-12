namespace WindowsForms
{
    partial class AddNewEvent
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEventName = new System.Windows.Forms.TextBox();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.comboBoxEventType = new System.Windows.Forms.ComboBox();
            this.textBoxGuestCount = new System.Windows.Forms.TextBox();
            this.textBoxParticipants = new System.Windows.Forms.TextBox();
            this.textBoxEventDetails = new System.Windows.Forms.TextBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.labelEventName = new System.Windows.Forms.Label();
            this.labelEventDate = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelEventType = new System.Windows.Forms.Label();
            this.labelGuestCount = new System.Windows.Forms.Label();
            this.labelParticipants = new System.Windows.Forms.Label();
            this.labelEventDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEventName
            // 
            this.textBoxEventName.Location = new System.Drawing.Point(30, 32);
            this.textBoxEventName.Name = "textBoxEventName";
            this.textBoxEventName.Size = new System.Drawing.Size(250, 20);
            this.textBoxEventName.TabIndex = 0;
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(381, 29);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(250, 20);
            this.dateTimePickerEventDate.TabIndex = 1;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(33, 87);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(250, 20);
            this.textBoxLocation.TabIndex = 2;
            // 
            // comboBoxEventType
            // 
            this.comboBoxEventType.FormattingEnabled = true;
            this.comboBoxEventType.Items.AddRange(new object[] {
            "Conference",
            "Workshop",
            "Seminar",
            "Meeting"});
            this.comboBoxEventType.Location = new System.Drawing.Point(381, 86);
            this.comboBoxEventType.Name = "comboBoxEventType";
            this.comboBoxEventType.Size = new System.Drawing.Size(250, 21);
            this.comboBoxEventType.TabIndex = 3;
            // 
            // textBoxGuestCount
            // 
            this.textBoxGuestCount.Location = new System.Drawing.Point(33, 156);
            this.textBoxGuestCount.Name = "textBoxGuestCount";
            this.textBoxGuestCount.Size = new System.Drawing.Size(247, 20);
            this.textBoxGuestCount.TabIndex = 4;
            this.textBoxGuestCount.TextChanged += new System.EventHandler(this.textBoxGuestCount_TextChanged);
            // 
            // textBoxParticipants
            // 
            this.textBoxParticipants.Location = new System.Drawing.Point(33, 221);
            this.textBoxParticipants.Name = "textBoxParticipants";
            this.textBoxParticipants.Size = new System.Drawing.Size(250, 20);
            this.textBoxParticipants.TabIndex = 5;
            this.textBoxParticipants.TextChanged += new System.EventHandler(this.textBoxParticipants_TextChanged);
            // 
            // textBoxEventDetails
            // 
            this.textBoxEventDetails.Location = new System.Drawing.Point(381, 156);
            this.textBoxEventDetails.Multiline = true;
            this.textBoxEventDetails.Name = "textBoxEventDetails";
            this.textBoxEventDetails.Size = new System.Drawing.Size(250, 85);
            this.textBoxEventDetails.TabIndex = 7;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(214, 321);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(250, 30);
            this.buttonAddEvent.TabIndex = 8;
            this.buttonAddEvent.Text = "Add New Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(30, 12);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(73, 13);
            this.labelEventName.TabIndex = 9;
            this.labelEventName.Text = "Event Name *";
            // 
            // labelEventDate
            // 
            this.labelEventDate.AutoSize = true;
            this.labelEventDate.Location = new System.Drawing.Point(381, 9);
            this.labelEventDate.Name = "labelEventDate";
            this.labelEventDate.Size = new System.Drawing.Size(68, 13);
            this.labelEventDate.TabIndex = 10;
            this.labelEventDate.Text = "Event Date *";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(33, 67);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(55, 13);
            this.labelLocation.TabIndex = 11;
            this.labelLocation.Text = "Location *";
            // 
            // labelEventType
            // 
            this.labelEventType.AutoSize = true;
            this.labelEventType.Location = new System.Drawing.Point(381, 66);
            this.labelEventType.Name = "labelEventType";
            this.labelEventType.Size = new System.Drawing.Size(69, 13);
            this.labelEventType.TabIndex = 12;
            this.labelEventType.Text = "Event Type *";
            // 
            // labelGuestCount
            // 
            this.labelGuestCount.AutoSize = true;
            this.labelGuestCount.Location = new System.Drawing.Point(33, 136);
            this.labelGuestCount.Name = "labelGuestCount";
            this.labelGuestCount.Size = new System.Drawing.Size(73, 13);
            this.labelGuestCount.TabIndex = 13;
            this.labelGuestCount.Text = "Guest Count *";
            this.labelGuestCount.Click += new System.EventHandler(this.labelGuestCount_Click);
            // 
            // labelParticipants
            // 
            this.labelParticipants.AutoSize = true;
            this.labelParticipants.Location = new System.Drawing.Point(33, 201);
            this.labelParticipants.Name = "labelParticipants";
            this.labelParticipants.Size = new System.Drawing.Size(69, 13);
            this.labelParticipants.TabIndex = 14;
            this.labelParticipants.Text = "Participants *";
            this.labelParticipants.Click += new System.EventHandler(this.labelParticipants_Click);
            // 
            // labelEventDetails
            // 
            this.labelEventDetails.AutoSize = true;
            this.labelEventDetails.Location = new System.Drawing.Point(381, 136);
            this.labelEventDetails.Name = "labelEventDetails";
            this.labelEventDetails.Size = new System.Drawing.Size(77, 13);
            this.labelEventDetails.TabIndex = 16;
            this.labelEventDetails.Text = "Event Details *";
            // 
            // AddNewEvent
            // 
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(671, 386);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.labelEventDetails);
            this.Controls.Add(this.textBoxEventDetails);
            this.Controls.Add(this.labelParticipants);
            this.Controls.Add(this.textBoxParticipants);
            this.Controls.Add(this.labelGuestCount);
            this.Controls.Add(this.textBoxGuestCount);
            this.Controls.Add(this.labelEventType);
            this.Controls.Add(this.comboBoxEventType);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.labelEventDate);
            this.Controls.Add(this.dateTimePickerEventDate);
            this.Controls.Add(this.labelEventName);
            this.Controls.Add(this.textBoxEventName);
            this.Name = "AddNewEvent";
            this.Text = "Add New Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEventName;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.ComboBox comboBoxEventType;
        private System.Windows.Forms.TextBox textBoxGuestCount;
        private System.Windows.Forms.TextBox textBoxParticipants;
        private System.Windows.Forms.TextBox textBoxEventDetails;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.Label labelEventDate;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Label labelEventType;
        private System.Windows.Forms.Label labelGuestCount;
        private System.Windows.Forms.Label labelParticipants;
        private System.Windows.Forms.Label labelEventDetails;
    }
}
