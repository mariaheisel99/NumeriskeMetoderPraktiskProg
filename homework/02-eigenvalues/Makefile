all : wave.txt dr.txt rmax.txt OutPartA.txt OutPartB.txt Dr_convergens.svg Rmax_convergens.svg Wave.svg 
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = ../../matlib/matrix

OutPartA.txt : mainPartA.exe
	mono $<  >$@


OutPartB.txt : mainPartB.exe
	mono $< > $@

drs = $$(seq 0.05 0.05 0.5)
dr.txt : mainPartB.exe
	>$@
	for dr in $(drs); do \
		mono mainPartB.exe -rmax:9 -dr:$$dr >> dr.txt;\
	done

rmaxs = $$(seq 2 1 10)
rmax.txt : mainPartB.exe
	>$@
	for rmax in $(rmaxs); do \
		mono mainPartB.exe -rmax:$$rmax -dr:0.1 >> rmax.txt;\
	done

NumericalCalculation.txt : mainParB.exe Makefile

wave.txt: mainPartB.exe
	>$@
	mono $< -dr:0.1 -rmax:10 -wave:True >>$@
	mono $< -dr:0.3 -rmax:10 -wave:True >>$@
	mono $< -dr:0.1 -rmax:4 -wave:True >>$@
	mono $< -dr:0.3 -rmax:4 -wave:True >>$@


matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs jacobi.cs hydrogen.cs 
	mcs -target:library -out:./matrix.dll $^

mainPartA.exe: mainPartA.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

mainPartB.exe: mainPartB.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

Dr_convergens.svg : dr.gpi dr.txt
	gnuplot $<


Rmax_convergens.svg : rmax.gpi rmax.txt
	gnuplot $<

Wave.svg : wave.gpi wave.txt output_analytical_wave.txt
	gnuplot $<

.PHONY: clean
clean:
	-$(RM) *.txt *.exe *.dll *.data *.svg
