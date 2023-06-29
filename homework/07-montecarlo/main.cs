using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
	int N = 50000;
	WriteLine("-----Two and three dimensional integral with MC routin for both part A (plain) and the quasi-random sequence part B. ----");
	//First test of integral 
	WriteLine("* Integration test of a 2 dimensional function x*cos(y) with x[0,1] and y[0,pi/2]");
	Func<vector, double> f = x =>x[0]*Cos(x[1]);
	vector a = new vector(0,0); //lower limit
	vector b = new vector(1.0,PI/2.0); // upper limit
	int[] shift = new int[2] {0,2};
	(double mean_plain, double sigma_plain) = montecarlo_integrator.plainmc(f,a,b,N);
	(double mean_quasi, double sigma_quasi) = montecarlo_integrator.quasi_halton(f,a,b,N,shift);
	double true_val = 1.0/2;

	WriteLine(" ### Plain Monte Carlo integration ### ");
	WriteLine($"result = {mean_plain} error {sigma_plain}");
	WriteLine($"The actual error from true value: {Abs(mean_plain-true_val)}");
	Write("\n");
	WriteLine(" ### Quasi-random Monte Carlo integration ### ");
	WriteLine($"result = {mean_quasi} error {sigma_quasi}");
	WriteLine($"The actual error from true value: {Abs(mean_quasi-true_val)}");
			
	Write("\n\n\n");
	WriteLine(" * Integration of a 3 dimensional function (1-cos(x)*cos(y)*cos(z))^-1*pi^-3 with x[0,pi] and y[0,pi] and z[0,pi]");
	Func<vector, double> g = x =>1.0/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,-3);
	vector c = new vector(0,0,0); //lower limit
	vector d = new vector(PI,PI,PI); // upper limit

	(double mean_plain2, double sigma_plain2) = montecarlo_integrator.plainmc(g,c,d,N);

	(double mean_quasi2, double sigma_quasi2) = montecarlo_integrator.quasi_halton(g,c,d,N,shift);

	double true_val2= Pow(sfuns.gamma(1.0/4),4)/(4*Pow(PI,3));
	Error.Write($"value {true_val2}");
	WriteLine(" ### Plain Monte Carlo integration ### ");
	WriteLine($"result = {mean_plain2} error {sigma_plain2}");
	WriteLine($"The actual error from true value: {Abs(mean_plain2-true_val)}");
	Write("\n");
	WriteLine(" ### Quasi-random Monte Carlo integration ### ");
	WriteLine($"result = {mean_quasi2} error {sigma_quasi2}");
	WriteLine($"The actual error from true value: {Abs(mean_quasi2-true_val2)}");
	
	WriteLine(" ---- A calculateion of area on unit circle is performed with both MC integrator ( pseudo-random and quasi-radnaom) -----");
	WriteLine(" The results are seen in the mcUNitCircle.svg and ErrorEstiamed.svg. It is checked to scale with 1/sqrt(N)");
		
	}//Main
}//class
