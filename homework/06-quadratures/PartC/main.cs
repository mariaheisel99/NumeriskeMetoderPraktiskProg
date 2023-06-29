using System;
using static System.Console;
using static System.Math;

class main{

public static void Main(){

	Func<double, double> f1, f2, f3;
	int ncalls = 0;
	WriteLine(" ###### Test of  (open quandrature) adaptive integrator with Clenshaw–Curtis variable transformation for some (converging) infitine limit integrals and added error estimation ######");
	WriteLine(" Test pefromed with some integrals. Comapared with python integration routines with the same tolerance");
	Write("\n\n");	
	WriteLine(" # Integrating Exp(-x*x) from -inf to inf");
	f1 = delegate(double x){ncalls ++; return Exp(-x*x);};
	ncalls = 0;	var (result1,err1) = integrate.ClenshawCurtisTransformation(f1,-double.PositiveInfinity,double.PositiveInfinity);
	WriteLine($"Result: {result1}  , error: {err1}\nCalled {ncalls}");
	WriteLine(" #### results from python scipy is given as: ####");
	WriteLine(" result for exp(-x*x) is 1.7724538509067376 and it is called 150. It should be noted that scipy gave 4e-6 error");
	
	Write("\n\n");	

	WriteLine(" # Integrating Exp(x) from -inf to 0");
	f2 = delegate(double x){ncalls ++; return Exp(x);};
	ncalls = 0;	var (result2,err2) = integrate.ClenshawCurtisTransformation(f2,double.NegativeInfinity,0);
	WriteLine($"Result: {result2}  , error: {err2}\nCalled {ncalls}");
	WriteLine(" #### results from python scipy is given as: ####");
	WriteLine(" result for exp(x) is 0.9999999997018258 and it is called 75. It should be noted that scipy gave 5e-5 error");
	

	Write("\n\n");	

	WriteLine(" # Integrating 1/x^2 from 1 to inf");
	f3 = delegate(double x){ncalls ++; return 1/(x*x);};
	ncalls = 0;	var (result3,err3) = integrate.ClenshawCurtisTransformation(f3,1,double.PositiveInfinity);
	WriteLine($"Result: {result3}  , error: {err3}\nCalled {ncalls}");
	WriteLine(" #### results from python scipy is given as: ####");
	WriteLine(" result for 1/x^2 is 1.0 and it is called 15. It should be noted that scipy gave 1e-14 error");


}//Main



}//main
