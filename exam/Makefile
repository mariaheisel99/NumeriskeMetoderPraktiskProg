iall : Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../matlib


Out.txt : main.exe
	mono $< 1> $@ 


main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : cholesky.cs $(DIR)/matrix/jacobi.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
