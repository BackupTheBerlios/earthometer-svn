/*
 * Erstellt mit SharpDevelop.
 * Benutzer: flammensboeck
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
using System.Windows.Forms;

namespace Sosp.EarthOMeter
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
			Application.Run(new Sosp.EarthOMeter.WFGUI.MainForm());
		}
		
	}
}
