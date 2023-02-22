using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
class main{

public static int Main(string[] args){
	int nterms=(int)1e8;
	foreach(var arg in args)
	{
		var words = arg.Split(':');
		if(words[0]=="-terms"  )nterms  =(int)float.Parse(words[1]);
	}
	
	double sum=0;
	//WriteLine("Ordinary serial loop result:");
	//for(int i=1;i<nterms+1;i++){sum+=1.0/i;}
	WriteLine("harmonic sum Parallal.For loop result:");
	Parallel.For( 1, nterms+1, delegate(int i){ sum+=1.0/i;} );
	WriteLine($"nterms={nterms} sum={sum}");

	return 0;
	}

}
