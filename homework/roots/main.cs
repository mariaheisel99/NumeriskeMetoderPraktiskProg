using System;
using static System.Console;
using static System.Math;


public static class main{
	public static void Main(){
		Func<vector,vector> f = x => new vector (2*x[0]);
		vector x0 = new vector(1);
		x0[0] = -0.5;
		var result = root_finder.newton(f,x0);
		result.print();

		//Func<vector,vector> h = x => new vector ((-2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0])), (200*(x[1] - x[0]*x[0])));
		Func<vector, vector> g = x => new vector(2*x[0]*Log(x[0])+x[0]);
		vector x1 = new vector(1);
		x1[0] = 3;
		WriteLine("\n NEW CALCUALTION \n");
		var result3 = root_finder.newton(g,x1);
		result3.print();


}//Main

}// class main
