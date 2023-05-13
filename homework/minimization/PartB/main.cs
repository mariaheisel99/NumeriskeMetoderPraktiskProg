using System;
using static System.Console;
using static System.Math;

static class main{

    static System.Collections.Generic.List<double> energy, signal, error;

    public static int datapoints;

    public static double Dbreitwigner(vector x){
        double A = x[0];
        double m = x[1];
        double G = x[2];
        double Sum = 0;

        for(int i = 0; i < datapoints; i++){
            double E = energy[i];
            double y = signal[i];
            double dy = error[i];
            Sum += Pow((breitwigner(A, E, m, G) - y)/dy, 2);
        }

        return Sum;
    }

    public static double breitwigner(double A, double E, double m, double G){
        return A / (Pow(E - m, 2) + Pow(G, 2) / 4);
    }

    static void Main(){
        energy = new System.Collections.Generic.List<double>();
        signal = new System.Collections.Generic.List<double>();
        error  = new System.Collections.Generic.List<double>();

        System.IO.TextReader stdin = Console.In;
        var separators = new char[] {' ', '\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;

        do {
            string line = stdin.ReadLine();
            if (line == null) break;
            string[] words = line.Split(separators, options);
            energy.Add(double.Parse(words[0]));
            signal.Add(double.Parse(words[1]));
            error.Add(double.Parse(words[2]));
        } while (true);

        datapoints = energy.Count;

        vector start = new vector(6, 123, 3);
        double A, m, G;
        vector vec = start.copy();
        int nsteps = qnewton.minimum(Dbreitwigner, ref vec, 1e-6);
        A = vec[0]; m = vec[1]; G = vec[2];
        Error.WriteLine($" A = {A}, m = {m}, G = {G}");
	Error.WriteLine($" steps = {nsteps}");
	
	for(double E = energy[0];E<energy[datapoints-1];E+=1.0/64){
		WriteLine($"{E} {breitwigner(A,E,m,G)}");}
    }//Main
}//main class

