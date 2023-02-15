all: main1.exe main2.exe main3.exe

#Ex1
main1.exe : main1.cs
	mcs -out:main1.exe $^

#Ex2
main2.exe : main2.cs
	mcs -out:main2.exe $^

#Ex3
main3.exe : main3.cs
	mcs -out:main3.exe $^

.PHONY: clean
clean:
	rm -f main1.exe main2.exe
