using System;
using static System.Console;
using static System.Math;


public static class main{
	
	public static void print(this double x, string s){/* x.print("x=");*/
		Write(s);WriteLine(x);
		}
	public static void print(this double x){/* x.print()*/
		x.print("");
		}

	public static void Main(){
	WriteLine("Tester forskellige opperationer for vec.dll");

	vec v = new vec(2,4,7);
	vec u = new vec(1,2,3);
	u.print("u=");

	(v+u).print("u=");
	(4*u).print("4*u = ");
	
	vec w = u+v+3*v;
	w.print("w = ");
	(-u).print("-u = ");
	
	double w2 = u%v;
	double w3 = u.dot(v);
	w2.print("u%v=");
	w3.print("u.dot(v)=");

	// Testing the approx methodes
	
	WriteLine("");
	WriteLine("Tester approx functioner i vec.dll");
	double a1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double a2 = 8*0.1;
	WriteLine($"a1 =  0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1 = {a1:e15}");
	WriteLine($"a2 =  0.1*8 = {a2:e15}");	
	WriteLine($"a1==a2 ? => {a1==a2}");

	WriteLine($"Test as approx til a1 og a2: a1==a2 ? => {vec.approx(a1,a2)}");
	
	WriteLine("Test for approx til vector");
	vec a = new vec(a1, 0.1+0.1+0.1,0.1+0.1+0.1+0.1);
	vec b = new vec(a2,3*0.1,4*0.1);
	WriteLine($"vec a :ax = {a.x:e15},ay = {a.y:e15}, az = {a.z:e15} ");
	WriteLine($"vec b :bx = {b.x:e15},by = {b.y:e15}, bz = {b.z:e15} ");
	WriteLine("Tester for a og b vectorer");
	WriteLine($" vec a == vec b ? => {vec.approx(a,b)}");
	
	}

}
