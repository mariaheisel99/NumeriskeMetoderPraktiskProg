# Exercise perfomed: 
 complex, epsilon, gerneric_list, hello, inputoutput, math, multiprocessing, plots, vec

#homeworks performed:
 all homework is done. In the following table the performed parts in the homework are written. In the homework different approaches were used. Some of them are divived into folder containing the part A, B, and C. In others, the part A,B and C are performed in the same folder and  overlap each other. In each homework, the Out.txt explain what is performed and where the result can be seen.  

# NumeriskeMetoderPraktiskProg
| #  |    homework                   | A | B | C | Σ   |
| -- | ----------------------------- | - | - | - | --- |
| 1  | LinEq                         | 6 | 3 | 1 | 10  |
| 2  | EVD                           | 6 | 3 | - |  9  |
| 3  | LeastSquares                  | 6 | 3 | 1 | 10  |
| 4  | Splines                       | 6 | 3 | - |  9  |
| 5  | ODE                           | 6 | 3 | - |  9  |
| 6  | Adaptive Integration          | 6 | 3 | 1 | 10  |
| 7  | Monte Carlo                   | 6 | 3 | - |  9  |
| 8  | Roots                         | 6 | 3 | - |  9  |
| 9  | Minimization                  | 6 | 3 | - |  9  |
| 10 | Artificial Neural Networks    | 6 | 3 | - |  9  |
 

|                    total points: 93  |
| ------------------------------------ |

# exam performed : exam project 14 Cholesky decomposition of a real symmetric positive-definite matrix

In the exam the Cholesky decomposition of a real symmetric positive-definite matrix are implemented. This is done using the Cholesky–Crout algorithm which starts from the upper left corner of the matrix L and proceeds the matrix column by column.
A = L*L^T
The decompostion is inside cholesky.cs.

The cholesky.cs contains a class cholesky that contain a matrix L, which is to store the lower triangular matrix L.  It is build with object-oriented programming with different separat methodes (constructor, solve, det, inverse)

* A constructor cholesky(matrix A) takes matrix A as input and perform Cholesky decomposition on the matrix A.  
* solve(vector b) is to solve equation Ax=b. It returns the solution vector x.
This is done first with forward substitution method to solve equation Ly=b, where L is the lower triangular matrix. After this beackward substitution method is used to sole equation L^T*x=y.
* the methode det() calculated the determinant of the input matrix using the cholesky decomposition. Det(A)=Det(LL^T)=Det(L)Det(Æ^T)=Det(L)^2. Due to L beign lower triangular the determinant of L is the product of the diagonal elements in L. 
* The methode inverse() findes the inverse of matrix A by solving Axi=LL^Txi=ei i times. 

Beside teh build cholesky.cs a methode is added to the matrix.cs files. This the random_symmetric_matrix(int n) that takes integer n and construct a random symmetric matrix, also IsReal(double val) and checkEigenvalues(matrix B) are implemnted. That check for real and positive eigenvalues. This methodes are implemented sush that the main.cs in the exam first havea methode cales positive_definite_matrix(int n), that returns a positive definite matrix with n dimension. It construct a symmetric matrix and uses jacobi.cyclic to finde the eigenvalues and thereafter check for real and postive eigenvalues. This gives per definition a psotive definite matrix due to matrix M beign positive-definite if M is symmetic and all eigenvalues are positive and real. 

In the main.cs different test and calcualtion are beformed. This is lined out in the Out.txt.  

Performed is 
- [x] Implemented Cholesky decompotion using Cholesky-Crout algorithm
- [x] Implemented linear equation solver
- [x] Implemented calculation of determinant
- [x] Implemented calculation of inverse matrix

To furhter investigation operations count for the Cholesky decompostion could have been performed. This was also tried implemented. But due to the positive-definite matrix generating included check for eigenvalues (jacobi.cs used) already the dimension n=7 took to long to genereate the positive-definite-matrix and therefor the operation count was not excecuted. It was expected to scale with O(n^3).

I rate the exam project 9/10 due to not being able of determine the operation count and compare to eg. LU-decompostion or QR-factorize. 
