using System;
using static System.Console;

class programPlot{
	
static void Main(string[] args){
	int ndim = 1;
	foreach(var arg in args){
	var words = arg.Split(':');
	if(words[0] == "-dim")ndim = (int)float.Parse(words[1]);
	}
	WriteLine($"{ndim}");
	var A = matrix.random_matrix(ndim,ndim);
	var (Q,R) = QRGS.dec(A);
	
}//Main 

}//class
