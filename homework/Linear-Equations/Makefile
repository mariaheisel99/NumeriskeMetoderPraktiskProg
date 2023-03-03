all : count.exe main.exe Out.txt time.data timeQRGS.svg
TIME = time -f --portability --append --output $@
DIR = ~/repos/NumeriskeMetoderPraktiskProg/matlib/matrix


Out.txt : main.exe
	mono $< > $@

Ns = $$(seq 400 20 500)
time.data : count.exe Makefile
	>$@
	for N in $(Ns); do \
	echo $$N; \
	$(TIME) -f "$$N %U" mono count.exe -dim:$$N >log ; \
	done

#	$(TIME) mono count.exe -dim:10 >>$@
#	$(TIME) mono count.exe -dim:20 >>$@
#	$(TIME) mono count.exe -dim:40 >>$@
#	$(TIME) mono count.exe -dim:80 >>$@
#	$(TIME) mono count.exe -dim:100 >>$@
#	$(TIME) mono count.exe -dim:200 >>$@
#	$(TIME) mono count.exe -dim:250 >>$@
#	$(TIME) mono count.exe -dim:300 >>$@


matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs 
	mcs -target:library -out:./matrix.dll $^

count.exe : count.cs matrix.dll QRGS.cs
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

timeQRGS.svg : time.gpi time.data
	gnuplot $<	

main.exe : main.cs QRGS.cs matrix.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	

i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll 
