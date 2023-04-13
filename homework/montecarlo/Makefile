iall : PlainmcUnitCircle.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib

PlainmcUnitCircle.svg : PlainmcUnitCircle.gpi Out.Circle.txt
	gnuplot $<

Ns = $$(seq 1000 1000 100000)

Out.Circle.txt : main.exe
	>$@
	for N in $(Ns); do \
	echo $$N; \
	mono $< $$N >> $@ 2> log ; \
	done 

main.exe : main.cs matlib.dll 
	$(MKEXE)

matlib.dll : montecarlo_integrator.cs $(DIR)/matrix/vector.cs 
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
