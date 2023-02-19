using System;
using static System.Console;
using static System.Math;

public class genlist<T>{ // alt efter hvad T er, så bliver listen under en array med f.eks. doubles hvis T er double
	public T[] data;
	public int size => data.Length; //property, size er lige lenght af data
	public T this[int i] => data[i]; // indexer
	public genlist(){ data = new T[0]; } //constructor

	// Exercise1
	public void add(T item) { /* add item to the list */
		//realocate an array. Vi laver en nu array som har en ekstra plads og overføre hele den gamle array ind i den.
		T[] newdata = new T[size + 1];  
		System.Array.Copy(data, newdata, size);	// copy size of data into newdata	
		newdata[size] = item;
		data = newdata; // data is no a reference to the object newdata. So data is a pointer to newdata in ram, and newdata is pointed to its definition in the ram. The things in data before is lost beacuse it doesn't point to it anymore. 
		}
	
	// Exercise2
	public void remove(int i) {
		T[] newdata = new T[size - 1];
		int j = 0;
		for (int k = 0;k<size; k++){
			if (k!=1) {
			newdata[j] = data [k];}
			j++;
		}
	data = newdata;
	}

}


