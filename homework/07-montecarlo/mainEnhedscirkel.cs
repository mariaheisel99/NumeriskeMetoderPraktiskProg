using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(string[] args){
	int N = 1;
	N = (int)double.Parse(args[0]);
	
	//enhedscirkel test
	var r = 1;
	Func<vector, double> f = x =>{
		if(x.norm() <= r) return 1; //norm of vector x containg x and y in the total area is less than 1 inside unit circle
		else return 0;
		};
	vector a = new vector(-1.0,-1.0); //lower limit
	vector b = new vector(1.0,1.0); // upper limit
	int[] shift = new int[2] {0,2};
	(double mean_plain, double sigma_plain) = montecarlo_integrator.plainmc(f,a,b,N);
	(double mean_quasi, double sigma_quasi) = montecarlo_integrator.quasi_halton(f,a,b,N,shift);
	double true_val = PI;
	double fit = 1.0/Sqrt(N);
	WriteLine($"{N} {mean_plain} {sigma_plain} {Abs(true_val-mean_plain)} {mean_quasi} {sigma_quasi} {Abs(true_val-mean_quasi)} {fit}");		
	
		
	}//Main
}//class
