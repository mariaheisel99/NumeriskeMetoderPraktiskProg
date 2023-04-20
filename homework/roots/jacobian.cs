using System;
using static System.Console;
using static System.Math;
public static partial class roots{

public static double DELTA = Pow(2,-26);

public static matrix jacobian
(Func<vector,vector> f,vector x,vector fx=null,vector dx=null){
//	if(dx == null) dx = x.map(t => Max(Abs(t),1)*DELTA);
	if(dx == null) dx = x.map(t => Abs(t)*DELTA);
	var n = x.size;
	matrix J = new matrix(n,n);
	if(fx == null)fx=f(x);
	for(int j=0;j<x.size;j++){
		x[j]+=dx[j];
		dx.print("jacob cx rigtige ");
		vector df=f(x)-fx;
		for(int i=0;i<x.size;i++){
			 J[i,j]=df[i]/dx[j];
			Error.Write($" rigtige {dx[j]} ");}
		x[j]-=dx[j];
		}
	return J;
}

}//roots
