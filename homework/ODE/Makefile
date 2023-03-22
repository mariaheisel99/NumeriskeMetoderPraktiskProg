all : main.exe Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib

out.debug.txt : main.exe
	mono $< 1> $@ 2> log

main.exe : main.cs matlib.dll 
	$(MKEXE)

matlib.dll : ode.cs $(DIR)/matrix/vector.cs $(DIR)/genlist.cs
	 $(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data
