using System;
using static System.Console;
using static System.Math;

public class jacobi{

// Function that multiplies matrix A and Jacobi matrix
public static void timesJ(matrix A, int p, int q, double theta){
	double c = Cos(theta), s = Sin(theta);
	var n = A.size1;
	for(int i = 0; i <n;i++){
		double aip = A[i,p], aiq = A[i,q];
		A[i,p] = c*aip-s*aiq;
		A[i,q] = s*aip + c*aiq;
		}
	}// timesJ
	
//Function that multiplies the Jacobi matrix and matrix A
public static void Jtimes(matrix A, int p, int q, double theta){
	double c = Cos(theta), s=Sin(theta);
	var n = A.size1;
	for(int j=0;j<n;j++){
		double apj = A[p,j], aqj = A[q,j];
		A[p,j] = c*apj+s*aqj;
		A[q,j] = -s*apj+c*aqj;
		}
	}// Jtimes

public static (matrix, matrix) cyclic(matrix A){
	int n = A.size1;
	var D = A.copy();
	var V = new matrix(n,n);
	V.set_identity();
	
	bool changed;
	do{
		changed=false;
		for(int p=0;p<n-1;p++){
		for(int q=p+1;q<n;q++){
			double apq = matrix.get(D,p,q);
			double app = matrix.get(D,p,p);
			double aqq = matrix.get(D,q,q);
			double theta = 0.5*Atan2(2*apq,aqq-app);
			double c = Cos(theta), s = Sin(theta);
			double new_app = c*c*app-2*s*c*apq+s*s*aqq;
				//WriteLine($"app={app}");
			double new_aqq = s*s*app + 2*s*c*apq+c*c*aqq;
			if(new_app!=app || new_aqq!=aqq) //do the rotation
			{
			changed = true;
			timesJ(D,p,q,theta);
			Jtimes(D,p,q,-theta); // A<-J^T*A*J
			timesJ(V,p,q,theta); //V<-V*J
		 	}
		
		}//for loop
		}//for loop
		//WriteLine($"Changed: {changed}");	
	}while(changed);
return (D,V);			
}//cyclic

}//class jacobi
