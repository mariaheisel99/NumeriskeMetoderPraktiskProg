using System;
using System.IO;
using static System.Console;
using static System.Math;

public class mainB{

public static void Main(string [] args){
	double rmax = 10; double dr = 0.3; bool wave = false;
	if(args.Length > 0) {
		foreach(var arg in args){
			var words = arg.Split(':');
			if (words[0] == "-dr") dr = double.Parse(words[1]);
			if (words[0] == "-rmax") rmax = double.Parse(words[1]);
			if (words[0] == "-wave") {	
				wave = bool.Parse(words[1]);
				}
			}
		
}
 	hydrogen hydrogenH = new hydrogen(rmax,dr);
        var (e0, ve0) =hydrogenH.lowest_energy();
	if(wave) {
		for(int i = 0; i<hydrogenH.r.size; i ++){
			WriteLine($"{hydrogenH.r[i]} {ve0[i]/Sqrt(dr)}");
		}
	WriteLine("\n");
	}
	else
	{
	        WriteLine($"{rmax} {dr} {e0}");
	}
	
	if(args.Length == 0) {
	WriteLine("");
	WriteLine("Part B");
	WriteLine("Hamiltonian and jacobi routine for the s-wave of hydrogen atom");
	WriteLine("A calculation of the hydrogen has been performed by following investigations:");
	WriteLine(" ** Convergens have beeen investigated on Dr_convergens.svg and Rmax_convergens.svg for severeal dr and rmax values");
	WriteLine(" ** Plot of different lowest eigen-functions are performed for different dr and rmax paramerets. The result are shown on Wave.svg. The exponentiel analytical function are also demonstrated.");

	using (StreamWriter file1 = new StreamWriter("output_analytical_wave.txt", false)){
	for(int i = 0; i < 100; i++){
		file1.WriteLine($"{i/10.0}\t{Exp(-i/10.0)}");}
	}
		}

	}//Main
}//class main

