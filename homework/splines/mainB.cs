using System;
using static System.Console;
using System.IO;
using static System.Math;

class main{
public static void Main(){
	WriteLine(" PartB: Quadratic spline ");
	WriteLine("\n A quadriatic spline has been implemented with derivative and integral by Object oriented programming.");
	string [] fileNames = {"data1_qspline.txt","data2_qspline.txt","data3_qspline.txt"};
	int n = 11; //number of data points
	int N = n*5; //number of z points
	StreamWriter[] files = new StreamWriter[fileNames.Length];
	double[] points = new double[n];
	for(int i = 0; i < n; i++)points[i]=-5+i;

	double[] cnst = new double[3];
	cnst[0] = -4; cnst[1] = 6.5; cnst[2]=-30;
	WriteLine("Makes test points for three different tables \n * {xi = i,yi=1}, i = -5,...,5\n * {xi = i,yi = xi}, i = -5,...,5 \n * {xi = i, yi = xi^2}, i=-5,...,5\n");	
	for(int i =0; i<3;i++){/* test datapoints*/
		files[i] = new StreamWriter(fileNames[i],append:false);

		var x = new vector(n);
		var y = new vector(n);
		for(int j = 0;j<n;j++){
			x[j] = points[j];
			y[j] = Pow(points[j],i);
			files[i].WriteLine($"{x[j]} {y[j]}");
		}//for loop
		//Error.WriteLine($" i = {i}");
		var myspline = new qspline(x,y);
		files[i].WriteLine("\n");
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
	
	//WriteLine("Plots o

}//MainB
}//mainB class
