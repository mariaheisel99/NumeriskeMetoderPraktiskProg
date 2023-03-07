using System;
using System.IO;
using static System.Console;
using static System.Math;

public class mainB{
public static matrix hamiltonian(double rmax, double dr){

        //Builds the Hamiltonian matrix
        //double rmax = 10, dr = 0.3;
	int npoints =(int)(rmax/dr)-1;
        vector r = new vector(npoints);
        for(int i = 0; i<npoints;i++)r[i]=dr*(i+1);
        var H = new matrix(npoints, npoints);
        for(int i=0;i<npoints-1;i++){
        	matrix.set(H,i,i,-2);
                matrix.set(H,i,i+1,1);
                matrix.set(H,i+1,i,1);
                }//for loop
        matrix.set(H,npoints-1,npoints-1,-2);
        H*=-0.5/dr/dr;
        for(int i = 0;i<npoints;i++)H[i,i]+=-1/r[i];
	return H;
        }//hamiltonian	


public static void Main(){
	
	WriteLine("");
	WriteLine("Part B");
	WriteLine("Hamiltonian and jacobi routine with rmax = 10 and dr=0.3");
	var H  = hamiltonian(10,0.3);
	var (D,V) = jacobi.cyclic(H);
        H.print("H = ");
	D.print("D=");
	V.print("V=");

	StreamWriter file1 = new StreamWriter("output_eigenvalues_dr.data");
	StreamWriter file2 = new StreamWriter("output_eigenvalues_rmax.data");
	
	// fixed rmax = 10
	for(double x=0.01;x<1;x+=0.01){
                var H1 = hamiltonian(10,x);
                var (D1,V1) = jacobi.cyclic(H1);
                file1.WriteLine($"{x} {D1[1,1]}");
		}
	// fixed dr = 0.1
	for(double k=0;k<10;k++){
                var H2 = mainB.hamiltonian(k,0.1);
                var (D2,V2) = jacobi.cyclic(H2);
                WriteLine($"{k} {D2[1,1]}");
		}

	file1.Close();
	file2.Close();
	}//Main
}//class main

