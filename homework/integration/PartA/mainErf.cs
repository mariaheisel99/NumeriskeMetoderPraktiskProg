using System;
using static System.Console;
using static System.Math;

class main{

public static void Main(){
	for(double x=-3 + 1.0/128;x<=3;x+=1.0/64){
		WriteLine($"{x} {sfuns.erf(x)}");	
	}//for
	
	Write("\n\n");
	
	Func<double,double> f; 
	f = delegate(double x){return Exp(-Pow(x,2));};
	for(double z=-2+1.0/68;z<3;z+=1.0/2){
		var result = integrate.integrator(f,0,z);
		WriteLine($" {z} {2.0/Sqrt(PI)*result}");
		}//for loop
}//Main


}//class main
