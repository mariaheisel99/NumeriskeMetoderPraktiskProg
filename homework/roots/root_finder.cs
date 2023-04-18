using System;
using static System.Console;
using static System.Math;


public static class root_finder{

	public static vector newton(Func<vector, vector> f, vector x, double epsi = 1e-2){
		
		int n = x.size;
		var dfdx = new vector(n);
		matrix J = new matrix(n,n);
		double deltax = 0; 
		vector Deltax = new vector(n);	
	
	
		do{	
			//Calculate the Jacobian matrix J
			for (int k = 0;k<n; k++){
				vector xs = x.copy();
				deltax = Abs(x[k])*Pow(2,-26);
				xs[k] = xs[k]+deltax;	
				dfdx = (f(xs)-f(x))/deltax;
					for(int i = 0; i<n; i++){
						J[k,i] = dfdx[i];
				}//for loop
			}//forloop
			J.print("Jacobain matrix  = ");

			//solve JDeltax = -f(x) for Deltax with QR
			var test = f(x);
			test.print("f(x) = ");
			var (Q,R) = QRGS.dec(J);
			Deltax = QRGS.solve(J,R,-1.0*f(x));
			Deltax.print("Delta x solved = ");
		
			double lambda = 1;
			do {
				lambda = lambda/2.0;
			}while((f(x + lambda*Deltax)).norm() > (1-lambda/2.0)*(f(x)).norm() && lambda > 1/32);

			x.print("x = ");	
			x = x + lambda*Deltax;
		
		}while((f(x).norm() > epsi)  || (Deltax.norm() > deltax));

		return x;


	}//newton



}//class
