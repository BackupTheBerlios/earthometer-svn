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
using System.Globalization;

namespace Sosp.Geographic.kml
{
	
	
	public class KmlCoordinatesParser
	{
		const string validfloatchars = "0123456789.";
		
		char[] coordinatesCharArray;
		string coordinatesString;
		int currentIndex = 0;
		
	    private enum coordinateState
	    {
	    	Longitude,
	    	Latitude,
	    	Altitude
	    }
	    private enum parserState
	    {
	    	Overreading,
	    	ReadingDouble,
	    	ReadyReadingCoordinate
	    	
	    }
	    
		public KmlCoordinatesParser(string coordinatesstring)
		{
			this.coordinatesString = coordinatesstring;
			this.coordinatesCharArray = coordinatesstring.ToCharArray();
		}
		
		public bool NextCoordinate(out double[] coordinate){
			coordinate = new double[3];
			if (currentIndex < coordinatesCharArray.Length) {
				parserState state = parserState.Overreading;
				coordinateState cState = coordinateState.Longitude;
				int doubleStartIndex=0;
				CultureInfo englishCulture = new CultureInfo("en-US");
				do{
					switch (state)
	        		{
	            		case  parserState.Overreading:
	            			if (validfloatchars.IndexOf(coordinatesCharArray[currentIndex]) >= 0){
	            				doubleStartIndex = currentIndex;
	            				state = parserState.ReadingDouble;
	            			}	
	                	break;
	                	case  parserState.ReadingDouble:
	                		if (validfloatchars.IndexOf(coordinatesCharArray[currentIndex]) < 0){
	            				string floatString = coordinatesString.Substring(doubleStartIndex,currentIndex-doubleStartIndex);
	            				coordinate[(int)cState] = Double.Parse(floatString,englishCulture.NumberFormat);
	            				state = parserState.Overreading;
	            				switch (cState)
	            				{
	            					case coordinateState.Longitude:
	            						cState = coordinateState.Latitude;
	            					break;
	            					case coordinateState.Latitude:
	            						cState = coordinateState.Altitude;
	            					break;
	            					case coordinateState.Altitude:
	            						state = parserState.ReadyReadingCoordinate;
	            					break;
	            				}
	            			}	
	                	break;
	                    default:
	                		throw(new ArgumentException("Invalid parser state"));
	       			}
					currentIndex++;	
				}while((currentIndex < coordinatesCharArray.Length) && (state != parserState.ReadyReadingCoordinate));
				
				if (state == parserState.ReadyReadingCoordinate){
					return true;
				}else{
					return false;
				}
			}else{
				return false;
			}
		}
	}
}
