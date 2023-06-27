using System;


public class hydrogen{

public static double Fe(double E, double r, double rmin=1e-4, double acc = 0.01, double eps = 0.01){
	if(r<rmin) return r-r*r;
	/* -1/2f''-(1/r)f=ef => -f''-2*(-1/x+e)f=0 differential eq ODE solver used*/
	Func<double,vector,vector> s_wave = (x,y) => new vector (y[1],2*(-1/x-E)*y[0]);
	
	vector yrmin = new vector(rmin-rmin*rmin,1-2*rmin);
 	var xs = new genlist<double>();
        var ys = new genlist<vector>();
        var yrmax = ode.driver(s_wave, rmin, yrmin, r, xs, ys,0.01,acc,eps);

	return yrmax[0];	
}//Fe
}//class
