using System;
using static System.Console;
using System.IO;
using static System.Math;

class main{
public static void Main(){
	WriteLine("Part A is performed where the linespline.cs is built with the procedurial style. \n # It does the interpolation with linesplines and also integrate the linear spline from point x0 to a given point. \n\n # The linearspline test is performed on a cos(x) points. The result can be seen on PlotA.svg ");
	StreamWriter datapoints = new StreamWriter("datapoints.txt", append:false);
	StreamWriter linterpdata = new StreamWriter("linterpdata.txt", append:false);
	StreamWriter linintgdata = new StreamWriter("linintgdata.txt", append:false);

	int n = 8; //number of datapoints 
	int N = 10*n;// number of z values
	var x = new double[n];
	var y1 = new double[n];
	var y2 = new double[n];

	for(int i = 0 ; i<n;i++){/* generating n datapoints random*/
		double r = (2*PI)/n;
		x[i] = r*i;
		y1[i] = Cos(x[i]);
		y2[i] = 2*x[i];
		datapoints.WriteLine($"{x[i]} {y1[i]} {y2[i]}");
		}//for loop
	datapoints.Close();

	for(int i = 0;i<N;i++){/*genereates N z values and makes lineterp for them with x and y*/
		double z = x[0] + i*(x[n-1]-x[0])/(N-1);
		var s1 = linespline.linterp(x,y1,z);
		var S1 = linespline.linterpInteg(x,y1,z);
		var s2 = linespline.linterp(x,y2,z);
		var S2 = linespline.linterpInteg(x,y2,z);
		linterpdata.WriteLine($" {z} {s1} {s2}");
		linintgdata.WriteLine($" {z} {S1} {S2}"); 
	}//forloop
	linterpdata.Close();
	linintgdata.Close();
	
	
	

}//Main
}//main class
