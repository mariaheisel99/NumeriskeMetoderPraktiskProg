# Exe 1
Out1.txt : main1.exe 
	mono main.exe -numbers:1,2,3,4,5,6,7 > Out1.txt
main1.exe : main1.cs
	mcs main1.cs
                
#Exe 2
Out2.txt : main2.exe
	mono main2.exe 1 2 3 4 5 6 > Out2.txt
			
main.exe : main2.cs
	mcs main2.cs
