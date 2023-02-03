Out.txt : hello.exe #Out.txt depends on hello.exe
	mono hello.exe > Out.txt #run hello.exe, send output to Out.txt
hello.exe : hello.cs #hello.exe depends on hello.cs
	mcs hello.cs #compile hello.cs into hello.exe

clean:	#a phoney target (not really the name of file rather it is just a name for recip to be executed), no dependencies
	rm -f Out.txt hello.exe #remove secondary files


