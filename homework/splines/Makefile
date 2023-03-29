all : PlotA.svg PlotB.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib/matrix


PlotA.svg : PlotA.gpi datapoints.txt linterpdata.txt
	gnuplot $<
PlotB.svg : PlotB.gpi data1_qspline.txt data2_qspline.txt data3_qspline.txt
	gnuplot $<

datapoints.txt linterpdata.txt linintgdata.txt : mainA.exe
	mono $< >$@
	
data1_qspline.txt : mainB.exe
	mono $< >$@
mainA.exe : mainA.cs matlib.dll ; $(MKEXE)

mainB.exe : mainB.cs matlib.dll ; $(MKEXE)

matlib.dll : linespline.cs qspline.cs $(DIR)/vector.cs
	 $(MKLIB)



i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data 
