Out.txt : main.exe input.txt
	mono $< <input.txt> $@ 2> log

main.exe : main.cs genlist3.dll
	mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)

genlist3.dll : genlist3.cs
	mcs -target:library -out:$@ $<


.PHONY : clean
clean: 
	$(RM) *.exe *.dll [Oo]ut* log*


