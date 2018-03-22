namespace LORAProofOfConceptClient
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
			this.components = new System.ComponentModel.Container();
			this.binsLabel = new System.Windows.Forms.Label();
			this.binsGridView = new System.Windows.Forms.DataGridView();
			this.binDetailsGroupBox = new System.Windows.Forms.GroupBox();
			this.statusText = new System.Windows.Forms.Label();
			this.capacityTextBox = new System.Windows.Forms.TextBox();
			this.capacityLabel = new System.Windows.Forms.Label();
			this.longTextBox = new System.Windows.Forms.TextBox();
			this.longLabel = new System.Windows.Forms.Label();
			this.latTextBox = new System.Windows.Forms.TextBox();
			this.latLabel = new System.Windows.Forms.Label();
			this.IDTextBox = new System.Windows.Forms.TextBox();
			this.binIDLabel = new System.Windows.Forms.Label();
			this.refreshButton = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.binsGridView)).BeginInit();
			this.binDetailsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// binsLabel
			// 
			this.binsLabel.AutoSize = true;
			this.binsLabel.Location = new System.Drawing.Point(155, 9);
			this.binsLabel.Name = "binsLabel";
			this.binsLabel.Size = new System.Drawing.Size(73, 13);
			this.binsLabel.TabIndex = 0;
			this.binsLabel.Text = "Vuilnisbakken";
			// 
			// binsGridView
			// 
			this.binsGridView.AllowUserToAddRows = false;
			this.binsGridView.AllowUserToDeleteRows = false;
			this.binsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.binsGridView.Location = new System.Drawing.Point(81, 25);
			this.binsGridView.Name = "binsGridView";
			this.binsGridView.ReadOnly = true;
			this.binsGridView.RowHeadersVisible = false;
			this.binsGridView.Size = new System.Drawing.Size(240, 150);
			this.binsGridView.TabIndex = 3;
			this.binsGridView.SelectionChanged += new System.EventHandler(this.binsGridView_SelectionChanged);
			// 
			// binDetailsGroupBox
			// 
			this.binDetailsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.binDetailsGroupBox.Controls.Add(this.statusText);
			this.binDetailsGroupBox.Controls.Add(this.capacityTextBox);
			this.binDetailsGroupBox.Controls.Add(this.capacityLabel);
			this.binDetailsGroupBox.Controls.Add(this.longTextBox);
			this.binDetailsGroupBox.Controls.Add(this.longLabel);
			this.binDetailsGroupBox.Controls.Add(this.latTextBox);
			this.binDetailsGroupBox.Controls.Add(this.latLabel);
			this.binDetailsGroupBox.Controls.Add(this.IDTextBox);
			this.binDetailsGroupBox.Controls.Add(this.binIDLabel);
			this.binDetailsGroupBox.Location = new System.Drawing.Point(52, 208);
			this.binDetailsGroupBox.Name = "binDetailsGroupBox";
			this.binDetailsGroupBox.Size = new System.Drawing.Size(291, 255);
			this.binDetailsGroupBox.TabIndex = 4;
			this.binDetailsGroupBox.TabStop = false;
			this.binDetailsGroupBox.Text = "Vuilnisbak Details";
			// 
			// statusText
			// 
			this.statusText.AutoSize = true;
			this.statusText.Location = new System.Drawing.Point(6, 226);
			this.statusText.Name = "statusText";
			this.statusText.Size = new System.Drawing.Size(0, 13);
			this.statusText.TabIndex = 8;
			// 
			// capacityTextBox
			// 
			this.capacityTextBox.Location = new System.Drawing.Point(93, 168);
			this.capacityTextBox.Name = "capacityTextBox";
			this.capacityTextBox.ReadOnly = true;
			this.capacityTextBox.Size = new System.Drawing.Size(100, 20);
			this.capacityTextBox.TabIndex = 7;
			// 
			// capacityLabel
			// 
			this.capacityLabel.AutoSize = true;
			this.capacityLabel.Location = new System.Drawing.Point(129, 152);
			this.capacityLabel.Name = "capacityLabel";
			this.capacityLabel.Size = new System.Drawing.Size(39, 13);
			this.capacityLabel.TabIndex = 6;
			this.capacityLabel.Text = "Vol (%)";
			// 
			// longTextBox
			// 
			this.longTextBox.Location = new System.Drawing.Point(7, 129);
			this.longTextBox.Name = "longTextBox";
			this.longTextBox.ReadOnly = true;
			this.longTextBox.Size = new System.Drawing.Size(278, 20);
			this.longTextBox.TabIndex = 5;
			// 
			// longLabel
			// 
			this.longLabel.AutoSize = true;
			this.longLabel.Location = new System.Drawing.Point(103, 113);
			this.longLabel.Name = "longLabel";
			this.longLabel.Size = new System.Drawing.Size(67, 13);
			this.longLabel.TabIndex = 4;
			this.longLabel.Text = "Lengtegraad";
			// 
			// latTextBox
			// 
			this.latTextBox.Location = new System.Drawing.Point(6, 80);
			this.latTextBox.Name = "latTextBox";
			this.latTextBox.ReadOnly = true;
			this.latTextBox.Size = new System.Drawing.Size(278, 20);
			this.latTextBox.TabIndex = 3;
			// 
			// latLabel
			// 
			this.latLabel.AutoSize = true;
			this.latLabel.Location = new System.Drawing.Point(105, 64);
			this.latLabel.Name = "latLabel";
			this.latLabel.Size = new System.Drawing.Size(71, 13);
			this.latLabel.TabIndex = 2;
			this.latLabel.Text = "Breedtegraad";
			// 
			// IDTextBox
			// 
			this.IDTextBox.Location = new System.Drawing.Point(6, 32);
			this.IDTextBox.Name = "IDTextBox";
			this.IDTextBox.ReadOnly = true;
			this.IDTextBox.Size = new System.Drawing.Size(278, 20);
			this.IDTextBox.TabIndex = 1;
			// 
			// binIDLabel
			// 
			this.binIDLabel.AutoSize = true;
			this.binIDLabel.Location = new System.Drawing.Point(129, 16);
			this.binIDLabel.Name = "binIDLabel";
			this.binIDLabel.Size = new System.Drawing.Size(18, 13);
			this.binIDLabel.TabIndex = 0;
			this.binIDLabel.Text = "ID";
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(158, 507);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(75, 23);
			this.refreshButton.TabIndex = 5;
			this.refreshButton.Text = "Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Enabled = true;
			this.refreshTimer.Interval = 300000;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 551);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.binDetailsGroupBox);
			this.Controls.Add(this.binsGridView);
			this.Controls.Add(this.binsLabel);
			this.Name = "MainForm";
			this.Text = "LoRa Proof of Concept";
			((System.ComponentModel.ISupportInitialize)(this.binsGridView)).EndInit();
			this.binDetailsGroupBox.ResumeLayout(false);
			this.binDetailsGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label binsLabel;
		private System.Windows.Forms.DataGridView binsGridView;
		private System.Windows.Forms.GroupBox binDetailsGroupBox;
		private System.Windows.Forms.Label binIDLabel;
		private System.Windows.Forms.TextBox IDTextBox;
		private System.Windows.Forms.Label latLabel;
		private System.Windows.Forms.TextBox latTextBox;
		private System.Windows.Forms.Label longLabel;
		private System.Windows.Forms.TextBox longTextBox;
		private System.Windows.Forms.Label capacityLabel;
		private System.Windows.Forms.TextBox capacityTextBox;
		private System.Windows.Forms.Label statusText;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Timer refreshTimer;
	}
}

