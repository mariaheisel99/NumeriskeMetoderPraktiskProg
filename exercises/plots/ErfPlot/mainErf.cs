using System;
using static System.Console;

class main{
static void Main(){
	for(double x=-3 + 1.0/128;x<=3;x+=1.0/64){
		WriteLine($"{x} {sfuns.erf(x)}");	
	}//for

}//Main
}//class
