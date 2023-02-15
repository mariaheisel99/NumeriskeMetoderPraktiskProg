using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(string[] args){
	Write("helleo\n");		
	foreach(string arg in args)System.Console.Out.Write(args);
	double [] numbers = input_get_numbers_from_args(args);
	foreach (double number in numbers)System.Console.Out.WriteLine($"{number:0.00e+00}");
	System.Console.Error.WriteLine("return code 0");
	}
}		
