using System;
using static System.Console;
using System.IO;
using static System.Math;
using System.Collections.Generic;

class main{
public static void Main(){
	WriteLine(" PartB: Quadratic spline ");
	WriteLine("\n A quadriatic spline has been implemented with derivative and integral by Object oriented programming.");
	WriteLine(" An indicative plot of quadratics spline can be seen in PlotB.svg, where the integrating and dericative also are plotted");
	WriteLine("Different dataset are used to test");
	string [] fileNames = {"data1_qspline.txt","data2_qspline.txt","data3_qspline.txt"};
	int n = 11; //number of data points
	int N = n*5; //number of z points
	StreamWriter[] files = new StreamWriter[fileNames.Length];
	double[] points = new double[n];
	for(int i = 0; i < n; i++)points[i]=-5+i;
	double[] cnst = new double[3];
	cnst[0] = -4; cnst[1] = 6.5; cnst[2]=-30;
	WriteLine("Makes test points for three different tables and the manually calculated would be");
	WriteLine("* {xi = i,yi = 1},\ti = -5,...,5 \t\t b_i = 0 \t\t c_i = 0");
	WriteLine("* {xi = i,yi = xi},\ti = -5,...,5 \t\t b_i = 1 \t\t c_i = 0");
	WriteLine("* {xi = i,yi = xi^2},\ti=-5,...,5\t\t b_i = 2x_i\t\t c_i = 1");
	WriteLine("OBS - for c_i=0 for i =-5 pr. choosen condition in qspline.cs therefor b_i = 2x-i+1 for i=-5");	
	WriteLine("The analytical are given below:");
	for(int i =0; i<3;i++){/* test datapoints*/
		files[i] = new StreamWriter(fileNames[i],append:false);
		var x = new vector(n);
		var y = new vector(n);
		for(int j = 0;j<n;j++){
			x[j] = points[j];
			y[j] = Pow(points[j],i);
			files[i].WriteLine($"{x[j]} {y[j]}");
		}//for loop
		var myspline = new qspline(x,y);
		files[i].WriteLine("\n");
		WriteLine(" ---------------------------------------------------------");
		x.print("x = ");
		y.print("y = ");		
		var b = myspline.b;
		b.print("bi = ");
		var c = myspline.c;
		c.print("ci = ");
		for(int k = 0;k<N;k++){
			double z = x[0]+k*(x[x.size -1]-x[0])/(N-1);
			var fz = myspline.eval(z);
			var dfz = myspline.derivative(z);
			var Fz = myspline.integral(z,cnst[i]);
		//	Error.WriteLine($"{z} {fz} {dfz}");
			files[i].WriteLine($"{z} {fz} {dfz} {Fz}");
		}
		files[i].Close();
	}//forloop	
	
	WriteLine("The found analytical b_i and c_i correspond find with manually calcualted");

}//MainB
}//mainB class
