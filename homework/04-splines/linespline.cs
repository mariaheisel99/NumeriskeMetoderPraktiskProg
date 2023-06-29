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

public static double linterpInteg(double[] x, double[] y, double z){
	int i = binsearch(x,z);//which x[k] we integrate from
	double sum = 0;
	for(int k = 0; k<i; k++){
		double dy = y[k+1]-y[k];
		double dx = x[k+1]-x[k];
		sum += y[k]*dx + 1.0/2*dy*dx;
	}//for loop
	double dxi = x[i+1]-x[i];
	double dyi = y[i+1]-y[i];
	sum += y[i]*(z-x[i])+1.0/2*(dyi/dxi)*(z-x[i])*(z-x[i]);

	return sum;
}//lineterpTnteg	

}//class 
