iall : Higgs.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib

Higgs.svg : higgs.gpi higgs.data Out.txt
	gnuplot $<

Out.txt : main.exe
	mono $< < higgs.data 1> Out.txt 2> log.Out


main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
