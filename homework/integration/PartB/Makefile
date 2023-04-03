all : Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib


Out.txt : main.exe
	mono $< 1> $@ 2> logErf

main.exe : main.cs matlib.dll 
	$(MKEXE)


matlib.dll : integrate.cs $(DIR)/complex/complex.cs
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
