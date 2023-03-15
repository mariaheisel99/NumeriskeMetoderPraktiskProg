all : mainB.exe main.exe PlotA.svg PlotB.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix


PlotA.svg : PlotA.gpi datapoints.txt linterpdata.txt qinterpdata.txt
	gnuplot $<
PlotB.svg : PlotB.gpi data1_qspline.txt data2_qspline.txt data3_qspline.txt
	gnuplot $<

datapoints.txt linterpdata.txt qinterpdata.txt: main.exe
	mono $< >$@
	
data1_qspline.txt : mainB.exe
	mono $< >$@
main.exe : main.cs matlib.dll ; $(MKEXE)

mainB.exe : mainB.cs matlib.dll ; $(MKEXE)

matlib.dll : linespline.cs qspline.cs $(DIR)/vector.cs
	 $(MKLIB)



#matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs ordinary_LeastSquare_fit.cs; $(MKLIB)



#Plot.svg : Plot.gpi dataPartABC.data dataPartABC_fit.data
#	gnuplot $<
	


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data
