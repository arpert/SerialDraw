/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2014-06-25
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SerialDraw
{
	/// <summary>
	/// Description of FrmDisplay.
	/// </summary>
	public partial class FrmDisplay : Form
	{
		public System.Collections.Generic.List<System.Drawing.PointF[]> pts;
		public System.Collections.Generic.List<int> chanList;
		public DrawConfig cfg;

		public FrmDisplay()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void DrawGrid(Graphics gr, DrawConfig drc)
		{
			Pen pn = new Pen(cfg.gridColor);
			int w = ClientRectangle.Width;
			int h = ClientRectangle.Height;
			int nx;
			int ny;
			for(double x = cfg.minX; x <= cfg.maxX; x += cfg.gridStepX)
			{
				nx = (int)((x - cfg.minX) / (cfg.maxX - cfg.minX) * w);
			   gr.DrawLine(pn, nx, 0, nx, h);
			}
			
			for(double y = cfg.minY; y <= cfg.maxY; y += cfg.gridStepY)
			{
				ny = (int)((y - cfg.minY) / (cfg.maxY - cfg.minY) * h);
			    gr.DrawLine(pn, 0, ny, w, ny);
			}
		}
		
		void FrmDisplayPaint(object sender, PaintEventArgs e)
		{
			this.BackColor = cfg.BkgColor;
			
			Graphics gr = e.Graphics;
			Pen pn;
			if (cfg.showGrid)
			{
				DrawGrid(gr, cfg);
			}
			
			if (Owner != null)
			{
				int mx = ((MainForm)Owner).curData;
			   gr.DrawLine(Pens.BlueViolet, mx, 0, mx, 3);
			   gr.DrawLine(Pens.BlueViolet, mx, ClientRectangle.Height, mx, ClientRectangle.Height - 3);
			}
			
			if (pts != null)
			{
				for(int i = 0; i < pts.Count; i++)
				{
					pn = new Pen(cfg.chanList[cfg.dispXY ? cfg.channelX : chanList[i]].LineColor);
      				gr.DrawLines(pn, pts[i]);
				}
			}
		}
		
		void FrmDisplayResize(object sender, EventArgs e)
		{
			Refresh();
		}
	}
}
