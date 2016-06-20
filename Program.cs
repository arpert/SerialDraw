/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2014-06-25
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace SerialDraw
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm frm = new MainForm();
			
			frm.cfg = LoadCfg();
			
			Application.Run(frm);
			SaveCfg(frm.cfg);
		}

   private static void SaveCfg(DrawConfig cfg)
   {
      XmlSerializer ser = new XmlSerializer(typeof(DrawConfig));
      TextWriter tw = new StreamWriter(Application.ProductName + ".cfg");
      ser.Serialize(tw, cfg);
      tw.Close();
   }
   
   private static DrawConfig LoadCfg()
   {
      DrawConfig cfg;
      TextReader tr = null;      

      try
      {
         XmlSerializer ser = new XmlSerializer(typeof(DrawConfig));
         tr = new StreamReader(Application.ProductName + ".cfg");
         cfg = (DrawConfig)ser.Deserialize(tr);
         tr.Close();
      }
      catch (Exception ex)
      {
         System.Console.WriteLine(ex.StackTrace);
         cfg = DrawConfig.Instance;
         if (tr != null)
            tr.Close();
      }
       return cfg;
   }
		
	}
}
