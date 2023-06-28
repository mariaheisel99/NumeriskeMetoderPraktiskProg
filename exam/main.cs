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
		WriteLine("A real symmetric positive-definite matrix is constructed with dimension n=3:");
		int n = 3; //matrix size
		matrix A = positive_definite_matrix(n);
		A.print("Matrix A =");
		WriteLine("The matrix A is symmetric and square. The eigenvalues of A should be positive, which are checked for when genereating A.");
		cholesky CholDec = new cholesky(A);
		var L = CholDec.L;
		WriteLine("Usinge the Chloesky decomposition the lower triangular matrix is given with");
		L.print("L = ");
		WriteLine("It is seen that L is a lower triangular matrix as aspected.");
		WriteLine("To check the decomposition L*L.T is calcualted and the test should be true for:");	
		var test = L*L.T;
		WriteLine($"L*L.T = A ? => {test.approx(A)}");

		WriteLine("\n ------ Part Two -------- ");
		WriteLine("Implementation and test of linear equation solve, calcualtion of determinant, and inverse matrix");
		
		WriteLine("\n * Solving an linear equation");
		WriteLine("The A matrix is used to solve Ax=b, here b also have the dimension 3:");
		var b = matrix.random_vector(n);
		b.print("b =");
		WriteLine("Using the implemented solve in class of cholesky the solution x is:");
		var x = CholDec.solve(b);		
		x.print("x = ");
		WriteLine("Check for the solution x is performed:");
		WriteLine($"L*L.Tx=Ax=b ? =>  {(A*x).approx(b)}");

		WriteLine("\n * Determinant of A");
		var detA = CholDec.det();
		WriteLine($"Determinanten af A = {detA}");

		WriteLine("\n * Inverse ");
		var InvA = CholDec.inverse();
		matrix I = new matrix(A.size1,A.size2);
		I.set_identity();
		InvA.print("Inverse A = ");
		WriteLine("To check if the inverse A is correct, it is check whether A*A^-1 = I, where I is the identity matrix");
		WriteLine($"A*A^-1 = I ? => {(A*InvA).approx(I)}");
		WriteLine(" \n\n ---- Same test as above no performed for n=5 dimension for matrix M");
		int N = 5; //matrix size
		matrix M = positive_definite_matrix(N);
		M.print("Matrix M =");
		cholesky CholDec1 = new cholesky(M);
		var L1 = CholDec1.L;
		L1.print("L = ");
		var test1 = L1*L1.T;
		WriteLine($"L*L.T = M ? => {test1.approx(M)}");

		WriteLine("\n * Solving an linear equation");
		var b1 = matrix.random_vector(N);
		b1.print("b =");
		var x1 = CholDec1.solve(b1);		
		x1.print("x = ");
		WriteLine($"L*L.Tx=Mx=b ? =>  {(M*x1).approx(b1)}");

		WriteLine("\n * Determinant of M");
		var detM = CholDec1.det();
		WriteLine($"Determinanten af M = {detM}");

		WriteLine("\n * Inverse of M ");
		var InvM = CholDec1.inverse();
		matrix I1 = new matrix(M.size1,M.size2);
		I1.set_identity();
		InvM.print("Inverse M = ");
		WriteLine($"M*M^-1 = I ? => {(M*InvM).approx(I1)}");

	}//Main
}//class
