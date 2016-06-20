/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2014-06-25
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SerialDraw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.cbDisplay = new System.Windows.Forms.CheckBox();
			this.numMaxX = new System.Windows.Forms.NumericUpDown();
			this.numMaxY = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbPortList = new System.Windows.Forms.ComboBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.cbXY = new System.Windows.Forms.CheckBox();
			this.btPortOpen = new System.Windows.Forms.Button();
			this.tbRx = new System.Windows.Forms.TextBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btOK = new System.Windows.Forms.Button();
			this.btApply = new System.Windows.Forms.Button();
			this.cbChanX = new System.Windows.Forms.ComboBox();
			this.cbChanY = new System.Windows.Forms.ComboBox();
			this.cbSeparator = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numMaxX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxY)).BeginInit();
			this.SuspendLayout();
			// 
			// cbDisplay
			// 
			this.cbDisplay.Location = new System.Drawing.Point(12, 12);
			this.cbDisplay.Name = "cbDisplay";
			this.cbDisplay.Size = new System.Drawing.Size(118, 24);
			this.cbDisplay.TabIndex = 0;
			this.cbDisplay.Text = "Pokaż wykres";
			this.cbDisplay.UseVisualStyleBackColor = true;
			this.cbDisplay.CheckedChanged += new System.EventHandler(this.CbDisplayCheckedChanged);
			// 
			// numMaxX
			// 
			this.numMaxX.Location = new System.Drawing.Point(67, 42);
			this.numMaxX.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.numMaxX.Minimum = new decimal(new int[] {
			140,
			0,
			0,
			0});
			this.numMaxX.Name = "numMaxX";
			this.numMaxX.Size = new System.Drawing.Size(73, 22);
			this.numMaxX.TabIndex = 3;
			this.numMaxX.Value = new decimal(new int[] {
			140,
			0,
			0,
			0});
			this.numMaxX.ValueChanged += new System.EventHandler(this.NumMaxXValueChanged);
			// 
			// numMaxY
			// 
			this.numMaxY.Location = new System.Drawing.Point(67, 70);
			this.numMaxY.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
			this.numMaxY.Minimum = new decimal(new int[] {
			20,
			0,
			0,
			0});
			this.numMaxY.Name = "numMaxY";
			this.numMaxY.Size = new System.Drawing.Size(73, 22);
			this.numMaxY.TabIndex = 4;
			this.numMaxY.Value = new decimal(new int[] {
			120,
			0,
			0,
			0});
			this.numMaxY.ValueChanged += new System.EventHandler(this.NumMaxYValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "X max";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Y max";
			// 
			// lbPortList
			// 
			this.lbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lbPortList.FormattingEnabled = true;
			this.lbPortList.Location = new System.Drawing.Point(67, 98);
			this.lbPortList.Name = "lbPortList";
			this.lbPortList.Size = new System.Drawing.Size(73, 24);
			this.lbPortList.Sorted = true;
			this.lbPortList.TabIndex = 7;
			this.lbPortList.SelectedIndexChanged += new System.EventHandler(this.LbPortListSelectedIndexChanged);
			// 
			// serialPort1
			// 
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
			// 
			// cbXY
			// 
			this.cbXY.Location = new System.Drawing.Point(12, 157);
			this.cbXY.Name = "cbXY";
			this.cbXY.Size = new System.Drawing.Size(104, 24);
			this.cbXY.TabIndex = 8;
			this.cbXY.Text = "    X          Y";
			this.cbXY.UseVisualStyleBackColor = true;
			this.cbXY.CheckedChanged += new System.EventHandler(this.CbXYCheckedChanged);
			// 
			// btPortOpen
			// 
			this.btPortOpen.Location = new System.Drawing.Point(67, 128);
			this.btPortOpen.Name = "btPortOpen";
			this.btPortOpen.Size = new System.Drawing.Size(73, 25);
			this.btPortOpen.TabIndex = 9;
			this.btPortOpen.Text = "Połącz";
			this.btPortOpen.UseVisualStyleBackColor = true;
			this.btPortOpen.Click += new System.EventHandler(this.BtPortOpenClick);
			// 
			// tbRx
			// 
			this.tbRx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbRx.Location = new System.Drawing.Point(12, 308);
			this.tbRx.Name = "tbRx";
			this.tbRx.ReadOnly = true;
			this.tbRx.Size = new System.Drawing.Size(128, 22);
			this.tbRx.TabIndex = 10;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.Location = new System.Drawing.Point(165, 12);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(231, 290);
			this.propertyGrid1.TabIndex = 11;
			this.propertyGrid1.ToolbarVisible = false;
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(321, 308);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 25);
			this.btOK.TabIndex = 12;
			this.btOK.Text = "Koniec";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.BtOKClick);
			// 
			// btApply
			// 
			this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btApply.Location = new System.Drawing.Point(171, 308);
			this.btApply.Name = "btApply";
			this.btApply.Size = new System.Drawing.Size(75, 25);
			this.btApply.TabIndex = 13;
			this.btApply.Text = "Zastosuj";
			this.btApply.UseVisualStyleBackColor = true;
			this.btApply.Click += new System.EventHandler(this.BtApplyClick);
			// 
			// cbChanX
			// 
			this.cbChanX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChanX.FormattingEnabled = true;
			this.cbChanX.Location = new System.Drawing.Point(46, 187);
			this.cbChanX.Name = "cbChanX";
			this.cbChanX.Size = new System.Drawing.Size(44, 24);
			this.cbChanX.Sorted = true;
			this.cbChanX.TabIndex = 14;
			this.cbChanX.SelectedIndexChanged += new System.EventHandler(this.CbChanXSelectedIndexChanged);
			// 
			// cbChanY
			// 
			this.cbChanY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChanY.FormattingEnabled = true;
			this.cbChanY.Location = new System.Drawing.Point(96, 187);
			this.cbChanY.Name = "cbChanY";
			this.cbChanY.Size = new System.Drawing.Size(44, 24);
			this.cbChanY.Sorted = true;
			this.cbChanY.TabIndex = 15;
			this.cbChanY.SelectedIndexChanged += new System.EventHandler(this.CbChanYSelectedIndexChanged);
			// 
			// cbSeparator
			// 
			this.cbSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSeparator.FormattingEnabled = true;
			this.cbSeparator.Items.AddRange(new object[] {
			",",
			";",
			"|",
			"\\t",
			":"});
			this.cbSeparator.Location = new System.Drawing.Point(96, 231);
			this.cbSeparator.Name = "cbSeparator";
			this.cbSeparator.Size = new System.Drawing.Size(44, 24);
			this.cbSeparator.TabIndex = 16;
			this.cbSeparator.SelectedIndexChanged += new System.EventHandler(this.CbSeparatorSelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 234);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 23);
			this.label3.TabIndex = 17;
			this.label3.Text = "Separator";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(408, 343);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbSeparator);
			this.Controls.Add(this.cbChanY);
			this.Controls.Add(this.cbChanX);
			this.Controls.Add(this.btApply);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.tbRx);
			this.Controls.Add(this.btPortOpen);
			this.Controls.Add(this.cbXY);
			this.Controls.Add(this.lbPortList);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numMaxY);
			this.Controls.Add(this.numMaxX);
			this.Controls.Add(this.cbDisplay);
			this.Name = "MainForm";
			this.Text = "Monitor ";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.numMaxX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxY)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox cbChanX;
		private System.Windows.Forms.ComboBox cbChanY;
		private System.Windows.Forms.ComboBox cbSeparator;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btApply;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.TextBox tbRx;
		private System.Windows.Forms.Button btPortOpen;
		private System.Windows.Forms.CheckBox cbXY;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.ComboBox lbPortList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numMaxY;
		private System.Windows.Forms.NumericUpDown numMaxX;
		private System.Windows.Forms.CheckBox cbDisplay;
	}
}
