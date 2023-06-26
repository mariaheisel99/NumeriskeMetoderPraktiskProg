using System;
using static System.Console;
using static System.Math;

class main{

    public static double Erffunc(double z){

        Func<double,double> f;
        if(z<0){
            var result1 = -Erffunc(-z);
            return (result1);
        }
        if((z >= 0) && (z <= 1.0)){
            f = delegate(double x){return Exp(-Pow(x,2));};
            var result2 = integrate.integrator(f,0,z);
            return (2.0/Sqrt(PI)*result2);
        }
        if(z > 1.0){
            f = delegate(double t){return Exp(-Pow((z+(1-t)/t),2))/t/t;};
            var result3 = integrate.integrator(f,0,1);
            return (1-2.0/Sqrt(PI)*result3);
        }
        // Default return statement
        return 0.0;
   }

public static void Main(){
	for(double x=-3 + 1.0/128;x<=3;x+=1.0/64){
		WriteLine($"{x} {sfuns.erf(x)}");
			
	}//for
	Write("\n\n");

	for(double z =-3+1.0/68;z<3;z+=1.0/4){
		WriteLine($"{z} {Erffunc(z)}");

}
//	Func<double,double> f2,f3; 
//	f2 = delegate(double x){return Exp(-Pow(x,2));};
	

//	for(double z=0+1.0/68;z<1;z+=1.0/8){
//		var result = integrate.integrator(f2,0,z);
//		WriteLine($" {z} {2.0/Sqrt(PI)*result}");
//		}//for loop
//	for(double z=1+1.0/68;z<3;z+=1.0/8){
//		f3 = delegate(double t){return Exp(-Pow((z+(1-t)/t),2))/t/t;};
//		var result = integrate.integrator(f3,0,1);
//		WriteLine($" {z} {1-2.0/Sqrt(PI)*result}");
//		}
}//Main
}//class main
