Out.txt : main.exe
	mono main.exe > Out.txt

DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/complex
cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

main.exe : main.cs cmath.dll
	mcs -target:exe -out:main.exe -reference:cmath.dll main.cs

clean :
	rm *.txt *.exe


