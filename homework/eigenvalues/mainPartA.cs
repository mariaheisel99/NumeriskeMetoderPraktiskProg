using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){

	WriteLine("Part A:");
	WriteLine("Genereate symmetric random 3x3 matrix A");
	var A = matrix.random_symmetric_matrix(3);
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
	matrix I = new matrix(3,3);
	I.set_identity();
	test3.print("V^T*V =");
	WriteLine($"V^T*V=I ? => {test3.approx(I)}");
	WriteLine("");
	test4.print("V*V^T =");
	WriteLine($"V*V^T=I ? => {test2.approx(I)}");
		
	}//Main
}//class main

