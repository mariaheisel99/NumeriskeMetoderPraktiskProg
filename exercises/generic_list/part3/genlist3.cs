using System;
using static System.Console;
using static System.Math;

public class genlist<T>{ // alt efter hvad T er, så bliver listen under en array med f.eks. doubles hvis T er double
	
		
	
	// Exercise3
	public T[] data;
	public int size=0,capacity=8;
	public genlist(){ data = new T[capacity]; }
	public void add(T item){ /* add item to list */
		if(size==capacity){
			T[] newdata = new T[capacity*=2];
			System.Array.Copy(data,newdata,size);
			data=newdata;
			}
		data[size]=item;
		size++;
		// data = newdata;
	}

} //genlist


