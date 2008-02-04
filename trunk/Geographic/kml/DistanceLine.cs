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

namespace Sosp.Geographic.kml
{
	
	
	public class DistanceLine
	{
		string name;
		double distance;
		
		public DistanceLine(string name, double distance)
		{
			this.name = name;
			this.distance = distance;
		}
		
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		public double Distance{
			get {
				return distance;
			}
			set {
				distance = value;
			}
		}
	}
}
