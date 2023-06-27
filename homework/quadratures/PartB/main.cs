using System;
using static System.Console;
using static System.Math;

class main{

public static void Main(){

	Func<double, double> f;
	int ncalls = 0;
	WriteLine(" ###### Test of  (open quandrature) adaptive integrator with added Clenshaw–Curtis variable transformation #######");
	WriteLine(" Test pefromed with some integrals with integrable divergencies at the end-point. Comaped with ordinary integrator with out variable transformation");
	Write("\n\n");	
	WriteLine(" # Integrating 1/sqrt(x) from 0 to 1");
	f = delegate(double x){ncalls ++; return 1.0/Sqrt(x);};
	ncalls = 0;	var (result_wo_trans,err_wo_trans) = integrate.integrator(f,0,1); 
	WriteLine($"Result without transformation {result_wo_trans}. Called {ncalls}");
	ncalls = 0;	var (result_w_trans,err_w_trans) = integrate.ClenshawCurtisTransformation(f,0,1);
	WriteLine($"Result with transformation {result_w_trans}. Called {ncalls}");
	
	Write("\n\n");	

	WriteLine(" # Integrating ln(x)/sqrt(x) from 0 to 1");
	f = delegate(double x){ncalls ++; return Log(x)/Sqrt(x);};
	ncalls = 0; var (result_wo_trans2,err_wo_trans2) = integrate.integrator(f,0,1); 
	WriteLine($"Result without transformation {result_wo_trans2}. Called {ncalls}");
	ncalls = 0; var (result_w_trans2,err_w_trans2) = integrate.ClenshawCurtisTransformation(f,0,1);
	WriteLine($"Result with transformation {result_w_trans2}. Called {ncalls}");

	Write("\n\n");	
	WriteLine(" #### results from python scipy is given as: ####");
	WriteLine(" result for 1/Sqrt(x) is 2.0000000000000004 and it is called 231");

	Write("\n\n");	
	WriteLine(" result for ln(x)/Sqrt(x) is . -3.999999999999974 and it is called 315");

	WriteLine($" test {err_w_trans2}");

}//Main



}//main
