using System;
using static System.Console;
using System.IO;
using static System.Math;

class main{
public static void Main(){
	WriteLine("Part A is performed where the linespline.cs is built with the procedurial style.\n The ");
	StreamWriter datapoints = new StreamWriter("datapoints.txt", append:false);
	StreamWriter linterpdata = new StreamWriter("linterpdata.txt", append:false);
	StreamWriter linintgdata = new StreamWriter("linintgdata.txt", append:false);

	int n = 8; //number of datapoints 
	int N = 10*n;// number of z values
	var x = new double[n];
	var y = new double[n];
	
	for(int i = 0 ; i<n;i++){/* generating n datapoints random*/
		double r = (2*PI)/n;
		x[i] = r*i;
		y[i] = Cos(x[i]);
		datapoints.WriteLine($"{x[i]} {y[i]}");
		}//for loop
	datapoints.Close();

	for(int i = 0;i<N;i++){/*genereates N z values and makes lineterp for them with x and y*/
		double z = x[0] + i*(x[n-1]-x[0])/(N-1);
		var s = linespline.linterp(x,y,z);
		var S = linespline.linterpInteg(x,y,z);
		linterpdata.WriteLine($" {z} {s}");
		linintgdata.WriteLine($" {z} {S}"); 
	}//forloop
	linterpdata.Close();
	linintgdata.Close();
	

			
	
	
	

}//Main
}//main class
