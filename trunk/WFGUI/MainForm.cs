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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Sosp.Geographic.kml;

namespace Sosp.EarthOMeter.WFGUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
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
		
		void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
		
		void EinfügenToolStripMenuItemClick(object sender, EventArgs e)
		{
			insertFromClipboard();
		}
		
		protected void insertFromClipboard()
		{	
			try{
				String text = Clipboard.GetText();
				XmlTextReader reader = new XmlTextReader(new StringReader(text));
				KMLDistance myKmlDistance = new KMLDistance(reader);
				fillDistancesToTreeview(myKmlDistance);
			}catch{
			}
		}
		private void fillDistancesToTreeview(KMLDistance myKmlDistance)
		{
			distancesGridView.Rows.Clear();
			String[] row = new String[2];
			for (int i=0; i< myKmlDistance.Count; i++) {
				row[0] = myKmlDistance[i].Name;
				row[1] = Math.Round(myKmlDistance[i].Distance,3)+" km";
       			distancesGridView.Rows.Add(row);
			}
		
		}
		protected void openFromFile()
		{
			
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
	        {
				XmlTextReader reader = new XmlTextReader(openFileDialog1.OpenFile());
	        	KMLDistance myKmlDistance = new KMLDistance(reader);
				fillDistancesToTreeview(myKmlDistance);
	        }
		}
		protected void showAboutBox()
		{
			AboutForm about = new AboutForm();
			about.ShowDialog();
		}
		
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			insertFromClipboard();
		}
		
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			openFromFile();
		}
		
		void ÖffnenToolStripMenuItemClick(object sender, EventArgs e)
		{
			openFromFile();
		}
		
		void InfoToolStripMenuItemClick(object sender, EventArgs e)
		{
			showAboutBox();
		}
	}
}
