using System;
using static System.Console;
using System.IO;
using static System.Math;

class main{
public static void Main(){

	string [] fileNames = {"data1_qspline.txt","data2_qspline.txt","data3_qspline.txt"};
	int n = 5; //number of data points
	int N = n*10; //number of z points
	StreamWriter[] files = new StreamWriter[fileNames.Length];
		
	for(int i =0; i<3;i++){/* test datapoints*/
		files[i] = new StreamWriter(fileNames[i],append:false);
		var x = new vector(n);
		var y = new vector(n);
		for(int j = 0;j<n;j++){
			x[j] = j+1;
			y[j] = Pow(j+1,i);
			files[i].WriteLine($"{x[j]} {y[j]}");
		}//for loop
		//Error.WriteLine($" i = {i}");
		var myspline = new qspline(x,y);
		files[i].WriteLine("\n");
		for(int k = 0;k<N;k++){
			double z = x[0]+k*(x[x.size -1]-x[0])/(N-1);
			var fz = myspline.eval(z);
			var dfz = myspline.derivative(z);
			var Fz = myspline.integral(z);
		//	Error.WriteLine($"{z} {fz} {dfz}");
			files[i].WriteLine($"{z} {fz} {dfz} {Fz}");
		}
		files[i].Close();
	}//forloop	
	

}//MainB
}//mainB class