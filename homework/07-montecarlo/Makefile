iall : UnitCircle.svg ErrorEstimate.svg Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib

UnitCircle.svg : plainmcUnitCircle.gpi out.Circle.txt
	gnuplot $<
ErrorEstimate.svg : errorComparing.gpi out.Circle.txt
	gnuplot $<

Ns = $$(seq 1 1000 100000)

out.Circle.txt : mainEnhedscirkel.exe
	>$@
	for N in $(Ns); do \
	echo $$N; \
	mono $< $$N >> $@ 2> log.circle ; \
	done 

Out.txt : main.exe
	mono $< 1> $@ 2> log.out	

mainEnhedscirkel.exe : mainEnhedscirkel.cs matlib.dll 
	$(MKEXE)

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : montecarlo_integrator.cs $(DIR)/matrix/vector.cs  $(DIR)/mixed/gamma.cs 
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
