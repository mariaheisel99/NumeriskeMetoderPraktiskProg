using System;
using static System.Console;
using static System.Math;
using System.IO;
class main{
	public static void Main(){
		WriteLine("############# Part A: ###########");
		WriteLine("QR-dec for tall matrices");
		var A = matrix.random_matrix(8,3);
		A.print("A = ");
		WriteLine($" n ={A.size1},m = {A.size2}");	
		var (Q,R) = QRGS.dec(A);
		Q.print("Q = ");
		R.print("R = ");
		var test1 = Q.T*Q;
		test1.print(" Q^T*Q = 1 ? =>");
		WriteLine("It is shown that QR decomposition works due to R is m x m upper triangular and Q is n x m and Q^T*Q=1");
		
		// definding some data and fitting it. Fitting results written to outPartA.txt
		StreamWriter outPartA = new StreamWriter("outPartA.txt", false);
		StreamWriter dataPartA = new StreamWriter("dataPartA.data",false);

		WriteLine("Measure of radioactivity of the element ThXat time, the data is defined and solving fit by QR decomposition. The result is the vector c:");	
		vector t = new vector(new double [] {1,2,3,4,6,9,10,13,15});
		vector y = new vector(new double [] {117,100,88,72,53,29.5,25.2,15.2,11.1});

		vector dy = new vector(new double [] {5,5,5,5,5,5,1,1,1,1});
		var fs = new Func<double,double>[] {z=> 1.0, z => z};

		vector lny = new vector(y.size);
		vector dlny = new vector(dy.size);
		for(int i = 0;i<y.size;i++){
			lny[i] = Log(y[i]);
			dlny[i] = dy[i]/y[i];
		}
		
		var c = LeastSquare.solQRdec(t, lny, dlny, fs); 		
		c.print("c = ");
		double lna = c[0];
		double a = Exp(lna);
		double lambda = -c[1];
		outPartA.WriteLine($"lambda = {lambda:f6}");
		outPartA.WriteLine($"T_0.5 = {Log(2)/lambda:f2} days");
		outPartA.Close();

		//data and generate fit data
		for(int i = 0; i<t.size;i++){
			dataPartA.WriteLine($"{t[i]} {y[i]} {dy[i]}");
			}
		dataPartA.Close();
		
		StreamWriter dataPartA_fit = new StreamWriter("dataPartA_fit.data",false);
		for(double i = 1.0/64;i<22;i+=1.0/64){
			double y_fit = a*Exp(-lambda*i);
			dataPartA_fit.WriteLine($"{i} {y_fit}");
			}
		dataPartA_fit.Close();
		
		
	} //Main
}//class maini
