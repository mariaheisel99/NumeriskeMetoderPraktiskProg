Out.txt : main.exe
	mono $< > $@

DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs 
	mcs -target:library -out:./matrix.dll $^

main.exe : main.cs QRGS.cs matrix.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	

i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll 
