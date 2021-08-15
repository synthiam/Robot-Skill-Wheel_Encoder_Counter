﻿namespace Wheel_Encoder_Counter {
  partial class FormMain {
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
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.btnResetValues = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbUpdate = new System.Windows.Forms.CheckBox();
      this.cbDebug = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.White;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.ForeColor = System.Drawing.Color.Black;
      this.button1.Location = new System.Drawing.Point(3, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(136, 43);
      this.button1.TabIndex = 0;
      this.button1.Text = "Get Wheel Values";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.Black;
      this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox1.ForeColor = System.Drawing.Color.White;
      this.textBox1.Location = new System.Drawing.Point(0, 82);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(442, 49);
      this.textBox1.TabIndex = 1;
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.White;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.ForeColor = System.Drawing.Color.Black;
      this.button2.Location = new System.Drawing.Point(287, 3);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(136, 43);
      this.button2.TabIndex = 2;
      this.button2.Text = "Get Wheel Values && Reset";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // btnResetValues
      // 
      this.btnResetValues.BackColor = System.Drawing.Color.White;
      this.btnResetValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnResetValues.ForeColor = System.Drawing.Color.Black;
      this.btnResetValues.Location = new System.Drawing.Point(145, 3);
      this.btnResetValues.Name = "btnResetValues";
      this.btnResetValues.Size = new System.Drawing.Size(136, 43);
      this.btnResetValues.TabIndex = 3;
      this.btnResetValues.Text = "Reset Values";
      this.btnResetValues.UseVisualStyleBackColor = false;
      this.btnResetValues.Click += new System.EventHandler(this.btnResetValues_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.cbDebug);
      this.panel1.Controls.Add(this.cbUpdate);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.btnResetValues);
      this.panel1.Controls.Add(this.button2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.ForeColor = System.Drawing.Color.Black;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(442, 82);
      this.panel1.TabIndex = 4;
      // 
      // cbUpdate
      // 
      this.cbUpdate.AutoSize = true;
      this.cbUpdate.Location = new System.Drawing.Point(3, 52);
      this.cbUpdate.Name = "cbUpdate";
      this.cbUpdate.Size = new System.Drawing.Size(136, 17);
      this.cbUpdate.TabIndex = 4;
      this.cbUpdate.Text = "Update every 1,000 ms";
      this.cbUpdate.UseVisualStyleBackColor = true;
      this.cbUpdate.CheckedChanged += new System.EventHandler(this.cbUpdate_CheckedChanged);
      // 
      // cbDebug
      // 
      this.cbDebug.AutoSize = true;
      this.cbDebug.Location = new System.Drawing.Point(159, 52);
      this.cbDebug.Name = "cbDebug";
      this.cbDebug.Size = new System.Drawing.Size(58, 17);
      this.cbDebug.TabIndex = 5;
      this.cbDebug.Text = "Debug";
      this.cbDebug.UseVisualStyleBackColor = true;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(442, 131);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.panel1);
      this.Name = "FormMain";
      this.Text = "FormMain";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button btnResetValues;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbUpdate;
    private System.Windows.Forms.CheckBox cbDebug;
  }
}