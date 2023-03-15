using System;
using static System.Console;
using System.IO;
using static System.Math;

class main{
public static void Main(){

	StreamWriter datapoints = new StreamWriter("datapoints.txt", append:false);
	StreamWriter linterpdata = new StreamWriter("linterpdata.txt", append:false);
	StreamWriter linintgdata = new StreamWriter("linintgdata.txt", append:false);
	StreamWriter qinterpdata = new StreamWriter("qinterpdata.txt", append:false);

	var rnd = new System.Random();
	int n = 8; //number of datapoints 
	int N = 10*n;// number of z values
	var x = new double[n];
	var y = new double[n];
	
	for(int i =0; i<n;i++){/* generating n datapoints random*/
		x[i] = i;
		y[i] = rnd.NextDouble()*5;
		datapoints.WriteLine($"{x[i]} {y[i]}");
		}//for loop
	datapoints.Close();


	var myspline = new qspline(x,y);

	for(int i = 0;i<N;i++){/*genereates N z values and makes lineterp for them with x and y*/
		double z = x[0] + i*(x[x.Length -1]-x[0])/(N-1);
		var s = linespline.linterp(x,y,z);
		//var S = linespline.linterpInteg(x,y,z);
		linterpdata.WriteLine($" {z} {s}");
		//linintgdata.WriteLine($" {z} {S}"); 
		var fz = myspline.eval(z);
		qinterpdata.WriteLine($" {z} {fz}");
	}//forloop
	linterpdata.Close();
	qinterpdata.Close();
	

			
	
	
	

}//Main
}//main class
