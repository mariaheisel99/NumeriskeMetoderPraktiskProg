all : OutPartA.txt OutPartB.txt Eigenvalues_dr.svg Eigenvalues_rmax.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = ../../matlib/matrix

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

Eigenvalues_dr.svg : eigenvalues_dr.gpi output_eigenvalues_dr.data
	gnuplot $<

Eigenvalues_rmax.svg : eigenvalues_rmax.gpi output_eigenvalues_rmax.data
	gnuplot $<


.PHONY: clean
clean:
	-$(RM) *.txt *.exe *.dll *.data *.svg
