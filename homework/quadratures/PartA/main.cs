using System;
using static System.Console;
using static System.Math;

class main{

public static void Main(){
	Func<double,double> f; 

	WriteLine("######### Test of recusive adaptive integrator on different integrals #########");
	WriteLine("");
	f = delegate(double x){return Sqrt(x);};
	var result1 = integrate.integrator(f,0,1);
	var exact1 = 2.0/3;	
	WriteLine($"int[0;1] sqrt(x) = {result1}");
	WriteLine($"Test result with error 1e-3 acceptance of (exact = {exact1}): {complex.approx(exact1,result1,1e-3,1e-3)}");

	WriteLine("");
	f = delegate(double x){return 1.0/Sqrt(x);};
	var result2 =  integrate.integrator(f,0,1,1e-6,0);	
	var exact2 = 2.0;
	WriteLine($"int[0;1] 1/sqrt(x) = {result2}");
	WriteLine($"Test result with error 1e-6 acceptance of (exact = {exact2}): {complex.approx(exact2,result2,1e-6,1e-6)}");

	
	WriteLine("");
	f = delegate(double x){return 4.0*Sqrt(1-Pow(x,2));};
	var result3 =  integrate.integrator(f,0,1,1e-6,0);	
	var exact3 = PI;
	WriteLine($"int[0;1] 4*sqrt(1-x^2) = {result3}");
	WriteLine($"Test result with error 1e-6 acceptance of (exact = {exact3}): {complex.approx(exact3,result3,1e-6,1e-6)}");

	WriteLine("");
	f = delegate(double x){return Log(x)/Sqrt(x);};
	var result4 =  integrate.integrator(f,0,1,1e-6,0);	
	var exact4 = -4.0;
	WriteLine($"int[0;1] ln(x)/sqrt(x) = {result4}");
	WriteLine($"Test result with error 1e-6 acceptance of (exact = {exact4}): {complex.approx(exact4,result4,1e-6,1e-6)}");
	
	


}//Main


}//class main
