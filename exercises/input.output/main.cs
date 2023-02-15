using static System.Console;
using static System.Math;
class main{
    public static int Main(string[] args){
        // exe1(args);
        // exe2();
        // exe3(args)
        
        return exe2();
    }   

    static int exe1(string[] args){
        foreach(var arg in args){
            var words = arg.Split(':');
        if(words[0]=="-numbers"){
            var numbers=words[1].Split(',');
            foreach(var number in numbers){
                double x = double.Parse(number);
                WriteLine($"{x} {Sin(x)} {Cos(x)}");
                }
            }
        }
    return 0;
	}

    static int exe2(){
        char[] split_delimiters = {' ','\t','\n'};
        var split_options = System.StringSplitOptions.RemoveEmptyEntries;
        for( string line = ReadLine(); line != null; line = ReadLine() ){
	        var numbers = line.Split(split_delimiters,split_options);
	        foreach(var number in numbers){
		        double x = double.Parse(number);
		        WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }
	return 0;	
    }

    static int exe3(string[] args){
        string infile=null,outfile=null;
        foreach(var arg in args){
            var words=arg.Split(':');
            if(words[0]=="-input")infile=words[1];
            if(words[0]=="-output")outfile=words[1];
        }
        if( infile==null || outfile==null) {
            Error.WriteLine("wrong filename argument");
            return 1;
        }
        var instream = new System.IO.StreamReader(infile);
        var outstream = new System.IO.StreamWriter(outfile,append:false);
        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            double x=double.Parse(line);
            outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
        }
        instream.Close();
        outstream.Close();
        return 0;
    }
    
}
