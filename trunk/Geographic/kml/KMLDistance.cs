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
using System.Collections;
using System.Xml;
using System.Globalization;
using Sosp.Geographic;

namespace Sosp.Geographic.kml
{
	
	public class KMLDistance
	{
		ArrayList distanceLines = new ArrayList();
		private void calculateDistancesFromKml(XmlTextReader reader){
			reader.ReadStartElement("kml"); 
			reader.Read();
			if (reader.Name == "Document" || reader.Name == "Folder"){ 
				string name = "";
				string coordinates;
				while (reader.Read()) {
					if (reader.Name == "Placemark"){
						while (reader.Read() && reader.Name != "Placemark"){
							if (reader.Name == "name"){
								name = reader.ReadElementString();
							}
							if (reader.Name == "LineString"){
								while (reader.Read() && reader.Name != "LineString"){
									if (reader.Name == "coordinates"){
										CoordinatesDistanceSummarizer summarizer = new CoordinatesDistanceSummarizer();
										
									
										
										coordinates = reader.ReadElementString();
										
										KmlCoordinatesParser parser = new KmlCoordinatesParser(coordinates);
										double[] coordinate;
										while (parser.NextCoordinate(out coordinate)){
											summarizer.AddCoordinate(coordinate[1],coordinate[0]);
										}
										DistanceLine dl = new DistanceLine(name,summarizer.Summarize());
										distanceLines.Add(dl);
									
									}
								
								}
						
							}
						}
					}
				}
			}
		}
		public KMLDistance(string filename)
		{
			XmlTextReader reader = new XmlTextReader(filename);
			calculateDistancesFromKml(reader);
			
		}
		public KMLDistance(XmlTextReader reader)
		{
			calculateDistancesFromKml(reader);
		}
		
		public DistanceLine this[int index]
		{
			get { 
				return (DistanceLine)distanceLines[index]; 
			}
			set { 
				distanceLines[index] = value; 
			}
		}
		public int Count
		{
			get {
				return distanceLines.Count;
			}
		}
	}
}
