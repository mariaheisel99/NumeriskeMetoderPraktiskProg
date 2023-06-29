using System;
using static System.Console;
using static System.Math;
using System.IO;

public static class main{
		public static double rmax, rmin;
		
		public static void Main(string [] args){
			rmax = 8; rmin = 1e-3;
			double acc = 0.01; double eps = 0.01;
			bool wave = false;
			if(args.Length > 0){
				foreach(var arg in args){
				var words = arg.Split(':');
				if (words[0] == "-rmax") rmax = double.Parse(words[1]);
				if (words[0] == "-rmin") rmin = double.Parse(words[1]);
				if (words[0] == "-acc") acc = double.Parse(words[1]);
				if (words[0] == "-eps") eps = double.Parse(words[1]);
				if (words[0] == "-wave") {
					wave = bool.Parse(words[1]);}
				}
			}
	
			Func<vector,vector> F_function = (vector v) => {
				double e=v[0];
				double Frmax = hydrogen.Fe(e,rmax,rmin, acc, eps);
				return new vector (Frmax);};

			vector vstart = new vector(-1.0);
			var E0 = root_finder.newton(F_function,vstart);
			var energy = E0[0];


			if( wave ) {
			
//			StreamWriter outfile = new StreamWriter("wave_function.txt",false);
			for (double r=0; r<rmax; r+=rmax/128){
				var calF_r = hydrogen.Fe(energy,r);
				var exactF_r = r*Exp(-r);
				WriteLine($"{r} {calF_r} {exactF_r}");
				}
			WriteLine("\n");
			}
			else
				 {
				WriteLine($"{rmax} {rmin} {acc} {eps} {energy}");
				}

			if(args.Length == 0){
			WriteLine("\n");
			WriteLine("------ Part B ------- ");
			WriteLine("A hydrogen function is implemented that solved the radial Schrödinger equation at the lowest energy stat. This is done using the ODE solver from previusly homework. After this the root finding is used to estimate the energies for the solution of the hydrogens radial wave s-wave");
			
			WriteLine("\n Task: First the lowest root E0 are found for rmax = 8 this gave:");
			WriteLine($"Energy EO at rmax = {rmax}: E0 = {energy}");
			WriteLine("The loewst E0's wave function are plotted together with the exact result. See Plot_Swave.svg");
			WriteLine($"Investigation of convergence of the solutions toward the exact result of E0=-1/2 are performed for rmax, rmin and acc, eps of the ODE driver.\n The default parameteres, that are not changed when the convergens for the other parameter are invested are\n * rmax:{rmax} \n * rmin:{rmin} \n * acc:{acc} \n * eps:{eps} \n The result are seen on Convergens.svg"); 
			//outfile.Close();
				}
}//Main

}// class main
