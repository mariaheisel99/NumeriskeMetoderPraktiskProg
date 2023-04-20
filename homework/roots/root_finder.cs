using System;
using static System.Console;
using static System.Math;


public static class root_finder{

	public static vector newton(Func<vector, vector> f, vector x, double epsi = 1e-2){
		vector fx=f(x),z,fz;	
		vector Deltax, dx;
		int n = x.size;
		var df = new vector(n);
		matrix J = new matrix(n,n);
		double Delta = Pow(2,-26);	
	
		do{	
			//Calculate the Jacobian matrix J
			dx = x.map(t => Abs(t)*Delta);	
			for (int k = 0;k<n; k++){
				x[k] += dx[k];	
				dx.print("dx test");
				df = (f(x)-fx);
				f(x).print("f(x) = ");
				fx.print("fx = ");
				df.print("df = " );
					for(int i = 0; i<n; i++){
						J[k,i] = df[i]/dx[i];
					x[k]-=dx[k];
				}//for loop 
			}//forloop
			J.print("Jacobain matrix  = ");
			var (Q,R) = QRGS.dec(J);
			Deltax = QRGS.solve(J,R,-1.0*f(x));
			//Deltax.print("Delta x solved = ");
			
			double lambda = 1;
			do { //backtracing linesearch
				lambda /= 2.0;
				z = x + lambda*Deltax;
				fz = f(z);
			}while(fz.norm() > (1-lambda/2.0)*fx.norm() && lambda > 1/32);
			z.print("z = ");	
			x = z;
			fx = fz;
		
		}while(fx.norm() > epsi  || (Deltax.norm() > dx.norm()));

		return x;



	}//newton



}//class
