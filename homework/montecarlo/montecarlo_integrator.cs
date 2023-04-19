using System;
using static System.Console;
using static System.Math;

public class montecarlo_integrator{
	public static (double,double) plainmc(Func<vector,double> f, vector a , vector b, int N){
		int dim = a.size; double V=1;
		for(int i = 0;i<dim;i++)V*=b[i]-a[i]; //volume of the regtangle from a lower bound and b upper bound
		double sum=0,sum2=0;
		var x = new vector(dim); 
		for(int i = 0; i<N;i++){
			var rnd = new Random();
			for(int k = 0;k<dim;k++)x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]); //rand number between a and b
			double fx = f(x); sum+=fx; sum2+=fx*fx;
			}
		double mean = sum/N;
		double sigma = Sqrt(sum2/N-mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;
	}//plainmc

	private static double corput(int n, int b){
		double q =0, bk=(double)1/b;
		while(n>0){
			q+= (n % b)*bk;
			n /= b;
			bk /= b;
		}
		return q;}

	private static vector halton(int n, int d, int shift=0){
		int[] Base = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
		int maxd = Base.Length;
		if(d > maxd){
			throw new System.Exception("Halton method does not work because the dimension is too high");
		} 
		vector x = new vector(d);
		for (int i = 0;i<d; i++){
			x[i] = corput(n,Base[i+shift]);
		}
		return x;
	} 

public static (double,double) quasi_halton(Func<vector,double> f, vector a , vector b, int N, int[] shift){
		int dim = a.size; double V=1;
		for(int i = 0;i<dim;i++)V*=b[i]-a[i]; //volume of the regtangle from a lower bound and b upper bound
		double sum1=0,sum2=0;
		var x = new vector(dim); 
		for(int i = 1; i<N/2;i++){
			var quasi_rnd = halton(i,dim,shift:shift[0]);
			for(int k = 0;k<dim;k++)x[k]=a[k]+quasi_rnd[k]*(b[k]-a[k]); //rand number between a and b
			double fx = f(x); sum1+=fx;
			}
		for(int i = 1; i<N/2;i++){
			var quasi_rnd = halton(i,dim,shift:shift[1]);
			for(int k = 0;k<dim;k++)x[k]=a[k]+quasi_rnd[k]*(b[k]-a[k]); //rand number between a and b
			double fx = f(x); sum2+=fx;
			}
		double mean = (sum1+sum2)/N;
		double sigma = Math.Abs(sum1-sum2)/N*2;
		var result = (mean*V,sigma*V);
		return result;
	}//quasi_halto
}//class
