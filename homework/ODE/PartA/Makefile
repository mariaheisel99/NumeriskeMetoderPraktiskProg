all : Osc_friction.svg Out.debug.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib


Osc_friction.svg : osc_friction.gpi Out.osc_friction.txt
	gnuplot $<
Out.debug.txt : main.exe
	mono $< 1> $@ 2> log
Out.osc_friction.txt : main_osc_friction.exe
	mono $< 1> $@ 2>log.osc_frition

main.exe : main.cs matlib.dll 
	$(MKEXE)

main_osc_friction.exe : main_osc_friction.cs matlib.dll
	$(MKEXE)

matlib.dll : ode.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data
