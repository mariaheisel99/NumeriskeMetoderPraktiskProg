all: Out.txt main1.exe main2.exe main3.exe

Out.txt : main1.exe main2.exe main3.exe Makefile
	>$@
	
	echo  "Reading numbers from command-line arguments:" >>$@
	mono Exercise1/main1.exe -numbers:1.1,2.2,3.3,4.4,5.5 1>>$@ 2>>log
	
	echo "Reading numbers from stdandard input:" >>$@
	mono Exercise2/main2.exe <Exercise2/input2.txt 1>>$@ 2>>log
	
	echo "Reading numbers from a file and writing to a file:" >>$@
	mono Exercise3/main3.exe -input:Exercise3/input3.txt -output:Exercise2/out3.txt \
		1>>$@ 2>>log
	
	echo "here is a copy of the output:" >>$@
	cat Exercise3/out3.txt >> $@
#Ex1
main1.exe : Exercise1/main1.cs
	mcs -out:Exercise1/main1.exe $^

#Ex2
main2.exe : Exercise2/main2.cs
	mcs -out:Exercise2/main2.exe $^

#Ex3
main3.exe : Exercise3/main3.cs
	mcs -out:Exercise3/main3.exe $^

.PHONY: clean
clean:
	rm -f *.exe
