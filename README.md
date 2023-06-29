### Exercise perfomed: 
 complex, epsilon, gerneric_list, hello, inputoutput, math, multiprocessing, plots, vec

### Homeworks performed:
 all homework is done. In the following table, the performed parts of the homework are written. In the homework, different approaches were used. Some of them are divided into folders containing part A, B, and C. In others, the part A,B and C are performed in the same folder and  overlap each other. In each homework, the Out.txt explain what is performed and where the result can be seen.  

#### NumeriskeMetoderPraktiskProg
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

### Exam performed: exam project 14 Cholesky decomposition of a real symmetric positive-definite matrix

In the exam, the Cholesky decomposition of a real symmetric positive-definite matrix was implemented. This was done using the Cholesky–Crout algorithm which starts from the upper left corner of the matrix L and proceeds the matrix column by column.
 A = L*L^T
The decompostion is inside cholesky.cs.

The cholesky.cs contain a class cholesky that contains a matrix L, which is to store the lower triangular matrix L.  It is built with object-oriented programming with different separate methods (constructor, solve, det, inverse)

* A constructor cholesky(matrix A) takes matrix A as input and performs Cholesky decomposition on matrix A.  
* solve(vector b) is to solve equation Ax=b. It returns the solution vector x.
This is done first with the forward substitution method to solve equation Ly=b, where L is the lower triangular matrix. After this backward substitution method is used to solve the equation L^T*x=y.
* the method det() calculated the determinant of the input matrix using the cholesky decomposition. Det(A)=Det(LL^T)=Det(L)Det(Æ^T)=Det(L)^2. Due to L being lower triangular the determinant of L is the product of the diagonal elements in L. 
* The method inverse() finds the inverse of matrix A by solving Axi=LL^Txi=ei i times. 

Besides the build cholesky.cs a method is added to the matrix.cs files. This is the random_symmetric_matrix(int n) that takes integer n and constructs a random symmetric matrix, also IsReal(double value) and checkEigenvalues(matrix B) are implemented. That check for real and positive eigenvalues. These methods are implemented so that the main.cs in the exam first have a method called positive_definite_matrix(int n), that returns a positive definite matrix with n dimension. It constructs a symmetric matrix and uses jacobi.cyclic to find the eigenvalues and thereafter check for real and positive eigenvalues. This gives per definition a positive definite matrix due to matrix M being positive-definite if M is symmetric and all eigenvalues are positive and real. 

In the main.cs different tests and calculations are performed. This is lined out in the Out.txt.  

Performed is 
- [x] Implemented Cholesky decomposition using Cholesky-Crout algorithm
- [x] Implemented linear equation solver
- [x] Implemented calculation of the determinant
- [x] Implemented calculation of inverse matrix

For further investigate operations count for the Cholesky decomposition could have been performed. This was also tried to implement. But due to the positive-definite matrix generating including a check for eigenvalues (jacobi.cs used) already the dimension n=7 took too long to generate the positive-definite-matrix and therefore the operation count was not executed. It was expected to scale with O(n^3).

I rate the exam project 9.5/10 due to not being able to determine the operation count and compare it to eg. LU-decomposition or QR-factorize. But still, I finished all the mentioned implementations. 

