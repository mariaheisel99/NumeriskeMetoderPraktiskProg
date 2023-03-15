using System;
using static System.Console;

public class qspline {
	public vector x,y,b,c;
	public qspline (vector xs, vector ys){
		x = xs.copy();
		y = ys.copy();
		int n = x.size;
		b = new vector(n-1);
		c = new vector(n-1);
		var p = new vector(n-1);
		var h = new vector(n-1);
		for(int i=0; i<n-1; i++){
			h[i] = x[i+1]-x[i]; if(!(h[i]>0)) throw new Exception("uuups...");
			var dy = y[i+1]-y[i];
			p[i] = dy/h[i];
		}//forloop
	
		c[0] = 0;
		for(int i = 0;i<n-2;i++){
			c[i+1]=(p[i+1]-p[i]-c[i]*h[i])/h[i+1];
		}//forloop forward recursion
		c[n-2]/=2;
		for(int i = n-3;i>0;i--){
			c[i]=(p[i+1]-p[i]-c[i+1]*h[i+1])/h[i];
		}//forloop backward recursion
		for(int i = 0; i<n-1;i++){b[i]=p[i]-c[i]*h[i];}
	}//qspline

	public double eval (double z){
		int i = linespline.binsearch(x,z);
		return y[i]+(z-x[i])*(b[i]+(z-x[i])*c[i]); //interpolating polynomial

	}//eval

	public double derivative (double z){ /*evaluate the derivative */ 
		int i = linespline.binsearch(x,z);
		return b[i]+2*(z-x[i])*c[i];
		
		}//derivative

//	public double integral (double z){
//		double sum = 0;
//		int i = linespline.binsearch(x,z);
		
//	}//integral
}//class
		
					
	
