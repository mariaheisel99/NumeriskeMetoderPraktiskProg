using System;
using static System.Console;
using static System.Math;

public static partial class qnewton{

public static double delta = Pow(2,-26);

public static vector gradient(Func<vector,double>f, vector x){
	var n = x.size;
	vector dfdx = new vector(n);
	double fx = f(x);
	for (int i = 0; i<n;i++){
		double dx = Abs(x[i])*delta;
		x[i] += dx;
		dfdx[i] = (f(x)-fx)/dx;
		x[i] -= dx;
	}//forloop
	return dfdx;

}//gradient

public static matrix hessian(Func<vector,double> phi, vector x){
	var n = x.size;
	matrix H = new matrix(n,n);
	Func<vector,vector> g = z => gradient(phi,z);
	double delta = Pow(2,-13);
	vector dx = new vector(n);
	for(int i = 0; i<n;i++){dx[i]=Abs(x[i]*delta);}
	vector gx = g(x);
	for(int j=0;j<n;j++){
		x[j]+=dx[j];
		vector df = g(x)-gx;
		for(int k = 0;k<n;k++){
			H[k,j] = df[k]/dx[j];}
		x[j]-=dx[j];
	}//forloop
	return H;

}//hessian

public static int minimum(
	Func<vector,double>f, /* objective function */
	ref vector x, /* starting point */
	double acc /* accuracy goal, on exit |gradient| should be < acc */
	){
	vector gx=gradient(f,x);
	double fx = f(x);
	double epsilon = Pow(2,-26);
	int step = 0;
/*	
 
	matrix H = hessian(f,x);
	var (Q,R) = QRGS.dec(H);
	matrix B = QRGS.inverse(H);
*/
	var n = x.size;
	matrix B = matrix.id(n);

	while(gx.norm() > acc){
		step++;
		vector Dx = -B*gx;
	if(Dx.norm() < epsilon*x.norm() || Dx.norm() < acc){
		Error.WriteLine("dx < deltax");
		}
		vector z; 
		vector gz = new vector(n);
		double fz;
		double lambda = 1;
		do{ // backtracking linesearch
			z = x+lambda*Dx;
			fz = f(z);
			if(fz < fx){/*accept step and update SR1*/
				vector s = z-x;
				gz = gradient(f,z);
				vector y = gz-gx;
				vector u = s-B*y;
				double uTy = u%y;
				if(Abs(uTy)> acc){
					B.update(u,u,1/uTy);
				}
			break;}
			if(lambda < epsilon){
				B.setid();
				break;}
			lambda /= 2;			
		}while(true);
	x = z;
	gx = gz;
	fx = fz;
	}//while
	return step;
 
}//qnewton minimum
}//class
