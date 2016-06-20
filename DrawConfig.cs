/*
 * Created by SharpDevelop.
 * User: arpert
 * Date: 2014-06-25
 * Time: 16:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Xml.Serialization;
using OrderedPropertyGrid;
   


namespace SerialDraw
{
	[DisplayName("Właściwości wykresu")]
    [TypeConverter(typeof(PropertySorter))]
	public class ChartProps
	{
        [Category("Wykres"),
         DisplayName("Kolor"),
         Description("Kolor linii wykresu"),
         TypeConverter("System.Drawing.Color"),
         XmlIgnore,
         PropertyOrder(2)]
		public Color LineColor { get; set; }

		[Browsable(false)]
		public string lineColor { get { return ColorTranslator.ToHtml(LineColor); }
			                      set { LineColor = ColorTranslator.FromHtml(value); } }

        [Category("Wykres"),
         DisplayName("Min Y"),
         Description("Minimalna wyświetlana wartość Y"),
         TypeConverter("double"),
         PropertyOrder(3)]
        public double MinY { get; set; }
		
        [Category("Wykres"),
         DisplayName("Max Y"),
         Description("Maksmalna wyświetlana wartość Y"),
         TypeConverter("double"),
         PropertyOrder(4)]
        public double MaxY { get; set; }
 
        [Category("Wykres"),
         DisplayName("Pokaż"),
         Description("Czy pokazywać"),
         TypeConverter("bool"),
         PropertyOrder(1)]
        public bool show { get; set; }
        
        public ChartProps()
        {
        	LineColor = Color.Blue;
        	MinY = 0;
        	MaxY = 128;
        	show = true;
        }
	}
	
	/// <summary>
	/// Description of DrawConfig.
	/// </summary>
	public class DrawConfig
	{
        private static volatile DrawConfig instance;
        private static object syncRoot = new Object();
        
       public static DrawConfig Instance
	   {
	      get 
	      {
	         if (instance == null) 
	         {
	            lock (syncRoot) 
	            {
	               if (instance == null) instance = new DrawConfig();
	            }
	         }
	         return instance;
	      }
	   }

        /// <summary>
		/// Attributes
		/// </summary>
		public int displayWidth;
		public int displayHeight;
		public bool showDisplay;
		public string portUsed;
		
		/// <summary>
		/// Data separator
		/// </summary>
		public char separator;
		
		/// <summary>
		/// XY mode
		/// </summary>
		public bool dispXY;
		public int channelX;
		public int channelY;

		/// <summary>
		/// Properties
		/// </summary>
		[Category("Skala"),
         DisplayName("Min X"),
         Description("Minimalna wyświetlana wartość X"),
         TypeConverter("double")]
		public double minX { get; set; }

        [Category("Skala"),
         DisplayName("Max X"),
         Description("Maksymalna wyświetlana wartość X"),
         TypeConverter("double")]
		public double maxX { get; set; }

        [Category("Skala"),
         DisplayName("Min Y"),
         Description("Minimalna wyświetlana wartość Y"),
         TypeConverter("double")]
		public double minY { get; set; }

        [Category("Skala"),
         DisplayName("Max Y"),
         Description("Maksymalna wyświetlana wartość Y"),
         TypeConverter("double")]
		public double maxY { get; set; }
		
		/// <summary>
		///  Grid attributes
		/// </summary>
//		public bool m_showGrid;
        [Category("Siatka"),
         DisplayName("Pokaż siatkę"),
         Description("Wartość decyduje, czy pojawi się siatka"),
         TypeConverter("bool")]
		public bool showGrid { get; set; }
		
        [Category("Siatka"),
         DisplayName("Kolor"),
         Description("Kolor siatki"),
         TypeConverter("System.Drawing.Color"),
         XmlIgnore,
         PropertyOrder(2)]
		public Color gridColor { get; set; }

        [Category("Siatka"),
         DisplayName("Kolor tła"),
         Description("Kolor tła wykresu"),
         TypeConverter("System.Drawing.Color"),
         XmlIgnore,
         PropertyOrder(2)]
		public Color BkgColor { get; set; }
		
		[Browsable(false)]
		public string bkgColorName { get { return ColorTranslator.ToHtml(BkgColor); }
			                   set { BkgColor = ColorTranslator.FromHtml(value); } }
		
		[Browsable(false)]
		public string gridColorName { get { return ColorTranslator.ToHtml(gridColor); }
			                          set { gridColor = ColorTranslator.FromHtml(value); } }
        [Category("Siatka"),
         DisplayName("Skok X"),
         Description("Skok siatki w osi X"),
         Range(2, 100)]
		public double gridStepX { get; set; }

		[Category("Siatka"),
         DisplayName("Skok Y"),
         Description("Skok siatki w osi Y"),
         TypeConverter("double"),
         Range(2.0, 100.0)]
		public double gridStepY { get; set; } 
		
		[Category("Kanały"),
         DisplayName("Właściwości kanałów"),
         Description("Atrybuty wyświetlania kanałów")]
        public ChartProps []chanList { get; set; }
		
		
		private DrawConfig()
		{
			displayWidth = 256; 
		    displayHeight = 256;
		    dispXY = false;
		    channelX = 0;
		    channelY = 1;
		    showDisplay = true;
		    portUsed = "";
			minX = 0;
			maxX = 128;
			minY = 0;
			maxY = 128;
			showGrid = true;
			gridColorName = "MediumAquamarine";
			bkgColorName = "White";
			gridStepX = 16; 
			gridStepY = 16; 
		    chanList = new ChartProps[2];
		    chanList[0] = new ChartProps { LineColor = Color.Blue,   MinY = 0, MaxY = 128 };
			chanList[1] = new ChartProps { LineColor = Color.Green,  MinY = 0, MaxY = 128 };
//			chanList[2] = new ChartProps { Kolor = Color.Blue,   MinY = 0, MaxY = 128 };
//			chanList[3] = new ChartProps { Kolor = Color.Red,    MinY = 0, MaxY = 128 };
//			chanList[4] = new ChartProps { Kolor = Color.Violet, MinY = 0, MaxY = 128 };
		}
	}
}
