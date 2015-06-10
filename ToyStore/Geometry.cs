using System;

namespace Geomerty {
	
	class Point {
		
		private double positionX;
		private double positionY;
		
		public Point(double x, double y){
			this.positionX = x;
			this.positionY = y;
		}
		
		public double GetDistance(Point other){
			
			double deltaX = this.positionX - other.positionX;
			double deltaY = this.positionY - other.positionY;
			
			deltaX *= deltaX;
			deltaY *= deltaY;

			return Math.Sqrt((deltaX + deltaY));
			
		}
		
	}
	
	class Circle {
		
		private double radius;
		
		private Point center;
		
		
		
		public Circle(Point center, double radius){
			this.center = center;
			this.radius = radius;
		}
		
		
		public bool Intersect(Circle other){
			
			double distance = this.center.GetDistance(other.center);
			double sumRadius = this.radius + other.radius;
			
			if(distance < sumRadius){
				return true;
			} else {
				return false;
			}
						
		}
		
		
	}
	
	
}