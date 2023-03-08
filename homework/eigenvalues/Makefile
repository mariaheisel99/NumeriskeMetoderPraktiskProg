all : OutPartA.txt OutPartB.txt eigenvalues_dr.svg eigenvalues_rmax.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix

OutPartA.txt : mainPartA.exe
	mono $< > $@
OutPartB.txt : mainPartB.exe
	mono $< > $@

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs jacobi.cs 
	mcs -target:library -out:./matrix.dll $^

mainPartA.exe: mainPartA.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

mainPartB.exe: mainPartB.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

eigenvalues_dr.svg : eigenvalues_dr.gpi output_eigenvalues_dr.data
	gnuplot $<

eigenvalues_rmax.svg : eigenvalues_rmax.gpi output_eigenvalues_rmax.data
	gnuplot $<


.PHONY: clean
clean:
	-$(RM) *.txt *.exe *.dll *.data
