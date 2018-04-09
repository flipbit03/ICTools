// =============================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// =============================================================================
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Microsoft.TeamFoundation.Samples.Ticker
{
	/// <summary>
	/// SysTray class that can be used to display animated icons or text in the system tray
	/// </summary>
	public class SysTray : IDisposable
	{
        #region Constructor
        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="text">The toolip text</param>
        /// <param name="icon">The icon that will be shown by default, can be null</param>
        /// <param name="menu">The context menu to be opened on right clicking on the 
        ///                    icon in the tray. This can be null.</param>
		public SysTray(string text, Icon icon, ContextMenu menu)
		{
			m_notifyIcon = new NotifyIcon();
            m_notifyIcon.Text = text;
            m_notifyIcon.Visible = true;
            m_notifyIcon.Icon = icon;
            m_DefaultIcon = icon;
            m_notifyIcon.ContextMenu = menu;
            m_font = new Font("Helvetica", 8);
            
		}
        #endregion // Constructor
    
        #region Public APIs
        /// <summary>
        /// Shows text instead of icon in the tray
        /// </summary>
        /// <param name="text">The text to be displayed on the tray. 
        ///                    Make this only 1 or 2 characters. E.g. "23"</param>
        public void ShowText(string text)
        {
            ShowText(text, m_font, m_col);
        }
        /// <summary>
        /// Shows text instead of icon in the tray
        /// </summary>
        /// <param name="text">Same as above</param>
        /// <param name="col">Color to be used to display the text in the tray</param>
        public void ShowText(string text, Color col)
        {
            ShowText(text, m_font, col);
        }
        /// <summary>
        /// Shows text instead of icon in the tray
        /// </summary>
        /// <param name="text">Same as above</param>
        /// <param name="font">The default color will be used but in user given font</param>
        public void ShowText(string text, Font font)
        {
            ShowText(text, font, m_col);
        }
        /// <summary>
        /// Shows text instead of icon in the tray
        /// </summary>
        /// <param name="text">the text to be displayed</param>
        /// <param name="font">The font to be used</param>
        /// <param name="col">The color to be used</param>
        public void ShowText(string text, Font font, Color col)
        {
            Bitmap bitmap = new Bitmap(16, 16);//, System.Drawing.Imaging.PixelFormat.Max);

            Brush brush = new SolidBrush(col);

            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawString(text, m_font,brush, 0, 0);

            IntPtr hIcon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            m_notifyIcon.Icon = icon;

        }

        public void SetToolTipText(string text)
        {
            m_notifyIcon.Text = text;
        }

        #endregion // Public APIs
       
        #region Dispose
        public void Dispose()
        {
            m_notifyIcon.Dispose();
            if(m_font != null)
                m_font.Dispose();
        }
        #endregion
   
         
        #region private variables

        private NotifyIcon m_notifyIcon;
        private Font m_font;
        private Color m_col = Color.White;
        private Icon m_DefaultIcon;
        
        #endregion // private variables
	}
}
