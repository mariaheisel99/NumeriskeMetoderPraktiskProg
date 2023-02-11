using System;
using static System.Console;
using static System.Math;


public static class main{
	public static bool approx
	(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}
	
	public static void Main(){
	// 1.Maximum/minimum representable integers
	WriteLine("1");
	WriteLine("Max values");	
	int i=1;
	while(i+1>i) {i++;}
	Write("my max int = {0}\n",i);	
	Write("MaxValue largest possible ={0}\n",int.MaxValue);
	
	WriteLine("Min value"); 
	int j=1;
	while(j-1<j) {j--;}
	Write("my min int = {0}\n",j);
	Write("MinValue returns = {0}\n", int.MinValue);

	//2. Macing epsilon
	WriteLine("2");

	double x = 1;
	while(1+x!=1){x/=2;} // Finder mindste mulige værdi af x sådan at 1+x = 1, ved at gentagende dividere med 2.	
	x*=2;
	Write("machine epsilon for doubles = {0}\n", x);	

	float y=1F; 
	while((float)(1F+y) != 1F){y/=2F;} // Finder mindste mulige værdi af y sådan at 1F+y = 1F, ved at gentagende dividere med 2F.
	y*=2F;
	Write("machin epsilon for float = {0}\n" ,y);
	
	// Tjek for mackhine epsilon float
	double check_float = Pow(2,-23);
	double check_double = Pow(2,-52);

	Write("check for machine epsilon float med 2^(-23) = {0}\n", check_float);
	Write("check for machine epsilon double med 2^(-52) = {0}\n", check_double);

	
	// 3 Antag at tiny=epsilon/2 og beregn to sum, antaler at epsilon er for double 
	WriteLine("3");
	int n = (int)1e6;
	double epsilon = Pow(2,-52);
	double tiny = epsilon/2;
	double sumA=0, sumB=0;
	
	// sumA=1+tiny+tiny+..+tiny
	sumA+=1; 
	for (int k = 0;k<n;k++){sumA+=tiny;}
	// sumB = tiny + tiny +..+ tiny +1
	for (int k = 0; k<n;k++){sumB+=tiny;}
	sumB+=1;

	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");

	WriteLine("Different in the sums is due to the accumulation of round of errors, due to limitations of the floating-point representation used by the double type. The order of the addition of +1 can make a different \n. ");

	//4. Equality operator "=="
	WriteLine("4");
	
	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;

	WriteLine($"d1={d1:e15}");
	WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 ? => {d1==d2}");
	


	WriteLine("Function approx test");
	WriteLine($"d1={d1:e15}");
        WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 for approx function ? => {approx(d1,d2)}");

	}


}
