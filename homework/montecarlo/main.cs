using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
	int N = 50000;
	
	//First test of integral 
	WriteLine("Integration test of a 2 dimensional function x*cos(y) with x[0,1] and y[0,pi/2]");
	Func<vector, double> f = x =>x[0]*Cos(x[1]);
	vector a = new vector(0,0); //lower limit
	vector b = new vector(1.0,PI/2.0); // upper limit
	(double mean, double sigma) = montecarlo_integrator.plainmc(f,a,b,N);
	double true_val = 1.0/2;
	WriteLine($"The value is = {mean} with error {sigma}");
	WriteLine($"The actual error from true value: {Abs(mean-true_val)}");		
	Write("\n\n");
	WriteLine("Integration of a 3 dimensional function (1-cos(x)*cos(y)*cos(z))^-1*pi^-3 with x[0,pi] and y[0,pi] and z[0,pi]");
	Func<vector, double> g = x =>1.0/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,-3);
	vector c = new vector(0,0,0); //lower limit
	vector d = new vector(PI,PI,PI); // upper limit
	(double mean2, double sigma2) = montecarlo_integrator.plainmc(g,c,d,N);
	double true_val2= Pow(sfuns.gamma(1.0/4),4)/(4*Pow(PI,3));
	Error.Write($"value {true_val2}");
	WriteLine($"The value is = {mean2} with error {sigma2}");
	WriteLine($"The actual error from true value: {Abs(mean2-true_val2)}");		
	
	
		
	}//Main
}//class
