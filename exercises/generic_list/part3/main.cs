using System;
using static System.Console;
using static System.Math;

class Program {
        public static int Main() {

        var list = new genlist<double[]>();
        char[] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
	
        for(string line = ReadLine(); line!=null; line = ReadLine()){
                var words = line.Split(delimiters, options);
                WriteLine($"Words = {words}");
                int n = words.Length;
                WriteLine($"n = {n}");
                var numbers = new double[n];
                for( int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
		WriteLine($"numbers {numbers} ");
                list.add(numbers);
		WriteLine($"list {list} ");
	}
     //   for(int i=0;i<list.size;i++){
       //         var numbers = list[i];
         //       foreach(var number in numbers)Write($"{number : 000e+00;-0.00e+00}");
           //     WriteLine();
             //   }

        return 0;
}//Main
}//class
