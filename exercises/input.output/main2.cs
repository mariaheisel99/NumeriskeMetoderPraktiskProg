using System;
using System.Console;
using System.Math;

public static class main2(){
	public static void Main2(){
		char[] split_delimiters = {' ','\t','\n'};
		var split_options = StringSplitOptions.RemoveEmptyEntries;
		for( string line = ReadLine(); line != null; line = ReadLine() ){
			var numbers = line.Split(split_delimiters,split_options);
			foreach(var number in numbers){
				double x = double.Parse(number);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
                	}
        	}
	}
}
