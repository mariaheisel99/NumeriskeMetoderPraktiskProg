using System;
using static System.Console;
using static cmath;
using static System.Math;
public static class main{
	
	public static void Main(){
	
	var z = new complex(-1);
	WriteLine($"sqrt(-1) = {cmath.sqrt(z)}, theoretical = +-i");

	var z2 = new complex(0,1);;
	WriteLine($"sqrt(i) = {cmath.sqrt(z2)}, theoretical = 1/sqrt(2)+i/sqrt(2)=0.707+0.07i");

        WriteLine($"e^i = {exp(z2)}, theoretical = 0.54+0.84i");
	
	var z3 = Math.PI;
        WriteLine($"e^(i pi) = {exp(z2*z3)}, theoretical = -1");

	WriteLine($"i^i = {cmath.pow(z2,z2)}, theoretical = 0.208 ");

        WriteLine($"ln(i) = {log(z2)}, theoretical = ipi/2=1.57i");
	
	WriteLine($"sin(i pi) = {sin(z3*z2)}, theoretical = isinh(pi)=11.549i");
	
	WriteLine($"sinh(i) = {sinh(z2)}, theoretical = isin(1)=0.84i");
	WriteLine($"cosh(i) = {cosh(z2)}, theoretical = cos(1)=0.54");


}
}

