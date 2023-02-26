all: ErfPlot/Erf.svg GammaPlot/Gamma.svg LngammaPlot/Lngamma.svg
# ErfPlot exercise 1
ErfPlot/Erf.svg : ErfPlot/erf.gpi ErfPlot/erf.data tabulatedErf.data
	gnuplot $<

ErfPlot/erf.data : ErfPlot/mainErf.exe
	mono $< > $@

ErfPlot/mainErf.exe : ErfPlot/mainErf.cs sfuns.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	cp sfuns.dll ErfPlot/

# GammaPlot exercise 2
GammaPlot/Gamma.svg : GammaPlot/gamma.gpi GammaPlot/gamma.data factorials.data
	gnuplot $<

GammaPlot/gamma.data : GammaPlot/mainGamma.exe
	mono $< > $@

GammaPlot/mainGamma.exe : GammaPlot/mainGamma.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	cp sfuns.dll GammaPlot/

# LnGamma Plot exercise 3
LngammaPlot/Lngamma.svg : LngammaPlot/lngamma.gpi LngammaPlot/lngamma.data 
	gnuplot $<

LngammaPlot/lngamma.data : LngammaPlot/mainLngamma.exe
	mono $< > $@

LngammaPlot/mainLngamma.exe : LngammaPlot/mainLngamma.cs sfuns.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
	cp sfuns.dll LngammaPlot/

sfuns.dll : gamma.cs erf.cs lngamma.cs
	mcs -target:library -out:$@ $^


factorialsGamma.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

i.PHONY: clean
clean: 
	rm -f GammaPlot/mainGamma.exe ErfPlot/mainErf.exe LngammaPlot/mainLngamma.exe
