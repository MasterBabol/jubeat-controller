namespace Jubeat_Controller_Receiver
{
	partial class MainForm
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
			this.textPortName = new System.Windows.Forms.TextBox();
			this.labelPortName = new System.Windows.Forms.Label();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.labelBaudRate = new System.Windows.Forms.Label();
			this.textBaudRate = new System.Windows.Forms.TextBox();
			this.buttonDisconnect = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.labelRead = new System.Windows.Forms.Label();
			this.buttonRequest = new System.Windows.Forms.Button();
			this.checkAutorequest = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// textPortName
			// 
			this.textPortName.Location = new System.Drawing.Point(85, 12);
			this.textPortName.Name = "textPortName";
			this.textPortName.Size = new System.Drawing.Size(143, 21);
			this.textPortName.TabIndex = 1;
			this.textPortName.Text = "COM";
			// 
			// labelPortName
			// 
			this.labelPortName.AutoSize = true;
			this.labelPortName.Location = new System.Drawing.Point(12, 15);
			this.labelPortName.Name = "labelPortName";
			this.labelPortName.Size = new System.Drawing.Size(69, 12);
			this.labelPortName.TabIndex = 1;
			this.labelPortName.Text = "Port Name:";
			// 
			// buttonConnect
			// 
			this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonConnect.Location = new System.Drawing.Point(236, 12);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(94, 21);
			this.buttonConnect.TabIndex = 3;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// labelBaudRate
			// 
			this.labelBaudRate.AutoSize = true;
			this.labelBaudRate.Location = new System.Drawing.Point(12, 42);
			this.labelBaudRate.Name = "labelBaudRate";
			this.labelBaudRate.Size = new System.Drawing.Size(63, 12);
			this.labelBaudRate.TabIndex = 3;
			this.labelBaudRate.Text = "Baud Rate";
			// 
			// textBaudRate
			// 
			this.textBaudRate.Location = new System.Drawing.Point(85, 39);
			this.textBaudRate.Name = "textBaudRate";
			this.textBaudRate.Size = new System.Drawing.Size(143, 21);
			this.textBaudRate.TabIndex = 2;
			this.textBaudRate.Text = "9600";
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDisconnect.Location = new System.Drawing.Point(237, 39);
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(93, 21);
			this.buttonDisconnect.TabIndex = 4;
			this.buttonDisconnect.Text = "Disconnect";
			this.buttonDisconnect.UseVisualStyleBackColor = true;
			this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(56, 76);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(172, 21);
			this.textBox1.TabIndex = 5;
			// 
			// labelRead
			// 
			this.labelRead.AutoSize = true;
			this.labelRead.Location = new System.Drawing.Point(12, 79);
			this.labelRead.Name = "labelRead";
			this.labelRead.Size = new System.Drawing.Size(38, 12);
			this.labelRead.TabIndex = 6;
			this.labelRead.Text = "Read:";
			// 
			// buttonRequest
			// 
			this.buttonRequest.Enabled = false;
			this.buttonRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRequest.Location = new System.Drawing.Point(237, 76);
			this.buttonRequest.Name = "buttonRequest";
			this.buttonRequest.Size = new System.Drawing.Size(92, 21);
			this.buttonRequest.TabIndex = 7;
			this.buttonRequest.Text = "Request";
			this.buttonRequest.UseVisualStyleBackColor = true;
			this.buttonRequest.Click += new System.EventHandler(this.buttonRequest_Click);
			// 
			// checkAutorequest
			// 
			this.checkAutorequest.AutoSize = true;
			this.checkAutorequest.Enabled = false;
			this.checkAutorequest.Location = new System.Drawing.Point(237, 106);
			this.checkAutorequest.Name = "checkAutorequest";
			this.checkAutorequest.Size = new System.Drawing.Size(95, 16);
			this.checkAutorequest.TabIndex = 8;
			this.checkAutorequest.Text = "Auto request";
			this.checkAutorequest.UseVisualStyleBackColor = true;
			this.checkAutorequest.CheckedChanged += new System.EventHandler(this.checkAutorequest_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 129);
			this.Controls.Add(this.checkAutorequest);
			this.Controls.Add(this.buttonRequest);
			this.Controls.Add(this.labelRead);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonDisconnect);
			this.Controls.Add(this.textBaudRate);
			this.Controls.Add(this.labelBaudRate);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.labelPortName);
			this.Controls.Add(this.textPortName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Jubeat Controller Receiver";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textPortName;
		private System.Windows.Forms.Label labelPortName;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Label labelBaudRate;
		private System.Windows.Forms.TextBox textBaudRate;
		private System.Windows.Forms.Button buttonDisconnect;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label labelRead;
		private System.Windows.Forms.Button buttonRequest;
		private System.Windows.Forms.CheckBox checkAutorequest;
	}
}

