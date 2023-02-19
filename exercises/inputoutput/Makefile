all: main1.exe main2.exe main3.exe

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
	rm -f main1.exe main2.exe
