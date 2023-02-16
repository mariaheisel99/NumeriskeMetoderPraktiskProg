#Out.txt : main.exe
#	mono main.exe > Out.txt

all: main.exe
main.exe : main.cs
	mcs -out:main.exe $^

.PHONY : clean
clean: 
	rm -f main.exe


