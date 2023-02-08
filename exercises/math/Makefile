Out.txt : main.exe #Out.txt depends on main.exe
	mono main.exe > Out.txt #run main.exe, send output to Out.txt
sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:main.exe -reference:sfuns.dll main.cs

clean:	#a phoney target (not really the name of file rather it is just a name for recip to be executed), no dependencies
	rm -f Out.txt main.exe #remove secondary files


