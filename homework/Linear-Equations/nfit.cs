using System;
using static System.Math;
using static System.Console;

public class fit{
public static void Main(){
	for(double x=400;x<1100;x+=2.0){
		WriteLine($"{x} {1.5e-8*Pow(x,3)}");
	}
}
}
