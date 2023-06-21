using System;
using static System.Math;

public class cholesky{
	public matrix L;

	public cholesky (matrix A) {/* decomp. with Cholesky decompostion with The Chloesky-Banachiewicz and Chloesky-Crout algorithms*/

		var m = A.size2;
		L = new matrix(m,m);
		for (int j = 0; j<m;j++){
			double sum = 0;
			for(int k=0;k<j;k++) sum+=L[j,k]*L[j,k];
			L[j,j] = Sqrt(A[j,j]-sum);
			
			for(int i=j+1;i<m;i++){
				double sum2 = 0;
				for(int k=0;k<j;k++) sum2+=L[i,k]*L[j,k];
				L[i,j]=1/L[j,j]*(A[i,j]-sum2);
			}//for loop
		}//for loop
	}//cholesky

	public vector solve(vector b){
		//Forward substitution solving Ly=b
		vector y = b.copy();
		for(int i = 0;i<b.size;i++){
			double sum = 0;
			for(int j=0;j<i;j++) sum+=L[i,j]*y[j];
		y[i]=(y[i]-sum)/L[i,i];
		}
		
		//backward substitution solving L.T*x=y
		vector x = y.copy();
		matrix LT = L.T;
		for (int i =x.size - 1; i >= 0;i--){
                        double sum = 0;
                        for(int k=i+1;k<x.size; k++) sum+=LT[i,k]*x[k];
               	x[i]=(x[i]-sum)/LT[i,i];
                }
        return x;
			
		}//solve

}//class
