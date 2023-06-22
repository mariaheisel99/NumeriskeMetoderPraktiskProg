all : Out.txt Out.test.txt Erf.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib


Out.test.txt : main.exe
	mono $< 1> $@ 2> logtest
Out.Erf.txt : mainErf.exe
	mono $< 1> $@ 2> logErf
Out.txt :
	@echo Test of implmentation of recusive open-quadrature adaptive integrator is performed and the result are given in Out.test.txt >> Out.txt
	@echo  >> Out.txt
	@echo The integrator is used on the error function via integral representation on plot Erf.svg. >> Out.txt

Erf.svg : erf.gpi Out.Erf.txt
	gnuplot $<

main.exe : main.cs matlib.dll 
	$(MKEXE)

mainErf.exe : mainErf.cs matlib.dll
	$(MKEXE)

matlib.dll : integrate.cs $(DIR)/complex/complex.cs $(DIR)/mixed/erf.cs
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
