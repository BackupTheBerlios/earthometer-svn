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
using System.Drawing;
using System.Windows.Forms;

namespace Sosp.EarthOMeter.WFGUI
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			lblVersion.Text = Application.ProductVersion.ToString();
		}
		
		void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
   				//Call the Process.Start method to open the default browser 
   				//with a URL:
   				System.Diagnostics.Process.Start("http://www.softsprings.de");
			}catch{
				MessageBox.Show("mailto:info@softsprings.de");
			}
			
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			
		}
		
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
   				//Call the Process.Start method to open the default browser 
   				//with a URL:
   				System.Diagnostics.Process.Start("http://www.softsprings.de");
			}catch{
				MessageBox.Show("Unable to open Link");
			}
		}
	}
}
