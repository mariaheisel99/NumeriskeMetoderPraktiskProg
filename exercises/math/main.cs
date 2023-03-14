using System;
using static System.Console;
using static System.Math;

public static class main{

	public static void Main(){
	
	double sqrt2 = Sqrt(2.0);
	Write($"sqrt(2) = {sqrt2}\n");

	Write($"2^(1/5) = {Pow(2,1.0/5.0)}\n");
	
	Write($"e^pi = {Pow(E,PI)}\n");

	Write($"pi^e = {Pow(PI,E)}\n");
	
	Write($"gamma(1) = {sfunc.gamma(1)}\n");


	Write($"gamma(2) = {sfunc.gamma(2)}\n");
	Write($"gamma(3) = {sfunc.gamma(3)}\n");
	Write($"gamma(10) = {sfunc.gamma(10)}\n");
	Write($"lngamma(-2) = {sfunc.lngamma(-2)}\n");
	Write($"lngamma(4) = {sfunc.lngamma(4)}\n");
	Write($"lngamma(10) = {sfunc.lngamma(10)}\n");
	}
}
