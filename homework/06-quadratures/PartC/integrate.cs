using System;
using static System.Console;
using static System.Math;

public class integrate{
	public static (double,double) integrator
		(Func<double, double> f,
		double a,
		double b,
		double delta = 0.001,
		double epsi = 0.001,
		double f2 = double.NaN, double f3 = double.NaN)
	{
	//Ensuring that b>a
	if(b<a){
		Func<double,double> newf =x => -f(x);
		return integrator(newf,a,b,delta,epsi);}
	//infinite integrals
	if (double.IsInfinity(b) && double.IsInfinity(a)){	
			Func <double,double> newf = x => f(x/(1-x*x))*(1+x*x)/Pow(1-x*x,2);
		return integrator(newf,-1,1,delta,epsi);}
	else if (double.IsInfinity(b)){
			Func<double,double> newf = x => f(a+x/(1-x))*1/(Pow(1-x,2));
		return integrator(newf, 0,1,delta,epsi);}
	else if (double.IsInfinity(a)){
		Func <double,double> newf = x => f(b+x/(1+x))/Pow(1+x,2);
		return integrator(newf,-1,0,delta,epsi);}
		
	double h = b-a;
	if(double.IsNaN(f2)){ f2 = f(a+2*h/6); f3 = f(a+4*h/6);} //in the first call there are no point to reuse
	double f1 = f(a+h/6), f4 = f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // the higher order rule
	double q = (f1+f2+f3+f4)/4*(b-a); // the lower order rule
	double err = Abs(Q-q); //the difference in higher and lower order
	double tol = delta + epsi*Abs(Q);
	if (err <= tol) return (Q,err);
	else{ 
		var (res1,err1) = integrator(f,a,(a+b)/2,delta/Sqrt(2),epsi,f1,f2);
		var (res2, err2) = integrator(f,(a+b)/2,b,delta/Sqrt(2),epsi,f3,f4);
		return (res1+res2, err1+err2);
	 }	
	}//integrate


	public static (double,double) ClenshawCurtisTransformation
		(Func<double, double> f,
                double a,
                double b,
                double delta = 0.001,
                double epsi = 0.001)
	{
		
	//Ensuring that b>a
	if(b<a){
		Func<double,double> newf =x => -f(x);
		return ClenshawCurtisTransformation(newf,a,b,delta,epsi);}
	//infinite integrals
	if (double.IsInfinity(b) && double.IsInfinity(a)){	
			Func <double,double> newf = x => f(x/(1-x*x))*(1+x*x)/Pow(1-x*x,2);
		return ClenshawCurtisTransformation(newf,-1,1,delta,epsi);}
	else if (double.IsInfinity(b)){
			Func<double,double> newf = x => f(a+x/(1-x))*1/(Pow(1-x,2));
		return ClenshawCurtisTransformation(newf, 0,1,delta,epsi);}
	else if (double.IsInfinity(a)){
		Func <double,double> newf = x => f(b+x/(1+x))/Pow(1+x,2);
		return ClenshawCurtisTransformation(newf,-1,0,delta,epsi);}
		
	Func<double,double> h = (theta) => f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;	

	return integrator(h,0,PI,delta,epsi);


	}//CleshawCurtisTransformation
}//class
