all : osc_friction.svg out.debug.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib


osc_friction.svg : osc_friction.gpi out.osc_friction.txt
	gnuplot $<
out.debug.txt : main.exe
	mono $< 1> $@ 2> log
out.osc_friction.txt : main_osc_friction.exe
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
