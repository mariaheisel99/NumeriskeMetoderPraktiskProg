all : main.exe matrix.dll Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix

Out.txt : main.exe
	mono $< > $@

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs jacobi.cs 
	mcs -target:library -out:./matrix.dll $^

main.exe: main.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)


i.PHONY: clean
clean:
	-$(RM) *.txt *.exe *.dll 
