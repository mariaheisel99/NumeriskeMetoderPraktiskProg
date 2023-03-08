using System;
using static System.Math;
using static System.Console;
public static class LeastSquare{
	public static (vector,matrix) solQRdec(vector x, vector y, vector dy, Func<double,double>[] f){
		int n = x.size;
		int m = f.Length;
		//makes matrix A with Aik=fk(xi)/dyi and bi =yi/dyi
		matrix A = new matrix(n,m);
		vector b = new vector(n);
	
		for(int i = 0;i<n;i++){
			for(int k = 0;k<m;k++){
			double d = dy[i];	
			A[i,k]=f[k](x[i])/d;
			}
		b[i] = y[i]/dy[i];
		}

		//decomposing A=QR with QRGS.cs
		var (Q,R) = QRGS.dec(A);
		//solving with QRGS.cs
		vector c = QRGS.solve(Q,R,b);
		matrix S = QRGS.inverseA(A); //finds (A^TA)^-1
	
	return (c,S);	
        }
	//solQRdec

}//class
