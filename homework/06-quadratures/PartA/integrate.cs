using System;
using static System.Console;
using static System.Math;

public class integrate{
	public static double integrator
		(Func<double, double> f,
		double a,
		double b,
		double delta = 0.001,
		double epsi = 0.001,
		double f2 = double.NaN, double f3 = double.NaN)
	{
	double h = b-a;
	if(double.IsNaN(f2)){ f2 = f(a+2*h/6); f3 = f(a+4*h/6);} //in the first call there are no point to reuse
	double f1 = f(a+h/6), f4 = f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // the higher order rule
	double q = (f1+f2+f3+f4)/4*(b-a); // the lower order rule
	double err = Abs(Q-q); //the difference in higher and lower order
	double tol = delta + epsi*Abs(Q);
	if (err <= tol) return Q;
	else return integrator(f,a,(a+b)/2,delta/Sqrt(2),epsi,f1,f2)+integrator(f,(a+b)/2,b,delta/Sqrt(2),epsi,f3,f4);
	}//integrate



}//class
