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

namespace Sosp.Geographic
{
	
	
	public class CoordinatesDistanceSummarizer
	{
		ArrayList coordinates = new ArrayList();
		public CoordinatesDistanceSummarizer()
		{
		}
		
		public void AddCoordinate(double latitude, double longitude){
			Coordinate coord = new Coordinate(latitude,longitude);
			AddCoordinate(coord);
		}
		
		public void AddCoordinate(Coordinate coordinate){
			coordinates.Add(coordinate);
		}
		
		public double Summarize(){
			double sum = 0;
			if (coordinates.Count > 1){
				Coordinate lastCoord = coordinates[0] as Coordinate;
				Coordinate nextCoord;
				for (int i = 1; i < coordinates.Count; i++){
					nextCoord = coordinates[i] as Coordinate;
					double dist = Calc( lastCoord.Latitude, lastCoord.Longitude, nextCoord.Latitude, nextCoord.Longitude); 
					sum = sum + dist;
					lastCoord = nextCoord;
				}
			}
			return sum;
		}
		
		private static double Calc(double Lat1, 
                  double Long1, double Lat2, double Long2)
	    {
	        /*
	            The Haversine formula according to Dr. Math.
	            http://mathforum.org/library/drmath/view/51879.html
	                
	            dlon = lon2 - lon1
	            dlat = lat2 - lat1
	            a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
	            c = 2 * atan2(sqrt(a), sqrt(1-a)) 
	            d = R * c
	                
	            Where
	                * dlon is the change in longitude
	                * dlat is the change in latitude
	                * c is the great circle distance in Radians.
	                * R is the radius of a spherical Earth.
	                * The locations of the two points in 
	                    spherical coordinates (longitude and 
	                    latitude) are lon1,lat1 and lon2, lat2.
	        */
	        double dDistance = Double.MinValue;
	        double dLat1InRad = Lat1 * (Math.PI / 180.0);
	        double dLong1InRad = Long1 * (Math.PI / 180.0);
	        double dLat2InRad = Lat2 * (Math.PI / 180.0);
	        double dLong2InRad = Long2 * (Math.PI / 180.0);

	        double dLongitude = dLong2InRad - dLong1InRad;
	        double dLatitude = dLat2InRad - dLat1InRad;

	        // Intermediate result a.
	        double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) + 
	                   Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * 
	                   Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

	        // Intermediate result c (great circle distance in Radians).
	        double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

	        // Distance.
	        // const Double kEarthRadiusMiles = 3956.0;
	        const Double kEarthRadiusKms = 6378.137;
	        dDistance = kEarthRadiusKms * c;

	        return dDistance;
	    }
	    
	    
	    public double distVincenty(double lat1, double lon1, double lat2, double lon2) {
			double a = 6378137;
			double b = 6356752.3142;
			double f = 1/298.257223563;  // WGS-84 ellipsiod
			double dlonrad = (lon2-lon1) * (Math.PI / 180.0); //L
	        double lat1InRad = lat1 * (Math.PI / 180.0);
	        double long1InRad = lon1 * (Math.PI / 180.0);
	        double lat2InRad = lat2 * (Math.PI / 180.0);
	        double long2InRad = lon2 * (Math.PI / 180.0);
			double u1 = Math.Atan((1-f) * Math.Tan(lat1InRad));
			double u2 = Math.Atan((1-f) * Math.Tan(lat2InRad));
			double sinU1 = Math.Sin(u1);
			double cosU1 = Math.Cos(u1);
			double sinU2 = Math.Sin(u2);
			double cosU2 = Math.Cos(u2);
			  
			double lambda = dlonrad;
			double lambdaP = 2*Math.PI;
			int iterLimit = 20;
			double cosSqAlpha=0;
			double sinSigma=0;
			double sigma=0;
			double cos2SigmaM=0;
			double cosSigma=0;
			while (Math.Abs(lambda-lambdaP) > Math.Exp(-12) && --iterLimit>0) {
				double sinLambda = Math.Sin(lambda);
				double cosLambda = Math.Cos(lambda);
				sinSigma = Math.Sqrt((cosU2*sinLambda) * (cosU2*sinLambda) + 
					(cosU1*sinU2-sinU1*cosU2*cosLambda) * (cosU1*sinU2-sinU1*cosU2*cosLambda));
				if (sinSigma==0) return 0;  // co-incident points
				cosSigma = sinU1*sinU2 + cosU1*cosU2*cosLambda;
				sigma = Math.Atan2(sinSigma, cosSigma);
				double sinAlpha = cosU1 * cosU2 * sinLambda / sinSigma;
				cosSqAlpha = 1 - sinAlpha*sinAlpha;
				
				if (cosSqAlpha != 0) {
					cos2SigmaM = cosSigma - 2*sinU1*sinU2/cosSqAlpha;
				} else {
					cos2SigmaM = 0;  // equatorial line: cosSqAlpha=0 (§6)
				}
				double c = f/16*cosSqAlpha*(4+f*(4-3*cosSqAlpha));
			    lambdaP = lambda;
			    lambda = dlonrad + (1-c) * f * sinAlpha *
					(sigma + c*sinSigma*(cos2SigmaM+c*cosSigma*(-1+2*cos2SigmaM*cos2SigmaM)));
			}
			if (iterLimit==0) throw(new ArgumentException("formula failed to converge")); 
			
			double uSq = cosSqAlpha * (a*a - b*b) / (b*b);
			double a1 = 1 + uSq/16384*(4096+uSq*(-768+uSq*(320-175*uSq)));
			double b1 = uSq/1024 * (256+uSq*(-128+uSq*(74-47*uSq)));
			double deltaSigma = b1*sinSigma*(cos2SigmaM+b1/4*(cosSigma*(-1+2*cos2SigmaM*cos2SigmaM)-
			    b1/6*cos2SigmaM*(-3+4*sinSigma*sinSigma)*(-3+4*cos2SigmaM*cos2SigmaM)));
			double s = b*a1*(sigma-deltaSigma);
  
			return s/1000;
		}
	    
	}	
}
