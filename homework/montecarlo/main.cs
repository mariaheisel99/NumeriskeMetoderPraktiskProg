using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(string[] args){
	int N = 1;
	N = (int)double.Parse(args[0]);
	//enhedscirkel
	var r = 1;
	Func<vector, double> f = x =>{
		if(x.norm() <=r) return 1;
		else return 0;
		};
	vector a = new vector(0.0,0.0); //lower limit
	vector b = new vector(1.0,1.0); // upper limit
	(double mean, double sigma) = montecarlo_integrator.plainmc(f,a,b,N);
	double true_val = PI/4.0;
	WriteLine($"{N} {mean} {sigma} {Abs(mean-true_val)}");
	
		
	}//Main
}//class
