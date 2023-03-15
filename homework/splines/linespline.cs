using System;
using static System.Console;

public class linespline{

//binsearch method
public static int binsearch(double [] x , double z)
	{/* locates the interval for z by bisection using x vector */
	if(!(x[0]<=z && z <=x[x.Length - 1])) throw new Exception("binsearch: bad z");
	int i = 0, j=x.Length-1;
	while(j-i>1){
		int mid = (i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
}//binsearch
public static double linterp(double[] x, double [] y, double z){
	int i = binsearch(x,z);
	double dx = x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uuups...");
	double dy = y[i+1]-y[i];
	return y[i]+dy/dx*(z-x[i]);
	}// linterp 

//public static double linterpInteg(double[] x, double[] y, double z){
//	int k = 0 ;//which x[k] we integrate from
//	if(!(x[k]>z))throw new Exception("wrong");
//	return y[k]*(z-x[k])+1.0/2*(y[k+1]-y[k])/(x[k+1]-x[k])*(z-x[k]);
//}//lineterpTnteg	

}//class 
