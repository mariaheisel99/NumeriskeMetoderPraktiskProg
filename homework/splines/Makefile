all : main.exe PlotA.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix


PlotA.svg : PlotA.gpi datapoints.txt linterpdata.txt
	gnuplot $<

datapoints.txt linterpdata.txt: main.exe
	mono $< >$@

main.exe : main.cs matlib.dll ; $(MKEXE)


matlib.dll : linespline.cs
	 $(MKLIB)



#matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs ordinary_LeastSquare_fit.cs; $(MKLIB)



#Plot.svg : Plot.gpi dataPartABC.data dataPartABC_fit.data
#	gnuplot $<
	


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data
