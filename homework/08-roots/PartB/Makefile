iall : Plot_convergens.svg convergens.txt wave_function.txt Out.txt Plot_Swave.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib

Out.txt : main.exe
	mono $< 1> $@	
wave_function.txt : main.exe
	>$@ mono main.exe -rmax:8 -wave:true >> wave_function.txt;

rmaxs = $$(seq 1 1 10)
rmins = $$(seq 0.001 0.05 0.5)
accs = 0.00000001 0.0000001 0.000001 0.00001 0.0001 0.001 0.01 0.1 
epss =   0.00000001 0.0000001 0.000001 0.00001 0.0001 0.001 0.01 0.1

convergens.txt : main.exe
	>$@ 
	echo "rmax - convergens"
	for rmax in  $(rmaxs); do \
		echo rmax = $$rmax;\
		mono main.exe -rmax:$$rmax >> $@;\
	done
	echo "\n" >> $@
	for rmin in  $(rmins); do \
		echo rmin = $$rmin;\
		mono main.exe -rmin:$$rmin >> $@;\
	done
	echo "\n" >> $@
	for acc in  $(accs); do \
		echo acc = $$acc;\
		mono main.exe -acc:$$acc >> $@;\
	done
	echo "\n" >> $@
	for eps in  $(epss); do \
		echo eps = $$eps;\
		mono main.exe -eps:$$eps >> $@;\
	done

Plot_Swave.svg : resultB.gpi wave_function.txt
	gnuplot $<
Plot_convergens.svg : convergens.gpi convergens.txt
	gnuplot $<

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll :root_finder.cs hydrogen.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs $(DIR)/mixed/ode.cs $(DIR)/mixed/genlist.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
