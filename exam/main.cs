using System;
using static System.Console;
using static System.Math;



public class main{

public static matrix positive_definite_matrix(int n){
	matrix M,D,V;
	do{
	//First construct symmetric random matrix with values from 1 to 100
	M = matrix.random_symmetric_matrix(n);
	//Check for eigenvalue real and positive
	(D,V) = jacobi.cyclic(M);
	}//do
	while (!matrix.checkEigenvalues(D));

	return M;}
			

	public static void Main(){
		WriteLine(" -------- Part one --------- ");
		WriteLine("Implement of Cholesky decomposition of a real symmetric positive-definite matrix");
		WriteLine("A real symmetric positive-definite matrix is given by:");
		matrix A = positive_definite_matrix(4);
		A.print("Matrix A =");
		cholesky CholDec = new cholesky(A);
		var L = CholDec.L;
		WriteLine("Usinge the Chloesky decomposition the lower triangle matrix is given with");
		L.print("L = ");
		WriteLine("To check the decomposition L*L.T is calcualted and the test should be true for:");	
		var test = L*L.T;
		WriteLine($"L*L.T = A ? => {test.approx(A)}");
		
		WriteLine("\n ------ Part Two -------- ");
		WriteLine("Implementation and test of linear equation solve, calcualtion of determinant, and inverse matrix");
		
		var b = matrix.random_vector(4);
		b.print("b =");
		var x = CholDec.solve(b);		
		x.print("x = ");
		WriteLine($"L*L.Tx=Ax=b ? =>  {(A*x).approx(b)}");

	}//Main
}//class
