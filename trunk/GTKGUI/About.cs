/*
	Author: Alois Flammensboeck
	Author URI: http://www.softsprings.de
	Version: 0.9.1

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.
*/
using System;

namespace Sosp.EarthOMeter
{
	
	
	public class About : Gtk.Window
	{		
		protected Gtk.Label lblVersionHeader;
		protected Gtk.Label lblVersion;
		protected Gtk.Label lblLicenseHeader;
		protected Gtk.Label lblLicense;
		protected Gtk.Label lblCopyrightHeader;
		protected Gtk.Label lblCopyright1;
		protected Gtk.Label lblCopyright2;
		protected Gtk.Label lblCopyright3;
		
		public About() : 
				base("")
		{
			Stetic.Gui.Build(this, typeof(EarthOMeter.About));
			Pango.FontDescription headerdesc = lblVersionHeader.PangoContext.FontDescription;
			headerdesc.AbsoluteSize = 12000;
			headerdesc.Weight = Pango.Weight.Bold;
			lblVersionHeader.ModifyFont(headerdesc);
			headerdesc = lblCopyrightHeader.PangoContext.FontDescription;
			headerdesc.AbsoluteSize = 12000;
			headerdesc.Weight = Pango.Weight.Bold;
			lblCopyrightHeader.ModifyFont(headerdesc);	
			headerdesc = lblLicenseHeader.PangoContext.FontDescription;
			headerdesc.AbsoluteSize = 12000;
			headerdesc.Weight = Pango.Weight.Bold;
			lblLicenseHeader.ModifyFont(headerdesc);		
			
			
			lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			Modal = true;
			WindowPosition = Gtk.WindowPosition.CenterOnParent;
						
			Gtk.Image background = Gtk.Image.LoadFromResource("About.png");
			Gdk.Pixmap pixmap, pixmap_mask;
			background.Pixbuf.RenderPixmapAndMask( out pixmap, out pixmap_mask, 255 );
			this.AppPaintable = true;
			this.GdkWindow.SetBackPixmap( pixmap, false );
			
			
		}
	}
}
