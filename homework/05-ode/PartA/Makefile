all : Osc_friction.svg Debug.svg Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib


Osc_friction.svg : osc_friction.gpi out.osc_friction.txt
	gnuplot $<

Debug.svg : debug.gpi out.debug.txt
	gnuplot $<

out.debug.txt : main.exe
	mono $< 1> $@ 2> log

out.osc_friction.txt : main_osc_friction.exe
	mono $< 1> $@ 2>log.osc_frition

Out.txt : 
	@echo Part A is performed with first solivng d^2u=-u. The result are shown on Debug.svg >> Out.txt
	@echo  >> Out.txt
	@echo Then an example for oscillator with friction is reproduced. Result are seen on Osc_friction.svg. rk45 is used.  >> Out.txt

main.exe : main.cs matlib.dll 
	$(MKEXE)

main_osc_friction.exe : main_osc_friction.cs matlib.dll
	$(MKEXE)

matlib.dll : ode.cs $(DIR)/matrix/vector.cs $(DIR)/mixed/genlist.cs
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg
