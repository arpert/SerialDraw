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
using System.Globalization;
using System.Windows.Forms;

namespace SerialDraw
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		FrmDisplay frmDisplay;
        bool m_bFirstShow = true;
        private System.Collections.Generic.List<System.Collections.Generic.List<float>> dataTable;
        public int curData = 0;
        int dataLen = 400;
        bool m_doEvents = true;
        public DrawConfig cfg; 
        string dataBuf;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		delegate double IniFun(double par);
			
		void MainFormLoad(object sender, EventArgs e)
		{
			if (cfg == null)
				cfg = DrawConfig.Instance;
			
			frmDisplay = new FrmDisplay();
//			frmDisplay.Parent = this;
			frmDisplay.cfg = cfg;
			
			cbDisplay.Checked = cfg.showDisplay;
			m_doEvents = false;
			numMaxX.Value = cfg.displayWidth;
			numMaxY.Value = cfg.displayHeight;
			cbXY.Checked = cfg.dispXY;
			m_doEvents = true;
			
			ResizeDisplay();
			ApplyShowStatus();
			int n;
			string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
			foreach(string prt in theSerialPortNames)
			{
				lbPortList.Items.Add(prt);
			}
			n = lbPortList.Items.IndexOf(cfg.portUsed);
			if (n >= 0)
				lbPortList.SelectedIndex = n;
			
			for(int i = 0; i < cfg.chanList.Length; i++)
			{
				cbChanX.Items.Add(i);
				cbChanY.Items.Add(i);
			}
			cbChanX.SelectedIndex = cfg.channelX;
			cbChanY.SelectedIndex = cfg.channelY;
			
			n = cbSeparator.Items.IndexOf(cfg.separator.ToString().Replace("\t", "\\t"));
			cbSeparator.SelectedIndex = (n < 0) ? 0 : n;
				
			if (cfg.dispXY)
			{
				cbChanX.Enabled = true;
				cbChanY.Enabled = true;
			} else
			{
				cbChanX.Enabled = false;
				cbChanY.Enabled = false;
			}
				
			OpenClosePort(true);
			propertyGrid1.SelectedObject = cfg;
			
			InitDataTable();
			ShowData();
		}
		
		void InitDataTable()
		{
			IniFun inif;
			
			if (dataTable == null)
    			dataTable = new List<List<float>>();
			int t = 100;
			for(int i = 0; i < dataLen; i++)
			{
				
				List<float> fl = new List<float>();
				for(int j = 0; j < cfg.chanList.Length; j++)
				{
                switch (j)
				{
					case 1:   inif = d => 50 + 50 * Math.Sin(Math.PI * d / t); break;
					case 2:   inif = delegate(double par) { return par % t; }; break;
					case 3:   inif = delegate(double par) { double d = par % t; return (d < t / 2) ? (2 * d) : 2*(t - d); }; break;
					default:  inif = d => d; break;
				}
					fl.Add((float)inif(i));
				}
				dataTable.Add(fl);
			}			
		}
		
		void OpenClosePort(bool showOnly)
		{
			if (!showOnly)
			{
				if (serialPort1.IsOpen)
					serialPort1.Close();
				else
					serialPort1.Open();
			}
			
			if (serialPort1.IsOpen)
			{
				btPortOpen.Text = "Rozłącz";
				
			} else
			{
				btPortOpen.Text = "Połącz";
			}
			
		}
		
		void ApplyShowStatus()
		{
			cfg.showDisplay = cbDisplay.Checked;
			if (cfg.showDisplay)
			{
				if (!frmDisplay.Visible)
					frmDisplay.Show(this);
				if (m_bFirstShow)
				{
				   frmDisplay.Left = Right;
			       frmDisplay.Top = Top;
			       m_bFirstShow = false;
				}
			}
		    else
		    	frmDisplay.Hide();
		}
		
		void CbDisplayCheckedChanged(object sender, EventArgs e)
		{
			ApplyShowStatus();
		}
		
		void ResizeDisplay()
		{
			cfg.displayWidth = (int)numMaxX.Value;
			cfg.displayHeight = (int)numMaxY.Value;
			InitDataTable();

			frmDisplay.ClientSize = new Size(cfg.displayWidth, cfg.displayHeight);
		}
			
		void NumMaxXValueChanged(object sender, EventArgs e)
		{
			if (m_doEvents)
     			ResizeDisplay();
		}
		
		void NumMaxYValueChanged(object sender, EventArgs e)
		{
			if (m_doEvents)
	    		ResizeDisplay();
		}
		
		
		void LbPortListSelectedIndexChanged(object sender, EventArgs e)
		{
			cfg.portUsed = lbPortList.SelectedItem.ToString();
			serialPort1.PortName = cfg.portUsed;
		}
		
		void BtPortOpenClick(object sender, EventArgs e)
		{
           OpenClosePort(false);			
		}

		private delegate void SetControlTextHandler(Control control, string text);

		public void SetControlText(Control control, string text)
		{
		    if (this.InvokeRequired)
		    {
		        this.Invoke(new SetControlTextHandler(SetControlText), new object[] { control, text });
		    }
		    else
		    {
        	   control.Text = text;
		    }
		}
		
		void ShowData()
		{
			int len0 = dataTable.Count;
			frmDisplay.pts = new List<PointF[]>();
			frmDisplay.chanList = new List<int>();
			
			float x, y;
			PointF []pt;
			
  			if (cfg.dispXY)
  			{
				pt = new PointF[len0];
  				for(int i = 0; i < len0; i++)
				{
     				x = (float)(cfg.displayWidth * (dataTable[(curData + i) % dataLen][cfg.channelX] - cfg.minX) / (cfg.maxX - cfg.minX));
	     			y = (float)(cfg.displayHeight * (dataTable[(curData + i) % dataLen][cfg.channelY] - cfg.minY) / (cfg.maxY - cfg.minY));
	     			
	     			pt[i] = new PointF(x, y);
				}
  				frmDisplay.pts.Add(pt);
  			} else
  			{
  				double miny;
  				double dy;
  				int ix;
  				int h = cfg.displayHeight;
  				for(int i = 0; i < cfg.chanList.Length; i++)
  				{
  					if (cfg.chanList[i].show)
  					{
	  					miny = cfg.chanList[i].MinY;
	  					dy = (cfg.chanList[i].MaxY - cfg.chanList[i].MinY);
	  					if (dy == 0) dy = 1;
	  					
  				     	pt = new PointF[len0];
                     	frmDisplay.chanList.Add(i);
  						for(int j = 0; j < len0; j++)
	  					{
  							ix = j;//(curData + j) % len0;
	                       if (dataTable[ix].Count > i)
	                          y = (float)(h - h * (dataTable[ix][i] - miny) / dy);
	                       else
	                          y = 0;
	     			       pt[j] = new PointF(ix, y);
	  					}
		     			frmDisplay.pts.Add(pt);
  					}
  				}
  			}
  			
     		frmDisplay.Invalidate();
		}
		
		void NewData(string data)
		{
			NumberFormatInfo nfi = new CultureInfo( "pl-PL", false ).NumberFormat;
	        nfi.NumberDecimalSeparator = ".";

			curData = (curData + 1) % dataLen;
			string []dtv = data.Split(',', '\t', ';', '|');
			
			if (dtv.Length > 0)
			{
				double d;
				for(int i = 0; i < 3; i++)
				{
					if (dtv.Length > i)
					{
						if (Double.TryParse(dtv[i], NumberStyles.Any, nfi, out d))
						{
					   		float f = (float)d;
					   		dataTable[curData][i] = f;
						}
					}
				}
			}
			
			ShowData();
		}
		
		void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			string str = "";
			str = serialPort1.ReadExisting();
			string s;
	    	for(int i = 0; i < str.Length; i++)
	        {
	    		s = str.Substring(i, 1);
		        if (s == "\r" || s == "\n")
		        {
		        	NewData(dataBuf);
		        	SetControlText(tbRx, dataBuf);
		        	dataBuf = "";
		        } else
		        {
		        	dataBuf += s;
		        }
	    	}
			
		}
		
		void CbXYCheckedChanged(object sender, EventArgs e)
		{
			if (m_doEvents)
			{
			   cfg.dispXY = ((CheckBox)sender).Checked;
			   //frmDisplay.cfg = cfg;
			    if (cfg.dispXY)
				{
					cbChanX.Enabled = true;
					cbChanY.Enabled = true;
				} else
				{
					cbChanX.Enabled = false;
					cbChanY.Enabled = false;
				}
			   ShowData();
			}
		}
		void BtOKClick(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
		void BtApplyClick(object sender, System.EventArgs e)
		{
			frmDisplay.cfg = cfg;
			ShowData();
		}
		void CbChanXSelectedIndexChanged(object sender, System.EventArgs e)
		{
			int n = ((ComboBox)sender).SelectedIndex;
			if (n == cfg.channelY)
				((ComboBox)sender).SelectedIndex = cfg.channelX;
			else
				cfg.channelX = n;
		}
		void CbChanYSelectedIndexChanged(object sender, System.EventArgs e)
		{
			int n = ((ComboBox)sender).SelectedIndex;
			if (n == cfg.channelX)
				((ComboBox)sender).SelectedIndex = cfg.channelY;
			else
				cfg.channelY = n;
		}
		void CbSeparatorSelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cb = (ComboBox)sender;
			int n = cb.SelectedIndex;
			cfg.separator = cb.Items[n].ToString().Replace("\\t", "\t").ToCharArray(0, 1)[0];
		}
	}
}
