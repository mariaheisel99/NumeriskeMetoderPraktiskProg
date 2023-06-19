using System;
using static System.Console;
using static System.Math;
using System.IO;
public class main{
	
	public static void Main(){
		
		WriteLine("------- Part A --------");
		WriteLine("Test of ann.cs are performed with training points for g(x)=Cos(5*x-1)*exp(-x^2)");
		WriteLine("The minimization of the cost function is performed with quasi-newton minimization");
		Func<double,double> Gw = x => x*Exp(-x*x); //Gaussian Wavelet
		Func<double,double> g = x => Cos(5*x-1)*Exp(-x*x);// test function g(x)
		//constructing x- and y-points
		WriteLine("Construting x and y trainingpoitns on the interval of -1 to 1 wiht 20 points. The Network is set up with 6 neurons");
		var outpoints = new StreamWriter("TrainPointsA.txt");
		int m = 20; //number of points
		double a = -1, b = 1; //interval
		vector xs = new vector(m), ys = new vector(m);
		for(int i = 0; i< m;i++){ //equal distributed uniform points
			xs[i] = a+(b-a)*i/(m-1);
			ys[i] = g(xs[i]);
			outpoints.WriteLine($"{xs[i]} {ys[i]}");
		 }//for loop
		outpoints.Close();
		//setting op network
		var Networkpoints = new StreamWriter("NetworkPointsA.txt");
		int n = 6;
		ann network = new ann(n,g);
		//Error.WriteLine($" newtork n = {network.n}");
		network.train(xs,ys); //training
		for(double j=a; j<b;j+=1.0/64){
		//	Error.WriteLine($" {j} {network.response(j)}");
			Networkpoints.WriteLine($"{j} {network.response(j)}");		
		}//forloop
		Networkpoints.Close();
	}//Main

}//main class
