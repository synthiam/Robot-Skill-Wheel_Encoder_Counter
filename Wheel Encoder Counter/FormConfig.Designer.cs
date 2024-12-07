namespace Wheel_Encoder_Counter {
  partial class FormConfig {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.nudTimerInterval = new System.Windows.Forms.NumericUpDown();
      this.ucHelpHover1 = new ARC.UCForms.UC.UCHelpHover();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.cbDebug = new System.Windows.Forms.CheckBox();
      this.ucHelpHover3 = new ARC.UCForms.UC.UCHelpHover();
      this.ucTabControl1 = new ARC.UCForms.UCTabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.cbNMS = new ARC.UCForms.UC.UCCheckGroupBox();
      this.tbPivotDiameter = new System.Windows.Forms.TextBox();
      this.tbEncoderTicks = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.ucHelpHover4 = new ARC.UCForms.UC.UCHelpHover();
      this.ucHelpHover6 = new ARC.UCForms.UC.UCHelpHover();
      this.label2 = new System.Windows.Forms.Label();
      this.tbWheelDiameter = new System.Windows.Forms.TextBox();
      this.ucHelpHover5 = new ARC.UCForms.UC.UCHelpHover();
      this.label3 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudTimerInterval)).BeginInit();
      this.panel1.SuspendLayout();
      this.ucTabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.cbNMS.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(8, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Poll Interval (ms)";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // nudTimerInterval
      // 
      this.nudTimerInterval.Location = new System.Drawing.Point(114, 6);
      this.nudTimerInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.nudTimerInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.nudTimerInterval.Name = "nudTimerInterval";
      this.nudTimerInterval.Size = new System.Drawing.Size(120, 20);
      this.nudTimerInterval.TabIndex = 1;
      this.nudTimerInterval.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // ucHelpHover1
      // 
      this.ucHelpHover1.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover1.Location = new System.Drawing.Point(238, 6);
      this.ucHelpHover1.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover1.Name = "ucHelpHover1";
      this.ucHelpHover1.SetHelpText = "";
      this.ucHelpHover1.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover1.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnCancel);
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 191);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(533, 52);
      this.panel1.TabIndex = 7;
      // 
      // btnCancel
      // 
      this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(75, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 52);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnSave
      // 
      this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Location = new System.Drawing.Point(0, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 52);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // cbDebug
      // 
      this.cbDebug.AutoSize = true;
      this.cbDebug.Location = new System.Drawing.Point(140, 44);
      this.cbDebug.Name = "cbDebug";
      this.cbDebug.Size = new System.Drawing.Size(147, 17);
      this.cbDebug.TabIndex = 9;
      this.cbDebug.Text = "Display debug information";
      this.cbDebug.UseVisualStyleBackColor = true;
      // 
      // ucHelpHover3
      // 
      this.ucHelpHover3.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover3.Location = new System.Drawing.Point(114, 41);
      this.ucHelpHover3.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover3.Name = "ucHelpHover3";
      this.ucHelpHover3.SetHelpText = "";
      this.ucHelpHover3.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover3.TabIndex = 8;
      // 
      // ucTabControl1
      // 
      this.ucTabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.ucTabControl1.BackColor = System.Drawing.Color.White;
      this.ucTabControl1.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(170)))), ((int)(((byte)(234)))));
      this.ucTabControl1.ButtonSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(146)))), ((int)(((byte)(66)))));
      this.ucTabControl1.ButtonTextColor = System.Drawing.Color.White;
      this.ucTabControl1.Controls.Add(this.tabPage1);
      this.ucTabControl1.Controls.Add(this.tabPage2);
      this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucTabControl1.ItemSize = new System.Drawing.Size(60, 50);
      this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
      this.ucTabControl1.Margin = new System.Windows.Forms.Padding(0);
      this.ucTabControl1.MarginLeft = 0;
      this.ucTabControl1.MarginTop = 0;
      this.ucTabControl1.Multiline = true;
      this.ucTabControl1.Name = "ucTabControl1";
      this.ucTabControl1.Padding = new System.Drawing.Point(0, 0);
      this.ucTabControl1.SelectedIndex = 0;
      this.ucTabControl1.Size = new System.Drawing.Size(533, 191);
      this.ucTabControl1.TabIndex = 10;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.nudTimerInterval);
      this.tabPage1.Controls.Add(this.cbDebug);
      this.tabPage1.Controls.Add(this.ucHelpHover3);
      this.tabPage1.Controls.Add(this.label1);
      this.tabPage1.Controls.Add(this.ucHelpHover1);
      this.tabPage1.Location = new System.Drawing.Point(4, 54);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(525, 133);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "General";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.cbNMS);
      this.tabPage2.Location = new System.Drawing.Point(4, 54);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(525, 133);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "NMS";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // cbNMS
      // 
      this.cbNMS.Controls.Add(this.tbPivotDiameter);
      this.cbNMS.Controls.Add(this.tbEncoderTicks);
      this.cbNMS.Controls.Add(this.label4);
      this.cbNMS.Controls.Add(this.ucHelpHover4);
      this.cbNMS.Controls.Add(this.ucHelpHover6);
      this.cbNMS.Controls.Add(this.label2);
      this.cbNMS.Controls.Add(this.tbWheelDiameter);
      this.cbNMS.Controls.Add(this.ucHelpHover5);
      this.cbNMS.Controls.Add(this.label3);
      this.cbNMS.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbNMS.Location = new System.Drawing.Point(3, 3);
      this.cbNMS.Name = "cbNMS";
      this.cbNMS.Size = new System.Drawing.Size(519, 127);
      this.cbNMS.TabIndex = 13;
      this.cbNMS.TabStop = false;
      this.cbNMS.Text = "Push to NMS as Level 3 Group 2 Pose Data";
      // 
      // tbPivotDiameter
      // 
      this.tbPivotDiameter.Location = new System.Drawing.Point(381, 92);
      this.tbPivotDiameter.Name = "tbPivotDiameter";
      this.tbPivotDiameter.Size = new System.Drawing.Size(100, 20);
      this.tbPivotDiameter.TabIndex = 12;
      // 
      // tbEncoderTicks
      // 
      this.tbEncoderTicks.Location = new System.Drawing.Point(381, 19);
      this.tbEncoderTicks.Name = "tbEncoderTicks";
      this.tbEncoderTicks.Size = new System.Drawing.Size(100, 20);
      this.tbEncoderTicks.TabIndex = 6;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(19, 92);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(356, 20);
      this.label4.TabIndex = 10;
      this.label4.Text = "Pivot diameter = distance between centers of wheel treads (mm)";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // ucHelpHover4
      // 
      this.ucHelpHover4.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover4.Location = new System.Drawing.Point(484, 19);
      this.ucHelpHover4.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover4.Name = "ucHelpHover4";
      this.ucHelpHover4.SetHelpText = "";
      this.ucHelpHover4.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover4.TabIndex = 5;
      // 
      // ucHelpHover6
      // 
      this.ucHelpHover6.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover6.Location = new System.Drawing.Point(484, 92);
      this.ucHelpHover6.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover6.Name = "ucHelpHover6";
      this.ucHelpHover6.SetHelpText = "";
      this.ucHelpHover6.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover6.TabIndex = 11;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(19, 19);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(356, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "Encoder ticks per wheel revolution";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // tbWheelDiameter
      // 
      this.tbWheelDiameter.Location = new System.Drawing.Point(381, 55);
      this.tbWheelDiameter.Name = "tbWheelDiameter";
      this.tbWheelDiameter.Size = new System.Drawing.Size(100, 20);
      this.tbWheelDiameter.TabIndex = 9;
      // 
      // ucHelpHover5
      // 
      this.ucHelpHover5.BackColor = System.Drawing.Color.Transparent;
      this.ucHelpHover5.Location = new System.Drawing.Point(484, 55);
      this.ucHelpHover5.Margin = new System.Windows.Forms.Padding(0);
      this.ucHelpHover5.Name = "ucHelpHover5";
      this.ucHelpHover5.SetHelpText = "";
      this.ucHelpHover5.Size = new System.Drawing.Size(20, 20);
      this.ucHelpHover5.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(19, 55);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(356, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Wheel diameter (mm)";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // FormConfig
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(533, 243);
      this.Controls.Add(this.ucTabControl1);
      this.Controls.Add(this.panel1);
      this.Name = "FormConfig";
      this.Text = "Config";
      ((System.ComponentModel.ISupportInitialize)(this.nudTimerInterval)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ucTabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.cbNMS.ResumeLayout(false);
      this.cbNMS.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown nudTimerInterval;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox cbDebug;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover3;
    private ARC.UCForms.UCTabControl ucTabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Label label2;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover4;
    private System.Windows.Forms.TextBox tbEncoderTicks;
    private System.Windows.Forms.TextBox tbWheelDiameter;
    private System.Windows.Forms.Label label3;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover5;
    private System.Windows.Forms.TextBox tbPivotDiameter;
    private System.Windows.Forms.Label label4;
    private ARC.UCForms.UC.UCHelpHover ucHelpHover6;
    private ARC.UCForms.UC.UCCheckGroupBox cbNMS;
  }
}