using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){

	WriteLine("Part A:");
	WriteLine("Genereate symmetric random 6x6 matrix A");
	var A = matrix.random_symmetric_matrix(6);
	var transposeA = A.T;
	A.print("A=");	
	transposeA.print("A.T = ");
	
	WriteLine("* Perform eigenvalue-decomposition with jacobi algoritme");
	var (D1,V1) = jacobi.cyclic(A);
	D1.print("D=");
	V1.print("V=");

	WriteLine("* Performance test");
	var test1 = V1.T*A*V1;
	var test2 = V1*D1*V1.T;
	var test3 = V1.T*V1;
	var test4 = V1*V1.T;
	WriteLine("");
	WriteLine($"V^T*A*V=D ? => {test1.approx(D1)}");
	WriteLine("");
	WriteLine($"V*D*V^T=A ? => {test2.approx(A)}");
	WriteLine("");
	matrix I = new matrix(5,5);
	I.set_identity();
	test3.print("V^T*V = ");
	WriteLine("Correspond to the identity matrix");
	WriteLine("");
	test4.print("V*V^T =");
	WriteLine("Correspond to the identity matrix");
		
	}//Main
}//class main

