using System;
using static System.Console;
using static cmath;
using static System.Math;
public static class main{
	
	public static void Main(){
	
	var z = sqrt(-1);
	WriteLine($"sqrt(-1) = {z}");
	WriteLine($"NaN = {complex.NaN}");

	var z2 =I;
	WriteLine($"sqrt(i) = {z2}");

        WriteLine($"e^i = {exp(z2)}");
	
	var z3 = Math.PI;
        WriteLine($"e^(i pi) = {exp(z2*z3)}");

	WriteLine($"i^i = {cmath.pow(z2,z2)}");

        WriteLine($"ln(i) = {log(z2)}");
	
	WriteLine($"sin(i pi) = {sin(z3*z2)}");
	
	WriteLine($"sinh(i) = {sinh(z2)}");
	WriteLine($"cosh(i) = {cosh(z2)}");


}
}

