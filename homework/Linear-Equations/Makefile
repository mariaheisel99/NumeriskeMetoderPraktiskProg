all : Time.data Out.txt TimeQRGS.svg Nfit.exe
TIME = time -f --portability --append --output $@
DIR = ../../matlib/matrix


Out.txt : main.exe
	mono $< > $@

Ns = $$(seq 400 50 1000)
Time.data : count.exe Makefile
	>$@
	for N in $(Ns); do \
	echo $$N; \
	$(TIME) -f "$$N %U" mono count.exe -dim:$$N >log ; \
	done

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs 
	mcs -target:library -out:./matrix.dll $^

count.exe : count.cs matrix.dll QRGS.cs
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

TimeQRGS.svg : time.gpi Time.data Nfit.data
	gnuplot $<	

Nfit.exe : Nfit.cs
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) 
Nfit.data : Nfit.exe
	mono $< > $@

main.exe : main.cs QRGS.cs matrix.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	

i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg 
