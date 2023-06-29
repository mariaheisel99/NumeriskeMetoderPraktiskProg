using System;
using static System.Console;
public class hydrogen {
	public matrix H;
	public vector r;

	public hydrogen(double rmax, double dr){

        //Builds the Hamiltonian matrix
	int npoints =(int)(rmax/dr)-1;
        r = new vector(npoints);
        for(int i = 0; i<npoints;i++)r[i]=dr*(i+1);
        H = new matrix(npoints, npoints);
        for(int i=0;i<npoints-1;i++){
        	matrix.set(H,i,i,-2);
                matrix.set(H,i,i+1,1);
                matrix.set(H,i+1,i,1);
                }//for loop
        matrix.set(H,npoints-1,npoints-1,-2);
        H*=-0.5/dr/dr;
        for(int i = 0;i<npoints;i++)H[i,i]+=-1/r[i];
 
       }//hamiltonian	

	public (matrix, matrix) diagonalize(){
		var (D,V) = jacobi.cyclic(H);	
		return (D,V);
		}//diagonalize
	
	public (matrix, vector) eigen(){
		//if D == null
		var (D,V) = diagonalize();
		vector eigen_vals = new vector(H.size1);
	
		for( int i = 0; i < H.size1; i++){
			eigen_vals[i] = D[i,i];}
	return (V, eigen_vals); //eigenvectors in matrix V and eigen_vals vector with eigenval


	}//eigen	
		
	public (double, vector) lowest_energy(){//returns lowest energy and lowest eigenvector
		var (V, eigen_vals) = eigen();
		double low = eigen_vals[0];
		vector low_vector = V[0];
		for (int i = 1;i<eigen_vals.size; i++){
			if(eigen_vals[i] < low) {
				low = eigen_vals[i];
				low_vector = V[i];
				}
			}
	return (low, low_vector);
	}//loewst_energy
		
}//class hydrogen
