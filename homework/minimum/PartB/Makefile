iall : Higgs.svg out.data.txt Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib

out.data.txt : main.exe
	mono $< < higgs.data 1> out.data.txt 2> log.Out

Higgs.svg : higgs.gpi higgs.data out.data.txt
	gnuplot $<

Out.txt :
	@echo Higgs discovery >> Out.txt
	@echo  >> Out.txt
	@echo The Breit-Wigner function are fitted to higgs data. The fit is performed by minomizing the deviation funcktion. The fit are plotted with experimental data on Higgs.svg >> Out.txt

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.svg log*
