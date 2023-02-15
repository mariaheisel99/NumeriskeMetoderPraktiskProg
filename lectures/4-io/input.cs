static public class input{
                public static double[] input_get_numbers_from_args(string[] args){
			double [] result = null;
			foreach(arg in arg){
				string[] words=arg.Split(':');
                        	if(words[0]=="-numbers"){
                                	string numbers=words[1].Split(',');
                                	double [] result = new double[umbers.Length];
                                	for(int i=0;i<numbers.Length;i++){
                                        	result[i]=double.Parse(numbers[i]);
                                }

                        }
                }
        return result;
        }
}
