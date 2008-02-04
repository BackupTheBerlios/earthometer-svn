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
using Gtk;
using Sosp.Geographic.kml;
using System.Xml;
using System.IO;


namespace Sosp.EarthOMeter{
	public class MainWindow: Gtk.Window {
	    
		Gtk.ListStore distanceListStore = new Gtk.ListStore (typeof (string), typeof (string));
		
		protected Gtk.Action paste;
		protected Gtk.TreeView treeview1;
		protected Gtk.Action open;
		protected Gtk.Action Info;

		
		public MainWindow (): base ("")
		{
			Stetic.Gui.Build (this, typeof(MainWindow));
			
			treeview1.AppendColumn ("Name", new Gtk.CellRendererText (), "text", 0);
			treeview1.AppendColumn ("Streckenlänge", new Gtk.CellRendererText (), "text", 1);

	 
			treeview1.Model = distanceListStore;
	    }
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
		protected virtual void pasteActivated(object sender, System.EventArgs e)
		{
			Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD",true)).RequestText(clipboardTextReceived);
		}
		
		protected void clipboardTextReceived (Clipboard clipboard, string text)
		{	
			try{
				XmlTextReader reader = new XmlTextReader(new StringReader(text));
				KMLDistance myKmlDistance = new KMLDistance(reader);
				fillDistancesToTreeview(myKmlDistance);
			}catch{
			}
		}
		private void fillDistancesToTreeview(KMLDistance myKmlDistance)
		{
			distanceListStore.Clear();
			for (int i=0; i< myKmlDistance.Count; i++) {
				distanceListStore.AppendValues(myKmlDistance[i].Name, Math.Round(myKmlDistance[i].Distance,3)+" km");
			}
		
		}

		protected virtual void openActivated(object sender, System.EventArgs e)
		{
			FileChooserDialog fcd = new Gtk.FileChooserDialog("Bitte wählen sie eine KML Datei aus",
	                                      this,
	                                      FileChooserAction.Open,
	                                      "Abbrechen",ResponseType.Cancel,
	                                      "Öffnen",ResponseType.Accept);
			fcd.Filter = new FileFilter();
			fcd.Filter.AddPattern("*.kml");
			if (fcd.Run() == (int)ResponseType.Accept)
	        {
	        	KMLDistance myKmlDistance = new KMLDistance(fcd.Filename);
				fillDistancesToTreeview(myKmlDistance);
	        }
	        //Don't forget to call Destroy() or the FileChooserDialog window won't get closed.
	        fcd.Destroy();
		}

		protected virtual void infoActivated(object sender, System.EventArgs e)
		{
			
			About aboutWin = new About();
			aboutWin.TransientFor = this;
			aboutWin.ShowAll();
		}




	}
}